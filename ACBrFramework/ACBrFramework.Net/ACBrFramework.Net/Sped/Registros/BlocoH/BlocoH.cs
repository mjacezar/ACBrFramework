using System;

namespace ACBrFramework.Sped
{
	public class BlocoH: ACBrComposedComponent
	{
		#region Constructor

		internal BlocoH(ACBrSpedFiscal parent)
			: base(parent)
		{
			RegistroH001 = new RegistroH001();
			RegistroH990 = new RegistroH990(parent);
		}
		
		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_H_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_H_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_H_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_H_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_H_GetGravado);
			}
		}

		public RegistroH001 RegistroH001 { get; set; }

		public RegistroH990 RegistroH990 { get; set; }

		#endregion Properties
	}
}