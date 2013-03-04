using ACBrFramework;
using ACBrFramework.ECF;
using System;
using System.Windows.Forms;

namespace ACBrDefExporter
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			string path = @"c:\multivendas\arquivos";
			StubGenerator stub;
			
			stub = new StubGenerator(typeof(ACBrDevice), typeof(ACBrDeviceInterop), "DEV", path);
			stub.Generate();

			stub = new StubGenerator(typeof(ACBrECF), typeof(ACBrECFInterop), "ECF", path);
			stub.Generate();

			stub = new StubGenerator(typeof(ChaveEventArgs), path);
			stub.Generate();

			foreach (var type in typeof(ACBrECF).Assembly.GetTypes())
			{
				if (type.IsSubclassOf(typeof(Enum))) continue;
				if (type.IsNested) continue;
				if (type.Namespace != "ACBrFramework.ECF") continue;
				if (type.IsSubclassOf(typeof(ACBrInteropBase))) continue;

				stub = new StubGenerator(type, path);
				stub.Generate();
			}


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}