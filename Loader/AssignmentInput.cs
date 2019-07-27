using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;

namespace Loader
{
	public class AssignmentInput
	{
		/// <summary>
		/// Операции, относящиеся к выбранным задачам.
		/// </summary>
		public List<Operation> Operations { get; set; }

		/// <summary>
		/// Типы транспортных средств (ТТС).
		/// </summary>
		public List<VehicleType> VehicleTypes { get; set; }

		/// <summary>
		/// Типы навесного оборудования (ТНО).
		/// </summary>
		public List<EquipmentType> EquipmentTypes { get; set; }

		/// <summary>
		/// Матрица совместимости ТТС и ТНО.
		/// </summary>
		public List<EquipmentCompatibility> Compatibility { get; set; }
	}
}
