using System;

namespace ACBrFramework.Sped
{
	public class Bloco9 : ACBrComposedComponent
	{
		#region Constructor

		internal Bloco9(ACBrSpedFiscal parent)
			: base(parent)
		{
			Registro9001 = new Registro9001();
			Registro9900 = new RegistroList<Registro9900>();
			Registro9990 = new Registro9990(parent);
			Registro9999 = new Registro9999(parent);
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_1_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_1_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_1_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_1_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_1_GetGravado);
			}
		}

		public Registro9001 Registro9001 { get; private set; }

		public RegistroList<Registro9900> Registro9900 { get; private set; }

		public Registro9990 Registro9990 { get; private set; }

		public Registro9999 Registro9999 { get; private set; }

		#endregion Properties
	}
}