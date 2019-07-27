using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class Location
    {
        private List<TechOper> _opers = new List<TechOper>();

        public string LocationName { get; set; }
        public double Square { get; set; }

        public List<TechOper> Opers { get => _opers; }

        public LocationResult GetLocationResult(double maxTime)
        {
            var res = new LocationResult();
            res.Location = this;
            foreach (var oper in Opers)
            {
                var vh = oper.GetVehicleResult(Square, maxTime);
                res.VehicleResult.Add(vh);
            }
            return res;
        }
    }
}
