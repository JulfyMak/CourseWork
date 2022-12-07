using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWork
{
	class CalcMod
	{
		private Int64 count_points = 0;
		private double lamda = 0;
		private double b_сoef = 0;
		private int a_limit = 0;
		private int b_limit = 20;
		private Int64 count_interv = 0;
		private Random rnd = new Random();
		private double max_val = 0;

		private int xp = 0;
		

		public Dictionary<int, double> table = new Dictionary<int, double>();

		public Int64 CountPoints
		{
			get { return count_points; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_points = value;
			}
		}
		public Int64 Intervals
		{
			get { return count_interv; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_interv = value;
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

		public int PrevX
		{
			get { return xp; }
			set
			{
				xp = value;
			}
		}

		private void recalcMaxVal()
		{
			double max = 0;
			double fx = 0;
			//double step = (b_limit - a_limit) / (double)count_interv;
			for (int i = 0; i <= Intervals; i++)
			{
				//fx = ((double)i) * step;
				//if(!Double.IsInfinity(analyticFunc(fx)))
				if (analyticFunc(i) > max) max = analyticFunc(i);
			}
			max_val = max;
		}
		public double analyticFunc(int x)
		{
			//SpecialFunction.acosh

			return Math.Exp(-Lamda) * Math.Pow(Lamda, x) / SpecialFunctions.Factorial(x);
		}

		public double CDF(int x)
		{
			//SpecialFunctions.gamma

			return SpecialFunctions.GammaUpperIncomplete(x + 1, Lamda) / SpecialFunctions.Factorial(x);
		}

		public void fillTable()
		{
			table.Clear();
			//double step = (b_limit- a_limit) / (double)count_interv;
			//double fx = 0;
			for(int i = 0; i <= count_interv; i++)
			{
				//fx = a_limit+Convert.ToDouble(i) * step;
				table.Add(i, CDF(i));
				//Console.WriteLine("x " + i + " cdf " + CDF(i));
			}
		}

		public int getCsiI()
		{

			double rndNum = rnd.NextDouble();
			int i = 0;
			double sum = analyticFunc(0);
			for ( i = 0; i <= Intervals; i++)
			{
				if (table.Values.ToArray()[i] >= rndNum)
				{
					//Console.WriteLine("val " + table.Values.ToArray()[i] + " rnd1 " + gamma);
					return table.Keys.ToArray()[i];
				}
			}
			//Console.WriteLine("val " + (i-1) + " rnd2 " + gamma);
			return i-1;
		}

		public int getCsiN()
		{
			recalcMaxVal();
			int xi = 0;
			double yi = 0;
			double fx = 0;
			double rn = 0;
			for (int i = 0; i < 1000; i++)
			{
				rn = rnd.NextDouble();
				if (rn == 0) rnd = new Random();
				xi = Convert.ToInt32(Math.Round(( LimitA + (LimitB - LimitA) * rnd.NextDouble())));
				yi = max_val * rnd.NextDouble();
				fx = analyticFunc(xi);

				if (fx > yi) return xi;


			}
			return Convert.ToInt32(Math.Round((LimitA + (LimitB - LimitA) * rnd.NextDouble())));
		}
		public int getCsiM()
		{
			int res = 0;

			int xn = 0;
			double fn = 0;
			double fp = 0;
			int delta = Convert.ToInt32(Math.Round(LimitA + (LimitB - LimitA) / 20.0));;
			double rndNum = 0;


			rndNum = rnd.NextDouble();
			if (rndNum == 0)
			{
				rnd = new Random();
				rndNum = rnd.NextDouble();
			}

			xn = xp + Convert.ToInt32(Math.Round(Convert.ToDouble(delta) * (2.0 * rndNum - 1.0)));
			while (xn < 0)
			{
				rndNum = rnd.NextDouble();
				if (rndNum == 0)
				{
					rnd = new Random();
					rndNum = rnd.NextDouble();
				}
				xn = xp + Convert.ToInt32(Math.Round(Convert.ToDouble(delta) * (2.0 * rndNum - 1.0)));
			}

			fn = analyticFunc(xn);
			fp = analyticFunc(xp);

			if (fn / fp >= 1.0) res = xn;
			else
			{
				rndNum = rnd.NextDouble();
				if (rndNum == 0)
				{
					rnd = new Random();
					rndNum = rnd.NextDouble();
				}

				if (fn / fp > rndNum) res = xn;
				else res = xp;
			}
			if (xn < LimitA || xn > LimitB)
				res = xp;
			xp = res;

			return res;
		}
		public Dictionary<double, double> normalizeY(Dictionary<double, double> arr)
		{
			//double max = arr.Values.Max();
			double max = arr.Values.Sum();
			for (int i = 0; i < arr.Count; i++)
			{
				arr[arr.Keys.ToArray()[i]] /= max;
			}
			return arr;
		}

		public Dictionary<double, double> normalizeX(Dictionary<double, double> arr, double a, double b)
		{
			Dictionary<double, double> res = new Dictionary<double, double>();
			double step = (b - a) / Convert.ToDouble(arr.Count - 1);
			for (int i = 0; i < arr.Count; i++)
			{
				res.Add(a + Convert.ToDouble(i) * step, arr[arr.Keys.ToArray()[i]]);
			}
			return res;
		}

		public double mathExpectation(Dictionary<double, double> arr)
		{
			Dictionary<double, double> tmp_arr = new Dictionary<double, double>(arr);
			tmp_arr = normalizeY(tmp_arr);
			double sum = 0;
			for (int i = 0; i < tmp_arr.Count; i++)
			{
				sum += Convert.ToDouble(i) * tmp_arr.Values.ToArray()[i];
			}
			return sum;
		}
		public double dispersion(Dictionary<double, double> arr)
		{
			Dictionary<double, double> tmp_arr = new Dictionary<double, double>(arr);
			tmp_arr = normalizeY(tmp_arr);
			double mathEx = mathExpectation(arr);
			double sum = 0;
			for (int i = 0; i < tmp_arr.Count; i++)
			{
				sum += tmp_arr.Values.ToArray()[i]*Math.Pow(tmp_arr.Keys.ToArray()[i]-mathEx,2);
			}
			return sum;
		}
	}
}
