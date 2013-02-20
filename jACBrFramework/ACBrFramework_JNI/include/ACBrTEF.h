/**
* ACBrFramework DefExporter
* Este arquivo foi gerado automaticamente
**/



#ifndef ACBr
#define ACBr

typedef void* INTPTR;
typedef char* PCHAR;
typedef char BOOL;

#endif


#ifndef _ACBrTEF_H_
#define _ACBrTEF_H_

#ifdef __cplusplus
#define DllImport extern "C"
#else
#define DllImport extern
#endif


// Tipos de dados

typedef void (*AguardaRespCallback) (PCHAR Arquivo,int SegundosTimeOut,BOOL *Interromper);

typedef void (*AntesCancelarTransacaoCallback) (INTPTR RespostaPendente);

typedef void (*AntesFinalizarRequisicaoCallback) (INTPTR Req);

typedef void (*BloqueiaMouseTecladoCallback) (BOOL Bloqueia,BOOL *Tratado);

typedef void (*ComandaECFAbreVinculadoCallback) (PCHAR COO,PCHAR IndiceECF,double Valor,int *RetornoECF);

typedef void (*ComandaECFCallback) (OperacaoECF Operacao,INTPTR Resp,int *RetornoECF);

typedef void (*ComandaECFImprimeViaCallback) (TipoRelatorio TipoRelatorio,int Via,INTPTR ImagemComprovante,int ImagemComprovanteCount,int *RetornoECF);

typedef void (*ComandaECFPagamentoCallback) (PCHAR IndiceECF,double Valor,int *RetornoECF);

typedef void (*ComandaECFSubtotalizaCallback) (double DescAcre,int *RetornoECF);

typedef void (*DepoisCancelarTransacoesCallback) (INTPTR RespostasPendentes);

typedef void (*DepoisConfirmarTransacoesCallback) (INTPTR RespostasPendentes);

typedef void (*ExecutaAcaoCallback) (BOOL *Tratado);

typedef void (*ExibeMsgCallback) (OperacaoMensagem Operacao,PCHAR Mensagem,ModalResult *AModalResult);

typedef void (*InfoECFCallback) (InfoECF Operacao,PCHAR RetornoECF,int RetornoECFLen);

typedef void (*MudaEstadoReqCallback) (ReqEstado EstadoReq);

typedef void (*MudaEstadoRespCallback) (RespEstado EstadoResp);

typedef void (*TEFCliSiTefExibeMenuCallback) (PCHAR Titulo,INTPTR Opcoes,int OpcoesCount,int *ItemSelecionado,BOOL *VoltarMenu);

typedef void (*TEFCliSiTefObtemCampoCalback) (PCHAR Titulo,int TamanhoMinimo,int TamanhoMaximo,int TipoCampo,TefCliSiTefOperacaoCampo Operacao,PCHAR Resposta,int RespLen,BOOL *Digitado,BOOL *VoltarMenu);


// Funções

DllImport int TEF_ADM(const INTPTR tefHandle, const int GP);
DllImport int TEF_AtivarGP(const INTPTR tefHandle, const int gp);
DllImport int TEF_ATV(const INTPTR tefHandle, const int GP);
DllImport int TEF_CancelarTransacoesPendentes(const INTPTR tefHandle);
DllImport int TEF_CHQ(const INTPTR tefHandle, const double Valor, const PCHAR IndiceFPG_ECF, const PCHAR DocumentoVinculado, const PCHAR CMC7, const char TipoPessoa, const PCHAR DocumentoPessoa, const double DataCheque, const PCHAR Banco, const PCHAR Agencia, const PCHAR AgenciaDC, const PCHAR Conta, const PCHAR ContaDC, const PCHAR Cheque, const PCHAR ChequeDC, const PCHAR Compensacao);
DllImport int TEF_CNC(const INTPTR tefHandle, const PCHAR Rede, const PCHAR NSU, const double DataHoraTransacao, const double Valor);
DllImport int TEF_CNF(const INTPTR tefHandle, const PCHAR Rede, const PCHAR NSU, const PCHAR Finalizacao, const PCHAR DocumentoVinculado);
DllImport int TEF_ConfirmarTransacoesPendentes(const INTPTR tefHandle);
DllImport int TEF_Create(INTPTR* tefHandle);
DllImport int TEF_CRT(const INTPTR tefHandle, const double Valor, const PCHAR IndiceFPG_ECF, const PCHAR DocumentoVinculado, const int Moeda);
DllImport int TEF_DesInicializar(const INTPTR tefHandle, const int gp);
DllImport int TEF_Destroy(INTPTR* tefHandle);
DllImport int TEF_FinalizarCupom(const INTPTR tefHandle, const BOOL mouse);
DllImport int TEF_GetAbout(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_GetArqLOG(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_GetAutoAtivar(const INTPTR tefHandle);
DllImport int TEF_GetAutoEfetuarPagamento(const INTPTR tefHandle);
DllImport int TEF_GetAutoFinalizarCupom(const INTPTR tefHandle);
DllImport int TEF_GetCHQEmGerencial(const INTPTR tefHandle);
DllImport int TEF_GetEsperaSleep(const INTPTR tefHandle);
DllImport int TEF_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_GetExibirMsgAutenticacao(const INTPTR tefHandle);
DllImport int TEF_GetGPAtual(const INTPTR tefHandle);
DllImport int TEF_GetMultiplosCartoes(const INTPTR tefHandle);
DllImport int TEF_GetNumeroMaximoCartoes(const INTPTR tefHandle);
DllImport int TEF_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_GetPathBackup(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_GetReq(const INTPTR tefHandle, INTPTR* reqHandle);
DllImport int TEF_GetResp(const INTPTR tefHandle, INTPTR* respHandle);
DllImport int TEF_GetRespostasPendentes(const INTPTR tefHandle, INTPTR* respHandle);
DllImport int TEF_GetTrocoMaximo(const INTPTR tefHandle, double* Troco);
DllImport int TEF_GetUltimoErro(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Identificacao_GetNomeAplicacao(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Identificacao_GetRazaoSocial(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Identificacao_GetSoftwareHouse(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Identificacao_GetVersaoAplicacao(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Identificacao_SetNomeAplicacao(const INTPTR tefHandle, const PCHAR NomeAplicacao);
DllImport int TEF_Identificacao_SetRazaoSocial(const INTPTR tefHandle, const PCHAR RazaoSocial);
DllImport int TEF_Identificacao_SetSoftwareHouse(const INTPTR tefHandle, const PCHAR SoftwareHouse);
DllImport int TEF_Identificacao_SetVersaoAplicacao(const INTPTR tefHandle, const PCHAR VersaoAplicacao);
DllImport int TEF_ImprimirTransacoesPendentes(const INTPTR tefHandle);
DllImport int TEF_Inicializar(const INTPTR tefHandle, const int gp);
DllImport int TEF_NCN(const INTPTR tefHandle, const PCHAR Rede, const PCHAR NSU, const PCHAR Finalizacao, const double Valor, const PCHAR DocumentoVinculado);
DllImport int TEF_Req_GetCMC7(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetDataCheque(const INTPTR tefHandle, const INTPTR reqHandle, double* DataCheque);
DllImport int TEF_Req_GetDataHoraTransacaoComprovante(const INTPTR tefHandle, const INTPTR reqHandle, double* DataHoraTransacaoComprovante);
DllImport int TEF_Req_GetDocumentoPessoa(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetDocumentoVinculado(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetFinalizacao(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetHeader(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetID(const INTPTR tefHandle, const INTPTR reqHandle);
DllImport int TEF_Req_GetMoeda(const INTPTR tefHandle, const INTPTR reqHandle);
DllImport int TEF_Req_GetNSU(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetRede(const INTPTR tefHandle, const INTPTR reqHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Req_GetTipoPessoa(const INTPTR tefHandle, const INTPTR reqHandle);
DllImport int TEF_Req_GetValorTotal(const INTPTR tefHandle, const INTPTR reqHandle, double* ValorTotal);
DllImport int TEF_Req_SetCMC7(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR CMC7);
DllImport int TEF_Req_SetDataCheque(const INTPTR tefHandle, const INTPTR reqHandle, const double DataCheque);
DllImport int TEF_Req_SetDataHoraTransacaoComprovante(const INTPTR tefHandle, const INTPTR reqHandle, const double DataHoraTransacaoComprovante);
DllImport int TEF_Req_SetDocumentoPessoa(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR DocumentoPesso);
DllImport int TEF_Req_SetDocumentoVinculado(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR DocumentoVinculado);
DllImport int TEF_Req_SetFinalizacao(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR Finalizacao);
DllImport int TEF_Req_SetHeader(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR Header);
DllImport int TEF_Req_SetID(const INTPTR tefHandle, const INTPTR reqHandle, const int ID);
DllImport int TEF_Req_SetMoeda(const INTPTR tefHandle, const INTPTR reqHandle, const int Moeda);
DllImport int TEF_Req_SetNSU(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR NSU);
DllImport int TEF_Req_SetRede(const INTPTR tefHandle, const INTPTR reqHandle, const PCHAR Rede);
DllImport int TEF_Req_SetTipoPessoa(const INTPTR tefHandle, const INTPTR reqHandle, const char TipoPessoa);
DllImport int TEF_Req_SetValorTotal(const INTPTR tefHandle, const INTPTR reqHandle, const double ValorTotal);
DllImport int TEF_Resp_GetAgencia(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetAgenciaDC(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetArqBackup(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetArqRespPendente(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetAutenticacao(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetBanco(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetCheque(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetChequeDC(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetCMC7(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetCNFEnviado(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetCodigoAutorizacaoTransacao(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetCodigoRedeAutorizada(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetConta(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetContaDC(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetCredito(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetDataCheque(const INTPTR tefHandle, const INTPTR respHandle, double* DataCheque);
DllImport int TEF_Resp_GetDataEntradaCDC(const INTPTR tefHandle, const INTPTR respHandle, double* DataEntradaCDC);
DllImport int TEF_Resp_GetDataHoraTransacaoCancelada(const INTPTR tefHandle, const INTPTR respHandle, double* DataHoraTransacaoCancelada);
DllImport int TEF_Resp_GetDataHoraTransacaoComprovante(const INTPTR tefHandle, const INTPTR respHandle, double* DataHoraTransacaoComprovante);
DllImport int TEF_Resp_GetDataHoraTransacaoHost(const INTPTR tefHandle, const INTPTR respHandle, double* DataHoraTransacaoHost);
DllImport int TEF_Resp_GetDataHoraTransacaoLocal(const INTPTR tefHandle, const INTPTR respHandle, double* DataHoraTransacaoLocal);
DllImport int TEF_Resp_GetDataPreDatado(const INTPTR tefHandle, const INTPTR respHandle, double* DataPreDatado);
DllImport int TEF_Resp_GetDataVencimento(const INTPTR tefHandle, const INTPTR respHandle, double* DataVencimento);
DllImport int TEF_Resp_GetDebito(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetDesconto(const INTPTR tefHandle, const INTPTR respHandle, double* Desconto);
DllImport int TEF_Resp_GetDocumentoPessoa(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetDocumentoVinculado(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetFinalizacao(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetHeader(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetID(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetImagemComprovante1aViaCount(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetImagemComprovante1aViaLinha(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen, const int linha);
DllImport int TEF_Resp_GetImagemComprovante2aViaCount(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetImagemComprovante2aViaLinha(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen, const int linha);
DllImport int TEF_Resp_GetIndiceFPG_ECF(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetInstituicao(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetModalidadeExtenso(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetModalidadePagto(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetModalidadePagtoDescrita(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetMoeda(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetNomeAdministradora(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetNSU(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetNSUTransacaoCancelada(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetNumeroLoteTransacao(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetOrdemPagamento(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetParceladoPor(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetQtdLinhasComprovante(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetQtdParcelas(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetRede(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetSaque(const INTPTR tefHandle, const INTPTR respHandle, double* Saque);
DllImport int TEF_Resp_GetStatusTransacao(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetTextoEspecialCliente(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetTextoEspecialOperador(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetTipoGP(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetTipoOperacao(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetTipoParcelamento(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetTipoPessoa(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetTipoTransacao(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetTrailer(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_Resp_GetTransacaoAprovada(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_Resp_GetValorEntradaCDC(const INTPTR tefHandle, const INTPTR respHandle, double* ValorEntradaCDC);
DllImport int TEF_Resp_GetValorOriginal(const INTPTR tefHandle, const INTPTR respHandle, double* ValorOriginal);
DllImport int TEF_Resp_GetValorTotal(const INTPTR tefHandle, const INTPTR respHandle, double* ValorTotal);
DllImport int TEF_Resp_LeInformacao(const INTPTR tefHandle, const INTPTR respHandle, PCHAR buffer, const int bufferLen, const int identificacao, const int sequencia);
DllImport int TEF_RespostasPendentes_GetCount(const INTPTR tefHandle, const INTPTR respHandle);
DllImport int TEF_RespostasPendentes_GetItem(const INTPTR tefHandle, const INTPTR respostaPendenteHandle, const int index, INTPTR* respHandle);
DllImport int TEF_RespostasPendentes_GetSaldoAPagar(const INTPTR tefHandle, const INTPTR respHandle, double* SaldoRestante);
DllImport int TEF_RespostasPendentes_GetSaldoRestante(const INTPTR tefHandle, const INTPTR respHandle, double* SaldoRestante);
DllImport int TEF_RespostasPendentes_GetTotalDesconto(const INTPTR tefHandle, const INTPTR respHandle, double* TotalDesconto);
DllImport int TEF_RespostasPendentes_GetTotalPago(const INTPTR tefHandle, const INTPTR respHandle, double* TotalPago);
DllImport int TEF_SetArqLOG(const INTPTR tefHandle, const PCHAR arqLog);
DllImport int TEF_SetAutoAtivar(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetAutoEfetuarPagamento(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetAutoFinalizarCupom(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetCHQEmGerencial(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetEsperaSleep(const INTPTR tefHandle, const int Espera);
DllImport int TEF_SetEsperaSTS(const INTPTR tefHandle, const int Espera);
DllImport int TEF_SetExibirMsgAutenticacao(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetGPAtual(const INTPTR tefHandle, const int gp);
DllImport int TEF_SetMultiplosCartoes(const INTPTR tefHandle, const BOOL Ativar);
DllImport int TEF_SetNumeroMaximoCartoes(const INTPTR tefHandle, const int Cartoes);
DllImport int TEF_SetNumVias(const INTPTR tefHandle, const int Vias);
DllImport int TEF_SetOnAguardaResp(const INTPTR tefHandler, const AguardaRespCallback method);
DllImport int TEF_SetOnAntesCancelarTransacao(const INTPTR tefHandler, const AntesCancelarTransacaoCallback method);
DllImport int TEF_SetOnAntesFinalizarRequisicao(const INTPTR tefHandler, const AntesFinalizarRequisicaoCallback method);
DllImport int TEF_SetOnBloqueiaMouseTeclado(const INTPTR tefHandler, const BloqueiaMouseTecladoCallback method);
DllImport int TEF_SetOnComandaECF(const INTPTR tefHandler, const ComandaECFCallback method);
DllImport int TEF_SetOnComandaECFAbreVinculado(const INTPTR tefHandler, const ComandaECFAbreVinculadoCallback method);
DllImport int TEF_SetOnComandaECFImprimeVia(const INTPTR tefHandler, const ComandaECFImprimeViaCallback method);
DllImport int TEF_SetOnComandaECFPagamento(const INTPTR tefHandler, const ComandaECFPagamentoCallback method);
DllImport int TEF_SetOnComandaECFSubtotaliza(const INTPTR tefHandler, const ComandaECFSubtotalizaCallback method);
DllImport int TEF_SetOnDepoisCancelarTransacoes(const INTPTR tefHandler, const DepoisCancelarTransacoesCallback method);
DllImport int TEF_SetOnDepoisConfirmarTransacoes(const INTPTR tefHandler, const DepoisConfirmarTransacoesCallback method);
DllImport int TEF_SetOnExibeMsg(const INTPTR tefHandler, const ExibeMsgCallback method);
DllImport int TEF_SetOnInfoECF(const INTPTR tefHandler, const InfoECFCallback method);
DllImport int TEF_SetOnLimpaTeclado(const INTPTR tefHandler, const ExecutaAcaoCallback method);
DllImport int TEF_SetOnMudaEstadoReq(const INTPTR tefHandler, const MudaEstadoReqCallback method);
DllImport int TEF_SetOnMudaEstadoResp(const INTPTR tefHandler, const MudaEstadoRespCallback method);
DllImport int TEF_SetOnRestauraFocoAplicacao(const INTPTR tefHandler, const ExecutaAcaoCallback method);
DllImport int TEF_SetPathBackup(const INTPTR tefHandle, const PCHAR path);
DllImport int TEF_SetTrocoMaximo(const INTPTR tefHandle, const double Troco);
DllImport int TEF_TEFAuttar_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFAuttar_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFAuttar_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFAuttar_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFAuttar_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFAuttar_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFAuttar_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFAuttar_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFAuttar_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFAuttar_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFAuttar_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFAuttar_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFAuttar_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFAuttar_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFAuttar_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFCliSiTef_DefineMensagemPermanentePinPad(const INTPTR tefHandle, const PCHAR mensagem);
DllImport int TEF_TEFCliSiTef_GetCodigoLoja(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_GetEnderecoIP(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_GetNumeroTerminal(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_GetOperacaoADM(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperacaoATV(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperacaoCHQ(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperacaoCNC(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperacaoCRT(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperacaoReImpressao(const INTPTR tefHandle);
DllImport int TEF_TEFCliSiTef_GetOperador(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_GetParametrosAdicionais(const INTPTR ecfHandle, PCHAR linha, const int bufferLen, const int index);
DllImport int TEF_TEFCliSiTef_GetParametrosAdicionaisCount(const INTPTR ecfHandle);
DllImport int TEF_TEFCliSiTef_GetRestricoes(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCliSiTef_ObtemQuantidadeTransacoesPendentes(const INTPTR tefHandle, const double data, const PCHAR cupom);
DllImport int TEF_TEFCliSiTef_SetCodigoLoja(const INTPTR tefHandle, const PCHAR CodigoLoja);
DllImport int TEF_TEFCliSiTef_SetEnderecoIP(const INTPTR tefHandle, const PCHAR EnderecoIP);
DllImport int TEF_TEFCliSiTef_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFCliSiTef_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFCliSiTef_SetNumeroTerminal(const INTPTR tefHandle, const PCHAR NumeroTerminal);
DllImport int TEF_TEFCliSiTef_SetOnExibeMenu(const INTPTR tefHandle, const TEFCliSiTefExibeMenuCallback method);
DllImport int TEF_TEFCliSiTef_SetOnObtemCampo(const INTPTR tefHandle, const TEFCliSiTefObtemCampoCalback method);
DllImport int TEF_TEFCliSiTef_SetOperacaoADM(const INTPTR tefHandle, const int OperacaoADM);
DllImport int TEF_TEFCliSiTef_SetOperacaoATV(const INTPTR tefHandle, const int OperacaoATV);
DllImport int TEF_TEFCliSiTef_SetOperacaoCHQ(const INTPTR tefHandle, const int OperacaoCHQ);
DllImport int TEF_TEFCliSiTef_SetOperacaoCNC(const INTPTR tefHandle, const int OperacaoCNC);
DllImport int TEF_TEFCliSiTef_SetOperacaoCRT(const INTPTR tefHandle, const int OperacaoCRT);
DllImport int TEF_TEFCliSiTef_SetOperacaoReImpressao(const INTPTR tefHandle, const int OperacaoReImpressao);
DllImport int TEF_TEFCliSiTef_SetOperador(const INTPTR tefHandle, const PCHAR Operador);
DllImport int TEF_TEFCliSiTef_SetParametrosAdicionais(const INTPTR ecfHandle, const PCHAR linhas[], const int count);
DllImport int TEF_TEFCliSiTef_SetRestricoes(const INTPTR tefHandle, const PCHAR Restricoes);
DllImport int TEF_TEFCrediShop_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFCrediShop_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFCrediShop_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFCrediShop_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFCrediShop_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFCrediShop_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFCrediShop_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFCrediShop_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFCrediShop_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFCrediShop_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFCrediShop_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFCrediShop_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFCrediShop_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFCrediShop_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFCrediShop_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFDial_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFDial_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFDial_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFDial_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDial_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFDial_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFDial_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFDial_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFDial_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFDial_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFDial_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFDial_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFDial_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFDial_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFDial_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFDisc_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFDisc_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFDisc_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFDisc_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFDisc_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFDisc_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFDisc_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFDisc_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFDisc_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFDisc_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFDisc_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFDisc_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFDisc_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFDisc_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFDisc_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFFoxWin_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFFoxWin_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFFoxWin_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFFoxWin_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFFoxWin_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFFoxWin_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFFoxWin_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFFoxWin_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFFoxWin_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFFoxWin_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFFoxWin_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFFoxWin_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFFoxWin_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFFoxWin_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFFoxWin_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFGood_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFGood_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFGood_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFGood_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGood_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFGood_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFGood_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFGood_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFGood_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFGood_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFGood_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFGood_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFGood_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFGood_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFGood_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFGPU_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFGPU_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFGPU_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFGPU_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFGPU_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFGPU_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFGPU_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFGPU_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFGPU_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFGPU_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFGPU_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFGPU_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFGPU_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFGPU_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFGPU_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFHiper_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFHiper_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFHiper_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFHiper_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFHiper_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFHiper_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFHiper_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFHiper_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFHiper_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFHiper_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFHiper_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFHiper_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFHiper_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFHiper_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFHiper_SetNumVias(const INTPTR tefHandle, const int NumVias);
DllImport int TEF_TEFPetrocard_GetArqReq(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetArqResp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetArqSTS(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetArqTemp(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetAutoAtivarGP(const INTPTR tefHandle);
DllImport int TEF_TEFPetrocard_GetEsperaSTS(const INTPTR tefHandle);
DllImport int TEF_TEFPetrocard_GetGPExeName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetHabilitado(const INTPTR tefHandle);
DllImport int TEF_TEFPetrocard_GetName(const INTPTR tefHandle, PCHAR buffer, const int bufferLen);
DllImport int TEF_TEFPetrocard_GetNumVias(const INTPTR tefHandle);
DllImport int TEF_TEFPetrocard_SetArqReq(const INTPTR tefHandle, const PCHAR ArqReq);
DllImport int TEF_TEFPetrocard_SetArqResp(const INTPTR tefHandle, const PCHAR ArqResp);
DllImport int TEF_TEFPetrocard_SetArqSTS(const INTPTR tefHandle, const PCHAR ArqSTS);
DllImport int TEF_TEFPetrocard_SetArqTemp(const INTPTR tefHandle, const PCHAR ArqTemp);
DllImport int TEF_TEFPetrocard_SetAutoAtivarGP(const INTPTR tefHandle, const BOOL AutoAtivarGP);
DllImport int TEF_TEFPetrocard_SetEsperaSTS(const INTPTR tefHandle, const int EsperaSTS);
DllImport int TEF_TEFPetrocard_SetGPExeName(const INTPTR tefHandle, const PCHAR ExeName);
DllImport int TEF_TEFPetrocard_SetHabilitado(const INTPTR tefHandle, const BOOL Habilitado);
DllImport int TEF_TEFPetrocard_SetName(const INTPTR tefHandle, const PCHAR Name);
DllImport int TEF_TEFPetrocard_SetNumVias(const INTPTR tefHandle, const int NumVias);


#endif
