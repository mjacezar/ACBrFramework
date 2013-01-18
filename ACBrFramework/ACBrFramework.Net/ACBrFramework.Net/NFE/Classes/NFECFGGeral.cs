using System;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFECFGGeral : ACBrComposedComponent
	{
		#region Constructor

		public NFECFGGeral(ACBrNFE parent)
			: base(parent)
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public TipoEmissao FormaEmissao
		{
			get
			{
				return (TipoEmissao)GetInt32(ACBrNFEInterop.NFE_CFG_Geral_GetFormaEmissao);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_CFG_Geral_SetFormaEmissao, (int)value);
			}
		}

		[Browsable(true)]
		public int FormaEmissaoCodigo
		{
			get
			{
				return GetInt32(ACBrNFEInterop.NFE_CFG_Geral_GetFormaEmissaoCodigo);
			}
		}

		[Browsable(true)]
		public bool Salvar
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Geral_GetSalvar);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Geral_SetSalvar, value);
			}
		}

		[Browsable(true)]
		public bool AtualizarXMLCancelado
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Geral_GetAtualizarXMLCancelado);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Geral_SetAtualizarXMLCancelado, value);
			}
		}

		[Browsable(true)]
		public string PathSalvar
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Geral_GetPathSalvar);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Geral_SetPathSalvar, value);
			}
		}

		[Browsable(true)]
		public string PathSchemas
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Geral_GetPathSchemas);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Geral_SetPathSchemas, value);
			}
		}

		[Browsable(true)]
		public bool IniFinXMLSECAutomatico
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_CFG_Geral_GetIniFinXMLSECAutomatico);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_CFG_Geral_SetIniFinXMLSECAutomatico, value);
			}
		}

		#endregion Properties

		#region Methods

		public bool Save(string AXMLName, string AXMLFile, string aPath)
		{
			int ret = ACBrNFEInterop.NFE_CFG_Geral_Save(this.Handle, ToUTF8(AXMLName), ToUTF8(AXMLFile), ToUTF8(aPath));
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		#endregion Methods

	}
}