/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente - não altere
* This file was generated automatically - don't change it.
**/


package jACBrFramework.interop;
import jACBrFramework.InteropLib;
import com.sun.jna.*;
import com.sun.jna.ptr.*;
import java.nio.ByteBuffer;
import java.util.Arrays;
import java.util.List;


public interface ACBrTEFInterop extends InteropLib
{
	public static final ACBrTEFInterop INSTANCE = (ACBrTEFInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrTEFInterop.class);

	// Tipos de dados

	public interface AguardaRespCallback extends Callback
	{
		void invoke(String Arquivo,int SegundosTimeOut,IntByReference Interromper);
	}


	public interface AntesCancelarTransacaoCallback extends Callback
	{
		void invoke(int RespostaPendente);
	}


	public interface AntesFinalizarRequisicaoCallback extends Callback
	{
		void invoke(int Req);
	}


	public interface BloqueiaMouseTecladoCallback extends Callback
	{
		void invoke(boolean Bloqueia,IntByReference Tratado);
	}


	public interface ComandaECFAbreVinculadoCallback extends Callback
	{
		void invoke(String COO,String IndiceECF,double Valor,IntByReference RetornoECF);
	}


	public interface ComandaECFCallback extends Callback
	{
		void invoke(int Operacao,int Resp,IntByReference RetornoECF);
	}


	public interface ComandaECFImprimeViaCallback extends Callback
	{
		void invoke(int TipoRelatorio,int Via,int ImagemComprovante,int ImagemComprovanteCount,IntByReference RetornoECF);
	}


	public interface ComandaECFPagamentoCallback extends Callback
	{
		void invoke(String IndiceECF,double Valor,IntByReference RetornoECF);
	}


	public interface ComandaECFSubtotalizaCallback extends Callback
	{
		void invoke(double DescAcre,IntByReference RetornoECF);
	}


	public interface DepoisCancelarTransacoesCallback extends Callback
	{
		void invoke(int RespostasPendentes);
	}


	public interface DepoisConfirmarTransacoesCallback extends Callback
	{
		void invoke(int RespostasPendentes);
	}


	public interface ExecutaAcaoCallback extends Callback
	{
		void invoke(IntByReference Tratado);
	}


	public interface ExibeMsgCallback extends Callback
	{
		void invoke(int Operacao,String Mensagem,IntByReference AModalResult);
	}


	public interface InfoECFCallback extends Callback
	{
		void invoke(int Operacao,ByteBuffer RetornoECF,int RetornoECFLen);
	}


	public interface MudaEstadoReqCallback extends Callback
	{
		void invoke(int EstadoReq);
	}


	public interface MudaEstadoRespCallback extends Callback
	{
		void invoke(int EstadoResp);
	}


	public interface TEFCliSiTefExibeMenuCallback extends Callback
	{
		void invoke(String Titulo,int Opcoes,int OpcoesCount,IntByReference ItemSelecionado,IntByReference VoltarMenu);
	}


	public interface TEFCliSiTefObtemCampoCalback extends Callback
	{
		void invoke(String Titulo,int TamanhoMinimo,int TamanhoMaximo,int TipoCampo,int Operacao,ByteBuffer Resposta,int RespLen,IntByReference Digitado,IntByReference VoltarMenu);
	}



	// Funções

	int TEF_ADM(int tefHandle, int GP);
	int TEF_AtivarGP(int tefHandle, int gp);
	int TEF_ATV(int tefHandle, int GP);
	int TEF_CancelarTransacoesPendentes(int tefHandle);
	int TEF_CHQ(int tefHandle, double Valor, String IndiceFPG_ECF, String DocumentoVinculado, String CMC7, char TipoPessoa, String DocumentoPessoa, double DataCheque, String Banco, String Agencia, String AgenciaDC, String Conta, String ContaDC, String Cheque, String ChequeDC, String Compensacao);
	int TEF_CNC(int tefHandle, String Rede, String NSU, double DataHoraTransacao, double Valor);
	int TEF_CNF(int tefHandle, String Rede, String NSU, String Finalizacao, String DocumentoVinculado);
	int TEF_ConfirmarTransacoesPendentes(int tefHandle);
	int TEF_Create(IntByReference tefHandle);
	int TEF_CRT(int tefHandle, double Valor, String IndiceFPG_ECF, String DocumentoVinculado, int Moeda);
	int TEF_DesInicializar(int tefHandle, int gp);
	int TEF_Destroy(int tefHandle);
	int TEF_FinalizarCupom(int tefHandle, boolean mouse);
	int TEF_GetAbout(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_GetArqLOG(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_GetAutoAtivar(int tefHandle);
	int TEF_GetAutoEfetuarPagamento(int tefHandle);
	int TEF_GetAutoFinalizarCupom(int tefHandle);
	int TEF_GetCHQEmGerencial(int tefHandle);
	int TEF_GetEsperaSleep(int tefHandle);
	int TEF_GetEsperaSTS(int tefHandle);
	int TEF_GetExibirMsgAutenticacao(int tefHandle);
	int TEF_GetGPAtual(int tefHandle);
	int TEF_GetMultiplosCartoes(int tefHandle);
	int TEF_GetNumeroMaximoCartoes(int tefHandle);
	int TEF_GetNumVias(int tefHandle);
	int TEF_GetPathBackup(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_GetReq(int tefHandle, IntByReference reqHandle);
	int TEF_GetResp(int tefHandle, IntByReference respHandle);
	int TEF_GetRespostasPendentes(int tefHandle, IntByReference respHandle);
	int TEF_GetTrocoMaximo(int tefHandle, DoubleByReference Troco);
	int TEF_GetUltimoErro(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Identificacao_GetNomeAplicacao(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Identificacao_GetRazaoSocial(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Identificacao_GetSoftwareHouse(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Identificacao_GetVersaoAplicacao(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Identificacao_SetNomeAplicacao(int tefHandle, String NomeAplicacao);
	int TEF_Identificacao_SetRazaoSocial(int tefHandle, String RazaoSocial);
	int TEF_Identificacao_SetSoftwareHouse(int tefHandle, String SoftwareHouse);
	int TEF_Identificacao_SetVersaoAplicacao(int tefHandle, String VersaoAplicacao);
	int TEF_ImprimirTransacoesPendentes(int tefHandle);
	int TEF_Inicializar(int tefHandle, int gp);
	int TEF_NCN(int tefHandle, String Rede, String NSU, String Finalizacao, double Valor, String DocumentoVinculado);
	int TEF_Req_GetCMC7(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetDataCheque(int tefHandle, int reqHandle, DoubleByReference DataCheque);
	int TEF_Req_GetDataHoraTransacaoComprovante(int tefHandle, int reqHandle, DoubleByReference DataHoraTransacaoComprovante);
	int TEF_Req_GetDocumentoPessoa(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetDocumentoVinculado(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetFinalizacao(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetHeader(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetID(int tefHandle, int reqHandle);
	int TEF_Req_GetMoeda(int tefHandle, int reqHandle);
	int TEF_Req_GetNSU(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetRede(int tefHandle, int reqHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Req_GetTipoPessoa(int tefHandle, int reqHandle);
	int TEF_Req_GetValorTotal(int tefHandle, int reqHandle, DoubleByReference ValorTotal);
	int TEF_Req_SetCMC7(int tefHandle, int reqHandle, String CMC7);
	int TEF_Req_SetDataCheque(int tefHandle, int reqHandle, double DataCheque);
	int TEF_Req_SetDataHoraTransacaoComprovante(int tefHandle, int reqHandle, double DataHoraTransacaoComprovante);
	int TEF_Req_SetDocumentoPessoa(int tefHandle, int reqHandle, String DocumentoPesso);
	int TEF_Req_SetDocumentoVinculado(int tefHandle, int reqHandle, String DocumentoVinculado);
	int TEF_Req_SetFinalizacao(int tefHandle, int reqHandle, String Finalizacao);
	int TEF_Req_SetHeader(int tefHandle, int reqHandle, String Header);
	int TEF_Req_SetID(int tefHandle, int reqHandle, int ID);
	int TEF_Req_SetMoeda(int tefHandle, int reqHandle, int Moeda);
	int TEF_Req_SetNSU(int tefHandle, int reqHandle, String NSU);
	int TEF_Req_SetRede(int tefHandle, int reqHandle, String Rede);
	int TEF_Req_SetTipoPessoa(int tefHandle, int reqHandle, char TipoPessoa);
	int TEF_Req_SetValorTotal(int tefHandle, int reqHandle, double ValorTotal);
	int TEF_Resp_GetAgencia(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetAgenciaDC(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetArqBackup(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetArqRespPendente(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetAutenticacao(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetBanco(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetCheque(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetChequeDC(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetCMC7(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetCNFEnviado(int tefHandle, int respHandle);
	int TEF_Resp_GetCodigoAutorizacaoTransacao(int tefHandle, int respHandle);
	int TEF_Resp_GetCodigoRedeAutorizada(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetConta(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetContaDC(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetCredito(int tefHandle, int respHandle);
	int TEF_Resp_GetDataCheque(int tefHandle, int respHandle, DoubleByReference DataCheque);
	int TEF_Resp_GetDataEntradaCDC(int tefHandle, int respHandle, DoubleByReference DataEntradaCDC);
	int TEF_Resp_GetDataHoraTransacaoCancelada(int tefHandle, int respHandle, DoubleByReference DataHoraTransacaoCancelada);
	int TEF_Resp_GetDataHoraTransacaoComprovante(int tefHandle, int respHandle, DoubleByReference DataHoraTransacaoComprovante);
	int TEF_Resp_GetDataHoraTransacaoHost(int tefHandle, int respHandle, DoubleByReference DataHoraTransacaoHost);
	int TEF_Resp_GetDataHoraTransacaoLocal(int tefHandle, int respHandle, DoubleByReference DataHoraTransacaoLocal);
	int TEF_Resp_GetDataPreDatado(int tefHandle, int respHandle, DoubleByReference DataPreDatado);
	int TEF_Resp_GetDataVencimento(int tefHandle, int respHandle, DoubleByReference DataVencimento);
	int TEF_Resp_GetDebito(int tefHandle, int respHandle);
	int TEF_Resp_GetDesconto(int tefHandle, int respHandle, DoubleByReference Desconto);
	int TEF_Resp_GetDocumentoPessoa(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetDocumentoVinculado(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetFinalizacao(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetHeader(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetID(int tefHandle, int respHandle);
	int TEF_Resp_GetImagemComprovante1aViaCount(int tefHandle, int respHandle);
	int TEF_Resp_GetImagemComprovante1aViaLinha(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen, int linha);
	int TEF_Resp_GetImagemComprovante2aViaCount(int tefHandle, int respHandle);
	int TEF_Resp_GetImagemComprovante2aViaLinha(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen, int linha);
	int TEF_Resp_GetIndiceFPG_ECF(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetInstituicao(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetModalidadeExtenso(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetModalidadePagto(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetModalidadePagtoDescrita(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetMoeda(int tefHandle, int respHandle);
	int TEF_Resp_GetNomeAdministradora(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetNSU(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetNSUTransacaoCancelada(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetNumeroLoteTransacao(int tefHandle, int respHandle);
	int TEF_Resp_GetOrdemPagamento(int tefHandle, int respHandle);
	int TEF_Resp_GetParceladoPor(int tefHandle, int respHandle);
	int TEF_Resp_GetQtdLinhasComprovante(int tefHandle, int respHandle);
	int TEF_Resp_GetQtdParcelas(int tefHandle, int respHandle);
	int TEF_Resp_GetRede(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetSaque(int tefHandle, int respHandle, DoubleByReference Saque);
	int TEF_Resp_GetStatusTransacao(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetTextoEspecialCliente(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetTextoEspecialOperador(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetTipoGP(int tefHandle, int respHandle);
	int TEF_Resp_GetTipoOperacao(int tefHandle, int respHandle);
	int TEF_Resp_GetTipoParcelamento(int tefHandle, int respHandle);
	int TEF_Resp_GetTipoPessoa(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetTipoTransacao(int tefHandle, int respHandle);
	int TEF_Resp_GetTrailer(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen);
	int TEF_Resp_GetTransacaoAprovada(int tefHandle, int respHandle);
	int TEF_Resp_GetValorEntradaCDC(int tefHandle, int respHandle, DoubleByReference ValorEntradaCDC);
	int TEF_Resp_GetValorOriginal(int tefHandle, int respHandle, DoubleByReference ValorOriginal);
	int TEF_Resp_GetValorTotal(int tefHandle, int respHandle, DoubleByReference ValorTotal);
	int TEF_Resp_LeInformacao(int tefHandle, int respHandle, ByteBuffer buffer, int bufferLen, int identificacao, int sequencia);
	int TEF_RespostasPendentes_GetCount(int tefHandle, int respHandle);
	int TEF_RespostasPendentes_GetItem(int tefHandle, int respostaPendenteHandle, int index, IntByReference respHandle);
	int TEF_RespostasPendentes_GetSaldoAPagar(int tefHandle, int respHandle, DoubleByReference SaldoRestante);
	int TEF_RespostasPendentes_GetSaldoRestante(int tefHandle, int respHandle, DoubleByReference SaldoRestante);
	int TEF_RespostasPendentes_GetTotalDesconto(int tefHandle, int respHandle, DoubleByReference TotalDesconto);
	int TEF_RespostasPendentes_GetTotalPago(int tefHandle, int respHandle, DoubleByReference TotalPago);
	int TEF_SetArqLOG(int tefHandle, String arqLog);
	int TEF_SetAutoAtivar(int tefHandle, boolean Ativar);
	int TEF_SetAutoEfetuarPagamento(int tefHandle, boolean Ativar);
	int TEF_SetAutoFinalizarCupom(int tefHandle, boolean Ativar);
	int TEF_SetCHQEmGerencial(int tefHandle, boolean Ativar);
	int TEF_SetEsperaSleep(int tefHandle, int Espera);
	int TEF_SetEsperaSTS(int tefHandle, int Espera);
	int TEF_SetExibirMsgAutenticacao(int tefHandle, boolean Ativar);
	int TEF_SetGPAtual(int tefHandle, int gp);
	int TEF_SetMultiplosCartoes(int tefHandle, boolean Ativar);
	int TEF_SetNumeroMaximoCartoes(int tefHandle, int Cartoes);
	int TEF_SetNumVias(int tefHandle, int Vias);
	int TEF_SetOnAguardaResp(int tefHandler, ACBrTEFInterop.AguardaRespCallback method);
	int TEF_SetOnAntesCancelarTransacao(int tefHandler, ACBrTEFInterop.AntesCancelarTransacaoCallback method);
	int TEF_SetOnAntesFinalizarRequisicao(int tefHandler, ACBrTEFInterop.AntesFinalizarRequisicaoCallback method);
	int TEF_SetOnBloqueiaMouseTeclado(int tefHandler, ACBrTEFInterop.BloqueiaMouseTecladoCallback method);
	int TEF_SetOnComandaECF(int tefHandler, ACBrTEFInterop.ComandaECFCallback method);
	int TEF_SetOnComandaECFAbreVinculado(int tefHandler, ACBrTEFInterop.ComandaECFAbreVinculadoCallback method);
	int TEF_SetOnComandaECFImprimeVia(int tefHandler, ACBrTEFInterop.ComandaECFImprimeViaCallback method);
	int TEF_SetOnComandaECFPagamento(int tefHandler, ACBrTEFInterop.ComandaECFPagamentoCallback method);
	int TEF_SetOnComandaECFSubtotaliza(int tefHandler, ACBrTEFInterop.ComandaECFSubtotalizaCallback method);
	int TEF_SetOnDepoisCancelarTransacoes(int tefHandler, ACBrTEFInterop.DepoisCancelarTransacoesCallback method);
	int TEF_SetOnDepoisConfirmarTransacoes(int tefHandler, ACBrTEFInterop.DepoisConfirmarTransacoesCallback method);
	int TEF_SetOnExibeMsg(int tefHandler, ACBrTEFInterop.ExibeMsgCallback method);
	int TEF_SetOnInfoECF(int tefHandler, ACBrTEFInterop.InfoECFCallback method);
	int TEF_SetOnLimpaTeclado(int tefHandler, ACBrTEFInterop.ExecutaAcaoCallback method);
	int TEF_SetOnMudaEstadoReq(int tefHandler, ACBrTEFInterop.MudaEstadoReqCallback method);
	int TEF_SetOnMudaEstadoResp(int tefHandler, ACBrTEFInterop.MudaEstadoRespCallback method);
	int TEF_SetOnRestauraFocoAplicacao(int tefHandler, ACBrTEFInterop.ExecutaAcaoCallback method);
	int TEF_SetPathBackup(int tefHandle, String path);
	int TEF_SetTrocoMaximo(int tefHandle, double Troco);
	int TEF_TEFAuttar_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFAuttar_GetEsperaSTS(int tefHandle);
	int TEF_TEFAuttar_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetHabilitado(int tefHandle);
	int TEF_TEFAuttar_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFAuttar_GetNumVias(int tefHandle);
	int TEF_TEFAuttar_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFAuttar_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFAuttar_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFAuttar_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFAuttar_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFAuttar_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFAuttar_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFAuttar_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFAuttar_SetName(int tefHandle, String Name);
	int TEF_TEFAuttar_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(int tefHandle, String mensagem);
	int TEF_TEFCliSiTef_GetCodigoLoja(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_GetEnderecoIP(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_GetHabilitado(int tefHandle);
	int TEF_TEFCliSiTef_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_GetNumeroTerminal(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_GetOperacaoADM(int tefHandle);
	int TEF_TEFCliSiTef_GetOperacaoATV(int tefHandle);
	int TEF_TEFCliSiTef_GetOperacaoCHQ(int tefHandle);
	int TEF_TEFCliSiTef_GetOperacaoCNC(int tefHandle);
	int TEF_TEFCliSiTef_GetOperacaoCRT(int tefHandle);
	int TEF_TEFCliSiTef_GetOperacaoReImpressao(int tefHandle);
	int TEF_TEFCliSiTef_GetOperador(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_GetParametrosAdicionais(int ecfHandle, ByteBuffer linha, int bufferLen, int index);
	int TEF_TEFCliSiTef_GetParametrosAdicionaisCount(int ecfHandle);
	int TEF_TEFCliSiTef_GetRestricoes(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(int tefHandle, double data, String cupom);
	int TEF_TEFCliSiTef_SetCodigoLoja(int tefHandle, String CodigoLoja);
	int TEF_TEFCliSiTef_SetEnderecoIP(int tefHandle, String EnderecoIP);
	int TEF_TEFCliSiTef_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFCliSiTef_SetName(int tefHandle, String Name);
	int TEF_TEFCliSiTef_SetNumeroTerminal(int tefHandle, String NumeroTerminal);
	int TEF_TEFCliSiTef_SetOnExibeMenu(int tefHandle, ACBrTEFInterop.TEFCliSiTefExibeMenuCallback method);
	int TEF_TEFCliSiTef_SetOnObtemCampo(int tefHandle, ACBrTEFInterop.TEFCliSiTefObtemCampoCalback method);
	int TEF_TEFCliSiTef_SetOperacaoADM(int tefHandle, int OperacaoADM);
	int TEF_TEFCliSiTef_SetOperacaoATV(int tefHandle, int OperacaoATV);
	int TEF_TEFCliSiTef_SetOperacaoCHQ(int tefHandle, int OperacaoCHQ);
	int TEF_TEFCliSiTef_SetOperacaoCNC(int tefHandle, int OperacaoCNC);
	int TEF_TEFCliSiTef_SetOperacaoCRT(int tefHandle, int OperacaoCRT);
	int TEF_TEFCliSiTef_SetOperacaoReImpressao(int tefHandle, int OperacaoReImpressao);
	int TEF_TEFCliSiTef_SetOperador(int tefHandle, String Operador);
	int TEF_TEFCliSiTef_SetParametrosAdicionais(int ecfHandle, String linhas[], int count);
	int TEF_TEFCliSiTef_SetRestricoes(int tefHandle, String Restricoes);
	int TEF_TEFCrediShop_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFCrediShop_GetEsperaSTS(int tefHandle);
	int TEF_TEFCrediShop_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetHabilitado(int tefHandle);
	int TEF_TEFCrediShop_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFCrediShop_GetNumVias(int tefHandle);
	int TEF_TEFCrediShop_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFCrediShop_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFCrediShop_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFCrediShop_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFCrediShop_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFCrediShop_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFCrediShop_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFCrediShop_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFCrediShop_SetName(int tefHandle, String Name);
	int TEF_TEFCrediShop_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFDial_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFDial_GetEsperaSTS(int tefHandle);
	int TEF_TEFDial_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetHabilitado(int tefHandle);
	int TEF_TEFDial_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDial_GetNumVias(int tefHandle);
	int TEF_TEFDial_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFDial_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFDial_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFDial_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFDial_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFDial_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFDial_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFDial_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFDial_SetName(int tefHandle, String Name);
	int TEF_TEFDial_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFDisc_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFDisc_GetEsperaSTS(int tefHandle);
	int TEF_TEFDisc_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetHabilitado(int tefHandle);
	int TEF_TEFDisc_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFDisc_GetNumVias(int tefHandle);
	int TEF_TEFDisc_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFDisc_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFDisc_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFDisc_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFDisc_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFDisc_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFDisc_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFDisc_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFDisc_SetName(int tefHandle, String Name);
	int TEF_TEFDisc_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFFoxWin_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFFoxWin_GetEsperaSTS(int tefHandle);
	int TEF_TEFFoxWin_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetHabilitado(int tefHandle);
	int TEF_TEFFoxWin_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFFoxWin_GetNumVias(int tefHandle);
	int TEF_TEFFoxWin_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFFoxWin_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFFoxWin_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFFoxWin_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFFoxWin_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFFoxWin_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFFoxWin_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFFoxWin_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFFoxWin_SetName(int tefHandle, String Name);
	int TEF_TEFFoxWin_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFGood_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFGood_GetEsperaSTS(int tefHandle);
	int TEF_TEFGood_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetHabilitado(int tefHandle);
	int TEF_TEFGood_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGood_GetNumVias(int tefHandle);
	int TEF_TEFGood_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFGood_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFGood_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFGood_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFGood_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFGood_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFGood_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFGood_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFGood_SetName(int tefHandle, String Name);
	int TEF_TEFGood_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFGPU_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFGPU_GetEsperaSTS(int tefHandle);
	int TEF_TEFGPU_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetHabilitado(int tefHandle);
	int TEF_TEFGPU_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFGPU_GetNumVias(int tefHandle);
	int TEF_TEFGPU_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFGPU_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFGPU_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFGPU_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFGPU_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFGPU_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFGPU_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFGPU_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFGPU_SetName(int tefHandle, String Name);
	int TEF_TEFGPU_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFHiper_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFHiper_GetEsperaSTS(int tefHandle);
	int TEF_TEFHiper_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetHabilitado(int tefHandle);
	int TEF_TEFHiper_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFHiper_GetNumVias(int tefHandle);
	int TEF_TEFHiper_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFHiper_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFHiper_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFHiper_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFHiper_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFHiper_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFHiper_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFHiper_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFHiper_SetName(int tefHandle, String Name);
	int TEF_TEFHiper_SetNumVias(int tefHandle, int NumVias);
	int TEF_TEFPetrocard_GetArqReq(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetArqResp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetArqSTS(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetArqTemp(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetAutoAtivarGP(int tefHandle);
	int TEF_TEFPetrocard_GetEsperaSTS(int tefHandle);
	int TEF_TEFPetrocard_GetGPExeName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetHabilitado(int tefHandle);
	int TEF_TEFPetrocard_GetName(int tefHandle, ByteBuffer buffer, int bufferLen);
	int TEF_TEFPetrocard_GetNumVias(int tefHandle);
	int TEF_TEFPetrocard_SetArqReq(int tefHandle, String ArqReq);
	int TEF_TEFPetrocard_SetArqResp(int tefHandle, String ArqResp);
	int TEF_TEFPetrocard_SetArqSTS(int tefHandle, String ArqSTS);
	int TEF_TEFPetrocard_SetArqTemp(int tefHandle, String ArqTemp);
	int TEF_TEFPetrocard_SetAutoAtivarGP(int tefHandle, boolean AutoAtivarGP);
	int TEF_TEFPetrocard_SetEsperaSTS(int tefHandle, int EsperaSTS);
	int TEF_TEFPetrocard_SetGPExeName(int tefHandle, String ExeName);
	int TEF_TEFPetrocard_SetHabilitado(int tefHandle, boolean Habilitado);
	int TEF_TEFPetrocard_SetName(int tefHandle, String Name);
	int TEF_TEFPetrocard_SetNumVias(int tefHandle, int NumVias);
}
