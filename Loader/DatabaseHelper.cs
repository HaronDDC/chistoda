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
        // Создаем задания для всех локаций
        public static int[] CreateTasks(int templateTaskId, string name)
        {
            var tasks = new List<int>();
            var companies = LoadCompanies(null);
            using (var db = new ChistoDatabase())
            {
                foreach (var company in companies)
                {
                    var square = company.Square;
                    tasks.Add(CreateTask(templateTaskId, name, company.Id, square));
                }
            }

            return tasks.ToArray();
        }

        public static int[] LoadTasks()
        {
            using (var db = new ChistoDatabase())
            {
                return db.Tasks.Where(t => t.Operationstaskidfkeys.Count() > 0).Select(t => t.Id).ToArray();
            }
        }

        /// <summary>
        /// Create task using task template.
        /// </summary>
        /// <param name="templateTaskId">Template task (we load template operations from it).</param>
        /// <param name="name">Task name (such as: Убрать снег с Красной Площади).</param>
        /// <param name="quantity">Quantity (like square to be processed).</param>
        /// <returns>Returns created task identity.</returns>
        public static int CreateTask(int templateTaskId, string name, int companyId, decimal quantity)
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
                    CompanyId = companyId,
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
                var compatibility = db.EquipmentCompatibilities.Select((et) => new EquipmentCompatibility()
                {
                    EquipmentTypeId = et.EquipmentTypeId,
                    VehicleTypeId = et.VehicleTypeId,
                    EquipmentType = et.EquipmentType,
                    VehicleType = et.VehicleType,
                    Factor = et.Factor,
                }).ToList();



                return new AssignmentInput
				{
					Operations = operations,
					VehicleTypes = vehicleTypes,
					EquipmentTypes = equipTypes,
					Compatibility = compatibility,
				};
			}
		}

        private static List<Company> LoadCompanies(int[] companyIds)
        {
            using (var db = new ChistoDatabase())
            {
                if (companyIds == null)
                {
                    return db.Companies.ToList();
                }

                return db.Companies.Where(c => companyIds.Contains(c.Id)).ToList();
            }
        }

        private static TotalTask CreateRealTask(int[] taskIds)
        {
            var res = new TotalTask();


            return res;
        }

        private static void LoadRealVehicles(TotalTask task)
        {

        }

        public static TotalTask LoadTotalTask(int[] taskIds, List<OptVehicle> vehicles)
        {
            using (var db = new ChistoDatabase())
            {
                // Технологические операции
                var operationQuery =
                    from to in db.Operations
                    where taskIds.Contains(to.TaskId)
                    select new
                    {
                        to.Task.CompanyId,
                        to.TemplateOperation.VehicleTypeId,
                        to.TemplateOperation.Speed,
                    };

                var operations = operationQuery.ToList();
                var opers = operations.Select(op => new TechOper
                {
                    CompanyID = op.CompanyId,
                    Speed = Convert.ToDouble(op.Speed),
                    Vehicle = vehicles.FirstOrDefault(x => x.VehicleTypeId == op.VehicleTypeId),
                }).ToList();

                var task = new TotalTask
                {
                    Vehicles = vehicles,
                    Opers = opers,
                };

                var companies = LoadCompanies(null);
                task.Locations = companies.Select(c => new Location
                {
                    LocationName = c.Name,
                    Opers = opers.Where(o => o.CompanyID == c.Id).ToList(),
                    Square = (double)c.Square,
                }).ToList();

                return task;
            }
        }
    }
}

