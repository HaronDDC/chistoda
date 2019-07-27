using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class LocationResult
    {
        private List<VehicleResult> _vehicleResult = new List<VehicleResult>();
        public Location Location { get; set; }

        public double MaxTime { get; set; }
        public List<VehicleResult> VehicleResult { get { return _vehicleResult; } }
        public int VehicleCount
        {
            get
            {
                int res = 0;
                foreach (var vr in VehicleResult)
                    res += vr.Count;
                return res;
            }
        }

        public double Cost
        {
            get
            {
                return TotalTask.GetCostMetrics(MaxTime, VehicleCount);
            }
        }

    }
}
