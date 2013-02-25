using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class NotaFiscal : ACBrComposedComponent
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NotaFiscal(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			
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

		public NFE NFe
		{
			get
			{
				IntPtr nfeHandle;
				int ret = ACBrNFEInterop.NFE_NF_GetNFe(this.Handle, ComposedHandle, out nfeHandle);
				CheckResult(ret);

				return new NFE(this.Parent, nfeHandle);
			}
		}

		public string Alertas
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NF_GetAlertas);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NF_SetAlertas, value);
			}
		}

		public string XML
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NF_GetXML);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NF_SetXML, value);
			}
		}

		public string Msg
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NF_GetMsg);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NF_SetMsg, value);
			}
		}

		public string NomeArq
		{
			get
			{
				return GetString(ACBrNFEInterop.NFE_NF_GetNomeArq);
			}
			set
			{
				SetString(ACBrNFEInterop.NFE_NF_SetNomeArq, value);
			}
		}

		public bool Confirmada
		{
			get
			{
				return GetBool(ACBrNFEInterop.NFE_NF_GetConfirmada);
			}
			set
			{
				SetBool(ACBrNFEInterop.NFE_NF_SetConfirmada, value);
			}
		}

		#endregion Properties

		#region Methods

		public void Imprimir()
		{
			int ret = ACBrNFEInterop.NFE_NF_Imprimir(this.Handle, this.ComposedHandle);
			CheckResult(ret);
		}

		public void ImprimirPDF()
		{
			int ret = ACBrNFEInterop.NFE_NF_ImprimirPDF(this.Handle, this.ComposedHandle);
			CheckResult(ret);
		}

		public bool SaveToFile(string arquivo, bool TXT = false)
		{
			int ret = ACBrNFEInterop.NFE_NF_SaveToFile(this.Handle, this.ComposedHandle, ToUTF8(arquivo), TXT);
			CheckResult(ret);

			return Convert.ToBoolean(ret);
		}

		public void EnviarEmail(string sSmtpHost, string sSmtpPort, string sSmtpUser, string sSmtpPasswd,
			        string sFrom, string sTo, string sAssunto, string[] sMensagem, bool SSL, bool EnviaPDF = true,
			        string[] sCC = null, string[] sAnexos = null, bool PedeConfirma = false, 
			        bool AguardarEnvio = false, string NomeRemetente = "", bool TLS = true, bool UsarThread = true)
		{
			int ret = ACBrNFEInterop.NFE_NF_EnviarEmail(this.Handle, this.ComposedHandle, ToUTF8(sSmtpHost),
			                    ToUTF8(sSmtpPort), ToUTF8(sSmtpUser), ToUTF8(sSmtpPasswd), ToUTF8(sFrom), ToUTF8(sTo),
								ToUTF8(sAssunto), ToUTF8(sMensagem), sMensagem.Length, SSL,
								EnviaPDF, ToUTF8(sCC), sCC == null ? 0 : sCC.Length, ToUTF8(sAnexos), sAnexos == null ? 0 : sAnexos.Length,
                                PedeConfirma, AguardarEnvio, ToUTF8(NomeRemetente), TLS, UsarThread);

			CheckResult(ret);
		}

		#endregion Methods
	}
}