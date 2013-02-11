using System;

namespace ACBrFramework.Sped
{
	public class BlocoD : ACBrComposedComponent
	{
		#region Constructor

		internal BlocoD(ACBrSpedFiscal parent)
			: base(parent)
		{
			RegistroD001 = new RegistroD001();
			RegistroD990 = new RegistroD990(parent);
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_D_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_D_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_D_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_D_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_D_GetGravado);
			}
		}

		public RegistroD001 RegistroD001 { get; private	set; }

		public RegistroD990 RegistroD990 { get; private set; }

		#endregion Properties
	}
}