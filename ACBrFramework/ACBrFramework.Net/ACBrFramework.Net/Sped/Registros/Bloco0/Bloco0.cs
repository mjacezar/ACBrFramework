using System;

namespace ACBrFramework.Sped
{
	public class Bloco0 : ACBrComposedComponent
	{
		#region Constructor

		internal Bloco0(ACBrSpedFiscal parent)
			: base(parent)
		{
			Registro0000 = new Registro0000();
			Registro0001 = new Registro0001();
			Registro0990 = new Registro0990(parent);
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_0_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_0_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_0_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrSpedFiscalInterop.SPDF_Bloco_0_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrSpedFiscalInterop.SPDF_Bloco_0_GetGravado);
			}
		}

		public Registro0000 Registro0000 { get; set; }

		public Registro0001 Registro0001 { get; set; }

		public Registro0990 Registro0990 { get; private set; }

		#endregion Properties
	}
}