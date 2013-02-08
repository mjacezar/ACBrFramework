using System;

namespace ACBrFramework.Sped
{
	public class BlocoC : ACBrComposedComponent
	{
		#region Constructor

		internal BlocoC(ACBrSpedFiscal parent)
			: base(parent)
		{
			RegistroC001 = new RegistroC001();
			RegistroC990 = new RegistroC990(parent);
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_C_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_C_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_C_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_C_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_C_GetGravado);
			}
		}

		public RegistroC001 RegistroC001 { get; private set; }

		public RegistroC990 RegistroC990 { get; private set; }

		#endregion Properties
	}
}