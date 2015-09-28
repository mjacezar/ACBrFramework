using System;

namespace ACBrFramework.LFD
{
	public class BlocoC : ACBrComposedComponent
	{
		#region Constructor

		internal BlocoC(ACBrLFD parent)
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
				return GetDateTime(ACBrLFDInterop.LFD_Bloco_C_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_Bloco_C_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrLFDInterop.LFD_Bloco_C_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_Bloco_C_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrLFDInterop.LFD_Bloco_C_GetGravado);
			}
		}

		public RegistroC001 RegistroC001 { get; private set; }

		public RegistroC990 RegistroC990 { get; private set; }

		#endregion Properties
	}
}