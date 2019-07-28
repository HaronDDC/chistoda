using DataModels;
using Loader;
using OptimizeLib.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private int[] Tasks { get; set; } = //new[] { 11, 8, 19, 14, 17, 20, 13, 10, 9, 7, 18, 16, 15, 6, 12 };
                                            //new[] { 21, 22, 23, 24, 25, 26, 27, 28 };
            DatabaseHelper.LoadTasks();

        private List<OptimizeLib.Model.Vehicle> Vehicles { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vehicles = AssigmentEq();
            LoadTask();
        }

        private List<OptimizeLib.Model.Vehicle> AssigmentEq()
        {
            var assignment = DatabaseHelper.LoadAssignmentInput(Tasks);

            List<Tuple<int, EquipmentCompatibility>> listVT = new List<Tuple<int, EquipmentCompatibility>>();
            List<Tuple<int, EquipmentCompatibility>> listEqT = new List<Tuple<int, EquipmentCompatibility>>();

            foreach (var comp in assignment.Compatibility)
            {
                if (!listVT.Any((g) => g.Item1 == comp.VehicleTypeId))
                {
                    listVT.Add(new Tuple<int, EquipmentCompatibility>(comp.VehicleTypeId, comp));
                }

                if (!listEqT.Any((g) => g.Item1 == comp.EquipmentTypeId))
                {
                    listEqT.Add(new Tuple<int, EquipmentCompatibility>(comp.EquipmentTypeId, comp));
                }
            }

            int countRows = listVT.Count();
            int countColumns = listEqT.Count();

            int[,] a = new int[countRows, countColumns];
            int[,] ba = new int[countRows, countColumns];

            for (int i = 0; i < countRows; i++)
            {
                int idV = listVT[i].Item1;
                for (int j = 0; j < countColumns; j++)
                {
                    int idE = listEqT[j].Item1;

                    var f = assignment.Compatibility.FirstOrDefault((b) => b.VehicleTypeId == idV && b.EquipmentTypeId == idE);
                    a[i, j] = f == null ? int.MaxValue : (int)Math.Ceiling(f.Factor);
                    ba[i, j] = a[i, j];
                }
            }

            List<OptimizeLib.Model.Vehicle> lvv = new List<OptimizeLib.Model.Vehicle>();

            var ddd = Assignment.Assign.Compute(ba, countRows, countColumns);

            gvEq.AutoGenerateColumns = false;
            gvEq.RowCount = countRows;
            gvEq.ColumnCount = countColumns;
            gvEq.RowHeadersWidth = 200;

            for (int i = 0; i < countRows; i++)
            {
                gvEq.Rows[i].HeaderCell.Value = listVT[i].Item2.VehicleType.Name;
                for (int j = 0; j < countColumns; j++)
                {
                    if (i == 0)
                        gvEq.Columns[j].Name = listEqT[j].Item2.EquipmentType.Name;

                    gvEq.Rows[i].Cells[j].Value = a[i, j] == int.MaxValue ? "-" : a[i, j].ToString();
                    gvEq.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            foreach (var d in ddd)
            {
                var fVT = listVT[d.Item1];
                var fEq = listEqT[d.Item2];

                OptimizeLib.Model.Vehicle v = new OptimizeLib.Model.Vehicle
                {
                    EqTypeId = fEq.Item1,
                    VehicleTypeId = fVT.Item1,
                    Name = fVT.Item2.VehicleType.Name + " + " + fEq.Item2.EquipmentType.Name,
                };

                gvEq.Rows[d.Item1].Cells[d.Item2].Style.BackColor = Color.LightGreen;
                lvv.Add(v);
            }

            return lvv;
        }


        private void LoadTask()
        {
            _task = LoadTest(); //CreateTest();
            UpdateSolution();
        }

        private TotalTask LoadTest()
        {
            return DatabaseHelper.LoadTotalTask(Tasks, Vehicles);
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
                lblResult.Text = $"Оптимальное суммарное количество техники: {_result[_bestIdx].Count:#,##0}\r\nСуммарная учетная стоимость: {_result[_bestIdx].Cost:#,##0} руб.\r\nВремя работы: {(int)_result[_bestIdx].MaxTime} мин.";
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
