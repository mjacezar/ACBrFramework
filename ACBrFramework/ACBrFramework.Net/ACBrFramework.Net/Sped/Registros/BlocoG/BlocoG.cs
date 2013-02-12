using System;

namespace ACBrFramework.Sped
{
	public class BlocoG: ACBrComposedComponent
	{
		#region Constructor

		internal BlocoG(ACBrSpedFiscal parent)
			: base(parent)
		{
			RegistroG001 = new RegistroG001();
			RegistroG990 = new RegistroG990(parent);
		}
		
		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_G_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_G_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_G_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_G_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_G_GetGravado);
			}
		}

		public RegistroG001 RegistroG001 { get; set; }

		public RegistroG990 RegistroG990 { get; set; }

		#endregion Properties
	}
}