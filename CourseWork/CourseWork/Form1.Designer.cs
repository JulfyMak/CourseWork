namespace CourseWork
{
	partial class Form1
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.grafChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.countLabel = new System.Windows.Forms.Label();
			this.lamdaLabel = new System.Windows.Forms.Label();
			this.countTextBox = new System.Windows.Forms.TextBox();
			this.lamdaTextBox = new System.Windows.Forms.TextBox();
			this.startButton = new System.Windows.Forms.Button();
			this.countErrLabel = new System.Windows.Forms.Label();
			this.aErrLabel = new System.Windows.Forms.Label();
			this.analyticProgressBar = new System.Windows.Forms.ProgressBar();
			this.analyticLabel = new System.Windows.Forms.Label();
			this.analyticBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.filesDataGrid = new System.Windows.Forms.DataGridView();
			this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.kCoef = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.reverseLabel = new System.Windows.Forms.Label();
			this.reverseProgressBar = new System.Windows.Forms.ProgressBar();
			this.neymanLabel = new System.Windows.Forms.Label();
			this.neymanProgressBar = new System.Windows.Forms.ProgressBar();
			this.integralGridView = new System.Windows.Forms.DataGridView();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripMenu = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSaveMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.metropolisLabel = new System.Windows.Forms.Label();
			this.metropolisProgressBar = new System.Windows.Forms.ProgressBar();
			this.reverseBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.neymanBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.metropolisBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.waiterBackgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.pauseButton = new System.Windows.Forms.Button();
			this.resumeButton = new System.Windows.Forms.Button();
			this.infoDataGridView = new System.Windows.Forms.DataGridView();
			this.mathExColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dispersionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grafChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.filesDataGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.integralGridView)).BeginInit();
			this.ToolStripMenu.SuspendLayout();
			this.deleteSaveMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// grafChart
			// 
			this.grafChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			chartArea2.AxisX.Interval = 0.5D;
			chartArea2.AxisX.Maximum = 20D;
			chartArea2.AxisX.Minimum = 0D;
			chartArea2.Name = "ChartArea1";
			this.grafChart.ChartAreas.Add(chartArea2);
			legend2.Name = "Legend";
			this.grafChart.Legends.Add(legend2);
			this.grafChart.Location = new System.Drawing.Point(399, 29);
			this.grafChart.Name = "grafChart";
			series5.ChartArea = "ChartArea1";
			series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series5.Legend = "Legend";
			series5.Name = "Аналитический";
			series6.ChartArea = "ChartArea1";
			series6.Legend = "Legend";
			series6.Name = "Обратной ф-ии";
			series7.ChartArea = "ChartArea1";
			series7.Legend = "Legend";
			series7.Name = "Неймана";
			series8.ChartArea = "ChartArea1";
			series8.Legend = "Legend";
			series8.Name = "Метрополиса";
			this.grafChart.Series.Add(series5);
			this.grafChart.Series.Add(series6);
			this.grafChart.Series.Add(series7);
			this.grafChart.Series.Add(series8);
			this.grafChart.Size = new System.Drawing.Size(794, 409);
			this.grafChart.TabIndex = 0;
			this.grafChart.TabStop = false;
			this.grafChart.Text = "grafChart";
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Location = new System.Drawing.Point(12, 37);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(96, 17);
			this.countLabel.TabIndex = 5;
			this.countLabel.Text = "Кол-во чисел";
			// 
			// lamdaLabel
			// 
			this.lamdaLabel.AutoSize = true;
			this.lamdaLabel.Location = new System.Drawing.Point(12, 66);
			this.lamdaLabel.Name = "lamdaLabel";
			this.lamdaLabel.Size = new System.Drawing.Size(51, 17);
			this.lamdaLabel.TabIndex = 7;
			this.lamdaLabel.Text = "Lamda";
			// 
			// countTextBox
			// 
			this.countTextBox.Location = new System.Drawing.Point(113, 34);
			this.countTextBox.Name = "countTextBox";
			this.countTextBox.Size = new System.Drawing.Size(100, 22);
			this.countTextBox.TabIndex = 1;
			this.countTextBox.Text = "10000";
			this.countTextBox.TextChanged += new System.EventHandler(this.CountTextBox_TextChanged);
			// 
			// lamdaTextBox
			// 
			this.lamdaTextBox.Location = new System.Drawing.Point(113, 63);
			this.lamdaTextBox.Name = "lamdaTextBox";
			this.lamdaTextBox.Size = new System.Drawing.Size(100, 22);
			this.lamdaTextBox.TabIndex = 2;
			this.lamdaTextBox.Text = "2";
			this.lamdaTextBox.TextChanged += new System.EventHandler(this.ATextBox_TextChanged);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(12, 154);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(95, 28);
			this.startButton.TabIndex = 4;
			this.startButton.Text = "Старт";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// countErrLabel
			// 
			this.countErrLabel.AutoSize = true;
			this.countErrLabel.Location = new System.Drawing.Point(219, 37);
			this.countErrLabel.Name = "countErrLabel";
			this.countErrLabel.Size = new System.Drawing.Size(0, 17);
			this.countErrLabel.TabIndex = 6;
			// 
			// aErrLabel
			// 
			this.aErrLabel.AutoSize = true;
			this.aErrLabel.Location = new System.Drawing.Point(219, 66);
			this.aErrLabel.Name = "aErrLabel";
			this.aErrLabel.Size = new System.Drawing.Size(0, 17);
			this.aErrLabel.TabIndex = 8;
			// 
			// analyticProgressBar
			// 
			this.analyticProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.analyticProgressBar.Location = new System.Drawing.Point(1199, 58);
			this.analyticProgressBar.Name = "analyticProgressBar";
			this.analyticProgressBar.Size = new System.Drawing.Size(313, 25);
			this.analyticProgressBar.TabIndex = 14;
			// 
			// analyticLabel
			// 
			this.analyticLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.analyticLabel.AutoSize = true;
			this.analyticLabel.Location = new System.Drawing.Point(1196, 38);
			this.analyticLabel.Name = "analyticLabel";
			this.analyticLabel.Size = new System.Drawing.Size(110, 17);
			this.analyticLabel.TabIndex = 17;
			this.analyticLabel.Text = "Аналитический";
			// 
			// analyticBackgroundWorker
			// 
			this.analyticBackgroundWorker.WorkerReportsProgress = true;
			this.analyticBackgroundWorker.WorkerSupportsCancellation = true;
			this.analyticBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AnalyticBackgroundWorker_DoWork);
			this.analyticBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AnalyticBackgroundWorker_ProgressChanged);
			this.analyticBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AnalyticBackgroundWorker_RunWorkerCompleted);
			// 
			// filesDataGrid
			// 
			this.filesDataGrid.AllowUserToAddRows = false;
			this.filesDataGrid.AllowUserToOrderColumns = true;
			this.filesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.filesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.filesDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
			this.filesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.filesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.countPoints,
            this.kCoef});
			this.filesDataGrid.Location = new System.Drawing.Point(12, 188);
			this.filesDataGrid.Name = "filesDataGrid";
			this.filesDataGrid.ReadOnly = true;
			this.filesDataGrid.RowHeadersVisible = false;
			this.filesDataGrid.RowHeadersWidth = 51;
			this.filesDataGrid.RowTemplate.Height = 24;
			this.filesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.filesDataGrid.Size = new System.Drawing.Size(378, 457);
			this.filesDataGrid.TabIndex = 22;
			this.filesDataGrid.TabStop = false;
			this.filesDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FilesDataGrid_CellMouseClick);
			// 
			// nameColumn
			// 
			this.nameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.nameColumn.HeaderText = "Название";
			this.nameColumn.MinimumWidth = 6;
			this.nameColumn.Name = "nameColumn";
			this.nameColumn.ReadOnly = true;
			// 
			// countPoints
			// 
			this.countPoints.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.countPoints.HeaderText = "Кол-во";
			this.countPoints.MinimumWidth = 6;
			this.countPoints.Name = "countPoints";
			this.countPoints.ReadOnly = true;
			this.countPoints.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// kCoef
			// 
			this.kCoef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.kCoef.FillWeight = 50F;
			this.kCoef.HeaderText = "k";
			this.kCoef.MinimumWidth = 6;
			this.kCoef.Name = "kCoef";
			this.kCoef.ReadOnly = true;
			this.kCoef.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			// 
			// reverseLabel
			// 
			this.reverseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.reverseLabel.AutoSize = true;
			this.reverseLabel.Location = new System.Drawing.Point(1196, 97);
			this.reverseLabel.Name = "reverseLabel";
			this.reverseLabel.Size = new System.Drawing.Size(110, 17);
			this.reverseLabel.TabIndex = 25;
			this.reverseLabel.Text = "Обратной ф-ии";
			// 
			// reverseProgressBar
			// 
			this.reverseProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.reverseProgressBar.Location = new System.Drawing.Point(1199, 117);
			this.reverseProgressBar.Name = "reverseProgressBar";
			this.reverseProgressBar.Size = new System.Drawing.Size(313, 25);
			this.reverseProgressBar.TabIndex = 24;
			// 
			// neymanLabel
			// 
			this.neymanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.neymanLabel.AutoSize = true;
			this.neymanLabel.Location = new System.Drawing.Point(1196, 157);
			this.neymanLabel.Name = "neymanLabel";
			this.neymanLabel.Size = new System.Drawing.Size(67, 17);
			this.neymanLabel.TabIndex = 27;
			this.neymanLabel.Text = "Неймана";
			// 
			// neymanProgressBar
			// 
			this.neymanProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.neymanProgressBar.Location = new System.Drawing.Point(1199, 177);
			this.neymanProgressBar.Name = "neymanProgressBar";
			this.neymanProgressBar.Size = new System.Drawing.Size(313, 25);
			this.neymanProgressBar.TabIndex = 26;
			// 
			// integralGridView
			// 
			this.integralGridView.AllowUserToAddRows = false;
			this.integralGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.integralGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.integralGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
			this.integralGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.integralGridView.Location = new System.Drawing.Point(396, 444);
			this.integralGridView.Name = "integralGridView";
			this.integralGridView.ReadOnly = true;
			this.integralGridView.RowHeadersVisible = false;
			this.integralGridView.RowHeadersWidth = 51;
			this.integralGridView.RowTemplate.Height = 24;
			this.integralGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.integralGridView.Size = new System.Drawing.Size(797, 201);
			this.integralGridView.TabIndex = 28;
			this.integralGridView.TabStop = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog";
			this.openFileDialog.Filter = "Данные|*.ser";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "ser";
			this.saveFileDialog.Filter = "Данные|*.ser";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// ToolStripMenu
			// 
			this.ToolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.помощьToolStripMenuItem});
			this.ToolStripMenu.Location = new System.Drawing.Point(0, 0);
			this.ToolStripMenu.Name = "ToolStripMenu";
			this.ToolStripMenu.Size = new System.Drawing.Size(1582, 28);
			this.ToolStripMenu.TabIndex = 30;
			this.ToolStripMenu.Text = "menuStrip1";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
			this.открытьToolStripMenuItem.Text = "Открыть";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// справкаToolStripMenuItem
			// 
			this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
			this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
			this.справкаToolStripMenuItem.Text = "Справка";
			this.справкаToolStripMenuItem.Click += new System.EventHandler(this.СправкаToolStripMenuItem_Click);
			// 
			// помощьToolStripMenuItem
			// 
			this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
			this.помощьToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
			this.помощьToolStripMenuItem.Text = "Помощь";
			this.помощьToolStripMenuItem.Click += new System.EventHandler(this.ПомощьToolStripMenuItem_Click);
			// 
			// deleteSaveMenuStrip
			// 
			this.deleteSaveMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.deleteSaveMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьКакToolStripMenuItem,
            this.deleteStripMenuItem});
			this.deleteSaveMenuStrip.Name = "deleteMenuStrip";
			this.deleteSaveMenuStrip.Size = new System.Drawing.Size(179, 52);
			// 
			// сохранитьКакToolStripMenuItem
			// 
			this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
			this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
			this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
			this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
			// 
			// deleteStripMenuItem
			// 
			this.deleteStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.deleteStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.deleteStripMenuItem.ImageTransparentColor = System.Drawing.SystemColors.Control;
			this.deleteStripMenuItem.Name = "deleteStripMenuItem";
			this.deleteStripMenuItem.Size = new System.Drawing.Size(178, 24);
			this.deleteStripMenuItem.Text = "Удалить";
			this.deleteStripMenuItem.Click += new System.EventHandler(this.DelStripMenuItem_Click);
			// 
			// metropolisLabel
			// 
			this.metropolisLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.metropolisLabel.AutoSize = true;
			this.metropolisLabel.Location = new System.Drawing.Point(1196, 215);
			this.metropolisLabel.Name = "metropolisLabel";
			this.metropolisLabel.Size = new System.Drawing.Size(97, 17);
			this.metropolisLabel.TabIndex = 32;
			this.metropolisLabel.Text = "Метрополиса";
			// 
			// metropolisProgressBar
			// 
			this.metropolisProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.metropolisProgressBar.Location = new System.Drawing.Point(1199, 235);
			this.metropolisProgressBar.Name = "metropolisProgressBar";
			this.metropolisProgressBar.Size = new System.Drawing.Size(313, 25);
			this.metropolisProgressBar.TabIndex = 31;
			// 
			// reverseBackgroundWorker
			// 
			this.reverseBackgroundWorker.WorkerReportsProgress = true;
			this.reverseBackgroundWorker.WorkerSupportsCancellation = true;
			this.reverseBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReverseBackgroundWorker_DoWork);
			this.reverseBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ReverseBackgroundWorker_ProgressChanged);
			this.reverseBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReverseBackgroundWorker_RunWorkerCompleted);
			// 
			// neymanBackgroundWorker
			// 
			this.neymanBackgroundWorker.WorkerReportsProgress = true;
			this.neymanBackgroundWorker.WorkerSupportsCancellation = true;
			this.neymanBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.NeymanBackgroundWorker_DoWork);
			this.neymanBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.NeymanBackgroundWorker_ProgressChanged);
			this.neymanBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.NeymanBackgroundWorker_RunWorkerCompleted);
			// 
			// metropolisBackgroundWorker
			// 
			this.metropolisBackgroundWorker.WorkerReportsProgress = true;
			this.metropolisBackgroundWorker.WorkerSupportsCancellation = true;
			this.metropolisBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MetropolisBackgroundWorker_DoWork);
			this.metropolisBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MetropolisBackgroundWorker_ProgressChanged);
			this.metropolisBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MetropolisBackgroundWorker_RunWorkerCompleted);
			// 
			// waiterBackgroundWorker
			// 
			this.waiterBackgroundWorker.WorkerReportsProgress = true;
			this.waiterBackgroundWorker.WorkerSupportsCancellation = true;
			this.waiterBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WaiterBackgroundWorker_DoWork);
			this.waiterBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WaiterBackgroundWorker_RunWorkerCompleted);
			// 
			// pauseButton
			// 
			this.pauseButton.Location = new System.Drawing.Point(118, 154);
			this.pauseButton.Name = "pauseButton";
			this.pauseButton.Size = new System.Drawing.Size(95, 28);
			this.pauseButton.TabIndex = 33;
			this.pauseButton.Text = "Пауза";
			this.pauseButton.UseVisualStyleBackColor = true;
			this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
			// 
			// resumeButton
			// 
			this.resumeButton.Location = new System.Drawing.Point(219, 154);
			this.resumeButton.Name = "resumeButton";
			this.resumeButton.Size = new System.Drawing.Size(106, 28);
			this.resumeButton.TabIndex = 34;
			this.resumeButton.Text = "Продолжить";
			this.resumeButton.UseVisualStyleBackColor = true;
			this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
			// 
			// infoDataGridView
			// 
			this.infoDataGridView.AllowUserToAddRows = false;
			this.infoDataGridView.AllowUserToDeleteRows = false;
			this.infoDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
			this.infoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.infoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mathExColumn,
            this.dispersionColumn});
			this.infoDataGridView.Location = new System.Drawing.Point(1199, 301);
			this.infoDataGridView.Name = "infoDataGridView";
			this.infoDataGridView.ReadOnly = true;
			this.infoDataGridView.RowHeadersWidth = 51;
			this.infoDataGridView.RowTemplate.Height = 24;
			this.infoDataGridView.Size = new System.Drawing.Size(313, 344);
			this.infoDataGridView.TabIndex = 35;
			// 
			// mathExColumn
			// 
			this.mathExColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.mathExColumn.HeaderText = "Мат. ожидание";
			this.mathExColumn.MinimumWidth = 6;
			this.mathExColumn.Name = "mathExColumn";
			this.mathExColumn.ReadOnly = true;
			// 
			// dispersionColumn
			// 
			this.dispersionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dispersionColumn.HeaderText = "Дисперсия";
			this.dispersionColumn.MinimumWidth = 6;
			this.dispersionColumn.Name = "dispersionColumn";
			this.dispersionColumn.ReadOnly = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1582, 653);
			this.Controls.Add(this.infoDataGridView);
			this.Controls.Add(this.resumeButton);
			this.Controls.Add(this.pauseButton);
			this.Controls.Add(this.metropolisLabel);
			this.Controls.Add(this.metropolisProgressBar);
			this.Controls.Add(this.ToolStripMenu);
			this.Controls.Add(this.integralGridView);
			this.Controls.Add(this.neymanLabel);
			this.Controls.Add(this.neymanProgressBar);
			this.Controls.Add(this.reverseLabel);
			this.Controls.Add(this.reverseProgressBar);
			this.Controls.Add(this.filesDataGrid);
			this.Controls.Add(this.analyticLabel);
			this.Controls.Add(this.analyticProgressBar);
			this.Controls.Add(this.aErrLabel);
			this.Controls.Add(this.countErrLabel);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.lamdaTextBox);
			this.Controls.Add(this.countTextBox);
			this.Controls.Add(this.lamdaLabel);
			this.Controls.Add(this.countLabel);
			this.Controls.Add(this.grafChart);
			this.MainMenuStrip = this.ToolStripMenu;
			this.MinimumSize = new System.Drawing.Size(1600, 700);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.grafChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.filesDataGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.integralGridView)).EndInit();
			this.ToolStripMenu.ResumeLayout(false);
			this.ToolStripMenu.PerformLayout();
			this.deleteSaveMenuStrip.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.infoDataGridView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart grafChart;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Label lamdaLabel;
		private System.Windows.Forms.TextBox countTextBox;
		private System.Windows.Forms.TextBox lamdaTextBox;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label countErrLabel;
		private System.Windows.Forms.Label aErrLabel;
		private System.Windows.Forms.ProgressBar analyticProgressBar;
		private System.Windows.Forms.Label analyticLabel;
		private System.ComponentModel.BackgroundWorker analyticBackgroundWorker;
		private System.Windows.Forms.DataGridView filesDataGrid;
		private System.Windows.Forms.Label reverseLabel;
		private System.Windows.Forms.ProgressBar reverseProgressBar;
		private System.Windows.Forms.Label neymanLabel;
		private System.Windows.Forms.ProgressBar neymanProgressBar;
		private System.Windows.Forms.DataGridView integralGridView;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.MenuStrip ToolStripMenu;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip deleteSaveMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
		private System.Windows.Forms.Label metropolisLabel;
		private System.Windows.Forms.ProgressBar metropolisProgressBar;
		private System.ComponentModel.BackgroundWorker reverseBackgroundWorker;
		private System.ComponentModel.BackgroundWorker neymanBackgroundWorker;
		private System.ComponentModel.BackgroundWorker metropolisBackgroundWorker;
		private System.ComponentModel.BackgroundWorker waiterBackgroundWorker;
		private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
		private System.Windows.Forms.Button pauseButton;
		private System.Windows.Forms.Button resumeButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countPoints;
		private System.Windows.Forms.DataGridViewTextBoxColumn kCoef;
		private System.Windows.Forms.DataGridView infoDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn mathExColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dispersionColumn;
	}
}

