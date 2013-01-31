using System;
using System.Windows.Forms;

namespace ACBrFramework.ECFTeste
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			ACBrFramework.ECF.ACBrECF ecf = new ECF.ACBrECF();

			string x = ecf.About;
			Console.WriteLine(x);
			Console.ReadLine();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MainForm());
		}
	}
}