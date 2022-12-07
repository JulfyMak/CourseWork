using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CourseWork
{
	class Fortran
	{

		[DllImport("Normal.dll", EntryPoint = "__normal_MOD_var1", CallingConvention = CallingConvention.Cdecl)]
		public static extern float Normal_var1();

		[DllImport("Normal.dll", EntryPoint = "__normal_MOD_var1", CallingConvention = CallingConvention.Cdecl)]
		public static extern float Normal_var2();

		public static float func1()
		{
			return Normal_var1();
		}

		public static float func2()
		{
			return Normal_var2();
		}
	}
}
