using System;
using System.Text;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFECFGArquivos : ACBrComposedComponent
	{
		#region Constructor

		public NFECFGArquivos(ACBrNFE parent)
			: base(parent)
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public bool AdicionarLiteral
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Arquivos_GetAdicionarLiteral);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Arquivos_SetAdicionarLiteral, value);
			}
		}

		[Browsable(true)]
		public bool EmissaoPathNFe
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Arquivos_GetEmissaoPathNFe);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Arquivos_SetEmissaoPathNFe, value);
			}
		}

		[Browsable(true)]
		public bool Salvar
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Arquivos_GetSalvar);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Arquivos_SetSalvar, value);
			}
		}

		[Browsable(true)]
		public bool PastaMensal
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Arquivos_GetPastaMensal);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Arquivos_SetPastaMensal, value);
			}
		}

		[Browsable(true)]
		public string PathNFe
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathNFe);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathNFe, value);
			}
		}

		[Browsable(true)]
		public string PathCan
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathCan);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathCan, value);
			}
		}

		[Browsable(true)]
		public string PathInu
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathInu);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathInu, value);
			}
		}

		[Browsable(true)]
		public string PathDPEC
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathDPEC);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathDPEC, value);
			}
		}

		[Browsable(true)]
		public string PathCCe
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathCCe);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathCCe, value);
			}
		}

		[Browsable(true)]
		public string PathMDe
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathMDe);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathMDe, value);
			}
		}

		[Browsable(true)]
		public string PathEvento
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_GetPathEvento);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Arquivos_SetPathEvento, value);
			}
		}

		#endregion Properties

		#region Methods

		public string GetPathCan()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathCan);
		}

		public string GetPathInu()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathInu);
		}

		public string GetPathDPEC()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathDPEC);
		}

		public string GetPathNFe(DateTime Data)
		{
			int bufferlen = 256;
			StringBuilder buffer = new StringBuilder(bufferlen);

			int ret = ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathNFe(this.Handle, Data.ToOADate(), buffer, bufferlen);

			return FromUTF8(buffer.ToString());
		}

		public string GetPathCCe()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathCCe);
		}

		public string GetPathMDe()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathMDe);
		}

		public string GetPathEvento()
		{
			return GetString(ACBrNFEInterop.NFE_CFG_Arquivos_FGetPathEvento);
		}

		#endregion Methods

	}
}