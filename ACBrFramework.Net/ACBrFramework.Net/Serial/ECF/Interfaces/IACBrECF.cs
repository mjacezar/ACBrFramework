using System.Runtime.InteropServices;
using ACBrFramework.AAC;
using ACBrFramework.EAD;
using ACBrFramework.RFD;
using System;
using System.Collections.Generic;

namespace ACBrFramework.ECF
{
    public interface IACBrECF : IDisposable
    {
        ACBrAAC AAC { get; set; }

        string About { get; }

        bool AguardaImpressao { get; set; }

        bool AguardandoResposta { get; }

        Aliquota[] Aliquotas { get; }

        string ArqLOG { get; set; }

        bool Arredonda { get; }

        bool ArredondaItemMFD { get; set; }

        bool ArredondaPorQtd { get; set; }

        bool Ativo { get; }

        bool ChequePronto { get; }

        string Cliche { get; }

        string CNPJ { get; }

        int Colunas { get; }

        string ComandoEnviado { get; }

        string ComandoLog { get; set; }

        ComprovanteNaoFiscal[] ComprovantesNaoFiscais { get; }

        ConfigBarras ConfigBarras { get; }

        Consumidor Consumidor { get; }

        bool ControlePorta { get; set; }

        DadosReducaoZClass DadosReducaoZClass { get; }

        DateTime DataHora { get; }

        DateTime DataHoraSB { get; }

        DateTime DataHoraUltimaReducaoZ { get; }

        DateTime DataMovimento { get; }

        int DecimaisPreco { get; set; }

        int DecimaisQtd { get; set; }

        bool DescricaoGrande { get; set; }

        IACBrDevice Device { get; }

        ACBrEAD EAD { get; set; }

        EstadoECF Estado { get; }

        FormaPagamento[] FormasPagamento { get; }

        bool GavetaAberta { get; }

        bool GavetaSinalInvertido { get; set; }

        decimal GrandeTotal { get; }

        bool HorarioVerao { get; }

        bool IdentificaConsumidorRodape { get; }

        string IE { get; }

        bool IgnorarTagsFormatacao { get; set; }

        string IM { get; }

        Rodape InfoRodapeCupom { get; }

        int IntervaloAposComando { get; set; }

        int LinhasEntreCupons { get; set; }

        int MaxLinhasBuffer { get; set; }

        string[] MemoParams { get; set; }

        string MFAdicional { get; }

        bool MFD { get; }

        ModeloECF Modelo { get; set; }

        string ModeloStr { get; }

        string NumCCF { get; }

        string NumCDC { get; }

        string NumCOO { get; }

        string NumCOOInicial { get; }

        string NumCRO { get; }

        string NumCRZ { get; }

        string NumCupom { get; }

        string NumECF { get; }

        string NumGNF { get; }

        string NumGRG { get; }

        string NumLoja { get; }

        string NumSerie { get; }

        string NumSerieMFD { get; }

        int NumUltItem { get; }

        string NumVersao { get; }

        string Operador { get; set; }

        string PAF { get; }

        int PaginaDeCodigo { get; set; }

        bool ParamDescontoISSQN { get; }

        int PausaRelatorio { get; set; }

        bool PoucoPapel { get; }

        bool QuebraLinhaRodape { get; set; }

        RelatorioGerencial[] RelatoriosGerenciais { get; }

        string RespostaComando { get; }

        bool Retentar { get; set; }

        ACBrRFD RFD { get; set; }

        string RFDID { get; }

        string SubModeloECF { get; }

        decimal SubTotal { get; }

        bool Termica { get; }

        decimal TotalAcrescimos { get; }

        decimal TotalAcrescimosISSQN { get; }

        decimal TotalCancelamentos { get; }

        decimal TotalCancelamentosISSQN { get; }

        decimal TotalDescontos { get; }

        decimal TotalDescontosISSQN { get; }

        decimal TotalIsencao { get; }

        decimal TotalIsencaoISSQN { get; }

        decimal TotalNaoFiscal { get; }

        decimal TotalNaoTributado { get; }

        decimal TotalNaoTributadoISSQN { get; }

        decimal TotalPago { get; }

        decimal TotalSubstituicaoTributaria { get; }

        decimal TotalSubstituicaoTributariaISSQN { get; }

        decimal TotalTroco { get; }

        string UsuarioAtual { get; }

        decimal VendaBruta { get; }

        event EventHandler OnAguardandoRespostaChange;
        
#if COM_INTEROP
        event AbreCupomEventHandler OnAntesAbreCupom;
#else
        event EventHandler<AbreCupomEventArgs> OnAntesAbreCupom;
#endif

        event EventHandler OnAntesAbreCupomVinculado;

#if COM_INTEROP
        event AbreCupomEventHandler OnAntesAbreNaoFiscal;
#else
        event EventHandler<AbreCupomEventArgs> OnAntesAbreNaoFiscal;
#endif

#if COM_INTEROP
        event RelatorioGerencialEventHandler OnAntesAbreRelatorioGerencial;
#else
        event EventHandler<RelatorioGerencialEventArgs> OnAntesAbreRelatorioGerencial;
#endif

        event EventHandler OnAntesCancelaCupom;

#if COM_INTEROP
        event CancelaItemEventHandler OnAntesCancelaItemNaoFiscal;
#else
        event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemNaoFiscal;
#endif

#if COM_INTEROP
        event CancelaItemEventHandler OnAntesCancelaItemVendido;
#else
        event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemVendido;
#endif

        event EventHandler OnAntesCancelaNaoFiscal;

#if COM_INTEROP
        event EfetuaPagamentoEventHandler OnAntesEfetuaPagamento;
#else
        event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamento;
#endif

#if COM_INTEROP
        event EfetuaPagamentoEventHandler OnAntesEfetuaPagamentoNaoFiscal;
#else
        event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamentoNaoFiscal;
#endif

#if COM_INTEROP
        event FechaCupomEventHandler OnAntesFechaCupom;
#else
        event EventHandler<FechaCupomEventArgs> OnAntesFechaCupom;
#endif

#if COM_INTEROP
        event FechaCupomEventHandler OnAntesFechaNaoFiscal;
#else
        event EventHandler<FechaCupomEventArgs> OnAntesFechaNaoFiscal;
#endif

        event EventHandler OnAntesFechaRelatorio;

        event EventHandler OnAntesLeituraX;

        event EventHandler OnAntesReducaoZ;

        #if COM_INTEROP
        event SangriaSuprimentoEventHandler OnAntesSangria;
#else
        event EventHandler<SangriaSuprimentoEventArgs> OnAntesSangria;
#endif

#if COM_INTEROP
        event SubtotalizaCupomEventHandler OnAntesSubtotalizaCupom;
#else
        event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaCupom;
#endif      

#if COM_INTEROP
        event SubtotalizaCupomEventHandler OnAntesSubtotalizaNaoFiscal;
#else
        event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaNaoFiscal;
#endif     

#if COM_INTEROP
        event SangriaSuprimentoEventHandler OnAntesSuprimento;
#else
        event EventHandler<SangriaSuprimentoEventArgs> OnAntesSuprimento;
#endif           

#if COM_INTEROP
        event VendeItemEventHandler OnAntesVendeItem;
#else
        event EventHandler<VendeItemEventArgs> OnAntesVendeItem;
#endif         

#if COM_INTEROP
        event BobinaAdicionaLinhasEventHandler OnBobinaAdicionaLinhas;
#else
        event EventHandler<BobinaAdicionaLinhasEventArgs> OnBobinaAdicionaLinhas;
#endif

#if COM_INTEROP
        event ChangeEstadoEventHandler OnChangeEstado;
#else
        event EventHandler<ChangeEstadoEventArgs> OnChangeEstado;
#endif

#if COM_INTEROP
        event ChequeEstadoEventHandler OnChequeEstado;
#else
        event EventHandler<ChequeEstadoEventArgs> OnChequeEstado;
#endif

#if COM_INTEROP
        event AbreCupomEventHandler OnDepoisAbreCupom;
#else
        event EventHandler<AbreCupomEventArgs> OnDepoisAbreCupom;
#endif

        event EventHandler OnDepoisAbreCupomVinculado;

#if COM_INTEROP
        event AbreCupomEventHandler OnDepoisAbreNaoFiscal;
#else
        event EventHandler<AbreCupomEventArgs> OnDepoisAbreNaoFiscal;
#endif

#if COM_INTEROP
        event RelatorioGerencialEventHandler OnDepoisAbreRelatorioGerencial;
#else
        event EventHandler<RelatorioGerencialEventArgs> OnDepoisAbreRelatorioGerencial;
#endif

        event EventHandler OnDepoisCancelaCupom;

#if COM_INTEROP
        event CancelaItemEventHandler OnDepoisCancelaItemNaoFiscal;
#else
        event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemNaoFiscal;
#endif

#if COM_INTEROP
        event CancelaItemEventHandler OnDepoisCancelaItemVendido;
#else
        event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemVendido;
#endif

        event EventHandler OnDepoisCancelaNaoFiscal;

#if COM_INTEROP
        event EfetuaPagamentoEventHandler OnDepoisEfetuaPagamento;
#else
        event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamento;
#endif

#if COM_INTEROP
        event EfetuaPagamentoEventHandler OnDepoisEfetuaPagamentoNaoFiscal;
#else
        event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamentoNaoFiscal;
#endif

#if COM_INTEROP
        event FechaCupomEventHandler OnDepoisFechaCupom;
#else
        event EventHandler<FechaCupomEventArgs> OnDepoisFechaCupom;
#endif

#if COM_INTEROP
        event FechaCupomEventHandler OnDepoisFechaNaoFiscal;
#else
        event EventHandler<FechaCupomEventArgs> OnDepoisFechaNaoFiscal;
#endif

        event EventHandler OnDepoisFechaRelatorio;

        event EventHandler OnDepoisLeituraX;

        event EventHandler OnDepoisReducaoZ;

#if COM_INTEROP
        event SangriaSuprimentoEventHandler OnDepoisSangria;
#else
        event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSangria;
#endif

#if COM_INTEROP
        event SubtotalizaCupomEventHandler OnDepoisSubtotalizaCupom;
#else
        event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaCupom;
#endif

#if COM_INTEROP
        event SubtotalizaCupomEventHandler OnDepoisSubtotalizaNaoFiscal;
#else
        event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaNaoFiscal;
#endif

#if COM_INTEROP
        event SangriaSuprimentoEventHandler OnDepoisSuprimento;
#else
        event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSuprimento;
#endif

#if COM_INTEROP
        event VendeItemEventHandler OnDepoisVendeItem;
#else
        event EventHandler<VendeItemEventArgs> OnDepoisVendeItem;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorAbreCupom;
#else
        event EventHandler<ErrorEventArgs> OnErrorAbreCupom;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorAbreCupomVinculado;
#else
        event EventHandler<ErrorEventArgs> OnErrorAbreCupomVinculado;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorAbreNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorAbreNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorRelatorioEventHandler OnErrorAbreRelatorioGerencial;
#else
        event EventHandler<ErrorRelatorioEventArgs> OnErrorAbreRelatorioGerencial;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorCancelaCupom;
#else
        event EventHandler<ErrorEventArgs> OnErrorCancelaCupom;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorCancelaItemNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorCancelaItemNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorCancelaItemVendido;
#else
        event EventHandler<ErrorEventArgs> OnErrorCancelaItemVendido;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorCancelaNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorCancelaNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorEfetuaPagamento;
#else
        event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamento;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorEfetuaPagamentoNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamentoNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorFechaCupom;
#else
        event EventHandler<ErrorEventArgs> OnErrorFechaCupom;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorFechaNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorFechaNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorFechaRelatorio;
#else
        event EventHandler<ErrorEventArgs> OnErrorFechaRelatorio;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorLeituraX;
#else
        event EventHandler<ErrorEventArgs> OnErrorLeituraX;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorReducaoZ;
#else
        event EventHandler<ErrorEventArgs> OnErrorReducaoZ;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorSangria;
#else
        event EventHandler<ErrorEventArgs> OnErrorSangria;
#endif

        event EventHandler OnErrorSemPapel;

#if COM_INTEROP
        event OnErrorEventHandler OnErrorSubtotalizaCupom;
#else
        event EventHandler<ErrorEventArgs> OnErrorSubtotalizaCupom;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorSubtotalizaNaoFiscal;
#else
        event EventHandler<ErrorEventArgs> OnErrorSubtotalizaNaoFiscal;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorSuprimento;
#else
        event EventHandler<ErrorEventArgs> OnErrorSuprimento;
#endif

#if COM_INTEROP
        event OnErrorEventHandler OnErrorVendeItem;
#else
        event EventHandler<ErrorEventArgs> OnErrorVendeItem;
#endif

#if COM_INTEROP
        event OnMsgEventHandler OnMsgAguarde;
#else
        event EventHandler<MsgEventArgs> OnMsgAguarde;
#endif

#if COM_INTEROP
        event OnMsgRetentarEventHandler OnMsgRetentar;
#else
        event EventHandler<MsgRetentarEventArgs> OnMsgRetentar;
#endif

#if COM_INTEROP
        event OnPAFCalcEADEventHandler OnPAFCalcEAD;
#else
        event EventHandler<PAFCalcEADEventArgs> OnPAFCalcEAD;
#endif

#if COM_INTEROP
        event ChaveEventHandler OnPAFGetKeyRSA;
#else
        event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA;
#endif

        void AbreCupom(string cpfCnpj = "", string nome = "", string endereco = "", bool ModoPreVenda = false);

#if !COM_INTEROP
        void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor);
#endif

        void AbreCupomVinculado(string coo, string codFormaPagto, decimal valor);

#if COM_INTEROP
        void AbreCupomVinculadoCNF(string coo, string codFormaPagto, string codComprovanteNaoFiscal, [MarshalAs(UnmanagedType.Currency)] decimal valor);
#else
        void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor);
#endif

        void AbreGaveta();

        void AbreNaoFiscal(string cpfCnpj = "", string nome = "", string endereco = "");

        void AbreRelatorioGerencial(int indice = 0);

        ComprovanteNaoFiscal AchaCNFDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true);

        FormaPagamento AchaFPGDescricao(string descricao, bool buscaExata = true, bool ignoreCase = true);

        FormaPagamento AchaFPGIndice(string indice);

        bool AcharECF(bool Modelo = true, bool Porta = true, int TimeOut = 3);

        bool AcharPorta(int TimeOut = 3);

        void ArquivoMFD_DLL(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, params TipoDocumento[] Documentos);

        void ArquivoMFD_DLL(int COOInicial, int COOFinal, string CaminhoArquivo, FinalizaArqMFD Finaliza = FinalizaArqMFD.MFD, TipoContador TipoContador = TipoContador.COO, params TipoDocumento[] Documentos);

        void Ativar();

        void CancelaCupom();

        void CancelaDescontoAcrescimoItem(int numItem);

        void CancelaDescontoAcrescimoSubTotal(string tipoAcrescimoDesconto);

        void CancelaImpressaoCheque();

        void CancelaItemVendido(int numItem);

        void CancelaItemVendidoParcial(int numItem, decimal quantidade);

        void CancelaNaoFiscal();

        void CarregaAliquotas();

        void CarregaComprovantesNaoFiscais();

        void CarregaFormasPagamento();

        void CarregaRelatoriosGerenciais();

        void CorrigeEstadoErro(bool reducaoZ = true);

        void CortaPapel(bool corteParcial = false);

        string DadosReducaoZ();

        string DadosUltimaReducaoZ();

        void DAV_Abrir(DateTime emissao, string decrdocumento, string numero, string situacao, string vendedor, string observacao, string cpfCnpj, string nome, string endereco, string numFabricacao = "", string marca = "", string modelo = "", string ano = "", string placa = "", string renavam = "", int indice = 0);

        void DAV_Fechar(string observacao, decimal desconto = 0m, decimal acrescimo = 0m);

        void DAV_RegistrarItem(string codigo, string descricao, string unidade, decimal quantidade, decimal vlrunitario, decimal desconto, decimal acrescimo, bool cancelado);

        void Desativar();

        void DescontoAcrescimoItemAnterior(decimal valorDesconto, string descontoAcrescimo, string tipodescontoAcrescimo = "%", int item = 0);

        void DoAtualizarValorGT();

        void DoVerificaValorGT();

        void EfetuaPagamento(string codFormaPagto, decimal valor, string observacao = "", bool imprimeVinculado = false);

        void EfetuaPagamentoNaoFiscal(string codFormaPagto, decimal valor, string observacao = "", bool imprimeVinculado = false);

        bool EmLinha(int timeOut = 1);

        string EnviaComando(string cmd, int timeout = -1);

        void EstornaPagamento(string codFormaPagtoEstornar, string codFormaPagtoEfetivar, double valor, string observacao);

        void FechaCupom(string observacao = "");

        void FechaNaoFiscal(string observacao = "", int IndiceBMP = 0);

        void FechaRelatorio();

        string GetRodapePaf();

        void IdentificaConsumidor(string cpfCnpj, string nome, string endereco);

        void IdentificaOperador(string nome);

        void IdentificaPAF(string nomeVersao, string md5);

        void ImprimeCheque(string Banco, decimal Valor, string Favorecido, string Cidade, DateTime Data, string Observacao = "");

        void LegendaInmetroProximoItem();

        string LeituraCMC7();

#if COM_INTEROP
        void LeituraMemoriaFiscalPorData(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
#else
        void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
#endif

#if COM_INTEROP
        void LeituraMemoriaFiscalPorCRZ(int reducaoInicial, int reducaoFinal, bool simplificada = false);
#else
        void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada = false);
#endif

#if COM_INTEROP
        string LeituraMemoriaFiscalSerialPorData(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
#else
        string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);
#endif

#if COM_INTEROP
        string LeituraMemoriaFiscalSerialPorCRZ(int reducaoInicial, int reducaoFinal, bool simplificada = false);
#else
        string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada = false);
#endif

#if COM_INTEROP
        void LeituraMemoriaFiscalSerialPorData(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false);
#else
        void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false);
#endif

#if COM_INTEROP
        void LeituraMemoriaFiscalSerialPorCRZ(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false);
#else
        void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false);
#endif

        void LeituraX();

        void LerTotaisAliquota();

        void LerTotaisComprovanteNaoFiscal();

        void LerTotaisFormaPagamento();

        void LerTotaisRelatoriosGerenciais();

        void LinhaCupomVinculado(string linha);

#if !COM_INTEROP
        void LinhaCupomVinculado(string[] linhas);
#endif

        void LinhaRelatorioGerencial(string linha, int indiceBMP = 0);

        void LinhaRelatorioGerencial(string[] linhas, int indiceBMP = 0);

        void MudaArredondamento(bool arredonda);

        void MudaHorarioVerao();

        void PafMF_ArqMF(string pathArquivo);

        void PafMF_ArqMFD(string pathArquivo);

        void PafMF_Binario(string pathArquivo);

        void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

#if COM_INTEROP
        void PafMF_LMFC_Cotepe1704PorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#else
        void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFC_Cotepe1704PorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#else
        void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFC_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#else
        void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFC_EspelhoPorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#else
        void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFC_ImpressaoPorData(DateTime DataInicial, DateTime DataFinal);
#else
        void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal);
#endif

#if COM_INTEROP
        void PafMF_LMFC_ImpressaoPorCRZ(int CRZInicial, int CRZFinal);
#else
        void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal);
#endif

#if COM_INTEROP
        void PafMF_LMFS_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#else
        void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFS_EspelhoPorCRZ(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#else
        void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_LMFS_ImpressaoPorData(DateTime DataInicial, DateTime DataFinal);
#else
        void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal);
#endif

#if COM_INTEROP
        void PafMF_LMFS_ImpressaoPorCRZ(int CRZInicial, int CRZFinal);
#else
        void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal);
#endif

 #if COM_INTEROP
        void PafMF_MFD_Cotepe1704PorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#else
        void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_MFD_Cotepe1704PorCOO(int COOInicial, int COOFinal, string CaminhoArquivo);
#else
        void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_MFD_EspelhoPorData(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#else
        void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);
#endif

#if COM_INTEROP
        void PafMF_MFD_EspelhoPorCOO(int COOInicial, int COOFinal, string CaminhoArquivo);
#else
        void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo);
#endif

        void PafMF_LX_Impressao();

#if COM_INTEROP
        void PafMF_RelDAVEmitidos(ref DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio);
#else
        void PafMF_RelDAVEmitidos(DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio);
#endif

#if COM_INTEROP
        void PafMF_RelMeiosPagamento(ref FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio);
#else
        void PafMF_RelMeiosPagamento(FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio);
#endif

#if COM_INTEROP
        void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF = null, int indiceRelatorio = 1);

        void PafMF_RelParametrosConfiguracao2(string perfil, int indiceRelatorio = 1);
#else
        void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF = null, int indiceRelatorio = 1);

        void PafMF_RelParametrosConfiguracao(string perfil, int indiceRelatorio = 1);
#endif

        void PreparaTEF();

        void ProgramaAliquota(decimal aliquota, string tipo, string posicao = "");

        void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao = "");

        void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao = "");

        void ProgramaRelatoriosGerenciais(string descricao, string posicao = "");

        void PulaLinhas(int numLinhas);

        void ReducaoZ();

        void ReducaoZ([Optional]DateTime data);

        void RegistraItemNaoFiscal(string codCNF, decimal value, string obs = "");

        void ReimpressaoVinculado();

        void RelatorioGerencial(IEnumerable<string> relatorio, int vias = 1, int indice = 0);

        void RelatorioGerencial(List<string> relatorio, int vias = 1, int indice = 0);

        void RelatorioGerencial(string[] relatorio, int vias = 1, int indice = 0);

        void Sangria(decimal valor, string obs, string DescricaoCNF = "SANGRIA", string DescricaoFPG = "DINHEIRO", int indicebmp = 0);

        void SegundaViaVinculado();

        void SubtotalizaCupom(decimal descontoAcrescimo = 0m, string mensagemRodape = "");

        void SubtotalizaNaoFiscal(decimal descontoAcrescimo, string mensagemRodape = "");

        void Suprimento(decimal valor, string obs, string DescricaoCNF = "SUPRIMENTO", string DescricaoFPG = "DINHEIRO", int indicebmp = 0);

        void TestaPodeAbrirCupom();

        void VendeItem(string codigo, string descricao, string aliquotaICMS, decimal qtd, decimal valorUnitario, decimal descontoPorc = 0m, string unidade = "UN", string tipoDescontoAcrescimo = "%", string descontoAcrescimo = "D", int CodDepartamento = -1);

        void VendeItemEx(string codigo, string descricao, string aliquotaICMS, decimal qtd,
            decimal valorUnitario, decimal descontoPorc = 0M,
            string unidade = "UN", string tipoDescontoAcrescimo = "%", string descontoAcrescimo = "D", int CodDepartamento = -1,
            string EAN13 = "", int CasasDecimaisQtde = 0, int CasasDecimaisValor = 0, char ArredondaTrunca = 'A', string NCM = "",
            string CFOP = "", string InformacaoAdicional = "",
            decimal TotalDosTributos = 0, int OrigemProduto = 0, string CST_ICMS = "", int ModalidadeBCICMS = 0,
            decimal PercentualReducaoBCICMS = 0, string CSOSN = "",
            decimal ValorBaseCalculoSN = 0, decimal ValorICMSRetidoSN = 0,
            decimal AliquotaCalculoCreditoSN = 0,
            decimal ValorCreditoICMSSN = 0, string ItemListaServico = "",
            string CodigoISS = "", string NaturezaOperacaoISS = "", int IndicadorIncentivoFiscalISS = 1,
            string CodigoIBGE = "", int ModalidadeBCICMSST = 0, decimal PercentualMargemICMSST = 0,
            decimal PercentualReducaoBCICMSST = 0,
            decimal ValorReducaoBCICMSST = 0, decimal AliquotaICMSST = 0,
            decimal ValorICMSST = 0, decimal ValorICMSDesonerado = 0,
            int MotivoDesoneracaoICMS = 9);
    }
}