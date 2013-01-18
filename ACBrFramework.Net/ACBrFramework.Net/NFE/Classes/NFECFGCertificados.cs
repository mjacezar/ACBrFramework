using System;
using System.Text;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFECFGCertificados : ACBrComposedComponent
	{
		#region Constructor

		public NFECFGCertificados(ACBrNFE parent)
			: base(parent)
		{

		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public string Certificado
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Certificados_GetCertificado);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Certificados_SetCertificado, value);
			}
		}

		[Browsable(true)]
		public string Senha
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_CFG_Certificados_GetSenha);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_CFG_Certificados_SetSenha, value);
			}
		}

		#endregion Properties

		#region Methods

		#endregion Methods
	}
}