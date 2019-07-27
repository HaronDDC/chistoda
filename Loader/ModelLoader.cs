using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using LinqToDB;
using OptimizeLib.Model;
using Task = DataModels.Task;

namespace Loader
{
    public static class ModelLoader
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
					Operationstaskidfkeys = templateOperations.Select(to => new Operation
					{
						OrderNumber = to.OrderNumber,
						Name = to.TemplateOperation.Name,
						TemplateOperationId = to.TemplateOperation.Id,
					}).ToArray(),
				};

				// save the task
				var result = db.InsertWithIdentity(task);
				return result as int? ?? 0;
			}
		}

		public static TotalTask LoadTotalTask(int id)
		{
			using (var db = new ChistoDatabase())
			{
				return null;
			}
		}
	}
}
