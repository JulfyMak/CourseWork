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
	public partial class Form1 : Form
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
		public Form1()
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

			//infoDataGridView.Rows.Add();
			//infoDataGridView.Rows[0].HeaderCell.Value = "zz";
			
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
				if (!isValidData())
				{
					MessageBox.Show("Введены некоррекные данные", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				calcMod.CountPoints = Convert.ToInt64(countTextBox.Text);
				calcMod.Lamda = Convert.ToDouble(lamdaTextBox.Text.Replace('.', ','));
				//calcMod.CoefB = Convert.ToDouble(bTextBox.Text.Replace('.', ','));
				calcMod.Intervals = 20;
				calcMod.LimitA = 0;
				calcMod.LimitB = 20;

				prog_data_file.Count = Convert.ToInt64(countTextBox.Text);
				prog_data_file.Lamda = Convert.ToDouble(lamdaTextBox.Text.Replace('.', ','));
				//prog_data_file.CoefB = Convert.ToDouble(bTextBox.Text.Replace('.', ','));
				prog_data_file.CountCalcA = 0;
				prog_data_file.CountCalcR = 0;
				prog_data_file.CountCalcN = 0;
				prog_data_file.CountCalcM = 0;
				prog_data_file.AnalyticDict.Clear();
				prog_data_file.ReversDict.Clear();
				prog_data_file.NeymanDict.Clear();
				prog_data_file.MetropolisDict.Clear();
				prog_data_file.Path = "test";
				prog_data_file.Intervals = 20;
				prog_data_file.LimitA = 0;
				prog_data_file.LimitB = 20;

				for (int i = 0; i <= prog_data_file.Intervals; i++)
				{
					//prog_data_file.AnalyticDict.Add(i, 0);
					prog_data_file.ReversDict.Add(i, 0);
					prog_data_file.NeymanDict.Add(i, 0);
					prog_data_file.MetropolisDict.Add(i, 0);
				}
			calcMod.fillTable();

			completeA = false;
			completeM = false;
			completeN = false;
			completeR = false;

			startButton.Enabled = false;
			pauseButton.Enabled = true;
			resumeButton.Enabled = false;
			waiterBackgroundWorker.RunWorkerAsync();

			analyticBackgroundWorker.RunWorkerAsync();
			reverseBackgroundWorker.RunWorkerAsync();
			neymanBackgroundWorker.RunWorkerAsync();

			if (prog_data_file.Lamda != 0)
				calcMod.PrevX = Convert.ToInt32(Math.Round(calcMod.LimitA + Convert.ToDouble(calcMod.LimitB - calcMod.LimitA) / 2.0));
			else calcMod.PrevX = 1;
			metropolisBackgroundWorker.RunWorkerAsync();

		}
		private int getInterval(double a, double b, double x, Int64 count_intervals)
		{
			////int interval = 0;
			double step = (b - a) / (double)count_intervals;
			//Console.WriteLine("step " + step);
			double fx = 0;
			int i = 0;
			for (i = 0; i <= count_intervals; i++)
			{
				fx =a + (Convert.ToDouble(i)) * step;
				if (x <= fx)
				{
					//Console.WriteLine("interval " + i + " x " + x);
					return i;
				}
			}
			return i-1;
		}
		private bool isValidData()
		{
			if (countErrLabel.Text.Equals("")&& aErrLabel.Text.Equals("")) return true;
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

		private void ATextBox_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (lamdaTextBox.Text.Length != 0)
					if (Convert.ToDouble(lamdaTextBox.Text.Replace('.', ',')) < 0) aErrLabel.Text = "Число должно быть >= 0";
					else aErrLabel.Text = "";
				else aErrLabel.Text = "";
			}
			catch (FormatException ex)
			{
				aErrLabel.Text = "Введено не число.";
			}
		}


		

		private void AnalyticBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			int fx = 0;
			double fy = 0;
			double max = 0;


			for (int i =prog_data_file.CountCalcA; i <= prog_data_file.Intervals; i++)
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


				fx = i;
				fy = calcMod.analyticFunc(fx);
				prog_data_file.AnalyticDict.Add(fx, fy);
				prog_data_file.CountCalcA = i;
			}
			prog_data_file.CountCalcA += 1;

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
			integralGridView.Columns.Add("AnalyticX", "X_A_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["AnalyticX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("AnalyticY", "Y_A_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["AnalyticY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("ReverseX", "X_R_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["ReverseX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("ReverseY", "Y_R_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["ReverseY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("NeymanX", "X_N_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["NeymanX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("NeymanY", "Y_N_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["NeymanY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Columns.Add("MetropolisX", "X_M_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["MetropolisX"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			integralGridView.Columns.Add("MetropolisY", "Y_M_" + Path.GetFileNameWithoutExtension(df.Path));
			integralGridView.Columns["MetropolisY"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			integralGridView.Rows.Clear();
			//Console.WriteLine("count" + df.AnalyticDict.Count);
			///forы
			for (Int64 i = 0; i < df.AnalyticDict.Count; i++)
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
					filesDataGrid.Rows.Add(Path.GetFileNameWithoutExtension(dat.Path), dat.Count, dat.Lamda);
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
			
			if (e.ColumnIndex == 4 && e.RowIndex >= 0 && e.Button == MouseButtons.Left)
			{
				if (!listBoxMeth.Visible)
				{
					int RowHeight1 = filesDataGrid.Rows[e.RowIndex].Height;
					Rectangle CellRectangle1 = filesDataGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

					CellRectangle1.X += filesDataGrid.Left;
					CellRectangle1.Y += filesDataGrid.Top + RowHeight1;

					listBoxMeth.Left = CellRectangle1.X;
					listBoxMeth.Top = CellRectangle1.Y;
					listBoxMeth.Visible = true;
					listBoxMeth.BringToFront();
				}
				else listBoxMeth.Visible = false;
			}
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
				calcMod.Lamda = prog_data_file.Lamda;
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
				//Console.WriteLine("DelClik11");
				this.filesDataGrid.CurrentCell = this.filesDataGrid.Rows[e.RowIndex].Cells[0];
				this.deleteSaveMenuStrip.Show(this.filesDataGrid, e.Location);
				//deleteMenuStrip.To
				deleteSaveMenuStrip.Show(Cursor.Position);
				//deleteMenuStrip.Visible = true;

			}
		}
		private bool checkResumeCond(DataFile df)
		{
			return df.CountCalcA >= df.Intervals+1 && df.CountCalcM == df.Count && df.CountCalcN == df.Count && df.CountCalcR == df.Count;
		}
		private void DelStripMenuItem_Click(object sender, EventArgs e)
		{
			Console.WriteLine("delete");
			this.filesDataGrid.Rows.RemoveAt(filesDataGrid.CurrentRow.Index);
			//files.RemoveAt(filesDataGrid.CurrentRow.Index);
			files.RemoveAt(filesDataGrid.CurrentRow.Index);
			Console.WriteLine("count files " + files.Count);
			for (int i = 0; i < files.Count; i++)
				Console.WriteLine(files.ToArray()[i].Count);
		}

		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Console.WriteLine(saveFileDialog.FileName);
				using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate))
				{
					
					formatter.Serialize(fs, files.ElementAt(filesDataGrid.CurrentRow.Index));
					files.ElementAt(filesDataGrid.CurrentRow.Index).Path = saveFileDialog.FileName;
					filesDataGrid.CurrentRow.Cells[0].Value = Path.GetFileNameWithoutExtension(saveFileDialog.FileName);
					filesDataGrid.CurrentRow.Cells[0].ToolTipText = saveFileDialog.FileName;
					Console.WriteLine("Объект сериализован");
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
				interval = getInterval(calcMod.LimitA, calcMod.LimitB, calcMod.getCsiI(), calcMod.Intervals);
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
			reverseProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(prog_data_file.CountCalcR) * 100.0 / Convert.ToDouble(prog_data_file.Count)));
			completeR = true;

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
				//interval = getInterval(calcMod.LimitA, calcMod.LimitB, calcMod.getCsiN(), calcMod.Intervals);
				prog_data_file.NeymanDict[calcMod.getCsiN()] += 1;
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

			for (Int64 i = prog_data_file.CountCalcM; i < prog_data_file.Count; i++)
			{
				if (metropolisBackgroundWorker.CancellationPending == true)
				{
					Console.WriteLine("break");
					pause = true;
					return;
				}
				if ((i % Math.Ceiling((double)prog_data_file.Count / (double)metropolisProgressBar.Maximum)) == 0)
				{
					metropolisBackgroundWorker.ReportProgress((int)((double)i * (double)metropolisProgressBar.Maximum / (double)prog_data_file.Count));
				}

				prog_data_file.MetropolisDict[calcMod.getCsiM()] += 1;
				prog_data_file.CountCalcM = i;
			}
			prog_data_file.CountCalcM += 1;
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
			calcMod.Lamda = prog_data_file.Lamda;
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
			metropolisProgressBar.Value = Convert.ToInt32(Math.Round( Convert.ToDouble(prog_data_file.CountCalcM) * 100.0 / Convert.ToDouble(prog_data_file.Count)));
			completeM = true;


		}

		private void WaiterBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!(completeA && completeR && completeN && completeM))
			{
				System.Threading.Thread.Sleep(100);
			}
			
		}
		private void fillInfoTable(DataFile df)
		{
			infoDataGridView.Rows.Clear();
			infoDataGridView.Rows.Add(df.Lamda, df.Lamda);
			infoDataGridView.Rows.Add(calcMod.mathExpectation(df.ReversDict), calcMod.dispersion(df.ReversDict));
			infoDataGridView.Rows.Add(calcMod.mathExpectation(df.NeymanDict), calcMod.dispersion(df.NeymanDict));
			infoDataGridView.Rows.Add(calcMod.mathExpectation(df.MetropolisDict), calcMod.dispersion(df.MetropolisDict));
			infoDataGridView.Rows[0].HeaderCell.Value = "A";
			infoDataGridView.Rows[1].HeaderCell.Value = "R";
			infoDataGridView.Rows[2].HeaderCell.Value = "N";
			infoDataGridView.Rows[3].HeaderCell.Value = "M";
		}
		private void WaiterBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			
			fillIntegralTableAllMeth(prog_data_file);
			drawAllMeth(prog_data_file);
			fillInfoTable(prog_data_file);

			filesDataGrid.Rows.Add(Path.GetFileNameWithoutExtension(prog_data_file.Path), prog_data_file.Count, prog_data_file.Lamda);
			filesDataGrid.Rows[filesDataGrid.Rows.Count - 1].Cells[0].ToolTipText = prog_data_file.Path;
			startButton.Enabled = true;
			pauseButton.Enabled = false;
			files.Add(prog_data_file.Clone());

			this.filesDataGrid.CurrentCell = this.filesDataGrid.Rows[this.filesDataGrid.Rows.Count - 1].Cells[0];
			
		}
	}
}
