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

        event EventHandler<AbreCupomEventArgs> OnAntesAbreCupom;

        event EventHandler OnAntesAbreCupomVinculado;

        event EventHandler<AbreCupomEventArgs> OnAntesAbreNaoFiscal;

        event EventHandler<RelatorioGerencialEventArgs> OnAntesAbreRelatorioGerencial;

        event EventHandler OnAntesCancelaCupom;

        event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemNaoFiscal;

        event EventHandler<CancelaItemEventArgs> OnAntesCancelaItemVendido;

        event EventHandler OnAntesCancelaNaoFiscal;

        event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamento;

        event EventHandler<EfetuaPagamentoEventArgs> OnAntesEfetuaPagamentoNaoFiscal;

        event EventHandler<FechaCupomEventArgs> OnAntesFechaCupom;

        event EventHandler<FechaCupomEventArgs> OnAntesFechaNaoFiscal;

        event EventHandler OnAntesFechaRelatorio;

        event EventHandler OnAntesLeituraX;

        event EventHandler OnAntesReducaoZ;

        event EventHandler<SangriaSuprimentoEventArgs> OnAntesSangria;

        event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaCupom;

        event EventHandler<SubtotalizaCupomEventArgs> OnAntesSubtotalizaNaoFiscal;

        event EventHandler<SangriaSuprimentoEventArgs> OnAntesSuprimento;

        event EventHandler<VendeItemEventArgs> OnAntesVendeItem;

        event EventHandler<BobinaAdicionaLinhasEventArgs> OnBobinaAdicionaLinhas;

        event EventHandler<ChangeEstadoEventArgs> OnChangeEstado;

        event EventHandler<ChequeEstadoEventArgs> OnChequeEstado;

        event EventHandler<AbreCupomEventArgs> OnDepoisAbreCupom;

        event EventHandler OnDepoisAbreCupomVinculado;

        event EventHandler<AbreCupomEventArgs> OnDepoisAbreNaoFiscal;

        event EventHandler<RelatorioGerencialEventArgs> OnDepoisAbreRelatorioGerencial;

        event EventHandler OnDepoisCancelaCupom;

        event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemNaoFiscal;

        event EventHandler<CancelaItemEventArgs> OnDepoisCancelaItemVendido;

        event EventHandler OnDepoisCancelaNaoFiscal;

        event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamento;

        event EventHandler<EfetuaPagamentoEventArgs> OnDepoisEfetuaPagamentoNaoFiscal;

        event EventHandler<FechaCupomEventArgs> OnDepoisFechaCupom;

        event EventHandler<FechaCupomEventArgs> OnDepoisFechaNaoFiscal;

        event EventHandler OnDepoisFechaRelatorio;

        event EventHandler OnDepoisLeituraX;

        event EventHandler OnDepoisReducaoZ;

        event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSangria;

        event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaCupom;

        event EventHandler<SubtotalizaCupomEventArgs> OnDepoisSubtotalizaNaoFiscal;

        event EventHandler<SangriaSuprimentoEventArgs> OnDepoisSuprimento;

        event EventHandler<VendeItemEventArgs> OnDepoisVendeItem;

        event EventHandler<ErrorEventArgs> OnErrorAbreCupom;

        event EventHandler<ErrorEventArgs> OnErrorAbreCupomVinculado;

        event EventHandler<ErrorEventArgs> OnErrorAbreNaoFiscal;

        event EventHandler<ErrorRelatorioEventArgs> OnErrorAbreRelatorioGerencial;

        event EventHandler<ErrorEventArgs> OnErrorCancelaCupom;

        event EventHandler<ErrorEventArgs> OnErrorCancelaItemNaoFiscal;

        event EventHandler<ErrorEventArgs> OnErrorCancelaItemVendido;

        event EventHandler<ErrorEventArgs> OnErrorCancelaNaoFiscal;

        event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamento;

        event EventHandler<ErrorEventArgs> OnErrorEfetuaPagamentoNaoFiscal;

        event EventHandler<ErrorEventArgs> OnErrorFechaCupom;

        event EventHandler<ErrorEventArgs> OnErrorFechaNaoFiscal;

        event EventHandler<ErrorEventArgs> OnErrorFechaRelatorio;

        event EventHandler<ErrorEventArgs> OnErrorLeituraX;

        event EventHandler<ErrorEventArgs> OnErrorReducaoZ;

        event EventHandler<ErrorEventArgs> OnErrorSangria;

        event EventHandler OnErrorSemPapel;

        event EventHandler<ErrorEventArgs> OnErrorSubtotalizaCupom;

        event EventHandler<ErrorEventArgs> OnErrorSubtotalizaNaoFiscal;

        event EventHandler<ErrorEventArgs> OnErrorSuprimento;

        event EventHandler<ErrorEventArgs> OnErrorVendeItem;

        event EventHandler<MsgEventArgs> OnMsgAguarde;

        event EventHandler OnMsgPoucoPapel;

        event EventHandler<MsgRetentarEventArgs> OnMsgRetentar;

        event EventHandler<PAFCalcEADEventArgs> OnPAFCalcEAD;

        event EventHandler<ChaveEventArgs> OnPAFGetKeyRSA;

        void AbreCupom(string cpfCnpj = "", string nome = "", string endereco = "", bool ModoPreVenda = false);

        void AbreCupomVinculado(int coo, string codFormaPagto, decimal valor);

        void AbreCupomVinculado(string coo, string codFormaPagto, decimal valor);

        void AbreCupomVinculado(string coo, string codFormaPagto, string codComprovanteNaoFiscal, decimal valor);

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

        void LeituraMemoriaFiscal(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);

        void LeituraMemoriaFiscal(int reducaoInicial, int reducaoFinal, bool simplificada = false);

        string LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, bool simplificada = false);

        string LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, bool simplificada = false);

        void LeituraMemoriaFiscalSerial(DateTime dataInicial, DateTime dataFinal, string nomeArquivo, bool simplificada = false);

        void LeituraMemoriaFiscalSerial(int reducaoInicial, int reducaoFinal, string nomeArquivo, bool simplificada = false);

        void LeituraX();

        void LerTotaisAliquota();

        void LerTotaisComprovanteNaoFiscal();

        void LerTotaisFormaPagamento();

        void LerTotaisRelatoriosGerenciais();

        void LinhaCupomVinculado(string linha);

        void LinhaCupomVinculado(string[] linhas);

        void LinhaRelatorioGerencial(string linha, int indiceBMP = 0);

        void LinhaRelatorioGerencial(string[] linhas, int indiceBMP = 0);

        void MudaArredondamento(bool arredonda);

        void MudaHorarioVerao();

        void PafMF_ArqMF(string pathArquivo);

        void PafMF_ArqMFD(string pathArquivo);

        void PafMF_Binario(string pathArquivo);

        void PafMF_GerarCAT52(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_LMFC_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_LMFC_Cotepe1704(int CRZInicial, int CRZFinal, string CaminhoArquivo);

        void PafMF_LMFC_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_LMFC_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);

        void PafMF_LMFC_Impressao(DateTime DataInicial, DateTime DataFinal);

        void PafMF_LMFC_Impressao(int CRZInicial, int CRZFinal);

        void PafMF_LMFS_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_LMFS_Espelho(int CRZInicial, int CRZFinal, string CaminhoArquivo);

        void PafMF_LMFS_Impressao(DateTime DataInicial, DateTime DataFinal);

        void PafMF_LMFS_Impressao(int CRZInicial, int CRZFinal);

        void PafMF_LX_Impressao();

        void PafMF_MFD_Cotepe1704(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_MFD_Cotepe1704(int COOInicial, int COOFinal, string CaminhoArquivo);

        void PafMF_MFD_Espelho(DateTime DataInicial, DateTime DataFinal, string CaminhoArquivo);

        void PafMF_MFD_Espelho(int COOInicial, int COOFinal, string CaminhoArquivo);

        void PafMF_RelDAVEmitidos(DAVs[] DAVs, string TituloRelatorio, int IndiceRelatorio);

        void PafMF_RelIdentificacaoPafECF(IdenticacaoPaf identificacaoPAF = null, int indiceRelatorio = 0);

        void PafMF_RelMeiosPagamento(FormaPagamento[] formasPagamento, string TituloRelatorio, int indiceRelatorio);

        void PafMF_RelParametrosConfiguracao(InfoPaf infoPAF = null, int indiceRelatorio = 1);

        void PafMF_RelParametrosConfiguracao(string perfil, int indiceRelatorio = 1);

        void PreparaTEF();

        void ProgramaAliquota(decimal aliquota, string tipo, string posicao = "");

        void ProgramaComprovanteNaoFiscal(string descricao, string tipo, string posicao = "");

        void ProgramaFormaPagamento(string descricao, bool permiteVinculado, string posicao = "");

        void ProgramaRelatoriosGerenciais(string descricao, string posicao = "");

        void PulaLinhas(int numLinhas);

        void ReducaoZ();

        void ReducaoZ(DateTime data = default(DateTime));

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
    }
}