using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACBrFramework.TEFD
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
		public delegate void ComandaECFCallback(ACBrTEFDOperacaoECF Operacao, IntPtr Resp, ref RetornoECF RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFSubtotalizaCallback(double DescAcre, ref RetornoECF RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFPagamentoCallback(string IndiceECF, double Valor, ref RetornoECF RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref RetornoECF RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFImprimeViaCallback(ACBrTEFDTipoRelatorio TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref RetornoECF RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void InfoECFCallback(ACBrTEFDInfoECF Operacao, StringBuilder RetornoECF, int RetornoECFLen);

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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFCliSiTefExibeMenuCallback(string Titulo, IntPtr Opcoes, int OpcoesCount, ref int ItemSelecionado, ref bool VoltarMenu);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFCliSiTefObtemCampoCalback(string Titulo, int TamanhoMinimo, int TamanhoMaximo, int TipoCampo, ACBrTEFDCliSiTefOperacaoCampo Operacao, StringBuilder Resposta, int RespLen, ref bool Digitado, ref bool VoltarMenu);

		#endregion InteropTypes

		#region Methods

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Create(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Destroy(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetUltimoErro(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Inicializar(IntPtr tefHandle, int gp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_CRT(IntPtr tefHandle, double Valor, string IndiceFPG_ECF, string DocumentoVinculado, int Moeda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetGPAtual(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetGPAtual(IntPtr tefHandle, int gp);

		#region Identificacao

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_GetNomeAplicacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_SetNomeAplicacao(IntPtr tefHandle, String NomeAplicacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_GetVersaoAplicacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_SetVersaoAplicacao(IntPtr tefHandle, String VersaoAplicacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_GetSoftwareHouse(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_SetSoftwareHouse(IntPtr tefHandle, String SoftwareHouse);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_GetRazaoSocial(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Identificacao_SetRazaoSocial(IntPtr tefHandle, String RazaoSocial);

		#endregion Identificacao

		#region TEFCliSiTef

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetEnderecoIP(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetEnderecoIP(IntPtr tefHandle, String EnderecoIP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetCodigoLoja(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetCodigoLoja(IntPtr tefHandle, String CodigoLoja);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetNumeroTerminal(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetNumeroTerminal(IntPtr tefHandle, String NumeroTerminal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperador(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperador(IntPtr tefHandle, String Operador);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetRestricoes(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetRestricoes(IntPtr tefHandle, String Restricoes);

		//Function TEF_TEFCliSiTef_GetParametrosAdicionais
		//Function TEF_TEFCliSiTef_SetParametrosAdicionais

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoATV(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoATV(IntPtr tefHandle, int OperacaoATV);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoADM(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoADM(IntPtr tefHandle, int OperacaoADM);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoCRT(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoCRT(IntPtr tefHandle, int OperacaoCRT);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoCHQ(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoCHQ(IntPtr tefHandle, int OperacaoCHQ);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoCNC(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoCNC(IntPtr tefHandle, int OperacaoCNC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetOperacaoReImpressao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOperacaoReImpressao(IntPtr tefHandle, int OperacaoReImpressao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOnExibeMenu(IntPtr tefHandle, TEFCliSiTefExibeMenuCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetOnObtemCampo(IntPtr tefHandle, TEFCliSiTefObtemCampoCalback method);

		#endregion TEFCliSiTef

		#region TEFDial

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFDial

		#region TEFDisc

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFDisc

		#region TEFHiper

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFHiper

		#region TEFGPU

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFGPU

		#region TEFAuttar

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFAuttar

		#region TEFGood

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFGood

		#region TEFFoxWin

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFFoxWin

		#region TEFPetrocard

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFPetrocard

		#region TEFCrediShop

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetAutoAtivarGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetAutoAtivarGP(IntPtr tefHandle, bool AutoAtivarGP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetNumVias(IntPtr tefHandle, int NumVias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetEsperaSTS(IntPtr tefHandle, int EsperaSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetArqTemp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetArqTemp(IntPtr tefHandle, String ArqTemp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetArqReq(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetArqReq(IntPtr tefHandle, String ArqReq);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetArqSTS(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetArqSTS(IntPtr tefHandle, String ArqSTS);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetArqResp(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetArqResp(IntPtr tefHandle, String ArqResp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetGPExeName(IntPtr tefHandle, String ExeName);

		#endregion TEFCrediShop

		#region Eventos

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

		#endregion Eventos

		#endregion Methods
	}
}