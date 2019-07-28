using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class TotalTask
    {
        private const double DeltaTime = 30;

        private static double _timeCost = 50;

        private static double _timeCountCost = 50;

        private List<Location> _locations = new List<Location>();
        private List<TechOper> _opers = new List<TechOper>();
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public List<Location> Locations { get => _locations; }

        public List<Vehicle> Vehicles { get => _vehicles; }

        public List<TechOper> Opers { get => _opers; }

        public static double TimeUsingCost { get { return _timeCost; } set { _timeCost = value; } }

        public static double TimeCountCost { get { return _timeCountCost; } set { _timeCountCost = value; } }

        public List<TotalResult> GetTotalResults(double startTime, double timeLong, out int globalOptimalIdx)
        {
            var res = new List<TotalResult>();
            double t = startTime;
            while (t <= timeLong)
            {
                var tr = GetTotalResult(t);
                res.Add(tr);
                t += DeltaTime;
            }
            globalOptimalIdx = FindGlobalOptimalIdx(res);
            return res;
        }

        public TotalResult GetTotalResult(double maxTime)
        {
            var res = new TotalResult();
            res.MaxTime = maxTime;
            foreach (var loc in Locations)
            {
                var lres = loc.GetLocationResult(maxTime);
                res.LocResult.Add(lres);
            }
            res.Cost = GetCostMetrics(maxTime, res.Count);
            return res;
        }

        public static double GetCostMetrics(double maxTime, int vehCount)
        {
            return maxTime * TimeUsingCost * vehCount + vehCount * TimeCountCost;
        }

        private int FindGlobalOptimalIdx(List<TotalResult> lst)
        {
            int res = -1;
            double resOptimal = double.MaxValue;
            for (int i = 0; i < lst.Count; i++)
            {
                if ((res == -1) || (lst[i].Cost < resOptimal))
                {
                    res = i;
                    resOptimal = lst[i].Cost;
                }

            }
            return res;
        }

        public static TotalTask CreateTestTask()
        {
            var task = new TotalTask();
            CreateTestVehicles(task);
            CreateTestOpers(task);

            var loc = new Location();
            loc.Square = 10000;
            loc.LocationName = "Красная площадь";
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[1]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 20000;
            loc.LocationName = "Манежная площадь";
            loc.Opers.Add(task.Opers[1]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 30000;
            loc.LocationName = "Поселок Северный";
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);

            for (int i = 1; i < 10; i++)
            {
                loc = new Location();
                loc.Square = 30000 + i * 10;
                loc.LocationName = "Поселок Северный" + i.ToString();
                loc.Opers.Add(task.Opers[i % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 1) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 2) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 3) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 4) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 5) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 6) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 7) % task.Opers.Count]);

                task.Locations.Add(loc);
            }


            return task;
        }

        private static TotalTask CreateTestLocations(TotalTask task)
        {
            var loc = new Location();
            loc.Square = 10000;
            loc.LocationName = "Красная площадь";
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[1]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 20000;
            loc.LocationName = "Манежная площадь";
            loc.Opers.Add(task.Opers[1]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);

            loc = new Location();
            loc.Square = 30000;
            loc.LocationName = "Поселок Северный";
            loc.Opers.Add(task.Opers[0]);
            loc.Opers.Add(task.Opers[2]);
            task.Locations.Add(loc);


            for (int i = 1; i < 10; i++)
            {
                loc = new Location();
                loc.Square = 30000 + i * 10;
                loc.LocationName = "Поселок Северный" + i.ToString();
                loc.Opers.Add(task.Opers[i % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 1) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 2) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 3) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 4) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 5) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 6) % task.Opers.Count]);
                loc.Opers.Add(task.Opers[(i + 7) % task.Opers.Count]);

                task.Locations.Add(loc);
            }

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

            for (int i = 0; i < 5; i++)
            {
                vh = new Vehicle();
                vh.Code = 4 + i;
                vh.Name = "Поливайка" + i.ToString();
                task.Vehicles.Add(vh);

            }
        }

        private static void CreateTestOpers(TotalTask task)
        {
            var oper = new TechOper() { Speed = 2, Vehicle = task.Vehicles[0] };
            task.Opers.Add(oper);

            oper = new TechOper() { Speed = 5, Vehicle = task.Vehicles[1] };
            task.Opers.Add(oper);

            oper = new TechOper() { Speed = 10, Vehicle = task.Vehicles[2] };
            task.Opers.Add(oper);

            for (int i = 0; i < 8; i++)
            {
                oper = new TechOper() { Speed = 1 + i, Vehicle = task.Vehicles[i] };
                task.Opers.Add(oper);

            }

        }

    }
}
