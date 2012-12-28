using System;

namespace ACBrFramework.Sped
{
	public class Registro1100
	{
		#region Constructor

		public Registro1100()
		{
			this.Registro1105 = new RegistroList<Registro1105>();
		}

		#endregion Constructor

		#region Properties

		public TipoDocto IND_DOC { get; set; }

		public string NRO_DE { get; set; }

		public DateTime DT_DE { get; set; }

		public Exportacao NAT_EXP { get; set; }

		public string NRO_RE { get; set; }

		public DateTime DT_RE { get; set; }

		public string CHC_EMB { get; set; }

		public DateTime DT_CHC { get; set; }

		public DateTime DT_AVB { get; set; }

		public ConhecEmbarque TP_CHC { get; set; }

		public string PAIS { get; set; }

		public RegistroList<Registro1105> Registro1105 { get; private set; }

		#endregion Properties
	}
}