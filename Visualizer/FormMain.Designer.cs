namespace Visualizer
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pageMain = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.chartCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.gvDistrib = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnCalc = new System.Windows.Forms.Button();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.edtCountCost = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.edtMaxTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edtVehCost = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.lblResult = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvEq = new System.Windows.Forms.DataGridView();
            this.pageMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistrib)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.grpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCountCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVehCost)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEq)).BeginInit();
            this.SuspendLayout();
            // 
            // pageMain
            // 
            this.pageMain.Controls.Add(this.pnlMain);
            this.pageMain.Controls.Add(this.pnlTop);
            this.pageMain.Location = new System.Drawing.Point(4, 22);
            this.pageMain.Name = "pageMain";
            this.pageMain.Padding = new System.Windows.Forms.Padding(3);
            this.pageMain.Size = new System.Drawing.Size(991, 855);
            this.pageMain.TabIndex = 0;
            this.pageMain.Text = "Решеине задачи оптимизации";
            this.pageMain.UseVisualStyleBackColor = true;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblResult);
            this.pnlMain.Controls.Add(this.chartCost);
            this.pnlMain.Controls.Add(this.chartMain);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.gvDistrib);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 118);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(985, 734);
            this.pnlMain.TabIndex = 3;
            // 
            // chartCost
            // 
            this.chartCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Interval = 1D;
            chartArea1.Name = "ChartArea1";
            this.chartCost.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCost.Legends.Add(legend1);
            this.chartCost.Location = new System.Drawing.Point(575, 55);
            this.chartCost.Name = "chartCost";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCost.Series.Add(series1);
            this.chartCost.Size = new System.Drawing.Size(405, 660);
            this.chartCost.TabIndex = 8;
            this.chartCost.Text = "chart1";
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.Interval = 1D;
            chartArea2.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMain.Legends.Add(legend2);
            this.chartMain.Location = new System.Drawing.Point(329, 55);
            this.chartMain.Name = "chartMain";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMain.Series.Add(series2);
            this.chartMain.Size = new System.Drawing.Size(248, 660);
            this.chartMain.TabIndex = 7;
            this.chartMain.Text = "chart1";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "Единиц техники от времени";
            // 
            // gvDistrib
            // 
            this.gvDistrib.AllowUserToAddRows = false;
            this.gvDistrib.AllowUserToDeleteRows = false;
            this.gvDistrib.AllowUserToOrderColumns = true;
            this.gvDistrib.AllowUserToResizeRows = false;
            this.gvDistrib.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvDistrib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDistrib.Location = new System.Drawing.Point(9, 50);
            this.gvDistrib.Name = "gvDistrib";
            this.gvDistrib.ReadOnly = true;
            this.gvDistrib.RowHeadersVisible = false;
            this.gvDistrib.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDistrib.Size = new System.Drawing.Size(314, 329);
            this.gvDistrib.TabIndex = 1;
            this.gvDistrib.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.GvDistrib_RowPrePaint);
            this.gvDistrib.SelectionChanged += new System.EventHandler(this.GvDistrib_SelectionChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnCalc);
            this.pnlTop.Controls.Add(this.grpParameters);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(985, 115);
            this.pnlTop.TabIndex = 2;
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalc.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCalc.Location = new System.Drawing.Point(660, 18);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(320, 70);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "Рассчитать";
            this.btnCalc.UseVisualStyleBackColor = false;
            this.btnCalc.Click += new System.EventHandler(this.BtnCalc_Click);
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.edtCountCost);
            this.grpParameters.Controls.Add(this.label5);
            this.grpParameters.Controls.Add(this.edtMaxTime);
            this.grpParameters.Controls.Add(this.label2);
            this.grpParameters.Controls.Add(this.edtVehCost);
            this.grpParameters.Controls.Add(this.label1);
            this.grpParameters.Location = new System.Drawing.Point(7, 12);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(440, 97);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Параметры";
            // 
            // edtCountCost
            // 
            this.edtCountCost.Location = new System.Drawing.Point(313, 37);
            this.edtCountCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.edtCountCost.Name = "edtCountCost";
            this.edtCountCost.Size = new System.Drawing.Size(109, 20);
            this.edtCountCost.TabIndex = 5;
            this.edtCountCost.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Учетная стоимость использования техники(руб/ед):";
            // 
            // edtMaxTime
            // 
            this.edtMaxTime.Location = new System.Drawing.Point(313, 61);
            this.edtMaxTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.edtMaxTime.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.edtMaxTime.Name = "edtMaxTime";
            this.edtMaxTime.Size = new System.Drawing.Size(109, 20);
            this.edtMaxTime.TabIndex = 3;
            this.edtMaxTime.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ограничение максимального времени работ(мин):";
            // 
            // edtVehCost
            // 
            this.edtVehCost.Location = new System.Drawing.Point(313, 14);
            this.edtVehCost.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.edtVehCost.Name = "edtVehCost";
            this.edtVehCost.Size = new System.Drawing.Size(109, 20);
            this.edtVehCost.TabIndex = 1;
            this.edtVehCost.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Учетная стоимость времени работы техники (руб/мин):";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageMain);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(999, 881);
            this.tabControl.TabIndex = 2;
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblResult.Location = new System.Drawing.Point(357, 6);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(611, 65);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Единиц техники от времени";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvEq);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(991, 855);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Распределение навесного оборудования";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvEq
            // 
            this.gvEq.AllowUserToAddRows = false;
            this.gvEq.AllowUserToDeleteRows = false;
            this.gvEq.AllowUserToOrderColumns = true;
            this.gvEq.AllowUserToResizeRows = false;
            this.gvEq.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvEq.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvEq.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvEq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvEq.Location = new System.Drawing.Point(3, 3);
            this.gvEq.MultiSelect = false;
            this.gvEq.Name = "gvEq";
            this.gvEq.ReadOnly = true;
            this.gvEq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvEq.Size = new System.Drawing.Size(985, 849);
            this.gvEq.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 881);
            this.Controls.Add(this.tabControl);
            this.Name = "FormMain";
            this.Text = "ЧистоДа. Оптимизация расходов на санитарную уборку улиц";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pageMain.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistrib)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtCountCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVehCost)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage pageMain;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.NumericUpDown edtMaxTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown edtVehCost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvDistrib;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCost;
        private System.Windows.Forms.NumericUpDown edtCountCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvEq;
    }
}

