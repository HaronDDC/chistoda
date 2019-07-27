using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using LinqToDB;
using OptimizeLib.Model;
using Task = DataModels.Task;
using OptVehicle = OptimizeLib.Model.Vehicle;

namespace Loader
{
    public static class DatabaseHelper
    {
		/// <summary>
		/// Create task using task template.
		/// </summary>
		/// <param name="templateTaskId">Template task (we load template operations from it).</param>
		/// <param name="name">Task name (such as: Убрать снег с Красной Площади).</param>
		/// <param name="quantity">Quantity (like square to be processed).</param>
		/// <returns>Returns created task identity.</returns>
		public static int CreateTask(int templateTaskId, string name, decimal quantity)
		{
			using (var db = new ChistoDatabase())
			{
				// load template tasks
				var query =
					from tt in db.TemplateTaskOperations
					where tt.TemplateTaskId == templateTaskId
					select new
					{
						tt.OrderNumber,
						tt.TemplateOperation,
					};

				var templateOperations = query.ToArray();

				// create actual task
				var task = new Task
				{
					Date = DateTime.Now,
					Name = name,
					Quantity = quantity,
					TemplateTaskId = templateTaskId,
				};

				// save the task
				var result = db.InsertWithIdentity(task);
				var taskId = result as int? ?? 0;
				if (taskId == 0)
				{
					throw new InvalidOperationException("Не удалось создать задачу.");
				}

				// create operations
				var taskOperations = templateOperations.Select(to => new Operation
				{
					TaskId = taskId,
					OrderNumber = to.OrderNumber,
					Name = to.TemplateOperation.Name,
					TemplateOperationId = to.TemplateOperation.Id,
				}).ToArray();

				foreach (var oper in taskOperations)
				{
					db.Insert(oper);
				}

				return taskId;
			}
		}

		public static AssignmentInput LoadAssignmentInput(int[] taskIds)
		{
			using (var db = new ChistoDatabase())
			{
				// Технологические операции
				var operationQuery =
					from to in db.Operations
					where taskIds.Contains(to.TaskId)
					select to;
				var operations = operationQuery.ToList();

				// Типы транспортных средств
				var vehicleTypes = db.VehicleTypes.ToList();

				// Типы оборудования
				var equipTypes = db.EquipmentTypes.ToList();

				// Матрица совместимости
				var compatibility = db.EquipmentCompatibilities.ToList();

				return new AssignmentInput
				{
					Operations = operations,
					VehicleTypes = vehicleTypes,
					EquipmentTypes = equipTypes,
					Compatibility = compatibility,
				};
			}
		}
	}
}
