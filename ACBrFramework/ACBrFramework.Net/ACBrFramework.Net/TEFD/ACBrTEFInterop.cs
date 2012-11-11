﻿using System;
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

		#region Constructor\Destructor\Error

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Create(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Destroy(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetUltimoErro(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		#endregion Constructor\Destructor\Error

		#region Funções TEF

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Inicializar(IntPtr tefHandle, int gp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_DesInicializar(IntPtr tefHandle, int gp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_AtivarGP(IntPtr tefHandle, int gp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_CRT(IntPtr tefHandle, double Valor, string IndiceFPG_ECF, string DocumentoVinculado, int Moeda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_ATV(IntPtr tefHandle, int GP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_ADM(IntPtr tefHandle, int GP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_CNC(IntPtr tefHandle, string Rede, string NSU, double DataHoraTransacao, double Valor);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_CNF(IntPtr tefHandle, string Rede, string NSU, string Finalizacao, string DocumentoVinculado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_NCN(IntPtr tefHandle, string Rede, string NSU, string Finalizacao, double Valor, string DocumentoVinculado);

		#endregion Funções TEF

		#region Propriedades Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetAutoAtivar(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetAutoAtivar(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetGPAtual(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetGPAtual(IntPtr tefHandle, int gp);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetMultiplosCartoes(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetMultiplosCartoes(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetAutoEfetuarPagamento(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetAutoEfetuarPagamento(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetAutoFinalizarCupom(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetAutoFinalizarCupom(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetCHQEmGerencial(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetCHQEmGerencial(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetEsperaSleep(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetEsperaSleep(IntPtr tefHandle, int Espera);	

		#endregion Propriedades Componente

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

		#region Req

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetReq(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetHeader(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetHeader(IntPtr tefHandle, String Header);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDocumentoVinculado(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDocumentoVinculado(IntPtr tefHandle, String DocumentoVinculado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetCMC7(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetCMC7(IntPtr tefHandle, String CMC7);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDocumentoPessoa(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDocumentoPessoa(IntPtr tefHandle, String DocumentoPesso);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetRede(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetRede(IntPtr tefHandle, String Rede);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetNSU(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetNSU(IntPtr tefHandle, String NSU);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetFinalizacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetFinalizacao(IntPtr tefHandle, String Finalizacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetID(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetID(IntPtr tefHandle, int ID);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetMoeda(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetMoeda(IntPtr tefHandle, int Moeda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetTipoPessoa(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetTipoPessoa(IntPtr tefHandle, char TipoPessoa);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetValorTotal(IntPtr tefHandle, ref double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetValorTotal(IntPtr tefHandle, double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDataCheque(IntPtr tefHandle, ref double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDataCheque(IntPtr tefHandle, double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDataHoraTransacaoComprovante(IntPtr tefHandle, ref double DataHoraTransacaoComprovante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDataHoraTransacaoComprovante(IntPtr tefHandle, double DataHoraTransacaoComprovante);

		#endregion Req

		#region Resp

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetHeader(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDocumentoVinculado(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCMC7(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoPessoa(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDocumentoPessoa(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetRede(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNSU(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetFinalizacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetStatusTransacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNSUTransacaoCancelada(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTextoEspecialOperador(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTextoEspecialCliente(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAutenticacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetBanco(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAgencia(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAgenciaDC(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetConta(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetContaDC(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCheque(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetChequeDC(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNomeAdministradora(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTrailer(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetArqBackup(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetArqRespPendente(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetIndiceFPG_ECF(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetInstituicao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadePagto(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadePagtoDescrita(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadeExtenso(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCodigoRedeAutorizada(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetID(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetMoeda(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoTransacao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCodigoAutorizacaoTransacao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNumeroLoteTransacao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoParcelamento(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetQtdParcelas(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetQtdLinhasComprovante(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetOrdemPagamento(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoGP(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetParceladoPor(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoOperacao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCNFEnviado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTransacaoAprovada(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDebito(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCredito(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorTotal(IntPtr tefHandle, ref double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorOriginal(IntPtr tefHandle, ref double ValorOriginal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetSaque(IntPtr tefHandle, ref double Saque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDesconto(IntPtr tefHandle, ref double Desconto);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorEntradaCDC(IntPtr tefHandle, ref double ValorEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataCheque(IntPtr tefHandle, ref double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoHost(IntPtr tefHandle, ref double DataHoraTransacaoHost);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoLocal(IntPtr tefHandle, ref double DataHoraTransacaoLocal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataPreDatado(IntPtr tefHandle, ref double DataPreDatado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoCancelada(IntPtr tefHandle, ref double DataHoraTransacaoCancelada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoComprovante(IntPtr tefHandle, ref double DataHoraTransacaoComprovante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataVencimento(IntPtr tefHandle, ref double DataVencimento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataEntradaCDC(IntPtr tefHandle, ref double DataEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante1aViaCount(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante1aViaLinha(IntPtr tefHandle, int linha, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante2aViaCount(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante2aViaLinha(IntPtr tefHandle, int linha, StringBuilder buffer, int bufferLen);

		#endregion Resp

		#region RespostasPendentes

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCount(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetSaldoRestante(IntPtr tefHandle, ref double SaldoRestante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTotalDesconto(IntPtr tefHandle, ref double TotalDesconto);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTotalPago(IntPtr tefHandle, ref double TotalPago);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetSaldoAPagar(IntPtr tefHandle, ref double SaldoRestante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetHeader(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDocumentoVinculado(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCMC7(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTipoPessoa(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDocumentoPessoa(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetRede(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetNSU(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetFinalizacao(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetStatusTransacao(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetNSUTransacaoCancelada(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTextoEspecialOperador(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTextoEspecialCliente(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetAutenticacao(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetBanco(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetAgencia(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetAgenciaDC(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetConta(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetContaDC(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCheque(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetChequeDC(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetNomeAdministradora(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTrailer(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetArqBackup(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetArqRespPendente(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetIndiceFPG_ECF(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetInstituicao(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetModalidadePagto(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetModalidadePagtoDescrita(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetModalidadeExtenso(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCodigoRedeAutorizada(IntPtr tefHandle, int index, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetID(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetMoeda(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTipoTransacao(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCodigoAutorizacaoTransacao(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetNumeroLoteTransacao(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTipoParcelamento(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetQtdParcelas(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetQtdLinhasComprovante(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetOrdemPagamento(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTipoGP(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetParceladoPor(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTipoOperacao(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCNFEnviado(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTransacaoAprovada(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDebito(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCredito(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetValorTotal(IntPtr tefHandle, int index, ref double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetValorOriginal(IntPtr tefHandle, int index, ref double ValorOriginal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetSaque(IntPtr tefHandle, int index, ref double Saque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDesconto(IntPtr tefHandle, int index, ref double Desconto);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetValorEntradaCDC(IntPtr tefHandle, int index, ref double ValorEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDate(IntPtr tefHandle, int index, ref double Date);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataCheque(IntPtr tefHandle, int index, ref double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataHoraTransacaoHost(IntPtr tefHandle, int index, ref double DataHoraTransacaoHost);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataHoraTransacaoLocal(IntPtr tefHandle, int index, ref double DataHoraTransacaoLocal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataPreDatado(IntPtr tefHandle, int index, ref double DataPreDatado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataHoraTransacaoCancelada(IntPtr tefHandle, int index, ref double DataHoraTransacaoCancelada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataHoraTransacaoComprovante(IntPtr tefHandle, int index, ref double DataHoraTransacaoComprovante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataVencimento(IntPtr tefHandle, int index, ref double DataVencimento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetDataEntradaCDC(IntPtr tefHandle, int index, ref double DataEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetImagemComprovante1aViaCount(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetImagemComprovante1aViaLinha(IntPtr tefHandle, int index, int linha, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetImagemComprovante2aViaCount(IntPtr tefHandle, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetImagemComprovante2aViaLinha(IntPtr tefHandle, int index, int linha, StringBuilder buffer, int bufferLen);

		#endregion RespostasPendentes

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