using System;

namespace ACBrFramework.AAC
{
	public sealed class AACECF
	{
		#region Properties

		public decimal ValorGT { get; set; }

		public string NumeroSerie { get; set; }

		public int CRO { get; set; }

		public int CNI { get; set; }

		public DateTime DtHrAtualizado { get; internal set; }

		#endregion Properties
	}
}