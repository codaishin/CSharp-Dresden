using System;

namespace BreakPoints
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] a = new int[] { 1, 2, 3, };
			a[10] = 5;

      /* Set breakpoint in line 11 and run via
         Top Menu -> Run -> Stat Debugging */
      /* Only works when this project is root of the VSCode Workspace */
		}
	}
}
