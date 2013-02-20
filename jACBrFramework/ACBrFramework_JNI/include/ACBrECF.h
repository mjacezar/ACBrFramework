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


#ifndef _ACBrECF_H_
#define _ACBrECF_H_

#ifdef __cplusplus
#define DllImport extern "C"
#else
#define DllImport extern
#endif


// Tipos de dados

typedef void (*AbreCupomCallback) (PCHAR CPF_CNPJ,PCHAR Nome,PCHAR Endereco);

typedef struct
{
	char Indice[4];
	double Aliquota;
	BOOL Tipo;
	double Total;
	BOOL Sequencia;
} AliquotaRec;

typedef void (*BobinaAdicionaLinhasCallback) (PCHAR linhas,PCHAR operacao);

typedef void (*ChangeEstadoCallback) (int EstadoAnterior,int EstadoAtual);

typedef BOOL (*ChequeEstadoCallback) (int EstadoAtual);

typedef struct
{
	char Indice[4];
	char Descricao[30];
	BOOL PermiteVinculado;
	char FormaPagamento[4];
	double Total;
	int Contador;
} ComprovanteNaoFiscalRec;

typedef struct
{
	char Numero[14];
	int COO_Cupom;
	int COO_Dav;
	char Titulo[31];
	double Valor;
	double DtEmissao;
} DAVsRec;

typedef void (*EfetuaPagamentoCallback) (PCHAR CodFormaPagto,double Valor,PCHAR Observacao,BOOL ImprimeVinculado);

typedef void (*FechaCupomCallback) (PCHAR Observacao,int IndiceBMP);

typedef struct
{
	char Indice[4];
	char Descricao[30];
	BOOL PermiteVinculado;
	double Total;
	double Data;
	char TipoDoc[30];
} FormaPagamentoRec;

typedef PCHAR (*GetKeyCallback) (void);

typedef void (*IntArgumentCallback) (int value);

typedef void (*NoArgumentCallback) (void);

typedef BOOL (*OnErrorCallback) (void);

typedef BOOL (*OnErrorRelatorioCallback) (int Indice);

typedef BOOL (*OnMsgRetentarCallback) (PCHAR Mensagem,PCHAR Situacao);

typedef struct
{
	char Indice[4];
	char Descricao[30];
	int Contador;
} RelatorioGerencialRec;

typedef void (*SangriaSuprimentoCallback) (double Valor,PCHAR Obs,PCHAR DescricaoCNF,PCHAR DescricaoFPG);

typedef void (*StringCallback) (PCHAR Mensagem);

typedef void (*SubtotalizaCupomCallback) (double DescontoAcrescimo,PCHAR MensagemRodape);

typedef void (*VendeItemCallback) (PCHAR Codigo,PCHAR Descricao,PCHAR AliquotaICMS,double Qtd,double ValorUnitario,double ValorDescontoAcrescimo,PCHAR Unidade,PCHAR TipoDescontoAcrescimo,PCHAR DescontoAcrescimo);


// Funções

DllImport int ECF_AbreCupom(const INTPTR ecfHandle, const PCHAR cpfCnpj, const PCHAR nome, const PCHAR endereco, const BOOL ModoPreVenda);
DllImport int ECF_AbreCupomVinculado(const INTPTR ecfHandle, const PCHAR coo, const PCHAR codFormaPagto, const double valor);
DllImport int ECF_AbreCupomVinculadoCNF(const INTPTR ecfHandle, const PCHAR coo, const PCHAR codFormaPagto, const PCHAR codComprovanteNaoFiscal, const double valor);
DllImport int ECF_AbreGaveta(const INTPTR ecfHandle);
DllImport int ECF_AbreNaoFiscal(const INTPTR ecfHandle, const PCHAR cpfCnpj, const PCHAR nome, const PCHAR endereco);
DllImport int ECF_AbreRelatorioGerencial(const INTPTR ecfHandle, const int indice);
DllImport int ECF_AchaCNFDescricao(const INTPTR ecfHandle, ComprovanteNaoFiscalRec* comprovanteNaoFiscal, const PCHAR descricao, const BOOL busca, const BOOL ignore);
DllImport int ECF_AchaFPGDescricao(const INTPTR ecfHandle, const PCHAR descricao, const BOOL buscaexata, const BOOL ignorecase, FormaPagamentoRec* formaPagamento);
DllImport int ECF_AchaFPGIndice(const INTPTR ecfHandle, const PCHAR indice, FormaPagamentoRec* formaPagamento);
DllImport int ECF_AcharECF(const INTPTR ecfHandle, const BOOL Modelo, const BOOL Porta, const int TimeOut);
DllImport int ECF_AcharPorta(const INTPTR ecfHandle, const int TimeOut);
DllImport int ECF_ArquivoMFD_DLL(const INTPTR ecfHandle, const double DaTaInicial, const double DaTaFinal, const PCHAR Arquivo, const int Documentos[], const int QTD_DOC, const int Finalidade);
DllImport int ECF_ArquivoMFD_DLL_COO(const INTPTR ecfHandle, const int COOInicial, const int COOFinal, const PCHAR Arquivo, const int Documentos[], const int QTD_DOC, const int Finalidade, const int TipoContador);
DllImport int ECF_Ativar(const INTPTR ecfHandle);
DllImport int ECF_CancelaCupom(const INTPTR ecfHandle);
DllImport int ECF_CancelaDescontoAcrescimoItem(const INTPTR ecfHandle, const int numItem);
DllImport int ECF_CancelaDescontoAcrescimoSubTotal(const INTPTR ecfHandle, const char tipoAcrescimoDesconto);
DllImport int ECF_CancelaImpressaoCheque(const INTPTR ecfHandle);
DllImport int ECF_CancelaItemVendido(const INTPTR ecfHandle, const int numItem);
DllImport int ECF_CancelaItemVendidoParcial(const INTPTR ecfHandle, const int numItem, const double quantidade);
DllImport int ECF_CancelaNaoFiscal(const INTPTR ecfHandle);
DllImport int ECF_CarregaAliquotas(const INTPTR ecfHandle);
DllImport int ECF_CarregaComprovantesNaoFiscais(const INTPTR ecfHandle);
DllImport int ECF_CarregaFormasPagamento(const INTPTR ecfHandle);
DllImport int ECF_CarregaRelatoriosGerenciais(const INTPTR ecfHandle);
DllImport int ECF_ConfigBarras_GetAltura(const INTPTR ecfHandle, int* value);
DllImport int ECF_ConfigBarras_GetLarguraLinha(const INTPTR ecfHandle, int* value);
DllImport int ECF_ConfigBarras_GetMostrarCodigo(const INTPTR ecfHandle);
DllImport int ECF_ConfigBarras_SetAltura(const INTPTR ecfHandle, const int value);
DllImport int ECF_ConfigBarras_SetLarguraLinha(const INTPTR ecfHandle, const int value);
DllImport int ECF_ConfigBarras_SetMostrarCodigo(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_Consumidor_AtribuiConsumidor(const INTPTR ecfHandle, const PCHAR CPF_CNPJ, const PCHAR Nome, const PCHAR Endereco);
DllImport int ECF_Consumidor_GetAtribuido(const INTPTR ecfHandle);
DllImport int ECF_Consumidor_GetDocumento(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_Consumidor_GetEndereco(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_Consumidor_GetEnviado(const INTPTR ecfHandle);
DllImport int ECF_Consumidor_GetNome(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_Consumidor_SetEnviado(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_Consumidor_Zera(const INTPTR ecfHandle);
DllImport int ECF_CorrigeEstadoErro(const INTPTR ecfHandle, const BOOL reducaoZ);
DllImport int ECF_CortaPapel(const INTPTR ecfHandle, const BOOL corteParcial);
DllImport int ECF_Create(INTPTR* ecfHandle);
DllImport int ECF_DadosReducaoZClass_CalculaValoresVirtuais(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetAcrescimoICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetAcrescimoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetAcrescimoOPNF(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetCancelamentoICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetCancelamentoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetCancelamentoOPNF(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetCCDC(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCCF(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCDC(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCFC(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCFD(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCNF(const INTPTR ecfHandle, ComprovanteNaoFiscalRec* record, const int value);
DllImport int ECF_DadosReducaoZClass_GetCNFCount(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCOO(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCRO(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetCRZ(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetDataDaImpressora(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetDataDoMovimento(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetDescontoICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetDescontoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetDescontoOPNF(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetFPG(const INTPTR ecfHandle, FormaPagamentoRec* record, const int value);
DllImport int ECF_DadosReducaoZClass_GetFPGCount(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetGNF(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetGNFC(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetGRG(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetICMS(const INTPTR ecfHandle, AliquotaRec* record, const int value);
DllImport int ECF_DadosReducaoZClass_GetICMSCount(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetIsentoICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetIsentoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetISSQN(const INTPTR ecfHandle, AliquotaRec* record, const int value);
DllImport int ECF_DadosReducaoZClass_GetISSQNCount(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetNaoTributadoICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetNaoTributadoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetNCN(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetNumeroCOOInicial(const INTPTR ecfHandle, PCHAR buffer, const int bufferlen);
DllImport int ECF_DadosReducaoZClass_GetNumeroDaLoja(const INTPTR ecfHandle, PCHAR buffer, const int bufferlen);
DllImport int ECF_DadosReducaoZClass_GetNumeroDeSerie(const INTPTR ecfHandle, PCHAR buffer, const int bufferlen);
DllImport int ECF_DadosReducaoZClass_GetNumeroDeSerieMFD(const INTPTR ecfHandle, PCHAR buffer, const int bufferlen);
DllImport int ECF_DadosReducaoZClass_GetNumeroDoECF(const INTPTR ecfHandle, PCHAR buffer, const int bufferlen);
DllImport int ECF_DadosReducaoZClass_GetRG(const INTPTR ecfHandle, RelatorioGerencialRec* record, const int value);
DllImport int ECF_DadosReducaoZClass_GetRGCount(const INTPTR ecfHandle);
DllImport int ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetTotalICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetTotalISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetTotalTroco(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetValorGrandeTotal(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetValorVendaBruta(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_GetVendaLiquida(const INTPTR ecfHandle, double* value);
DllImport int ECF_DadosReducaoZClass_MontaDadosReducaoZ(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_DAV_Abrir(const INTPTR ecfHandle, const double emissao, const PCHAR decrdocumento, const PCHAR numero, const PCHAR situacao, const PCHAR vendedor, const PCHAR observacao, const PCHAR cpfCnpj, const PCHAR nome, const PCHAR endereco, const int indice);
DllImport int ECF_DAV_Fechar(const INTPTR ecfHandle, const PCHAR observacao);
DllImport int ECF_DAV_RegistrarItem(const INTPTR ecfHandle, const PCHAR codigo, const PCHAR descricao, const PCHAR unidade, const double quantidade, const double vlrunitario, const double desconto, const double acrescimo, const BOOL cancelado);
DllImport int ECF_Desativar(const INTPTR ecfHandle);
DllImport int ECF_DescontoAcrescimoItemAnterior(const INTPTR ecfHandle, const double valorDescontoAcrescimo, const PCHAR descontoAcrescimo, const PCHAR TipoDescontoAcrescimo, const int Item);
DllImport int ECF_Destroy(INTPTR* ecfHandle);
DllImport int ECF_DoAtualizarValorGT(const INTPTR ecfHandle);
DllImport int ECF_DoVerificaValorGT(const INTPTR ecfHandle);
DllImport int ECF_EfetuaPagamento(const INTPTR ecfHandle, const PCHAR codFormaPagto, const double valor, const PCHAR observacao, const BOOL imprimeVinculado);
DllImport int ECF_EfetuaPagamentoNaoFiscal(const INTPTR ecfHandle, const PCHAR codFormaPagto, const double valor, const PCHAR observacao, const BOOL imprimeVinculado);
DllImport int ECF_EnviaComando(const INTPTR ecfHandle, const PCHAR cmd, const int timeout, PCHAR buffer, const int bufferlen);
DllImport int ECF_EspelhoMFD_DLL(const INTPTR ecfHandle, const double DaTaInicial, const double DaTaFinal, const PCHAR Arquivo, const int Documentos[], const int QTD_DOC);
DllImport int ECF_EspelhoMFD_DLL_COO(const INTPTR ecfHandle, const int COOInicial, const int COOFinal, const PCHAR Arquivo, const int Documentos[], const int QTD_DOC);
DllImport int ECF_EstornaPagamento(const INTPTR ecfHandle, const PCHAR codFormaPagtoEstornar, const PCHAR codFormaPagtoEfetivar, const double valor, const PCHAR observacao);
DllImport int ECF_FechaCupom(const INTPTR ecfHandle, const PCHAR observacao);
DllImport int ECF_FechaNaoFiscal(const INTPTR ecfHandle, const PCHAR observacao, const int indicebmp);
DllImport int ECF_FechaRelatorio(const INTPTR ecfHandle);
DllImport int ECF_GetAbout(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetAguardaImpressao(const INTPTR ecfHandle);
DllImport int ECF_GetAguardandoResposta(const INTPTR ecfHandle);
DllImport int ECF_GetALCount(const INTPTR ecfHandle, int* value);
DllImport int ECF_GetAliquota(const INTPTR ecfHandle, AliquotaRec* aliquota, const int index);
DllImport int ECF_GetArqLOG(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetArredonda(const INTPTR ecfHandle);
DllImport int ECF_GetArredondaItemMFD(const INTPTR ecfHandle);
DllImport int ECF_GetArredondaPorQtd(const INTPTR ecfHandle);
DllImport int ECF_GetAtivo(const INTPTR ecfHandle);
DllImport int ECF_GetChequePronto(const INTPTR ecfHandle);
DllImport int ECF_GetCliche(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetCNFCount(const INTPTR ecfHandle, int* value);
DllImport int ECF_GetCNPJ(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetColunas(const INTPTR ecfHandle);
DllImport int ECF_GetComandoEnviado(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetComandoLOG(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetComprovanteNaoFiscal(const INTPTR ecfHandle, ComprovanteNaoFiscalRec* comprovanteNaoFiscal, const int index);
DllImport int ECF_GetDadosReducaoZ(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetDadosUltimaReducaoZ(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetDataHora(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetDataHoraSB(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetDataMovimento(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetDecimaisPreco(const INTPTR ecfHandle);
DllImport int ECF_GetDecimaisQtd(const INTPTR ecfHandle);
DllImport int ECF_GetDescricaoGrande(const INTPTR ecfHandle);
DllImport int ECF_GetEmLinha(const INTPTR ecfHandle, const int timeOut);
DllImport int ECF_GetEstado(const INTPTR ecfHandle);
DllImport int ECF_GetFormaPagamento(const INTPTR ecfHandle, FormaPagamentoRec* formaPagamento, const int index);
DllImport int ECF_GetFPGCount(const INTPTR ecfHandle, int* value);
DllImport int ECF_GetGavetaAberta(const INTPTR ecfHandle);
DllImport int ECF_GetGavetaSinalInvertido(const INTPTR ecfHandle);
DllImport int ECF_GetGrandeTotal(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetHorarioVerao(const INTPTR ecfHandle);
DllImport int ECF_GetIdentificaConsumidorRodape(const INTPTR ecfHandle);
DllImport int ECF_GetIE(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetIgnorarTagsFormatacao(const INTPTR ecfHandle);
DllImport int ECF_GetIM(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetIntervaloAposComando(const INTPTR ecfHandle);
DllImport int ECF_GetLinhasEntreCupons(const INTPTR ecfHandle);
DllImport int ECF_GetMaxLinhasBuffer(const INTPTR ecfHandle);
DllImport int ECF_GetMemoParams(const INTPTR ecfHandle, PCHAR linha, const int bufferLen, const int index);
DllImport int ECF_GetMemoParamsLineCount(const INTPTR ecfHandle);
DllImport int ECF_GetMFAdicional(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetMFD(const INTPTR ecfHandle);
DllImport int ECF_GetModelo(const INTPTR ecfHandle);
DllImport int ECF_GetModeloStr(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCCF(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCDC(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCOO(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCOOInicial(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCRO(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCRZ(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumCupom(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumECF(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumGNF(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumGRG(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumLoja(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumSerie(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumSerieMFD(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetNumUltItem(const INTPTR ecfHandle);
DllImport int ECF_GetNumVersao(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetOperador(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetPAF(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetPaginaDeCodigo(const INTPTR ecfHandle);
DllImport int ECF_GetParamDescontoISSQN(const INTPTR ecfHandle);
DllImport int ECF_GetPausaRelatorio(const INTPTR ecfHandle);
DllImport int ECF_GetPoucoPapel(const INTPTR ecfHandle);
DllImport int ECF_GetRelatoriosGerenciais(const INTPTR ecfHandle, RelatorioGerencialRec* relatorio, const int index);
DllImport int ECF_GetRespostaComando(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetRFDID(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetSubModeloECF(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetSubTotal(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTermica(const INTPTR ecfHandle);
DllImport int ECF_GetTotalAcrescimos(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalAcrescimosISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalCancelamentos(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalCancelamentosISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalDescontos(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalDescontosISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalIsencao(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalIsencaoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalNaoFiscal(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalNaoTributado(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalNaoTributadoISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalPago(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalSubstituicaoTributaria(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalSubstituicaoTributariaISSQN(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetTotalTroco(const INTPTR ecfHandle, double* value);
DllImport int ECF_GetUltimoErro(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetUsuarioAtual(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_GetVendaBruta(const INTPTR ecfHandle, double* value);
DllImport int ECF_IdentificaConsumidor(const INTPTR ecfHandle, const PCHAR cpfCnpj, const PCHAR nome, const PCHAR endereco);
DllImport int ECF_IdentificaPAF(const INTPTR ecfHandle, const PCHAR nomeVersao, const PCHAR md5);
DllImport int ECF_ImprimeCheque(const INTPTR ecfHandle, const PCHAR Banco, const double Valor, const PCHAR Favorecido, const PCHAR Cidade, const double Data, const PCHAR Observacao);
DllImport int ECF_InfoRodapeCupom_GetCupomMania(const INTPTR ecfHandle);
DllImport int ECF_InfoRodapeCupom_GetDav(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_InfoRodapeCupom_GetDavOs(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_InfoRodapeCupom_GetMD5(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_InfoRodapeCupom_GetMinasLegal(const INTPTR ecfHandle);
DllImport int ECF_InfoRodapeCupom_GetParaibaLegal(const INTPTR ecfHandle);
DllImport int ECF_InfoRodapeCupom_GetPreVenda(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir(const INTPTR ecfHandle);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito(const INTPTR ecfHandle);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS(const INTPTR ecfHandle, double* value);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS(const INTPTR ecfHandle, double* value);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS(const INTPTR ecfHandle, const double value);
DllImport int ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS(const INTPTR ecfHandle, const double value);
DllImport int ECF_InfoRodapeCupom_SetCupomMania(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_InfoRodapeCupom_SetDav(const INTPTR ecfHandle, const PCHAR value);
DllImport int ECF_InfoRodapeCupom_SetDavOs(const INTPTR ecfHandle, const PCHAR value);
DllImport int ECF_InfoRodapeCupom_SetMD5(const INTPTR ecfHandle, const PCHAR value);
DllImport int ECF_InfoRodapeCupom_SetMinasLegal(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_InfoRodapeCupom_SetParaibaLegal(const INTPTR ecfHandle, const BOOL value);
DllImport int ECF_InfoRodapeCupom_SetPreVenda(const INTPTR ecfHandle, const PCHAR value);
DllImport int ECF_LegendaInmetroProximoItem(const INTPTR ecfHandle);
DllImport int ECF_LeituraCMC7(const INTPTR ecfHandle, PCHAR buffer, const int bufferLen);
DllImport int ECF_LeituraMemoriaFiscalArquivoData(const INTPTR ecfHandle, const double dataInicial, const double dataFinal, const PCHAR nomeArquivo, const BOOL simplificada);
DllImport int ECF_LeituraMemoriaFiscalArquivoReducao(const INTPTR ecfHandle, const int reducaoInicial, const int reducaoFinal, const PCHAR nomeArquivo, const BOOL simplificada);
DllImport int ECF_LeituraMemoriaFiscalData(const INTPTR ecfHandle, const double dataInicial, const double dataFinal, const BOOL simplificada);
DllImport int ECF_LeituraMemoriaFiscalReducao(const INTPTR ecfHandle, const int reducaoInicial, const int reducaoFinal, const BOOL simplificada);
DllImport int ECF_LeituraMemoriaFiscalSerialData(const INTPTR ecfHandle, const double dataInicial, const double dataFinal, const BOOL simplificada, PCHAR buffer, const int bufferLen);
DllImport int ECF_LeituraMemoriaFiscalSerialReducao(const INTPTR ecfHandle, const int reducaoInicial, const int reducaoFinal, const BOOL simplificada, PCHAR buffer, const int bufferLen);
DllImport int ECF_LeituraX(const INTPTR ecfHandle);
DllImport int ECF_LerTotaisAliquota(const INTPTR ecfHandle);
DllImport int ECF_LerTotaisComprovanteNaoFiscal(const INTPTR ecfHandle);
DllImport int ECF_LerTotaisFormaPagamento(const INTPTR ecfHandle);
DllImport int ECF_LerTotaisRelatoriosGerenciais(const INTPTR ecfHandle);
DllImport int ECF_LinhaCupomVinculado(const INTPTR ecfHandle, const PCHAR linha);
DllImport int ECF_LinhaRelatorioGerencial(const INTPTR ecfHandle, const PCHAR linha, const int indiceBMP);
DllImport int ECF_MudaArredondamento(const INTPTR ecfHandle, const BOOL arredonda);
DllImport int ECF_MudaHorarioVerao(const INTPTR ecfHandle);
DllImport int ECF_PafMF_GerarCAT52(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFC_Cotepe1704(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFC_Cotepe1704_CRZ(const INTPTR ecfHandle, const int CRZInicial, const int CRZFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFC_Espelho(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFC_Espelho_CRZ(const INTPTR ecfHandle, const int CRZInicial, const int CRZFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFC_Impressao(const INTPTR ecfHandle, const double DataInicial, const double DataFinal);
DllImport int ECF_PafMF_LMFC_Impressao_CRZ(const INTPTR ecfHandle, const int CRZInicial, const int CRZFinal);
DllImport int ECF_PafMF_LMFS_Espelho(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFS_Espelho_CRZ(const INTPTR ecfHandle, const int CRZInicial, const int CRZFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_LMFS_Impressao(const INTPTR ecfHandle, const double DataInicial, const double DataFinal);
DllImport int ECF_PafMF_LMFS_Impressao_CRZ(const INTPTR ecfHandle, const int CRZInicial, const int CRZFinal);
DllImport int ECF_PafMF_LX_Impressao(const INTPTR ecfHandle);
DllImport int ECF_PafMF_MFD_Cotepe1704(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_MFD_Cotepe1704_COO(const INTPTR ecfHandle, const int COOInicial, const int COOFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_MFD_Espelho(const INTPTR ecfHandle, const double DataInicial, const double DataFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_MFD_Espelho_COO(const INTPTR ecfHandle, const int COOInicial, const int COOFinal, const PCHAR CaminhoArquivo);
DllImport int ECF_PafMF_RelDAVEmitidos(const INTPTR ecfHandle, const DAVsRec DAVs[], const int index, const PCHAR TituloRelatorio, const int IndiceRelatorio);
DllImport int ECF_PafMF_RelIdentificacaoPafECF(const INTPTR ecfHandle, const INTPTR aacHandle, const int IndiceRelatorio);
DllImport int ECF_PafMF_RelMeiosPagamento(const INTPTR ecfHandle, const FormaPagamentoRec formasPagamento[], const int count, const PCHAR TituloRelatorio, const int IndiceRelatorio);
DllImport int ECF_PafMF_RelParametrosConfiguracao(const INTPTR ecfHandle, const INTPTR aacHandle, const int IndiceRelatorio);
DllImport int ECF_PreparaTEF(const INTPTR ecfHandle);
DllImport int ECF_ProgramaAliquota(const INTPTR ecfHandle, const double aliquota, const char tipo, const PCHAR posicao);
DllImport int ECF_ProgramaComprovanteNaoFiscal(const INTPTR ecfHandle, const PCHAR descricao, const PCHAR tipo, const PCHAR posicao);
DllImport int ECF_ProgramaFormaPagamento(const INTPTR ecfHandle, const PCHAR descricao, const BOOL permiteVinculado, const PCHAR posicao);
DllImport int ECF_ProgramaRelatoriosGerenciais(const INTPTR ecfHandle, const PCHAR descricao, const PCHAR posicao);
DllImport int ECF_PulaLinhas(const INTPTR ecfHandle, const int numLinhas);
DllImport int ECF_ReducaoZ(const INTPTR ecfHandle, const double data);
DllImport int ECF_RegistraItemNaoFiscal(const INTPTR ecfHandle, const PCHAR codCNF, const double value, const PCHAR obs);
DllImport int ECF_RelatorioGerencial(const INTPTR ecfHandle, const PCHAR linhas[], const int linhasCount, const int Via, const int Indice);
DllImport int ECF_Sangria(const INTPTR ecfHandle, const double valor, const PCHAR obs, const PCHAR DescricaoCNF, const PCHAR DescricaoFPG, const int indicebmp);
DllImport int ECF_SetAAC(const INTPTR ecfHandle, const INTPTR aacHandle);
DllImport int ECF_SetAguardaImpressao(const INTPTR ecfHandle, const BOOL aguardaImpressao);
DllImport int ECF_SetArqLOG(const INTPTR ecfHandle, const PCHAR arqLog);
DllImport int ECF_SetArredondaItemMFD(const INTPTR ecfHandle, const BOOL arredonda);
DllImport int ECF_SetArredondaPorQtd(const INTPTR ecfHandle, const BOOL arredonda);
DllImport int ECF_SetComandoLOG(const INTPTR ecfHandle, const PCHAR comandoLog);
DllImport int ECF_SetDecimaisPreco(const INTPTR ecfHandle, const int decimaisPreco);
DllImport int ECF_SetDecimaisQtd(const INTPTR ecfHandle, const int decimaisQtd);
DllImport int ECF_SetDescricaoGrande(const INTPTR ecfHandle, const BOOL descricaoGrande);
DllImport int ECF_SetEAD(const INTPTR ecfHandle, const INTPTR eadHandle);
DllImport int ECF_SetGavetaSinalInvertido(const INTPTR ecfHandle, const BOOL gavetaSinalInvertido);
DllImport int ECF_SetIgnorarTagsFormatacao(const INTPTR ecfHandle, const BOOL ignorar);
DllImport int ECF_SetIntervaloAposComando(const INTPTR ecfHandle, const int intervalo);
DllImport int ECF_SetLinhasEntreCupons(const INTPTR ecfHandle, const int linhasEntreCupons);
DllImport int ECF_SetMaxLinhasBuffer(const INTPTR ecfHandle, const int maxLinhas);
DllImport int ECF_SetMemoParams(const INTPTR ecfHandle, const PCHAR linhas[], const int count);
DllImport int ECF_SetModelo(const INTPTR ecfHandle, const int modelo);
DllImport int ECF_SetOnAguardandoRespostaChange(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesAbreCupom(const INTPTR ecfHandle, const AbreCupomCallback method);
DllImport int ECF_SetOnAntesAbreCupomVinculado(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesAbreNaoFiscal(const INTPTR ecfHandle, const AbreCupomCallback method);
DllImport int ECF_SetOnAntesAbreRelatorioGerencial(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnAntesCancelaCupom(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesCancelaItemNaoFiscal(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnAntesCancelaItemVendido(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnAntesCancelaNaoFiscal(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesEfetuaPagamento(const INTPTR ecfHandle, const EfetuaPagamentoCallback method);
DllImport int ECF_SetOnAntesEfetuaPagamentoNaoFiscal(const INTPTR ecfHandle, const EfetuaPagamentoCallback method);
DllImport int ECF_SetOnAntesFechaCupom(const INTPTR ecfHandle, const FechaCupomCallback method);
DllImport int ECF_SetOnAntesFechaNaoFiscal(const INTPTR ecfHandle, const FechaCupomCallback method);
DllImport int ECF_SetOnAntesFechaRelatorio(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesLeituraX(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesReducaoZ(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnAntesSangria(const INTPTR ecfHandle, const SangriaSuprimentoCallback method);
DllImport int ECF_SetOnAntesSubtotalizaCupom(const INTPTR ecfHandle, const SubtotalizaCupomCallback method);
DllImport int ECF_SetOnAntesSubtotalizaNaoFiscal(const INTPTR ecfHandle, const SubtotalizaCupomCallback method);
DllImport int ECF_SetOnAntesSuprimento(const INTPTR ecfHandle, const SangriaSuprimentoCallback method);
DllImport int ECF_SetOnAntesVendeItem(const INTPTR ecfHandle, const VendeItemCallback method);
DllImport int ECF_SetOnBobinaAdicionaLinhas(const INTPTR ecfHandle, const BobinaAdicionaLinhasCallback method);
DllImport int ECF_SetOnChangeEstado(const INTPTR ecfHandle, const ChangeEstadoCallback method);
DllImport int ECF_SetOnChequeEstado(const INTPTR ecfHandle, const ChequeEstadoCallback method);
DllImport int ECF_SetOnDepoisAbreCupom(const INTPTR ecfHandle, const AbreCupomCallback method);
DllImport int ECF_SetOnDepoisAbreCupomVinculado(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisAbreNaoFiscal(const INTPTR ecfHandle, const AbreCupomCallback method);
DllImport int ECF_SetOnDepoisAbreRelatorioGerencial(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnDepoisCancelaCupom(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisCancelaItemNaoFiscal(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnDepoisCancelaItemVendido(const INTPTR ecfHandle, const IntArgumentCallback method);
DllImport int ECF_SetOnDepoisCancelaNaoFiscal(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisEfetuaPagamento(const INTPTR ecfHandle, const EfetuaPagamentoCallback method);
DllImport int ECF_SetOnDepoisEfetuaPagamentoNaoFiscal(const INTPTR ecfHandle, const EfetuaPagamentoCallback method);
DllImport int ECF_SetOnDepoisFechaCupom(const INTPTR ecfHandle, const FechaCupomCallback method);
DllImport int ECF_SetOnDepoisFechaNaoFiscal(const INTPTR ecfHandle, const FechaCupomCallback method);
DllImport int ECF_SetOnDepoisFechaRelatorio(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisLeituraX(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisReducaoZ(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnDepoisSangria(const INTPTR ecfHandle, const SangriaSuprimentoCallback method);
DllImport int ECF_SetOnDepoisSubtotalizaCupom(const INTPTR ecfHandle, const SubtotalizaCupomCallback method);
DllImport int ECF_SetOnDepoisSubtotalizaNaoFiscal(const INTPTR ecfHandle, const SubtotalizaCupomCallback method);
DllImport int ECF_SetOnDepoisSuprimento(const INTPTR ecfHandle, const SangriaSuprimentoCallback method);
DllImport int ECF_SetOnDepoisVendeItem(const INTPTR ecfHandle, const VendeItemCallback method);
DllImport int ECF_SetOnErrorAbreCupom(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorAbreCupomVinculado(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorAbreNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorAbreRelatorioGerencial(const INTPTR ecfHandle, const OnErrorRelatorioCallback method);
DllImport int ECF_SetOnErrorCancelaCupom(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorCancelaItemNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorCancelaItemVendido(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorCancelaNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorEfetuaPagamento(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorEfetuaPagamentoNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorFechaCupom(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorFechaNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorFechaRelatorio(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorLeituraX(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorReducaoZ(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorSangria(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorSemPapel(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOnErrorSubtotalizaCupom(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorSubtotalizaNaoFiscal(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorSuprimento(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnErrorVendeItem(const INTPTR ecfHandle, const OnErrorCallback method);
DllImport int ECF_SetOnMsgAguarde(const INTPTR ecfHandle, const StringCallback method);
DllImport int ECF_SetOnMsgRetentar(const INTPTR ecfHandle, const OnMsgRetentarCallback method);
DllImport int ECF_SetOnPoucoPapel(const INTPTR ecfHandle, const NoArgumentCallback method);
DllImport int ECF_SetOperador(const INTPTR ecfHandle, const PCHAR operador);
DllImport int ECF_SetPAFCalcEAD(const INTPTR ecfHandle, const StringCallback method);
DllImport int ECF_SetPAFGetKeyRSA(const INTPTR ecfHandle, const GetKeyCallback method);
DllImport int ECF_SetPaginaDeCodigo(const INTPTR ecfHandle, const int pagina);
DllImport int ECF_SetPausaRelatorio(const INTPTR ecfHandle, const int pausa);
DllImport int ECF_SetRFD(const INTPTR ecfHandle, const INTPTR rfdHandle);
DllImport int ECF_SubtotalizaCupom(const INTPTR ecfHandle, const double descontoAcrescimo, const PCHAR mensagemRodape);
DllImport int ECF_SubtotalizaNaoFiscal(const INTPTR ecfHandle, const double descontoAcrescimo, const PCHAR mensagemRodape);
DllImport int ECF_Suprimento(const INTPTR ecfHandle, const double valor, const PCHAR obs, const PCHAR DescricaoCNF, const PCHAR DescricaoFPG, const int indicebmp);
DllImport int ECF_TestaPodeAbrirCupom(const INTPTR ecfHandle);
DllImport int ECF_VendeItem(const INTPTR ecfHandle, const PCHAR codigo, const PCHAR descricao, const PCHAR aliquotaICMS, const double qtd, const double valorUnitario, const double descontoPorc, const PCHAR unidade, const PCHAR tipoDescontoAcrescimo, const PCHAR descontoAcrescimo, const int CodDepartamento);


#endif
