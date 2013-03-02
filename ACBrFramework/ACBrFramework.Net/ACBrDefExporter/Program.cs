﻿using System;
using System.Windows.Forms;

namespace ACBrDefExporter
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			string path = @"c:\multivendas\arquivos";
			StubGenerator stub = new StubGenerator(typeof(ACBrFramework.ECF.ACBrECF), "ECF", path);
			stub.Generate();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}