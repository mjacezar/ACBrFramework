using System;

namespace ACBrFramework.Sped
{
	public class BlocoE: ACBrComposedComponent
	{
		#region Constructor

		internal BlocoE(ACBrSpedFiscal parent) : base(parent)
		{
			RegistroE001 = new RegistroE001();
			RegistroE990 = new RegistroE990(parent);
		}
		
		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_E_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_E_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_E_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_E_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_E_GetGravado);
			}
		}

		public RegistroE001 RegistroE001 { get; private set; }

		public RegistroE990 RegistroE990 { get; private set; }

		#endregion Properties
	}
}