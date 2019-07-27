﻿using OptimizeLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    public partial class FormMain : Form
    {
        private TotalTask _task = new TotalTask();
        private List<TotalResult> _result = new List<TotalResult>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            LoadTask();
        }


        private void LoadTask()
        {
            _task = CreateTest();
            UpdateSolution();
            //gvTechOpers.DataSource = _task.Opers;

        }

        private void UpdateSolution()
        {
            _task.TimeCost = Convert.ToDouble(edtVehCost.Value);
            double maxTime = Convert.ToInt32(edtMaxTime.Value);
            _result = _task.GetTotalResults(30, maxTime);
            gvDistrib.DataSource = _result;
        }

        private TotalTask CreateTest()
        {
            var task = TotalTask.CreateTestTask();
            //List<double> x = new List<double>();
            //List<string> xstr = new List<string>();
            //List<double> y = new List<double>();
            //List<double> ycost = new List<double>();

            //for (double i = 800; i < 1200; i += 30)
            //{
            //    x.Add(i);
            //    y.Add(task.GetVehicleCount(i));
            //    ycost.Add(task.GetCost(i));
            //}

            //// Set title.
            //this.chart1.Series.Clear();
            //this.chart2.Series.Clear();

            //this.chart1.Titles.Add("Vehicle count/Cost");

            //// Add series.
            //var serCount = this.chart1.Series.Add("Vehicle count");
            //var serCost = this.chart2.Series.Add("Normalized cost");
            //for (int i = 0; i < x.Count; i++)
            //{
            //    serCount.Points.AddXY(x[i], y[i]);
            //    serCost.Points.AddXY(x[i], ycost[i]);
            //}
            return task;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            UpdateChart();

        }

        private void UpdateChart()
        {
            if (gvDistrib.SelectedRows == null ||
                gvDistrib.SelectedRows.Count == 0)
                return;
            int selectedResult = gvDistrib.SelectedRows[0].Index;
            var result = _result[selectedResult];

            chartMain.Series.Clear();

            //var serAge = chartMain.Series.Add("Age");
            //var serScore = chartMain.Series.Add("Score");

            //serAge.Points.AddXY("Max", 1);
            //serAge.Points.AddXY("Carl", 2);
            //serAge.Points.AddXY("Fedor", 3);
            //serAge.Points.AddXY("Sasha", 4);

            //serScore.Points.AddXY("Max", 10);
            //serScore.Points.AddXY("Carl", 20);
            //serScore.Points.AddXY("Fedor", 30);
            //serScore.Points.AddXY("Sasha", 40);
            //return;

            //List<string> listVeh = new List<string>() { "Age", "Score" };
            //List<string> listLocation = new List<string>() { "Max", "Carl", "Fedor", "Sasha" };

            //Dictionary<string, Dictionary<string, int>> aaa = new Dictionary<string, Dictionary<string, int>>();
            //aaa["Max"] = new Dictionary<string, int>() { { "Age", 1 }, { "Score", 2 } };
            //aaa["Carl"] = new Dictionary<string, int>() { { "Age", 3 }, { "Score", 4 } };
            //aaa["Fedor"] = new Dictionary<string, int>() { { "Age", 5 }, { "Score", 6 } };
            //aaa["Sasha"] = new Dictionary<string, int>() { { "Age", 7 }, { "Score", 8 } };

            //foreach (var l in listLocation)
            //{

            //    foreach (var v in listVeh)
            //    {
            //        var ser = chartMain.Series.FindByName(v);
            //        if (ser == null)
            //        {
            //            ser = chartMain.Series.Add(v);
            //            ser.ChartType = SeriesChartType.Column;
            //        }
            //        ser.Points.AddXY(l, aaa[l][v]);
            //    }
            //}
            //return;
            Dictionary<string, int> pointIdx = new Dictionary<string, int>();
            int locIdx = 0;
            foreach (var loc in _task.Locations)
            {
                string locName = loc.LocationName;
                pointIdx[locName] = locIdx;
                foreach (var veh in _task.Vehicles)
                {
                    var ser = chartMain.Series.FindByName(veh.Name);
                    if (ser == null)
                    {
                        ser = chartMain.Series.Add(veh.Name);
                        ser.ChartType = SeriesChartType.Column;
                    }
                    ser.Points.AddXY(locName, 0);
                }
                locIdx++;
            }

            foreach (var loc in result.LocResult)
            {
                string locName = loc.Location.LocationName;
                foreach (var vr in loc.VehicleResult)
                {
                    var ser = chartMain.Series.FindByName(vr.Vehicle.Name);
                    if (ser == null)
                    {
                        ser = chartMain.Series.Add(vr.Vehicle.Name);
                        ser.ChartType = SeriesChartType.Column;
                    }
                    ser.Points[pointIdx[locName]].YValues = new double[] { vr.Count };
                    //ser.Points.AddXY(locName, vr.Count);
                }
            }

        }
    }
}
