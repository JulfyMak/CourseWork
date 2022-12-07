using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CourseWork
{
	public partial class MainWindow : Form
	{
		private CheckedListBox listBoxMeth = new CheckedListBox();

		private volatile DataFile prog_data_file = new DataFile();
		private CalcMod calcMod = new CalcMod();
		private BinaryFormatter formatter = new BinaryFormatter();

		private volatile bool pause = false;
		private volatile bool resume = false;
		private List<DataFile> files = new List<DataFile>();

		private volatile bool completeA = true, completeR = true, completeN = true, completeM = true;

		//private Dictionary<double, double> analyticDataSet = new Dictionary<double, double>();
		//private bool count_valid = true, a_valid = true, b_valid = true;
		public MainWindow()
		{
			InitializeComponent();
			listBoxMeth.Items.Add("Аналитический");
			listBoxMeth.Items.Add("Обратной ф-ии");
			listBoxMeth.Items.Add("Неймана");
			listBoxMeth.Items.Add("Метрополиса");
			listBoxMeth.Visible = false;
			listBoxMeth.CheckOnClick = true;
			listBoxMeth.MouseLeave += delegate { listBoxMeth.Visible = false; };
			this.Controls.Add(listBoxMeth);

		}

		private void StartButton_Click(object sender, EventArgs e)
		{
				if (!isValidData())
				{
					MessageBox.Show("Введены некоррекные данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				calcMod.CountPoints = Convert.ToInt64(countTextBox.Text);
				calcMod.D1_coef = Convert.ToDouble(d1TextBox.Text.Replace('.', ','));
			calcMod.D2_coef = Convert.ToDouble(d2TextBox.Text.Replace('.', ','));
			//calcMod.CoefB = Convert.ToDouble(bTextBox.Text.Replace('.', ','));
			calcMod.Intervals = 200;
				calcMod.LimitA = 0;
				calcMod.LimitB = 50;

				prog_data_file.Count = Convert.ToInt64(countTextBox.Text);
				prog_data_file.D1_coef = Convert.ToDouble(d1TextBox.Text.Replace('.', ','));
			prog_data_file.D2_coef = Convert.ToDouble(d2TextBox.Text.Replace('.', ','));
			prog_data_file.CountCalcA = 0;
				prog_data_file.CountCalcR = 0;
				prog_data_file.CountCalcN = 0;
				prog_data_file.CountCalcM = 0;
				prog_data_file.AnalyticDict.Clear();
				prog_data_file.ReversDict.Clear();
				prog_data_file.NeymanDict.Clear();
				prog_data_file.MetropolisDict.Clear();
				prog_data_file.Path = "def";
				prog_data_file.Intervals = 200;
				prog_data_file.LimitA = 0;
				prog_data_file.LimitB = 50;

				for (int i = 0; i <= prog_data_file.Intervals; i++)
				{
					//prog_data_file.AnalyticDict.Add(i, 0);
					prog_data_file.ReversDict.Add(i, 0);
					prog_data_file.NeymanDict.Add(i, 0);
					prog_data_file.MetropolisDict.Add(i, 0);
				}
			//Console.WriteLine("ct " + prog_data_file.ReversDict[100]);
				calcMod.fillTable();
			//grafChart.Series[0].Points.Clear();
			//for (int i = 0; i < calcMod.table.Count; i++)
			//{
			//	grafChart.Series[0].Points.AddXY(calcMod.table.Keys.ToArray()[i], calcMod.table.Values.ToArray()[i]);
			//}
			//return;
				completeA = false;
			completeM = false;
			completeN = false;
			completeR = false;

			startButton.Enabled = false;
			pauseButton.Enabled = true;
			resumeButton.Enabled = false;
			waiterBackgroundWorker.RunWorkerAsync();

				analyticBackgroundWorker.RunWorkerAsync();

			calcMod.PrevX = (calcMod.LimitB - calcMod.LimitA) / 3.0;
			reverseBackgroundWorker.RunWorkerAsync();
			neymanBackgroundWorker.RunWorkerAsync();
			metropolisBackgroundWorker.RunWorkerAsync();

		}
		private int getInterval(double a, double b, double x, int count_intervals)
		{
			////int interval = 0;
			double step = (b - a) / (double)count_intervals;
			//Console.WriteLine("step " + step);
			double fx = a;
			int i = 0;
			for (i = 0; i < count_intervals; i++)
			{
				fx = a + (Convert.ToDouble(i)) * step;
				if (x <= fx/* && x<fx+step*/)
				{
					//Console.WriteLine("interval " + i + " x " + x);
					return i;
				}
				
			}
			return i-1;
		}
		private bool isValidData()
		{
			if (countErrLabel.Text.Equals("")&& d1ErrLabel.Text.Equals("") && d2ErrLabel.Text.Equals("")) return true;
			return false;
		}
		private void CountTextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (countTextBox.Text.Length != 0)
					if (Convert.ToInt32(countTextBox.Text)<=0) countErrLabel.Text = "Число должно быть > 0";
					else countErrLabel.Text = "";
				else countErrLabel.Text = "";
			}
			catch (FormatException ex)
			{
				countErrLabel.Text = "Введите целое число.";
			}
		}

		private void D1TextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (d1TextBox.Text.Length != 0)
					if (Convert.ToInt64(d1TextBox.Text) <= 0) d1ErrLabel.Text = "Число должно быть > 0";
					else d1ErrLabel.Text = "";
				else d1ErrLabel.Text = "";
			}
			catch (FormatException ex)
			{
				d1ErrLabel.Text = "Неверный формат числа";
			}
		}
		private void d2TextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (d2TextBox.Text.Length != 0)
					if (Convert.ToInt64(d2TextBox.Text) <= 0) d2ErrLabel.Text = "Число должно быть > 0";
					else d1ErrLabel.Text = "";
				else d1ErrLabel.Text = "";
			}
			catch (FormatException ex)
			{
				d2ErrLabel.Text = "Неверный формат числа";
			}
		}




		private void AnalyticBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			double fx = 0;
			double fy = 0;
			//double[] analytic_arr = new double[prog_data_file.Intervals+1];
			double max = 0;
			double step= (prog_data_file.LimitB - prog_data_file.LimitA) / (Convert.ToDouble(calcMod.Intervals));

			for (Int64 i =prog_data_file.CountCalcA; i <= prog_data_file.Intervals; i++)
			{
				if (analyticBackgroundWorker.CancellationPending == true)
				{
					//Console.WriteLine("breakA");
					//prog_data_file.CountCalcA = i;
					//count_op = i;
					pause = true;
					return;
				}
				//Console.WriteLine(i);
				if ((i % Math.Ceiling((double)prog_data_file.Intervals / (double)analyticProgressBar.Maximum)) == 0)
				{
					analyticBackgroundWorker.ReportProgress((int)((double)i * (double)analyticProgressBar.Maximum / (double)prog_data_file.Intervals));
				}


				fx = i * step;
				fy = calcMod.analyticFunc(fx);
				//if (Double.IsInfinity(fy)) Console.WriteLine("i " + i);
					prog_data_file.AnalyticDict.Add(fx, fy);
				//Console.WriteLine("i " + i);
				prog_data_file.CountCalcA = i;
			}
			prog_data_file.CountCalcA += 1;
			//max = prog_data_file.AnalyticDict.Values.ToArray().Max();
			//for (int i = 0; i < prog_data_file.AnalyticDict.Count; i++)
			//{
			//	prog_data_file.AnalyticDict[prog_data_file.AnalyticDict.Keys.ElementAt(i)] /= max;
			//}
		}

		private void AnalyticBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			analyticProgressBar.Invoke(new MethodInvoker(() => analyticProgressBar.Value = e.ProgressPercentage));
		}

		private void AnalyticBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//prog_data_file.CountCalcA = prog_data_file.Intervals;
			completeA = true;
			analyticProgressBar.Value = analyticProgressBar.Maximum;



		}
		private void fillIntegralTableAllMeth(DataFile df)
		{
			
			integralGridView.Columns.Clear();
			integralGridView.Columns.Add("AnalyticX", "X");
			integralGridView.Columns["AnalyticX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("AnalyticY", "f(x)");
			integralGridView.Columns["AnalyticY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("ReverseX", "Интервал R");
			integralGridView.Columns["ReverseX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("ReverseY", "Y R");
			integralGridView.Columns["ReverseY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("NeymanX", "Интервал N");
			integralGridView.Columns["NeymanX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("NeymanY", "Y N");
			integralGridView.Columns["NeymanY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("MetropolisX", "Интервал M");
			integralGridView.Columns["MetropolisX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("MetropolisY", "Y M");
			integralGridView.Columns["MetropolisY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Rows.Clear();
			//Console.WriteLine("count" + df.AnalyticDict.Count);
			///forы
			for (int i = 0; i < df.AnalyticDict.Count; i++)
			{
				integralGridView.Rows.Add(df.AnalyticDict.Keys.ToArray()[i], df.AnalyticDict.Values.ToArray()[i]);
			}
			for (int i = 0; i < df.ReversDict.Count; i++)
			{
				//Console.WriteLine(df.ReversDict.Keys.ToArray()[i]);
				integralGridView.Rows[i].Cells[2].Value= df.ReversDict.Keys.ToArray()[i];
				integralGridView.Rows[i].Cells[3].Value = df.ReversDict.Values.ToArray()[i];
			}
			for (int i = 0; i < df.NeymanDict.Count; i++)
			{
				integralGridView.Rows[i].Cells[4].Value = df.NeymanDict.Keys.ToArray()[i];
				integralGridView.Rows[i].Cells[5].Value = df.NeymanDict.Values.ToArray()[i];
			}
			for (int i = 0; i < df.MetropolisDict.Count; i++)
			{
				integralGridView.Rows[i].Cells[6].Value = df.MetropolisDict.Keys.ToArray()[i];
				integralGridView.Rows[i].Cells[7].Value = df.MetropolisDict.Values.ToArray()[i];
			}
		}
			private void drawAllMeth(DataFile df)
		{
			grafChart.Series[0].Points.Clear();
			grafChart.Series[1].Points.Clear();
			grafChart.Series[2].Points.Clear();
			grafChart.Series[3].Points.Clear();
			Dictionary<double, double> tmp_arr = new Dictionary<double, double>(df.AnalyticDict);
			for(int i = 0; i < tmp_arr.Count; i++)
			{
				if (Double.IsInfinity(tmp_arr.Values.ToArray()[i]))
					tmp_arr.Remove(tmp_arr.Keys.ToArray()[i]);
			}
			tmp_arr = calcMod.normalizeY(tmp_arr);
			for (Int64 i = 0; i < tmp_arr.Count; i++)
			{
					grafChart.Series[0].Points.AddXY(tmp_arr.Keys.ToArray()[i], tmp_arr.Values.ToArray()[i]);
			}

			tmp_arr = new Dictionary<double, double>(df.ReversDict);
			tmp_arr = calcMod.normalizeY(tmp_arr);
			//Console.WriteLine(tmp_arr[tmp_arr.Keys.ToArray()[0]]);
			tmp_arr = calcMod.normalizeX(tmp_arr,df.LimitA,df.LimitB);
			//grafChart.Series[1].Points.AddXY(-1, 0.4);
			for (Int64 i = 0; i < tmp_arr.Count; i++)
			{
				grafChart.Series[1].Points.AddXY(tmp_arr.Keys.ToArray()[i], tmp_arr.Values.ToArray()[i]);
			}
			

			tmp_arr = new Dictionary<double, double>(df.NeymanDict);
			tmp_arr = calcMod.normalizeY(tmp_arr);
			tmp_arr = calcMod.normalizeX(tmp_arr, df.LimitA, df.LimitB);
			for (Int64 i = 0; i <tmp_arr.Count; i++)
			{
				grafChart.Series[2].Points.AddXY(tmp_arr.Keys.ToArray()[i], tmp_arr.Values.ToArray()[i]);
			}

			tmp_arr = new Dictionary<double, double>(df.MetropolisDict);
			tmp_arr = calcMod.normalizeY(tmp_arr);
			tmp_arr = calcMod.normalizeX(tmp_arr, df.LimitA, df.LimitB);
			for (Int64 i = 0; i < tmp_arr.Count; i++)
			{
				grafChart.Series[3].Points.AddXY(tmp_arr.Keys.ToArray()[i], tmp_arr.Values.ToArray()[i]);
			}
		}
		

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				//Console.WriteLine(openFileDialog.FileName);
				using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate))
				{
					DataFile dat = (DataFile)formatter.Deserialize(fs);
					dat.Path = openFileDialog.FileName;
					files.Add(dat);
					filesDataGrid.Rows.Add(Path.GetFileNameWithoutExtension(dat.Path), dat.Count, dat.D1_coef,dat.D2_coef);
					filesDataGrid.Rows[filesDataGrid.Rows.Count - 1].Cells[0].ToolTipText = dat.Path;

					//for (int i = 0; i < dat.AnalyticDict.Count; i++)
					//	Console.WriteLine("x= " + dat.AnalyticDict.Keys.ToArray()[i] + " val " + dat.AnalyticDict.Values.ToArray()[i]);
				}
			}
		}
		private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine(saveFileDialog.FileName);

				using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
				{
					formatter.Serialize(fs, prog_data_file);

					Console.WriteLine("Объект сериализован");
				}
			}
		}

		private void FilesDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			
			//if (e.ColumnIndex == 4 && e.RowIndex >= 0 && e.Button == MouseButtons.Left)
			//{
			//	Console.WriteLine("HUI");
			//	if (!listBoxMeth.Visible)
			//	{
			//		int RowHeight1 = filesDataGrid.Rows[e.RowIndex].Height;
			//		Rectangle CellRectangle1 = filesDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

			//		CellRectangle1.X += filesDataGrid.Left;
			//		CellRectangle1.Y += filesDataGrid.Top + RowHeight1;

			//		listBoxMeth.Left = CellRectangle1.X;
			//		listBoxMeth.Top = CellRectangle1.Y;
			//		listBoxMeth.Visible = true;
			//		listBoxMeth.BringToFront();
			//	}
			//	else listBoxMeth.Visible = false;
			//}
			if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.Button == MouseButtons.Left)
			{
				analyticProgressBar.Value = 100;
				reverseProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(files[e.RowIndex].CountCalcR) * 100.0 / Convert.ToDouble(files[e.RowIndex].Count)));
				neymanProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(files[e.RowIndex].CountCalcN) * 100.0 / Convert.ToDouble(files[e.RowIndex].Count)));
				metropolisProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(files[e.RowIndex].CountCalcM) * 100.0 / Convert.ToDouble(files[e.RowIndex].Count)));
				if (checkResumeCond(files[e.RowIndex]))
				{
					resumeButton.Enabled = false;
					startButton.Enabled = true;
					pauseButton.Enabled = false;
				}
				else
				{
					startButton.Enabled = true;
					pauseButton.Enabled = false;
					resumeButton.Enabled = true;
				}
				prog_data_file = files[e.RowIndex].Clone();
				calcMod.D1_coef = prog_data_file.D1_coef;
				//calcMod.CoefB = prog_data_file.CoefB;
				calcMod.Intervals = prog_data_file.Intervals;
				calcMod.CountPoints = prog_data_file.Count;
				calcMod.fillTable();
				drawAllMeth(files[e.RowIndex]);
				fillIntegralTableAllMeth(files[e.RowIndex]);
				fillInfoTable(files[e.RowIndex]);
			}

			if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.Button==MouseButtons.Right)
			{
				this.filesDataGrid.CurrentCell = this.filesDataGrid.Rows[e.RowIndex].Cells[0];
				this.deleteSaveMenuStrip.Show(this.filesDataGrid, e.Location);
				deleteSaveMenuStrip.Show(Cursor.Position);
			}
		}
		private bool checkResumeCond(DataFile df)
		{
			return df.CountCalcA >= df.Intervals+1 && df.CountCalcM == df.Count && df.CountCalcN == df.Count && df.CountCalcR == df.Count;
		}
		private void DelStripMenuItem_Click(object sender, EventArgs e)
		{
			files.RemoveAt(filesDataGrid.CurrentRow.Index);
			this.filesDataGrid.Rows.RemoveAt(filesDataGrid.CurrentRow.Index);
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				//Console.WriteLine(saveFileDialog.FileName);
				using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
				{
					
					formatter.Serialize(fs, files.ElementAt(filesDataGrid.CurrentRow.Index));
					files.ElementAt(filesDataGrid.CurrentRow.Index).Path = saveFileDialog.FileName;
					filesDataGrid.CurrentRow.Cells[0].Value = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
					filesDataGrid.CurrentRow.Cells[0].ToolTipText = saveFileDialog.FileName;
					//Console.WriteLine("Объект сериализован");
				}
			}
		}

		private void ReverseBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int interval = 0;
			for (Int64 i = prog_data_file.CountCalcR; i < prog_data_file.Count; i++)
			{
				if (reverseBackgroundWorker.CancellationPending == true)
				{
					Console.WriteLine("break");
					//prog_data_file.CountCalcR = i;
					pause = true;
					return;
				}
				//Console.WriteLine(i);
				if ((i % Math.Ceiling((double)prog_data_file.Count / (double)reverseProgressBar.Maximum)) == 0)
				{
					reverseBackgroundWorker.ReportProgress((int)((double)i * (double)reverseProgressBar.Maximum / (double)prog_data_file.Count));
				}
				interval = getInterval(calcMod.LimitA, calcMod.LimitB, calcMod.getCsiR(), calcMod.Intervals);
				//Console.WriteLine("interval " + interval);
				prog_data_file.ReversDict[interval] += 1;
				prog_data_file.CountCalcR = i;
			}
			prog_data_file.CountCalcR += 1;
		}

		private void ReverseBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			reverseProgressBar.Invoke(new MethodInvoker(() => reverseProgressBar.Value = e.ProgressPercentage));
		}

		private void ReverseBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//prog_data_file.CountCalcR = prog_data_file.Count;
			reverseProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(prog_data_file.CountCalcR) * 100.0 / Convert.ToDouble(prog_data_file.Count)));
			completeR = true;
			//reverseProgressBar.Value = reverseProgressBar.Maximum;
			//Console.WriteLine("CompleteR");
		}

		private void NeymanBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			//int[] arr = new int[prog_data_file.Intervals + 1];
			int interval = 0;
			for (Int64 i = prog_data_file.CountCalcN; i < prog_data_file.Count; i++)
			{
				if (neymanBackgroundWorker.CancellationPending == true)
				{
					Console.WriteLine("break");
					//prog_data_file.CountCalcN = i;
					//count_op = i;
					pause = true;
					return;
				}
				//Console.WriteLine(i);
				if ((i % Math.Ceiling((double)prog_data_file.Count/ (double)neymanProgressBar.Maximum)) == 0)
				{
					neymanBackgroundWorker.ReportProgress((int)((double)i * (double)neymanProgressBar.Maximum / (double)prog_data_file.Count));
				}
				interval = getInterval(calcMod.LimitA, calcMod.LimitB, calcMod.getCsiN(), calcMod.Intervals);
				prog_data_file.NeymanDict[interval] += 1;
				prog_data_file.CountCalcN = i;
				//arr[getInterval(0, 1, calcMod.getCsiN(), calcMod.Intervals)] += 1;
				//Console.WriteLine("i " + i);
			}
			prog_data_file.CountCalcN += 1;
			//for (int i = 0; i <= prog_data_file.Intervals; i++)
			//	prog_data_file.NeymanDict.Add(i,arr[i]);
		}

		private void NeymanBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			neymanProgressBar.Invoke(new MethodInvoker(() => neymanProgressBar.Value = e.ProgressPercentage));
		}

		private void NeymanBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//prog_data_file.CountCalcN = prog_data_file.Count;
			neymanProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(prog_data_file.CountCalcN) * 100.0 / Convert.ToDouble(prog_data_file.Count)));
			completeN = true;
			//neymanProgressBar.Value = neymanProgressBar.Maximum;

			//Console.WriteLine("CompleteN");
		}

		private void MetropolisBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int interval = 0;
			for (Int64 i = prog_data_file.CountCalcM; i < prog_data_file.Count; i++)
			{
				if (metropolisBackgroundWorker.CancellationPending == true)
				{
					Console.WriteLine("break");
					//prog_data_file.CountCalcM = i;
					//count_op = i;
					pause = true;
					return;
				}
				//Console.WriteLine(i);
				if ((i % Math.Ceiling((double)prog_data_file.Count / (double)metropolisProgressBar.Maximum)) == 0)
				{
					metropolisBackgroundWorker.ReportProgress((int)((double)i * (double)metropolisProgressBar.Maximum / (double)prog_data_file.Count));
				}
				interval = getInterval(calcMod.LimitA, calcMod.LimitB, calcMod.getCsiM(), calcMod.Intervals);
				prog_data_file.MetropolisDict[interval] += 1;
				prog_data_file.CountCalcM = i;
				//arr[getInterval(0, 1, calcMod.getCsiM(), calcMod.Intervals)] += 1;
			}
			prog_data_file.CountCalcM += 1;
			//for (int i = 0; i <= prog_data_file.Intervals; i++)
			//	prog_data_file.MetropolisDict.Add(i, Convert.ToDouble(arr[i]));
		}

		private void MetropolisBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			metropolisProgressBar.Invoke(new MethodInvoker(() => metropolisProgressBar.Value = e.ProgressPercentage));
		}

		private void PauseButton_Click(object sender, EventArgs e)
		{
			startButton.Enabled = true;
			resumeButton.Enabled = true;
			pauseButton.Enabled = false;
			analyticBackgroundWorker.CancelAsync();
			reverseBackgroundWorker.CancelAsync();
			neymanBackgroundWorker.CancelAsync();
			metropolisBackgroundWorker.CancelAsync();
		}

		private void ResumeButton_Click(object sender, EventArgs e)
		{
			startButton.Enabled = false;
			pauseButton.Enabled = true;
			resumeButton.Enabled = false;
			prog_data_file = files[filesDataGrid.CurrentRow.Index].Clone();
			calcMod.D1_coef = prog_data_file.D1_coef;
			//calcMod.CoefB = prog_data_file.CoefB;
			calcMod.Intervals = prog_data_file.Intervals;
			calcMod.CountPoints = prog_data_file.Count;
			calcMod.fillTable();

			//Console.WriteLine("lll" + prog_data_file.CountCalcA + " " + prog_data_file.CountCalcM + " " + prog_data_file.CountCalcN + " " + prog_data_file.CountCalcR);
			pause = false;
			completeA = false;
			completeM = false;
			completeN = false;
			completeR = false;

			waiterBackgroundWorker.RunWorkerAsync();

			analyticBackgroundWorker.RunWorkerAsync();
			reverseBackgroundWorker.RunWorkerAsync();
			neymanBackgroundWorker.RunWorkerAsync();
			metropolisBackgroundWorker.RunWorkerAsync();
		}

		private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			InfoForm infoForm = new InfoForm();
			infoForm.ShowDialog();
		}

		private void ПомощьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			HelpForm helpForm = new HelpForm();
			helpForm.ShowDialog();
		}

		private void MetropolisBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//prog_data_file.CountCalcM = prog_data_file.Count;
			metropolisProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(prog_data_file.CountCalcM) * 100.0 / Convert.ToDouble(prog_data_file.Count)));
			completeM = true;


		}

		private void countButton_Click(object sender, EventArgs e)
		{
			if (countErrLabel.Text.Equals(""))
			{
				MessageBox.Show("Введены некоррекные данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			prog_data_file.Count+= Convert.ToInt64(countTextBox.Text);
		}

		private void changeCountToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			ChangeCountForm changeCountForm = new ChangeCountForm();
			changeCountForm.ShowDialog();
			if (changeCountForm.DialogResult == DialogResult.OK)
			{
				Console.WriteLine(changeCountForm.Count);
				files.ElementAt(filesDataGrid.CurrentRow.Index).Count += changeCountForm.Count;
				filesDataGrid.CurrentRow.Cells[1].Value = files.ElementAt(filesDataGrid.CurrentRow.Index).Count;
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Fortran.func1().ToString());
		}

		private void WaiterBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!(completeA && completeR && completeN && completeM))
			{
				System.Threading.Thread.Sleep(100);
			}
			
		}
		private void WaiterBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			
			fillIntegralTableAllMeth(prog_data_file);
			drawAllMeth(prog_data_file);
			fillInfoTable(prog_data_file);
			filesDataGrid.Rows.Add(Path.GetFileNameWithoutExtension(prog_data_file.Path), prog_data_file.Count, prog_data_file.D1_coef, prog_data_file.D2_coef);
			filesDataGrid.Rows[filesDataGrid.Rows.Count - 1].Cells[0].ToolTipText = prog_data_file.Path;
			startButton.Enabled = true;
			pauseButton.Enabled = false;
			//resumeButton.Enabled = true;

			//if (checkResumeCond(prog_data_file))
			//{
			//	startButton.Enabled = true;
			//	pauseButton.Enabled = false;
			//	resumeButton.Enabled = false;
			//}
			//else Console.WriteLine("lll"+prog_data_file.CountCalcA+" "+prog_data_file.CountCalcM+" "+prog_data_file.CountCalcN+" "+prog_data_file.CountCalcR);
			files.Add(prog_data_file.Clone());

			this.filesDataGrid.CurrentCell = this.filesDataGrid.Rows[this.filesDataGrid.Rows.Count - 1].Cells[0];
			
		}
		private void fillInfoTable(DataFile df)
		{
			infoDataGridView.Rows.Clear();
			if (df.D2_coef > 2)
			{
				double d1 = Convert.ToDouble(df.D1_coef), d2 = Convert.ToDouble(df.D2_coef);
				if(df.D2_coef>4)
					infoDataGridView.Rows.Add(d2 / (d2 - 2.0), (2.0 * Math.Pow(d2,2)*(d1+d2-2.0))/(d1*Math.Pow(d2-2.0,2)*(d2-4.0)));
				else
					infoDataGridView.Rows.Add(d2 / (d2 - 2.0), calcMod.dispersion(calcMod.normalizeY(df.AnalyticDict)));
			}
			else
			{
				infoDataGridView.Rows.Add(calcMod.mathExpectation(calcMod.normalizeY(df.AnalyticDict)), calcMod.dispersion(calcMod.normalizeY(df.AnalyticDict)));
			}
			
			infoDataGridView.Rows.Add(calcMod.mathExpectation(calcMod.normalizeY(calcMod.normalizeX(df.ReversDict,df.LimitA,df.LimitB))), calcMod.dispersion(calcMod.normalizeY(calcMod.normalizeX(df.ReversDict, df.LimitA, df.LimitB))));
			infoDataGridView.Rows.Add(calcMod.mathExpectation(calcMod.normalizeY(calcMod.normalizeX(df.NeymanDict, df.LimitA, df.LimitB))), calcMod.dispersion(calcMod.normalizeY(calcMod.normalizeX(df.NeymanDict, df.LimitA, df.LimitB))));
			infoDataGridView.Rows.Add(calcMod.mathExpectation(calcMod.normalizeY(calcMod.normalizeX(df.MetropolisDict, df.LimitA, df.LimitB))), calcMod.dispersion(calcMod.normalizeY(calcMod.normalizeX(df.MetropolisDict, df.LimitA, df.LimitB))));
			infoDataGridView.Rows[0].HeaderCell.Value = "A";
			infoDataGridView.Rows[1].HeaderCell.Value = "R";
			infoDataGridView.Rows[2].HeaderCell.Value = "N";
			infoDataGridView.Rows[3].HeaderCell.Value = "M";
		}
	}
}
