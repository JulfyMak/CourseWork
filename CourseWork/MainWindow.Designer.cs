namespace CourseWork
{
	partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.countLabel = new System.Windows.Forms.Label();
            this.d1Label = new System.Windows.Forms.Label();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.d1TextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.countErrLabel = new System.Windows.Forms.Label();
            this.d1ErrLabel = new System.Windows.Forms.Label();
            this.analyticProgressBar = new System.Windows.Forms.ProgressBar();
            this.analyticLabel = new System.Windows.Forms.Label();
            this.analyticBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.filesDataGrid = new System.Windows.Forms.DataGridView();
            this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d1Coef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d2Coef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reverseLabel = new System.Windows.Forms.Label();
            this.reverseProgressBar = new System.Windows.Forms.ProgressBar();
            this.neymanLabel = new System.Windows.Forms.Label();
            this.neymanProgressBar = new System.Windows.Forms.ProgressBar();
            this.integralGridView = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.ToolStripMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSaveMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.d2TextBox = new System.Windows.Forms.TextBox();
            this.d2Label = new System.Windows.Forms.Label();
            this.d2ErrLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            chartArea1.AxisX.Interval = 0.5D;
            chartArea1.AxisX.Maximum = 5D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.grafChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend";
            this.grafChart.Legends.Add(legend1);
            this.grafChart.Location = new System.Drawing.Point(397, 30);
            this.grafChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grafChart.Name = "grafChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend";
            series1.Name = "Аналитический(A)";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend";
            series2.Name = "Обратной ф-ии(R)";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend";
            series3.Name = "Неймана(N)";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend";
            series4.Name = "Метрополиса(M)";
            this.grafChart.Series.Add(series1);
            this.grafChart.Series.Add(series2);
            this.grafChart.Series.Add(series3);
            this.grafChart.Series.Add(series4);
            this.grafChart.Size = new System.Drawing.Size(795, 409);
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
            // d1Label
            // 
            this.d1Label.AutoSize = true;
            this.d1Label.Location = new System.Drawing.Point(12, 66);
            this.d1Label.Name = "d1Label";
            this.d1Label.Size = new System.Drawing.Size(110, 17);
            this.d1Label.TabIndex = 7;
            this.d1Label.Text = "Коэфициент d1";
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(128, 34);
            this.countTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(85, 22);
            this.countTextBox.TabIndex = 1;
            this.countTextBox.Text = "10000";
            this.countTextBox.TextChanged += new System.EventHandler(this.CountTextBox_TextChanged);
            // 
            // d1TextBox
            // 
            this.d1TextBox.Location = new System.Drawing.Point(128, 63);
            this.d1TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.d1TextBox.Name = "d1TextBox";
            this.d1TextBox.Size = new System.Drawing.Size(85, 22);
            this.d1TextBox.TabIndex = 2;
            this.d1TextBox.Text = "10";
            this.d1TextBox.TextChanged += new System.EventHandler(this.D1TextBox_TextChanged);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(11, 143);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(109, 28);
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
            // d1ErrLabel
            // 
            this.d1ErrLabel.AutoSize = true;
            this.d1ErrLabel.Location = new System.Drawing.Point(219, 66);
            this.d1ErrLabel.Name = "d1ErrLabel";
            this.d1ErrLabel.Size = new System.Drawing.Size(0, 17);
            this.d1ErrLabel.TabIndex = 8;
            // 
            // analyticProgressBar
            // 
            this.analyticProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.analyticProgressBar.Location = new System.Drawing.Point(1199, 58);
            this.analyticProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.filesDataGrid.AllowUserToDeleteRows = false;
            this.filesDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.filesDataGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.filesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameColumn,
            this.countPoints,
            this.d1Coef,
            this.d2Coef});
            this.filesDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.filesDataGrid.Location = new System.Drawing.Point(12, 177);
            this.filesDataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filesDataGrid.MultiSelect = false;
            this.filesDataGrid.Name = "filesDataGrid";
            this.filesDataGrid.ReadOnly = true;
            this.filesDataGrid.RowHeadersVisible = false;
            this.filesDataGrid.RowHeadersWidth = 51;
            this.filesDataGrid.RowTemplate.Height = 24;
            this.filesDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.filesDataGrid.Size = new System.Drawing.Size(380, 468);
            this.filesDataGrid.TabIndex = 7;
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
            // d1Coef
            // 
            this.d1Coef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.d1Coef.HeaderText = "d1";
            this.d1Coef.MinimumWidth = 6;
            this.d1Coef.Name = "d1Coef";
            this.d1Coef.ReadOnly = true;
            this.d1Coef.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // d2Coef
            // 
            this.d2Coef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.d2Coef.HeaderText = "d2";
            this.d2Coef.MinimumWidth = 6;
            this.d2Coef.Name = "d2Coef";
            this.d2Coef.ReadOnly = true;
            this.d2Coef.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.reverseProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reverseProgressBar.Name = "reverseProgressBar";
            this.reverseProgressBar.Size = new System.Drawing.Size(313, 25);
            this.reverseProgressBar.TabIndex = 24;
            // 
            // neymanLabel
            // 
            this.neymanLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neymanLabel.AutoSize = true;
            this.neymanLabel.Location = new System.Drawing.Point(1196, 158);
            this.neymanLabel.Name = "neymanLabel";
            this.neymanLabel.Size = new System.Drawing.Size(67, 17);
            this.neymanLabel.TabIndex = 27;
            this.neymanLabel.Text = "Неймана";
            // 
            // neymanProgressBar
            // 
            this.neymanProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.neymanProgressBar.Location = new System.Drawing.Point(1199, 177);
            this.neymanProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.integralGridView.Location = new System.Drawing.Point(397, 444);
            this.integralGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.integralGridView.Name = "integralGridView";
            this.integralGridView.ReadOnly = true;
            this.integralGridView.RowHeadersVisible = false;
            this.integralGridView.RowHeadersWidth = 51;
            this.integralGridView.RowTemplate.Height = 24;
            this.integralGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.integralGridView.Size = new System.Drawing.Size(1115, 201);
            this.integralGridView.TabIndex = 8;
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
            // ToolStripMenu
            // 
            this.ToolStripMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.ToolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.ToolStripMenu.Name = "ToolStripMenu";
            this.ToolStripMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.ToolStripMenu.Size = new System.Drawing.Size(1584, 28);
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
            this.saveAsToolStripMenuItem,
            this.changeCountToolStripMenuItem,
            this.deleteStripMenuItem});
            this.deleteSaveMenuStrip.Name = "deleteMenuStrip";
            this.deleteSaveMenuStrip.Size = new System.Drawing.Size(179, 76);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.saveAsToolStripMenuItem.Text = "Сохранить как";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // changeCountToolStripMenuItem
            // 
            this.changeCountToolStripMenuItem.Name = "changeCountToolStripMenuItem";
            this.changeCountToolStripMenuItem.Size = new System.Drawing.Size(178, 24);
            this.changeCountToolStripMenuItem.Text = "Досчитать";
            this.changeCountToolStripMenuItem.Click += new System.EventHandler(this.changeCountToolStripMenuItem_Click);
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
            this.metropolisProgressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.pauseButton.Location = new System.Drawing.Point(141, 143);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(109, 28);
            this.pauseButton.TabIndex = 5;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(273, 143);
            this.resumeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(109, 28);
            this.resumeButton.TabIndex = 6;
            this.resumeButton.Text = "Продолжить";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // infoDataGridView
            // 
            this.infoDataGridView.AllowUserToAddRows = false;
            this.infoDataGridView.AllowUserToDeleteRows = false;
            this.infoDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.infoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mathExColumn,
            this.dispersionColumn});
            this.infoDataGridView.Location = new System.Drawing.Point(1199, 278);
            this.infoDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoDataGridView.Name = "infoDataGridView";
            this.infoDataGridView.ReadOnly = true;
            this.infoDataGridView.RowHeadersWidth = 51;
            this.infoDataGridView.RowTemplate.Height = 24;
            this.infoDataGridView.Size = new System.Drawing.Size(313, 160);
            this.infoDataGridView.TabIndex = 9;
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
            // d2TextBox
            // 
            this.d2TextBox.Location = new System.Drawing.Point(128, 97);
            this.d2TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.d2TextBox.Name = "d2TextBox";
            this.d2TextBox.Size = new System.Drawing.Size(85, 22);
            this.d2TextBox.TabIndex = 3;
            this.d2TextBox.Text = "20";
            this.d2TextBox.TextChanged += new System.EventHandler(this.d2TextBox_TextChanged);
            // 
            // d2Label
            // 
            this.d2Label.AutoSize = true;
            this.d2Label.Location = new System.Drawing.Point(12, 100);
            this.d2Label.Name = "d2Label";
            this.d2Label.Size = new System.Drawing.Size(110, 17);
            this.d2Label.TabIndex = 38;
            this.d2Label.Text = "Коэфициент d2";
            // 
            // d2ErrLabel
            // 
            this.d2ErrLabel.AutoSize = true;
            this.d2ErrLabel.Location = new System.Drawing.Point(219, 102);
            this.d2ErrLabel.Name = "d2ErrLabel";
            this.d2ErrLabel.Size = new System.Drawing.Size(0, 17);
            this.d2ErrLabel.TabIndex = 39;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1511, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 28);
            this.button1.TabIndex = 40;
            this.button1.Text = "Fortran";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1584, 661);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.d2ErrLabel);
            this.Controls.Add(this.d2TextBox);
            this.Controls.Add(this.d2Label);
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
            this.Controls.Add(this.d1ErrLabel);
            this.Controls.Add(this.countErrLabel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.d1TextBox);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.d1Label);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.grafChart);
            this.MainMenuStrip = this.ToolStripMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1599, 698);
            this.Name = "MainWindow";
            this.Text = "Distribution";
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
		private System.Windows.Forms.Label d1Label;
		private System.Windows.Forms.TextBox countTextBox;
		private System.Windows.Forms.TextBox d1TextBox;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Label countErrLabel;
		private System.Windows.Forms.Label d1ErrLabel;
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
		private System.Windows.Forms.MenuStrip ToolStripMenu;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip deleteSaveMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem deleteStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
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
		private System.Windows.Forms.DataGridView infoDataGridView;
		private System.Windows.Forms.DataGridViewTextBoxColumn mathExColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dispersionColumn;
		private System.Windows.Forms.TextBox d2TextBox;
		private System.Windows.Forms.Label d2Label;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countPoints;
		private System.Windows.Forms.DataGridViewTextBoxColumn d1Coef;
		private System.Windows.Forms.DataGridViewTextBoxColumn d2Coef;
		private System.Windows.Forms.Label d2ErrLabel;
		private System.Windows.Forms.ToolStripMenuItem changeCountToolStripMenuItem;
		private System.Windows.Forms.Button button1;
	}
}

