using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class Dest : ACBrComposedComponent
	{
		#region Constructor

		internal Dest(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.EnderDest = new EnderDest(parent, composedHandle);
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

		public string CNPJCPF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_GetCNPJCPF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_SetCNPJCPF, value);
			}
		}

		public string IE
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_GetIE);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_SetIE, value);
			}
		}

		public string ISUF
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_GetISUF);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_SetISUF, value);
			}
		}

		public string XNome
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_GetXNome);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_SetXNome, value);
			}
		}

		public string Email
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NFe_Dest_GetEmail);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NFe_Dest_SetEmail, value);
			}
		}

		public EnderDest EnderDest { get; private set; }

		#endregion Properties
	}
}