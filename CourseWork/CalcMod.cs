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
		private double d1_coef = 0;
		private double d2_coef = 0;
		private double xp = 0;
		private double a_limit = 0;
		private double b_limit = 1;
		private int count_interv = 0;
		private Random rnd = new Random();
		private double max_val = 0;

		

		public Dictionary<double, double> table = new Dictionary<double, double>();

		public Int64 CountPoints
		{
			get { return count_points; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_points = value;
			}
		}
		public int Intervals
		{
			get { return count_interv; }
			set
			{
				if (value <= 0) throw new ArgumentException("Число должно быть положительным");
				count_interv = value;
			}
		}

		public double LimitA
		{
			get { return a_limit; }
			set
			{
				a_limit = value;
			}
		}
		public double LimitB
		{
			get { return b_limit; }
			set
			{
				b_limit = value;
			}
		}

		public double PrevX
		{
			get { return xp; }
			set
			{
				xp = value;
			}
		}

		public double D2_coef { get => d2_coef; set => d2_coef = value; }
		public double D1_coef { get => d1_coef; set => d1_coef = value; }

		private void recalcMaxVal()
		{
			double max = 0;
			double fx = 0;
			double step = (b_limit - a_limit) / (double)count_interv;
			for (int i = 0; i < count_interv; i++)
			{
				fx = ((double)i) * step;
				if(!Double.IsInfinity(analyticFunc(fx)))
				if (analyticFunc(fx) > max) max = analyticFunc(fx);
			}
			max_val = max;
		}
		public double analyticFunc(double x)
		{
			//SpecialFunction.acosh
			double d1 = Convert.ToDouble(d1_coef), d2 = Convert.ToDouble(d2_coef);
			return (Meta.Numerics.Functions.AdvancedMath.Gamma((d1 + d2) / 2.0) * Math.Pow(d1 / d2, d1 / 2.0) * Math.Pow(x, d1 / 2.0 - 1.0)) / (Meta.Numerics.Functions.AdvancedMath.Gamma(d1 / 2.0) * Meta.Numerics.Functions.AdvancedMath.Gamma(d2 / 2.0) * Math.Pow((d1 / d2) * x + 1.0, (d1 + d2) / 2.0));
			//return Math.Sqrt(2.0 / Math.PI) * (Math.Pow(x, 2) * Math.Exp((-1.0) * Math.Pow(x, 2) / (2.0 * Math.Pow(D1_coef, 2.0)))/Math.Pow(D1_coef,3.0));
		}

		public double CDF(double x)
		{
			//SpecialFunctions.gamma
			double d1 = Convert.ToDouble(d1_coef), d2 = Convert.ToDouble(d2_coef);
			//if (x == 0) return 0;
			//else
			return SpecialFunctions.BetaRegularized(d1 / 2.0, d2 / 2.0, (d1*x) / (d1 * x + d2));
			//return SpecialFunctions.Erf(x / (Math.Sqrt(2.0) * D1_coef)) - Math.Sqrt(2.0 / Math.PI) * (x * Math.Exp((-1.0) * Math.Pow(x, 2) / (2.0 * Math.Pow(D1_coef, 2.0))) / D1_coef);
		}

		public void fillTable()
		{
			table.Clear();
			double step = (b_limit- a_limit) / (double)count_interv;
			double fx = 0;
			for(Int64 i = 0; i <= count_interv; i++)
			{
				fx = a_limit+Convert.ToDouble(i) * step;
				table.Add(fx, CDF(fx));
				//Console.WriteLine("x " + fx + " cdf " + CDF(fx));
			}
			
			//Console.WriteLine("x " + 5 + " cdf " + CDF(5));
		}

		public double getCsiR()
		{
			
			double gamma = rnd.NextDouble();
			Int64 i = 0;
			for ( i = 0; i < table.Count; i++)
			{
				if (table.Values.ToArray()[i] > gamma)
				{
					//Console.WriteLine("val " + table.Values.ToArray()[i] + " rnd1 " + gamma);
					return table.Keys.ToArray()[i];
				}
			}
			//Console.WriteLine("val " + (i-1) + " rnd2 " + gamma);
			return table.Count-1;
		}

		public double getCsiN()
		{
			//double res = 0;
			//Console.WriteLine("in Neyman");
			//rnd = new Random();
			recalcMaxVal();
			//Console.WriteLine("lims "+LimitB + LimitA);
			double xi = 0;
			double yi = 0;
			double fx = 0;
			double rn = 0;
			for (int i=0; i<1000;i++)
			{
				rn = rnd.NextDouble();
				//if (rn == 0) rnd = new Random();
				xi = LimitA + (LimitB - LimitA) * rnd.NextDouble();
				yi = max_val * rnd.NextDouble();
				fx = analyticFunc(xi);
				//Console.WriteLine("xi " + xi + " yi " + yi + " fx " + fx);
				if (!Double.IsInfinity(fx))
				{
					//Console.WriteLine(rn);
					if (fx > yi) return xi;
				}
				//else rnd = new Random();
				//else Console.WriteLine(rn);

			}
			return rnd.NextDouble();
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
				res.Add(a + Convert.ToDouble(i) * step-step/2.0, arr[arr.Keys.ToArray()[i]]);
			}
			return res;
		}

		public double getCsiM()
		{
			double res = 0;
			//double xp=(LimitB-LimitA)/2.0;
			//double xp = LimitA+ (LimitB - LimitA)*rnd.NextDouble();
			double xn = 0;
			double fn = 0;
			double fp = 0;
			//double delta = (LimitB - LimitA) / 4.0;
			double delta = LimitA + (LimitB - LimitA)/5.0;
			double rndNum = 0;
			rndNum = rnd.NextDouble();
			while (rndNum == 0)
			{
				rnd = new Random();
				rndNum = rnd.NextDouble();
			}
			xn = xp + delta * (2.0 * rndNum - 1.0);
			fn = analyticFunc(xn);
			fp = analyticFunc(xp);

			if (fn / fp >= 1.0) res = xn;
			else
			if (fn / fp > rnd.NextDouble()) res = xn;
			else res = xp;

			if (res < LimitA || res > LimitB)  res=xp;
			xp = res;
			return res;
		}

		public double mathExpectation(Dictionary<double, double> arr)
		{
			Dictionary<double, double> tmp_arr = new Dictionary<double, double>(arr);
			double sum = 0;
			for (int i = 0; i < tmp_arr.Count; i++)
			{
				sum += tmp_arr.Keys.ToArray()[i] * tmp_arr.Values.ToArray()[i];
			}
			return sum;
		}
		public double dispersion(Dictionary<double, double> arr)
		{
			Dictionary<double, double> tmp_arr = new Dictionary<double, double>(arr);
			double mathEx = mathExpectation(arr);
			double sum = 0;
			for (int i = 0; i < tmp_arr.Count; i++)
			{
				sum += tmp_arr.Values.ToArray()[i] * Math.Pow(tmp_arr.Keys.ToArray()[i] - mathEx, 2);
			}
			return sum;
		}
	}
}
