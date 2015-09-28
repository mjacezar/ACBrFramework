using System;

namespace ACBrFramework.LFD
{
	public class BlocoA : ACBrComposedComponent
	{
		#region Constructor

		internal BlocoA(ACBrLFD parent)
			: base(parent)
		{
			RegistroA001 = new RegistroA001();
			RegistroA990 = new RegistroA990(parent);
		}

		#endregion Constructor

		#region Properties

		public DateTime DT_INI
		{
			get
			{
				return GetDateTime(ACBrLFDInterop.LFD_Bloco_A_GetDT_INI);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_Bloco_A_SetDT_INI, value);
			}
		}

		public DateTime DT_FIN
		{
			get
			{
				return GetDateTime(ACBrLFDInterop.LFD_Bloco_A_GetDT_FIN);
			}
			set
			{
				SetDateTime(ACBrLFDInterop.LFD_Bloco_A_SetDT_FIN, value);
			}
		}

		public bool Gravado
		{
			get
			{
				return GetBool(ACBrLFDInterop.LFD_Bloco_A_GetGravado);
			}
		}

		public RegistroA001 RegistroA001 { get; set; }

		public RegistroA990 RegistroA990 { get; private set; }

		#endregion Properties
	}
}