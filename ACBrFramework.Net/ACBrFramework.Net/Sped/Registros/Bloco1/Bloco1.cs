using System;

namespace ACBrFramework.Sped
{
	public class Bloco1 : ACBrComposedComponent
	{
		#region Constructor

		internal Bloco1(ACBrSpedFiscal parent) : base(parent)
		{
			Registro1001 = new Registro1001();
			Registro1990 = new Registro1990(parent);
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

		public Registro1001 Registro1001 { get; set; }

		public Registro1990 Registro1990 { get; private set; }

		#endregion Properties
	}
}