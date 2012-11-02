using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.ACBrTEFD
{
	public static class ACBrTEFInterop
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
		public delegate void AguardaRespCallback(string Arquivo, int SegundosTimeOut, ref bool Interromper);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ExibeMsgCallback(ACBrTEFDOperacaoMensagem Operacao, string Mensagem, ref ModalResult AModalResult);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void BloqueiaMouseTecladoCallback(bool Bloqueia, ref bool Tratado);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ExecutaAcaoCallback(ref bool Tratado);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFCallback(ACBrTEFDOperacaoECF Operacao, IntPtr Resp, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFSubtotalizaCallback(double DescAcre, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFPagamentoCallback(string IndiceECF, double Valor, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFImprimeViaCallback(ACBrTEFDTipoRelatorio TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void InfoECFCallback(ACBrTEFDInfoECF Operacao, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AntesFinalizarRequisicaoCallback(IntPtr Req);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DepoisConfirmarTransacoesCallback(IntPtr RespostasPendentes);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AntesCancelarTransacaoCallback(IntPtr RespostaPendente);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DepoisCancelarTransacoesCallback(IntPtr RespostasPendentes);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MudaEstadoReqCallback(ACBrTEFDReqEstado EstadoReq);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MudaEstadoRespCallback(ACBrTEFDRespEstado EstadoResp);

		#endregion InteropTypes

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Create(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Destroy(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetUltimoErro(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnAguardaResp(IntPtr tefHandler, AguardaRespCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnExibeMsg(IntPtr tefHandler, ExibeMsgCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnBloqueiaMouseTeclado(IntPtr tefHandler, BloqueiaMouseTecladoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnRestauraFocoAplicacao(IntPtr tefHandler, ExecutaAcaoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnLimpaTeclado(IntPtr tefHandler, ExecutaAcaoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnComandaECF(IntPtr tefHandler, ComandaECFCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnComandaECFSubtotaliza(IntPtr tefHandler, ComandaECFSubtotalizaCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnComandaECFPagamento(IntPtr tefHandler, ComandaECFPagamentoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnComandaECFAbreVinculado(IntPtr tefHandler, ComandaECFAbreVinculadoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnComandaECFImprimeVia(IntPtr tefHandler, ComandaECFImprimeViaCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnInfoECF(IntPtr tefHandler, InfoECFCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnAntesFinalizarRequisicao(IntPtr tefHandler, AntesFinalizarRequisicaoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnDepoisConfirmarTransacoes(IntPtr tefHandler, DepoisConfirmarTransacoesCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnAntesCancelarTransacao(IntPtr tefHandler, AntesCancelarTransacaoCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnDepoisCancelarTransacoes(IntPtr tefHandler, DepoisCancelarTransacoesCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnMudaEstadoReq(IntPtr tefHandler, MudaEstadoReqCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetOnMudaEstadoResp(IntPtr tefHandler, MudaEstadoRespCallback method);

		#endregion Methods
	}
}