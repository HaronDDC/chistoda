using OptimizeLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Visualizer
{
    public partial class FormMain : Form
    {
        private TotalTask _task = new TotalTask();
        private List<TotalResult> _result = new List<TotalResult>();
        private int _bestIdx = -1;
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
        }

        private void UpdateSolution()
        {
            TotalTask.TimeUsingCost = Convert.ToDouble(edtVehCost.Value);
            TotalTask.TimeCountCost = Convert.ToDouble(edtCountCost.Value);
            double maxTime = Convert.ToInt32(edtMaxTime.Value);
            _result = _task.GetTotalResults(30, maxTime, out _bestIdx);
            gvDistrib.DataSource = _result;
            UpdateResultCaption();

            if (_bestIdx >= 0)
            {
                if ((gvDistrib.SelectedRows != null) && (gvDistrib.SelectedRows.Count != 0))
                {
                    int selIdx = gvDistrib.SelectedRows[0].Index;
                    gvDistrib.Rows[selIdx].Selected = false;
                }
                gvDistrib.Rows[_bestIdx].Selected = true;
            }
        }

        private TotalTask CreateTest()
        {
            var task = TotalTask.CreateTestTask();
            return task;
        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            UpdateModel();
        }

        private void UpdateModel()
        {
            UpdateSolution();
            UpdateMainChart();
            UpdateCostChart();
        }

        private TotalResult GetCurentResult()
        {
            if (gvDistrib.SelectedRows == null ||
              gvDistrib.SelectedRows.Count == 0)
                return null;
            int selectedResult = gvDistrib.SelectedRows[0].Index;
            var result = _result[selectedResult];
            return result;
        }

        private void UpdateResultCaption()
        {
            if (_bestIdx >= 0)
                lblResult.Text = $"Оптимальное суммарное количество техники: {_result[_bestIdx].Count}\r\nСуммарная учетная стоимость: {_result[_bestIdx].Cost} руб.\r\nВремя работы: {(int)_result[_bestIdx].MaxTime} мин.";
            else
                lblResult.Text = "";

        }

        private void UpdateCostChart()
        {
            var result = GetCurentResult();
            if (result == null)
                return;

            chartCost.Series.Clear();

            var ser = chartCost.Series.Add("Учетная стоимость");
            ser.ChartType = SeriesChartType.Bar;
            foreach (var loc in result.LocResult)
            {
                string locName = loc.Location.LocationName;
                ser.Points.AddXY(locName, loc.Cost);
            }
        }

        private void UpdateMainChart()
        {
            var result = GetCurentResult();
            if (result == null)
                return;

            chartMain.Series.Clear();
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
                        ser.ChartType = SeriesChartType.StackedBar;
                        //ser.IsValueShownAsLabel = true;
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
                    ser.Points[pointIdx[locName]].YValues = new double[] { vr.Count };
                }
            }

        }

        private void GvDistrib_SelectionChanged(object sender, EventArgs e)
        {
            UpdateMainChart();
            UpdateCostChart();
        }

        private void GvDistrib_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (_bestIdx < 0)
                return;
            if (_bestIdx == e.RowIndex)
                gvDistrib.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
        }
    }
}
