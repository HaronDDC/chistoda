﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizeLib.Model
{
    public class TotalResult
    {
        private List<LocationResult> _locResult = new List<LocationResult>();

        public List<LocationResult> LocResult { get => _locResult; }

        public int Count
        {
            get
            {
                int res = 0;
                foreach (var lr in LocResult)
                    res += lr.VehicleCount;
                return res;
            }
        }
    }
}