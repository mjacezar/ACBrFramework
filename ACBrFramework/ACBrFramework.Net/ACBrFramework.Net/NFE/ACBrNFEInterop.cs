using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.NFE
{
	public static class ACBrNFEInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region ACBrNFE

		#region Interop Types


		#endregion Interop Types

		#region Propriedades do Componente

		#region Configuracao Geral

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetFormaEmissao(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetFormaEmissao(IntPtr nfeHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetFormaEmissaoCodigo(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetSalvar(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetSalvar(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetAtualizarXMLCancelado(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetAtualizarXMLCancelado(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetPathSalvar(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetPathSalvar(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetPathSchemas(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetPathSchemas(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_GetIniFinXMLSECAutomatico(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_SetIniFinXMLSECAutomatico(IntPtr nfeHandle, bool value);

		#endregion Configuracao Geral

		#region Configuracao Arquivos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetAdicionarLiteral(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetAdicionarLiteral(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetEmissaoPathNFe(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetEmissaoPathNFe(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetSalvar(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetSalvar(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPastaMensal(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPastaMensal(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathNFe(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathNFe(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathCan(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathCan(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathInu(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathInu(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathDPEC(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathDPEC(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathCCe(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathCCe(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathMDe(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathMDe(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_GetPathEvento(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_SetPathEvento(IntPtr nfeHandle, string value);

		#endregion Configuracao Arquivos

		#region Configuracao Certificados

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Certificados_GetCertificado(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Certificados_SetCertificado(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Certificados_GetSenha(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Certificados_SetSenha(IntPtr nfeHandle, string value);

		#endregion Configuracao Certificados

		#region Configuracao WebServices

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetVisualizar(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetVisualizar(IntPtr nfeHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetUF(IntPtr nfeHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetUF(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetUFCodigo(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetAmbiente(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetAmbiente(IntPtr nfeHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetAmbienteCodigo(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetProxyHost(IntPtr nfeHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetProxyHost(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetProxyPort(IntPtr nfeHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetProxyPort(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetProxyUser(IntPtr nfeHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetProxyUser(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetProxyPass(IntPtr nfeHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetProxyPass(IntPtr nfeHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetAguardarConsultaRet(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetAguardarConsultaRet(IntPtr nfeHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetTentativas(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetTentativas(IntPtr nfeHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_GetAjustaAguardaConsultaRet(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_WebServices_SetAjustaAguardaConsultaRet(IntPtr nfeHandle, bool value);

		#endregion Configuracao WebServices

		#region NotasFiscais

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_GetItem(IntPtr nfeHandle, out IntPtr nfsHandle, int idx);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_SetItem(IntPtr nfeHandle, IntPtr nfsHandle, int idx);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Count(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_GetNamePath(IntPtr nfeHandle, StringBuilder buffer, int buferlen);

		#endregion NotasFiscais

		#region Nota Fiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetNFe(IntPtr nfeHandle, IntPtr nfHandle, out IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetAlertas(IntPtr nfeHandle, IntPtr nfHandle , StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SetAlertas(IntPtr nfeHandle, IntPtr nfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetXML(IntPtr nfeHandle, IntPtr nfHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SetXML(IntPtr nfeHandle, IntPtr nfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetMsg(IntPtr nfeHandle, IntPtr nfHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SetMsg(IntPtr nfeHandle, IntPtr nfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetNomeArq(IntPtr nfeHandle, IntPtr nfHandle, StringBuilder buffer, int bufferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SetNomeArq(IntPtr nfeHandle, IntPtr nfHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_GetConfirmada(IntPtr nfeHandle, IntPtr nfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SetConfirmada(IntPtr nfeHandle, IntPtr nfHandle, bool value);

		#endregion Nota Fiscal

		#endregion Propriedades do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_Create(ref IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_Destroy(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_GetUltimoErro(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		#region Configuracao Geral

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Geral_Save(IntPtr nfeHandle, string AXMLName, string AXMLFile, string aPath);

		#endregion Configuracao Geral

		#region Configuracao Arquivos

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathCan(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathInu(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathDPEC(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathNFe(IntPtr nfeHandle, double value, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathCCe(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathMDe(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_CFG_Arquivos_FGetPathEvento(IntPtr nfeHandle, StringBuilder buffer, int bufferLen);

		#endregion Configuracao Arquivos

		#region NotasFiscais

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Add(IntPtr nfeHandle, out IntPtr nfsHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Insert(IntPtr nfeHandle, out IntPtr nfsHandle, int idx);		

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Clear(IntPtr nfeHandle);		

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Assinar(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_GerarNFe(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Valida(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_ValidaAssinatura(IntPtr nfeHandle, StringBuilder buffer, int buferlen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_Imprimir(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_ImprimirPDF(IntPtr nfeHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_LoadFromFile(IntPtr nfeHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_LoadFromString(IntPtr nfeHandle, string arquivo);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_SaveToFile(IntPtr nfeHandle, string arquivo, bool txt);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NotasFiscais_SaveToTXT(IntPtr nfeHandle, string arquivo);

		#endregion NotasFiscais

		#region Nota Fiscal

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_Imprimir(IntPtr nfeHandle, IntPtr nfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_ImprimirPDF(IntPtr nfeHandle, IntPtr nfHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_SaveToFile(IntPtr nfeHandle, IntPtr nfHandle, string arquivo , bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NFE_NF_EnviarEmail(IntPtr nfeHandle, IntPtr nfHandle, string sSmtpHost,
			                    string sSmtpPort, string sSmtpUser, string sSmtpPasswd, string sFrom, string sTo,
								string sAssunto, string[] sMensagem, int szMensagem, bool SSL,
								bool EnviaPDF, string[] sCC, int szCC, string[] sAnexos, int szAnexos,
                                bool PedeConfirma, bool AguardarEnvio, string NomeRemetente, bool TLS,
								bool UsarThread);

		#endregion Nota Fiscal

		#endregion Methods

		#endregion ACBrNFE
	}
}