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
            this.pageMain = new System.Windows.Forms.TabPage();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnCalc = new System.Windows.Forms.Button();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.edtMaxTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.edtVehCost = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResultTest = new System.Windows.Forms.Label();
            this.gvDistrib = new System.Windows.Forms.DataGridView();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pageMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.grpParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVehCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistrib)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageMain);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(999, 881);
            this.tabControl.TabIndex = 2;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnCalc);
            this.pnlTop.Controls.Add(this.grpParameters);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(3, 3);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(985, 101);
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
            this.grpParameters.Controls.Add(this.edtMaxTime);
            this.grpParameters.Controls.Add(this.label2);
            this.grpParameters.Controls.Add(this.edtVehCost);
            this.grpParameters.Controls.Add(this.label1);
            this.grpParameters.Location = new System.Drawing.Point(7, 12);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(434, 76);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Параметры";
            // 
            // edtMaxTime
            // 
            this.edtMaxTime.Location = new System.Drawing.Point(313, 36);
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
            this.label2.Location = new System.Drawing.Point(17, 38);
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
            // lblResultTest
            // 
            this.lblResultTest.AutoSize = true;
            this.lblResultTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultTest.Location = new System.Drawing.Point(5, 14);
            this.lblResultTest.Name = "lblResultTest";
            this.lblResultTest.Size = new System.Drawing.Size(391, 24);
            this.lblResultTest.TabIndex = 0;
            this.lblResultTest.Text = "Оптимальное распределение техники";
            // 
            // gvDistrib
            // 
            this.gvDistrib.AllowUserToAddRows = false;
            this.gvDistrib.AllowUserToDeleteRows = false;
            this.gvDistrib.AllowUserToOrderColumns = true;
            this.gvDistrib.AllowUserToResizeRows = false;
            this.gvDistrib.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvDistrib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDistrib.Location = new System.Drawing.Point(9, 82);
            this.gvDistrib.Name = "gvDistrib";
            this.gvDistrib.RowHeadersVisible = false;
            this.gvDistrib.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDistrib.Size = new System.Drawing.Size(213, 297);
            this.gvDistrib.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chartMain);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.gvDistrib);
            this.pnlMain.Controls.Add(this.lblResultTest);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 104);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(985, 748);
            this.pnlMain.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 41);
            this.label3.TabIndex = 3;
            this.label3.Text = "Единиц техники от времени";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(236, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 41);
            this.label4.TabIndex = 4;
            this.label4.Text = "Распределение по предприятиям\r\n";
            // 
            // chartMain
            // 
            this.chartMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartMain.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMain.Legends.Add(legend1);
            this.chartMain.Location = new System.Drawing.Point(240, 82);
            this.chartMain.Name = "chartMain";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartMain.Series.Add(series1);
            this.chartMain.Size = new System.Drawing.Size(729, 300);
            this.chartMain.TabIndex = 7;
            this.chartMain.Text = "chart1";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 881);
            this.Controls.Add(this.tabControl);
            this.Name = "FormMain";
            this.Text = "ЧистоДа. Оптимизация расходов на санитарную уборку улиц";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pageMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVehCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDistrib)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvDistrib;
        private System.Windows.Forms.Label lblResultTest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
    }
}

