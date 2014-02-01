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
		public delegate void ExibeMsgCallback(int Operacao, string Mensagem, ref ModalResult AModalResult);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void BloqueiaMouseTecladoCallback(bool Bloqueia, ref bool Tratado);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ExecutaAcaoCallback(ref bool Tratado);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFCallback(int Operacao, IntPtr Resp, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFSubtotalizaCallback(double DescAcre, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFPagamentoCallback(string IndiceECF, double Valor, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFAbreVinculadoCallback(string COO, string IndiceECF, double Valor, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ComandaECFImprimeViaCallback(int TipoRelatorio, int Via, IntPtr ImagemComprovante, int ImagemComprovanteCount, ref int RetornoECF);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void InfoECFCallback(int Operacao, StringBuilder RetornoECF, int RetornoECFLen);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AntesFinalizarRequisicaoCallback(IntPtr Req);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DepoisConfirmarTransacoesCallback(IntPtr RespostasPendentes);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void AntesCancelarTransacaoCallback(IntPtr RespostaPendente);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void DepoisCancelarTransacoesCallback(IntPtr RespostasPendentes);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MudaEstadoReqCallback(int EstadoReq);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void MudaEstadoRespCallback(int EstadoResp);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFCliSiTefExibeMenuCallback(string Titulo, IntPtr Opcoes, int OpcoesCount, ref int ItemSelecionado, ref bool VoltarMenu);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFCliSiTefObtemCampoCalback(string Titulo, int TamanhoMinimo, int TamanhoMaximo, int TipoCampo, int Operacao, StringBuilder Resposta, int RespLen, ref bool Digitado, ref bool VoltarMenu);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFVeSPagueExibeMenuCallback(string Titulo, IntPtr Opcoes, int OpcoesCount, IntPtr Memo, int MemoCount, ref int ItemSelecionado);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void TEFVeSPagueObtemCampoCalback(string Titulo, string Mascara, char Tipo, ref String Resposta, ref bool Digitado);

		#endregion InteropTypes

		#region Methods

		#region Constructor\Destructor\Error

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Create(ref IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Destroy(IntPtr tefHandle);

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
		public static extern int TEF_CHQ(IntPtr tefHandle, double Valor, string IndiceFPG_ECF, string DocumentoVinculado,
			string CMC7, char TipoPessoa, string DocumentoPessoa, double DataCheque, string Banco, string Agencia,
			string AgenciaDC, string Conta, string ContaDC, string Cheque, string ChequeDC, string Compensacao);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_CancelarTransacoesPendentes(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_ConfirmarTransacoesPendentes(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_ImprimirTransacoesPendentes(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_FinalizarCupom(IntPtr tefHandle, bool mouse);

		#endregion Funções TEF

		#region Propriedades Componente

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetAbout(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetArqLOG(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetArqLOG(IntPtr tefHandle, string arqLog);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetEsperaSTS(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetEsperaSTS(IntPtr tefHandle, int Espera);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetNumVias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetNumVias(IntPtr tefHandle, int Vias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetNumeroMaximoCartoes(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetNumeroMaximoCartoes(IntPtr tefHandle, int Cartoes);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetExibirMsgAutenticacao(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetExibirMsgAutenticacao(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetPathBackup(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetPathBackup(IntPtr tefHandle, string path);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetTrocoMaximo(IntPtr tefHandle, ref double Troco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetTrocoMaximo(IntPtr tefHandle, double Troco);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetReq(IntPtr tefHandle, out IntPtr reqHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetResp(IntPtr tefHandle, out IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetRespostasPendentes(IntPtr tefHandle, out IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetSuportaDesconto(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetSuportaDesconto(IntPtr tefHandle, bool Ativar);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_GetSuportaSaque(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_SetSuportaSaque(IntPtr tefHandle, bool Ativar);

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
		public static extern int TEF_Req_GetHeader(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetHeader(IntPtr tefHandle, IntPtr reqHandle, String Header);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDocumentoVinculado(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDocumentoVinculado(IntPtr tefHandle, IntPtr reqHandle, String DocumentoVinculado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetCMC7(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetCMC7(IntPtr tefHandle, IntPtr reqHandle, String CMC7);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDocumentoPessoa(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDocumentoPessoa(IntPtr tefHandle, IntPtr reqHandle, String DocumentoPesso);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetRede(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetRede(IntPtr tefHandle, IntPtr reqHandle, String Rede);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetNSU(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetNSU(IntPtr tefHandle, IntPtr reqHandle, String NSU);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetFinalizacao(IntPtr tefHandle, IntPtr reqHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetFinalizacao(IntPtr tefHandle, IntPtr reqHandle, String Finalizacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetID(IntPtr tefHandle, IntPtr reqHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetID(IntPtr tefHandle, IntPtr reqHandle, int ID);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetMoeda(IntPtr tefHandle, IntPtr reqHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetMoeda(IntPtr tefHandle, IntPtr reqHandle, int Moeda);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetTipoPessoa(IntPtr tefHandle, IntPtr reqHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetTipoPessoa(IntPtr tefHandle, IntPtr reqHandle, char TipoPessoa);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetValorTotal(IntPtr tefHandle, IntPtr reqHandle, ref double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetValorTotal(IntPtr tefHandle, IntPtr reqHandle, double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDataCheque(IntPtr tefHandle, IntPtr reqHandle, ref double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDataCheque(IntPtr tefHandle, IntPtr reqHandle, double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_GetDataHoraTransacaoComprovante(IntPtr tefHandle, IntPtr reqHandle, ref double DataHoraTransacaoComprovante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Req_SetDataHoraTransacaoComprovante(IntPtr tefHandle, IntPtr reqHandle, double DataHoraTransacaoComprovante);

		#endregion Req

		#region Resp

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetHeader(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDocumentoVinculado(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCMC7(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoPessoa(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDocumentoPessoa(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetRede(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNSU(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetFinalizacao(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetStatusTransacao(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNSUTransacaoCancelada(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTextoEspecialOperador(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTextoEspecialCliente(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAutenticacao(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetBanco(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAgencia(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetAgenciaDC(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetConta(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetContaDC(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCheque(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetChequeDC(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNomeAdministradora(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTrailer(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetArqBackup(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetArqRespPendente(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetIndiceFPG_ECF(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetInstituicao(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadePagto(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadePagtoDescrita(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetModalidadeExtenso(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCodigoRedeAutorizada(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetID(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetMoeda(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoTransacao(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCodigoAutorizacaoTransacao(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetNumeroLoteTransacao(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoParcelamento(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetQtdParcelas(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetQtdLinhasComprovante(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetOrdemPagamento(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoGP(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetParceladoPor(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTipoOperacao(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCNFEnviado(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetTransacaoAprovada(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDebito(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetCredito(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorTotal(IntPtr tefHandle, IntPtr respHandle, ref double ValorTotal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorOriginal(IntPtr tefHandle, IntPtr respHandle, ref double ValorOriginal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetSaque(IntPtr tefHandle, IntPtr respHandle, ref double Saque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDesconto(IntPtr tefHandle, IntPtr respHandle, ref double Desconto);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetValorEntradaCDC(IntPtr tefHandle, IntPtr respHandle, ref double ValorEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataCheque(IntPtr tefHandle, IntPtr respHandle, ref double DataCheque);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoHost(IntPtr tefHandle, IntPtr respHandle, ref double DataHoraTransacaoHost);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoLocal(IntPtr tefHandle, IntPtr respHandle, ref double DataHoraTransacaoLocal);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataPreDatado(IntPtr tefHandle, IntPtr respHandle, ref double DataPreDatado);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoCancelada(IntPtr tefHandle, IntPtr respHandle, ref double DataHoraTransacaoCancelada);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataHoraTransacaoComprovante(IntPtr tefHandle, IntPtr respHandle, ref double DataHoraTransacaoComprovante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataVencimento(IntPtr tefHandle, IntPtr respHandle, ref double DataVencimento);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetDataEntradaCDC(IntPtr tefHandle, IntPtr respHandle, ref double DataEntradaCDC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante1aViaCount(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante1aViaLinha(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen, int linha);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante2aViaCount(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_GetImagemComprovante2aViaLinha(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen, int linha);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_Resp_LeInformacao(IntPtr tefHandle, IntPtr respHandle, StringBuilder buffer, int bufferLen, int identificacao, int sequencia);

		#endregion Resp

		#region RespostasPendentes

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetCount(IntPtr tefHandle, IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetItem(IntPtr tefHandle, IntPtr respostaPendenteHandle, int index, out IntPtr respHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetSaldoRestante(IntPtr tefHandle, IntPtr respHandle, ref double SaldoRestante);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTotalDesconto(IntPtr tefHandle, IntPtr respHandle, ref double TotalDesconto);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetTotalPago(IntPtr tefHandle, IntPtr respHandle, ref double TotalPago);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_RespostasPendentes_GetSaldoAPagar(IntPtr tefHandle, IntPtr respHandle, ref double SaldoRestante);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(IntPtr tefHandle, string mensagem);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(IntPtr tefHandle, double data, string cupom);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_SetParametrosAdicionais(IntPtr ecfHandle, string[] linhas, int count);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetParametrosAdicionais(IntPtr ecfHandle, StringBuilder linha, int bufferLen, int index);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCliSiTef_GetParametrosAdicionaisCount(IntPtr ecfHandle);

		#endregion TEFCliSiTef

		#region TEFVeSPague

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetAplicacao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetAplicacao(IntPtr tefHandle, String Aplicacao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetAplicacaoVersao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetAplicacaoVersao(IntPtr tefHandle, String AplicacaoVersao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetGPExeName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetGPExeName(IntPtr tefHandle, String GPExeName);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetGPExeParams(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetGPExeParams(IntPtr tefHandle, String GPExeParams);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetEnderecoIP(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetEnderecoIP(IntPtr tefHandle, String EnderecoIP);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetPorta(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetPorta(IntPtr tefHandle, String Porta);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTimeOut(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTimeOut(IntPtr tefHandle, int TimeOut);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTemPendencias(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTemPendencias(IntPtr tefHandle, bool TemPendencias);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoADM(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoADM(IntPtr tefHandle, String TransacaoADM);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoCRT(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoCRT(IntPtr tefHandle, String TransacaoCRT);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoCHQ(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoCHQ(IntPtr tefHandle, String TransacaoCHQ);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoCNC(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoCNC(IntPtr tefHandle, String TransacaoCNC);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoOpcao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoOpcao(IntPtr tefHandle, String TransacaoOpcao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoReImpressao(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoReImpressao(IntPtr tefHandle, String TransacaoReImpressao);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_GetTransacaoPendente(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetTransacaoPendente(IntPtr tefHandle, String TransacaoPendente);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetOnExibeMenu(IntPtr tefHandle, TEFVeSPagueExibeMenuCallback method);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFVeSPague_SetOnObtemCampo(IntPtr tefHandle, TEFVeSPagueObtemCampoCalback method);

		#endregion TEFVeSPague

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDial_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFDisc_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFHiper_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGPU_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFAuttar_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFGood_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFFoxWin_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFPetrocard_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetName(IntPtr tefHandle, StringBuilder buffer, int bufferLen);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetName(IntPtr tefHandle, String Name);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_GetHabilitado(IntPtr tefHandle);

		[DllImport(ACBr, CallingConvention = CallingConvention.Cdecl)]
		public static extern int TEF_TEFCrediShop_SetHabilitado(IntPtr tefHandle, bool Habilitado);

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