using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class TechOper
    {
        /// <summary>
        /// Скорость выполнения м^2/сек
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Типы транспортных/уборочных средств
        /// </summary>
        public Vehicle Vehicle { get; set; }

        public int CompanyID { get; set; }

        private int GetVehicleCount(double square, double maxTime)
        {
            // maxTime = square / (Speed * SpeedReduction(alpha))
            // maxTime = square / (Speed * alpha)
            return (int)Math.Max(1, Math.Ceiling(square / (maxTime * Speed)));
        }

        public VehicleResult GetVehicleResult(double square, double maxTime)
        {
            var res = new VehicleResult();
            res.Vehicle = this.Vehicle;
            res.Count = GetVehicleCount(square, maxTime);
            return res;
        }

    }
}
