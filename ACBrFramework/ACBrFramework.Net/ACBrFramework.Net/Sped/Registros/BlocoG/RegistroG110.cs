namespace ACBrFramework.Sped
{
	public class RegistroG110
	{
		#region Constructor

		public RegistroG110()
		{
			RegistroG125 = new RegistroList<RegistroG125>();
		}

		#endregion Constructor

		#region Properties

		public string MODO_CIAP { get; set; }  /// Até versão 102

		public decimal SALDO_IN_ICMS { get; set; }

		public decimal SALDO_FN_ICMS { get; set; } /// Até versão 102

		public decimal SOM_PARC { get; set; }

		public decimal VL_TRIB_EXP { get; set; }

		public decimal VL_TOTAL { get; set; }

		public decimal IND_PER_SAI { get; set; } /// Foi renomeado na versão 103

		public decimal ICMS_APROP { get; set; }

		public decimal SOM_ICMS_OC { get; set; }

		public RegistroList<RegistroG125> RegistroG125 { get; private set; }

		#endregion Properties
	}
}