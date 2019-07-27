using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class TotalTask
    {
        private const double TimeCost = 50;

        private List<Location> _locations = new List<Location>();
        private List<TechOper> _opers = new List<TechOper>();
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public List<Location> Locations { get => _locations; }

        public List<Vehicle> Vehicles { get => _vehicles; }

        public List<TechOper> Opers { get => _opers; }

        public TotalResult GetTotalResult(double maxTime)
        {
            var res = new TotalResult();
            foreach (var loc in Locations)
            {
                var lres = loc.GetLocationResult(maxTime);
                res.LocResult.Add(lres);
            }
            return res;
        }

        public double GetCost(double maxTime)
        {
            var lres = GetTotalResult(maxTime);
            return (maxTime * TimeCost) * lres.Count; 
        }

        public static TotalTask CreateTestTask()
        {
            var task = new TotalTask();
            CreateTestVehicles(task);
            CreateTestOpers(task);

            var loc = new Location();
            loc.Square = 10000;
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[1]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 20000;
            loc.Opers.Add(task.Opers[1]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 30000;
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);

            return task;
        }

        private static void CreateTestVehicles(TotalTask task)
        {
            var vh = new Vehicle();
            vh.Code = 1;
            vh.Name = "Камаз";
            task.Vehicles.Add(vh);

            vh = new Vehicle();
            vh.Code = 2;
            vh.Name = "Беларусь";
            task.Vehicles.Add(vh);

            vh = new Vehicle();
            vh.Code = 3;
            vh.Name = "Поливайка";
            task.Vehicles.Add(vh);


        }

        private static void CreateTestOpers(TotalTask task)
        {
            var oper = new TechOper() { Speed = 2, Vehicle = task.Vehicles[0] };
            task.Opers.Add(oper);

            oper = new TechOper() { Speed = 5, Vehicle = task.Vehicles[1] };
            task.Opers.Add(oper);

            oper = new TechOper() { Speed = 10, Vehicle = task.Vehicles[2] };
            task.Opers.Add(oper);

        }
    }
}
