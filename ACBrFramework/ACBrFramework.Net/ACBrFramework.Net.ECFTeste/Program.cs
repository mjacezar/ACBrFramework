using System;
using System.Windows.Forms;

namespace ACBrFramework.ECFTeste
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{

			//acbrAAC.Chave = aacChaveTextBox.Text;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}