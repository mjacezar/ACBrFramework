using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Emit : ACBrComposedComponent
	{
		#region Constructor

		internal Emit(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.EnderEmit = new EnderEmit(parent, composedHandle);
		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public string CNAE
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetCNAE);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetCNAE, value);
			}
		}

		public string CNPJCPF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetCNPJCPF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetCNPJCPF, value);
			}
		}

		public string IE
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetIE);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetIE, value);
			}
		}

		public string IEST
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetIEST);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetIEST, value);
			}
		}

		public string IM
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetIM);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetIM, value);
			}
		}

		public string xFant
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetxFant);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetxFant, value);
			}
		}

		public string xNome
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Emit_GetxNome);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Emit_SetxNome, value);
			}
		}

		public CRT CRT
		{
			get
			{
				return (CRT)GetInt32(ACBrNFEInterop.NFE_NFe_Emit_GetCRT);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Emit_SetCRT, (int)value);
			}
		}

		public EnderEmit EnderEmit { get; private set; }

		#endregion Properties
	}
}