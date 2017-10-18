using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ZedGraphSample
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
		    //LoadPointsHelper.GetPointPairList(@"‪E:\22.txt");
			Application.Run( new cht_lfa_boys_p_0_2_Form() );
		}
	}
}