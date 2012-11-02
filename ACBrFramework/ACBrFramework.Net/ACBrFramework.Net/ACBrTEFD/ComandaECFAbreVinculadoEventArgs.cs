﻿using System;

namespace ACBrFramework.ACBrTEFD
{
	public class ComandaECFAbreVinculadoEventArgs : EventArgs
	{
		#region Constructor

		public ComandaECFAbreVinculadoEventArgs(string coo, string indiceECF, decimal valor)
		{
			this.COO = coo;
			this.IndiceECF = indiceECF;
			this.Valor = valor;
		}

		#endregion Constructor

		#region Properties

		public string COO { get; private set; }

		public string IndiceECF { get; private set; }

		public decimal Valor { get; private set; }

		public int RetornoECF { get; set; }

		#endregion Properties
	}
}