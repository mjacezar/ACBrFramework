using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.RFD
{
	public static class ACBrRFDInterop
	{
		#region DLL

#if x86
		private const string ACBr = "ACBrFramework32.dll";
#elif x64
				private const string ACBr = "ACBrFramework64.dll";
#endif

		#endregion DLL

		#region InteropTypes

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void OnCalcEADCallback(string Arquivo);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string OnCalcHashLogCallback(string Linha);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate string OnGetKeyCallback();

		#endregion InteropTypes

		#region ACBrRFD

		#region Propriedades Visiveis do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetDirRFD(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetDirRFD(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_CNPJ(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_CNPJ(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_COO(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_COO(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_IE(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_IE(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_IM(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_IM(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_Linha1(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_Linha1(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_Linha2(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_Linha2(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_NomeAplicativo(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_NomeAplicativo(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_VersaoAplicativo(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_VersaoAplicativo(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetSH_NumeroAplicativo(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetSH_NumeroAplicativo(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetIgnoraEcfMfd(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetIgnoraEcfMfd(IntPtr rfdHandle, bool value);
		

		#endregion Propriedades Visiveis do Componente

		#region Propriedades Não Visiveis do Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetAtivo(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetAtivo(IntPtr rfdHandle, bool value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetDiaMov(IntPtr rfdHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetDirECF(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetDirECFLog(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetDirECFMes(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetArqRFDID(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetArqRFD(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetArqReducaoZ(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetArqINI(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetECF_CROAtual(IntPtr rfdHandl);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetECF_CROAtual(IntPtr rfdHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetECF_RFDID(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetECF_RFDID(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetECF_DataHoraSwBasico(IntPtr rfdHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetECF_DataHoraSwBasico(IntPtr rfdHandle, double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetAtoCotepe(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetAtoCotepe(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_CNPJ(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_CNPJ(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_IE(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_IE(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_NumUsuario(IntPtr rfdHandle, ref int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_NumUsuario(IntPtr rfdHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_RazaoSocial(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_RazaoSocial(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_Endereco(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_Endereco(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_DataHoraCadastro(IntPtr rfdHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_DataHoraCadastro(IntPtr rfdHandle, double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_CROCadastro(IntPtr rfdHandle, ref int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_CROCadastro(IntPtr rfdHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetCONT_GTCadastro(IntPtr rfdHandle, ref double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetCONT_GTCadastro(IntPtr rfdHandle, double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetECF(IntPtr rfdHandle, IntPtr ecfHandle);

		#endregion Propriedades Não Visiveis do Componente

		#region Constructors/Erro Handler

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_Create(ref IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_Destroy(ref IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GetUltimoErro(IntPtr rfdHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructors/Erro Handler

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_Ativar(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_Desativar(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_VerificaParametros(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_AchaRFDID(IntPtr rfdHandle, string value, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_LerINI(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_GravarINI(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_CriarArqRFDID(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_NomeArqRFD(IntPtr rfdHandle, double value, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_AbreCupom(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_VendeItem(IntPtr rfdHandle, string codigo, string descricao, double Qtd, double ValorUnitario, string Unidade, double ValorDescAcres, string Aliquota);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SubTotalizaCupom(IntPtr rfdHandle, double value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_FechaCupom(IntPtr rfdHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_CancelaCupom(IntPtr rfdHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_CancelaItemVendido(IntPtr rfdHandle, int value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_ReducaoZ(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_Documento(IntPtr rfdHandle, string value);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_EfetuaPagamento(IntPtr rfdHandle, string descricao, double valor);

		#region Evento

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetOnCalcEAD(IntPtr rfdHandle, OnCalcEADCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetOnCalcHashLog(IntPtr rfdHandle, OnCalcHashLogCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetOnGetKeyHashLog(IntPtr rfdHandle, OnGetKeyCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int RFD_SetOnGetKeyRSA(IntPtr rfdHandle, OnGetKeyCallback method);

		#endregion Evento

		#endregion Methods

		#endregion ACBrRFD
	}
}