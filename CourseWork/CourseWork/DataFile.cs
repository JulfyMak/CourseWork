using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWork
{
	[Serializable]
	class DataFile 
	{
		private Int64 count_points = 0;
		private Int64 count_intervals = 0;
		private int count_calcA = 0;
		private Int64 count_calcR = 0;
		private Int64 count_calcN = 0;
		private Int64 count_calcM = 0;
		private double lamda = 0;
		private int a_limit = 0;
		private int b_limit = 20;
		private string file_path = "def";
		private Dictionary<double, double> analytic_arr=null;
		private Dictionary<double, double> revers_arr =null;
		private Dictionary<double, double> neyman_arr =null;
		private Dictionary<double, double> metropolis_arr = null;

		public DataFile() { }
		public DataFile Clone()
		{
			DataFile newDF = new DataFile();
			newDF.Count = count_points;
			newDF.Intervals = count_intervals;
			newDF.Lamda = lamda;
			newDF.LimitA = a_limit;
			newDF.LimitB = b_limit;
			newDF.Path = file_path;
			newDF.CountCalcA = count_calcA;
			newDF.CountCalcR = count_calcR;
			newDF.CountCalcN = count_calcN;
			newDF.CountCalcM = count_calcM;

			newDF.AnalyticDict = new Dictionary<double,double>( this.AnalyticDict);
			newDF.ReversDict = new Dictionary<double, double>(this.ReversDict);
			newDF.NeymanDict = new Dictionary<double, double>(this.NeymanDict);
			newDF.MetropolisDict = new Dictionary<double, double>(this.MetropolisDict);
			return newDF;
		}
		public Int64 Count
		{
			get { return count_points; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_points = value;
			}
		}
		public int CountCalcA
		{
			get { return count_calcA; }
			set
			{
				if (value < 0) throw new ArgumentException("Число должно быть положительным");
				count_calcA = value;
			}
		}
		public Int64 CountCalcR
		{
			get { return count_calcR; }
			set
			{
				if (value < 0) throw new ArgumentException("Число должно быть положительным");
				count_calcR = value;
			}
		}
		public Int64 CountCalcN
		{
			get { return count_calcN; }
			set
			{
				if (value < 0) throw new ArgumentException("Число должно быть положительным");
				count_calcN = value;
			}
		}
		public Int64 CountCalcM
		{
			get { return count_calcM; }
			set
			{
				if (value < 0) throw new ArgumentException("Число должно быть положительным");
				count_calcM = value;
			}
		}
		public Int64 Intervals
		{
			get { return count_intervals; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_intervals = value;
			}
		}
		public int LimitA
		{
			get { return a_limit; }
			set
			{
				a_limit = value;
			}
		}
		public int LimitB
		{
			get { return b_limit; }
			set
			{
				b_limit = value;
			}
		}
		public double Lamda
		{
			get { return lamda; }
			set
			{
				if (value < 0) throw new ArgumentException("Число должно быть >= 0");
				lamda = value;
			}
		}
		public string Path
		{
			get { return file_path; }
			set
			{
				file_path = value;
			}
		}
		public Dictionary<double, double> AnalyticDict
		{
			get {
				if (analytic_arr == null) return analytic_arr = new Dictionary<double, double>();
				else
				return analytic_arr;
			}
			set
			{
				//if () throw new ArgumentException("Число должно быть положительным");
				analytic_arr = value;
			}
		}
		public Dictionary<double, double> MetropolisDict
		{
			get
			{
				if (metropolis_arr == null) return metropolis_arr = new Dictionary<double, double>();
				else
					return metropolis_arr;
			}
			set
			{
				//if () throw new ArgumentException("Число должно быть положительным");
				metropolis_arr = value;
			}
		}
		public Dictionary<double, double> ReversDict
		{
			get {
				if (revers_arr == null) return revers_arr = new Dictionary<double, double>();
				else
					return revers_arr;
			}
			set
			{
				//if () throw new ArgumentException("Число должно быть положительным");
				revers_arr = value;
			}
		}
		public Dictionary<double, double> NeymanDict
		{
			get {
				if (neyman_arr == null) return neyman_arr = new Dictionary<double, double>();
				return neyman_arr;
			}
			set
			{
				//if () throw new ArgumentException("Число должно быть положительным");
				neyman_arr = value;
			}
		}
	}
}
