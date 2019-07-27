using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using OptimizeLib.Model;

namespace Loader
{
    public static class ModelLoader
    {
		/// <summary>
		/// Create task using task template.
		/// </summary>
		/// <param name="templateTaskId">Template task (we load template operations from it).</param>
		/// <param name="quantity">Quantity (like square to be processed).</param>
		/// <returns>Returns created task identity.</returns>
		public static int CreateTask(int templateTaskId, decimal quantity)
		{
			using (var db = new ChistoDatabase())
			{
				// load template tasks
				var query =
					from tt in db.TemplateTaskOperations
					where tt.TemplateTaskId == templateTaskId
					select tt.TemplateOperation;
				var templateOperations = query.ToArray();

				// create actual task
				return 0;
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
