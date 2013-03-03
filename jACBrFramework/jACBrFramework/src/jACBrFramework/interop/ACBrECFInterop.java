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


public interface ACBrECFInterop extends InteropLib
{
	public static final ACBrECFInterop INSTANCE = (ACBrECFInterop)Native.loadLibrary(InteropLib.JNA_LIBRARY_NAME, ACBrECFInterop.class);

	// Tipos de dados

	public interface AbreCupomCallback extends Callback
	{
		void invoke(String CPF_CNPJ,String Nome,String Endereco);
	}


	public static class AliquotaRec extends Structure
	{
		public char[] Indice = new char[4];
		public double Aliquota;
		public boolean Tipo;
		public double Total;
		public boolean Sequencia;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Indice" , "Aliquota" , "Tipo" , "Total" , "Sequencia");
		}


		public static class ByReference extends AliquotaRec implements Structure.ByReference{ }
		public static class ByValue extends AliquotaRec implements Structure.ByValue{ }
	}

	public interface BobinaAdicionaLinhasCallback extends Callback
	{
		void invoke(String linhas,String operacao);
	}


	public interface ChangeEstadoCallback extends Callback
	{
		void invoke(int EstadoAnterior,int EstadoAtual);
	}


	public interface ChequeEstadoCallback extends Callback
	{
		boolean invoke(int EstadoAtual);
	}


	public static class ComprovanteNaoFiscalRec extends Structure
	{
		public char[] Indice = new char[4];
		public char[] Descricao = new char[30];
		public boolean PermiteVinculado;
		public char[] FormaPagamento = new char[4];
		public double Total;
		public int Contador;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Indice" , "Descricao" , "PermiteVinculado" , "FormaPagamento" , "Total" , "Contador");
		}


		public static class ByReference extends ComprovanteNaoFiscalRec implements Structure.ByReference{ }
		public static class ByValue extends ComprovanteNaoFiscalRec implements Structure.ByValue{ }
	}

	public static class DAVsRec extends Structure
	{
		public char[] Numero = new char[14];
		public int COO_Cupom;
		public int COO_Dav;
		public char[] Titulo = new char[31];
		public double Valor;
		public double DtEmissao;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Numero" , "COO_Cupom" , "COO_Dav" , "Titulo" , "Valor" , "DtEmissao");
		}


		public static class ByReference extends DAVsRec implements Structure.ByReference{ }
		public static class ByValue extends DAVsRec implements Structure.ByValue{ }
	}

	public interface EfetuaPagamentoCallback extends Callback
	{
		void invoke(String CodFormaPagto,double Valor,String Observacao,boolean ImprimeVinculado);
	}


	public interface FechaCupomCallback extends Callback
	{
		void invoke(String Observacao,int IndiceBMP);
	}


	public static class FormaPagamentoRec extends Structure
	{
		public byte[] Indice = new byte[4];
		public byte[] Descricao = new byte[30];
		public boolean PermiteVinculado;
		public double Total;
		public double Data;
		public byte[] TipoDoc = new byte[30];


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Indice" , "Descricao" , "PermiteVinculado" , "Total" , "Data" , "TipoDoc");
		}


		public static class ByReference extends FormaPagamentoRec implements Structure.ByReference{ }
		public static class ByValue extends FormaPagamentoRec implements Structure.ByValue{ }
	}

	public interface GetKeyCallback extends Callback
	{
		String invoke();
	}


	public interface IntArgumentCallback extends Callback
	{
		void invoke(int value);
	}


	public interface NoArgumentCallback extends Callback
	{
		void invoke();
	}


	public interface OnErrorCallback extends Callback
	{
		boolean invoke();
	}


	public interface OnErrorRelatorioCallback extends Callback
	{
		boolean invoke(int Indice);
	}


	public interface OnMsgRetentarCallback extends Callback
	{
		boolean invoke(String Mensagem,String Situacao);
	}


	public static class RelatorioGerencialRec extends Structure
	{
		public char[] Indice = new char[4];
		public char[] Descricao = new char[30];
		public int Contador;


		@Override
		protected List<String> getFieldOrder()
		{
			return Arrays.asList("Indice" , "Descricao" , "Contador");
		}


		public static class ByReference extends RelatorioGerencialRec implements Structure.ByReference{ }
		public static class ByValue extends RelatorioGerencialRec implements Structure.ByValue{ }
	}

	public interface SangriaSuprimentoCallback extends Callback
	{
		void invoke(double Valor,String Obs,String DescricaoCNF,String DescricaoFPG);
	}


	public interface StringCallback extends Callback
	{
		void invoke(String Mensagem);
	}


	public interface SubtotalizaCupomCallback extends Callback
	{
		void invoke(double DescontoAcrescimo,String MensagemRodape);
	}


	public interface VendeItemCallback extends Callback
	{
		void invoke(String Codigo,String Descricao,String AliquotaICMS,double Qtd,double ValorUnitario,double ValorDescontoAcrescimo,String Unidade,String TipoDescontoAcrescimo,String DescontoAcrescimo);
	}



	// Funções

	int ECF_AbreCupom(int ecfHandle, String cpfCnpj, String nome, String endereco, boolean ModoPreVenda);
	int ECF_AbreCupomVinculado(int ecfHandle, String coo, String codFormaPagto, double valor);
	int ECF_AbreCupomVinculadoCNF(int ecfHandle, String coo, String codFormaPagto, String codComprovanteNaoFiscal, double valor);
	int ECF_AbreGaveta(int ecfHandle);
	int ECF_AbreNaoFiscal(int ecfHandle, String cpfCnpj, String nome, String endereco);
	int ECF_AbreRelatorioGerencial(int ecfHandle, int indice);
	int ECF_AchaCNFDescricao(int ecfHandle, ACBrECFInterop.ComprovanteNaoFiscalRec comprovanteNaoFiscal, String descricao, boolean busca, boolean ignore);
	int ECF_AchaFPGDescricao(int ecfHandle, String descricao, boolean buscaexata, boolean ignorecase, ACBrECFInterop.FormaPagamentoRec formaPagamento);
	int ECF_AchaFPGIndice(int ecfHandle, String indice, ACBrECFInterop.FormaPagamentoRec formaPagamento);
	int ECF_AcharECF(int ecfHandle, boolean Modelo, boolean Porta, int TimeOut);
	int ECF_AcharPorta(int ecfHandle, int TimeOut);
	int ECF_ArquivoMFD_DLL(int ecfHandle, double DaTaInicial, double DaTaFinal, String Arquivo, int Documentos[], int QTD_DOC, int Finalidade);
	int ECF_ArquivoMFD_DLL_COO(int ecfHandle, int COOInicial, int COOFinal, String Arquivo, int Documentos[], int QTD_DOC, int Finalidade, int TipoContador);
	int ECF_Ativar(int ecfHandle);
	int ECF_CancelaCupom(int ecfHandle);
	int ECF_CancelaDescontoAcrescimoItem(int ecfHandle, int numItem);
	int ECF_CancelaDescontoAcrescimoSubTotal(int ecfHandle, char tipoAcrescimoDesconto);
	int ECF_CancelaImpressaoCheque(int ecfHandle);
	int ECF_CancelaItemVendido(int ecfHandle, int numItem);
	int ECF_CancelaItemVendidoParcial(int ecfHandle, int numItem, double quantidade);
	int ECF_CancelaNaoFiscal(int ecfHandle);
	int ECF_CarregaAliquotas(int ecfHandle);
	int ECF_CarregaComprovantesNaoFiscais(int ecfHandle);
	int ECF_CarregaFormasPagamento(int ecfHandle);
	int ECF_CarregaRelatoriosGerenciais(int ecfHandle);
	int ECF_ConfigBarras_GetAltura(int ecfHandle, IntByReference value);
	int ECF_ConfigBarras_GetLarguraLinha(int ecfHandle, IntByReference value);
	int ECF_ConfigBarras_GetMostrarCodigo(int ecfHandle);
	int ECF_ConfigBarras_SetAltura(int ecfHandle, int value);
	int ECF_ConfigBarras_SetLarguraLinha(int ecfHandle, int value);
	int ECF_ConfigBarras_SetMostrarCodigo(int ecfHandle, boolean value);
	int ECF_Consumidor_AtribuiConsumidor(int ecfHandle, String CPF_CNPJ, String Nome, String Endereco);
	int ECF_Consumidor_GetAtribuido(int ecfHandle);
	int ECF_Consumidor_GetDocumento(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_Consumidor_GetEndereco(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_Consumidor_GetEnviado(int ecfHandle);
	int ECF_Consumidor_GetNome(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_Consumidor_SetEnviado(int ecfHandle, boolean value);
	int ECF_Consumidor_Zera(int ecfHandle);
	int ECF_CorrigeEstadoErro(int ecfHandle, boolean reducaoZ);
	int ECF_CortaPapel(int ecfHandle, boolean corteParcial);
	int ECF_Create(IntByReference ecfHandle);
	int ECF_DadosReducaoZClass_CalculaValoresVirtuais(int ecfHandle);
	int ECF_DadosReducaoZClass_GetAcrescimoICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetAcrescimoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetAcrescimoOPNF(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetCancelamentoICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetCancelamentoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetCancelamentoOPNF(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetCCDC(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCCF(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCDC(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCFC(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCFD(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCNF(int ecfHandle, ACBrECFInterop.ComprovanteNaoFiscalRec record, int value);
	int ECF_DadosReducaoZClass_GetCNFCount(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCOO(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCRO(int ecfHandle);
	int ECF_DadosReducaoZClass_GetCRZ(int ecfHandle);
	int ECF_DadosReducaoZClass_GetDataDaImpressora(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetDataDoMovimento(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetDescontoICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetDescontoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetDescontoOPNF(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetFPG(int ecfHandle, ACBrECFInterop.FormaPagamentoRec record, int value);
	int ECF_DadosReducaoZClass_GetFPGCount(int ecfHandle);
	int ECF_DadosReducaoZClass_GetGNF(int ecfHandle);
	int ECF_DadosReducaoZClass_GetGNFC(int ecfHandle);
	int ECF_DadosReducaoZClass_GetGRG(int ecfHandle);
	int ECF_DadosReducaoZClass_GetICMS(int ecfHandle, ACBrECFInterop.AliquotaRec record, int value);
	int ECF_DadosReducaoZClass_GetICMSCount(int ecfHandle);
	int ECF_DadosReducaoZClass_GetIsentoICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetIsentoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetISSQN(int ecfHandle, ACBrECFInterop.AliquotaRec record, int value);
	int ECF_DadosReducaoZClass_GetISSQNCount(int ecfHandle);
	int ECF_DadosReducaoZClass_GetNaoTributadoICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetNaoTributadoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetNCN(int ecfHandle);
	int ECF_DadosReducaoZClass_GetNumeroCOOInicial(int ecfHandle, ByteBuffer buffer, int bufferlen);
	int ECF_DadosReducaoZClass_GetNumeroDaLoja(int ecfHandle, ByteBuffer buffer, int bufferlen);
	int ECF_DadosReducaoZClass_GetNumeroDeSerie(int ecfHandle, ByteBuffer buffer, int bufferlen);
	int ECF_DadosReducaoZClass_GetNumeroDeSerieMFD(int ecfHandle, ByteBuffer buffer, int bufferlen);
	int ECF_DadosReducaoZClass_GetNumeroDoECF(int ecfHandle, ByteBuffer buffer, int bufferlen);
	int ECF_DadosReducaoZClass_GetRG(int ecfHandle, ACBrECFInterop.RelatorioGerencialRec record, int value);
	int ECF_DadosReducaoZClass_GetRGCount(int ecfHandle);
	int ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetTotalICMS(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetTotalISSQN(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetTotalTroco(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetValorGrandeTotal(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetValorVendaBruta(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_GetVendaLiquida(int ecfHandle, DoubleByReference value);
	int ECF_DadosReducaoZClass_MontaDadosReducaoZ(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_DAV_Abrir(int ecfHandle, double emissao, String decrdocumento, String numero, String situacao, String vendedor, String observacao, String cpfCnpj, String nome, String endereco, int indice);
	int ECF_DAV_Fechar(int ecfHandle, String observacao);
	int ECF_DAV_RegistrarItem(int ecfHandle, String codigo, String descricao, String unidade, double quantidade, double vlrunitario, double desconto, double acrescimo, boolean cancelado);
	int ECF_Desativar(int ecfHandle);
	int ECF_DescontoAcrescimoItemAnterior(int ecfHandle, double valorDescontoAcrescimo, String descontoAcrescimo, String TipoDescontoAcrescimo, int Item);
	int ECF_Destroy(int ecfHandle);
	int ECF_DoAtualizarValorGT(int ecfHandle);
	int ECF_DoVerificaValorGT(int ecfHandle);
	int ECF_EfetuaPagamento(int ecfHandle, String codFormaPagto, double valor, String observacao, boolean imprimeVinculado);
	int ECF_EfetuaPagamentoNaoFiscal(int ecfHandle, String codFormaPagto, double valor, String observacao, boolean imprimeVinculado);
	int ECF_EnviaComando(int ecfHandle, String cmd, int timeout, ByteBuffer buffer, int bufferlen);
	int ECF_EspelhoMFD_DLL(int ecfHandle, double DaTaInicial, double DaTaFinal, String Arquivo, int Documentos[], int QTD_DOC);
	int ECF_EspelhoMFD_DLL_COO(int ecfHandle, int COOInicial, int COOFinal, String Arquivo, int Documentos[], int QTD_DOC);
	int ECF_EstornaPagamento(int ecfHandle, String codFormaPagtoEstornar, String codFormaPagtoEfetivar, double valor, String observacao);
	int ECF_FechaCupom(int ecfHandle, String observacao);
	int ECF_FechaNaoFiscal(int ecfHandle, String observacao, int indicebmp);
	int ECF_FechaRelatorio(int ecfHandle);
	int ECF_GetAbout(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetAguardaImpressao(int ecfHandle);
	int ECF_GetAguardandoResposta(int ecfHandle);
	int ECF_GetALCount(int ecfHandle, IntByReference value);
	int ECF_GetAliquota(int ecfHandle, ACBrECFInterop.AliquotaRec aliquota, int index);
	int ECF_GetArqLOG(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetArredonda(int ecfHandle);
	int ECF_GetArredondaItemMFD(int ecfHandle);
	int ECF_GetArredondaPorQtd(int ecfHandle);
	int ECF_GetAtivo(int ecfHandle);
	int ECF_GetChequePronto(int ecfHandle);
	int ECF_GetCliche(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetCNFCount(int ecfHandle, IntByReference value);
	int ECF_GetCNPJ(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetColunas(int ecfHandle);
	int ECF_GetComandoEnviado(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetComandoLOG(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetComprovanteNaoFiscal(int ecfHandle, ACBrECFInterop.ComprovanteNaoFiscalRec comprovanteNaoFiscal, int index);
	int ECF_GetDadosReducaoZ(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetDadosUltimaReducaoZ(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetDataHora(int ecfHandle, DoubleByReference value);
	int ECF_GetDataHoraSB(int ecfHandle, DoubleByReference value);
	int ECF_GetDataMovimento(int ecfHandle, DoubleByReference value);
	int ECF_GetDecimaisPreco(int ecfHandle);
	int ECF_GetDecimaisQtd(int ecfHandle);
	int ECF_GetDescricaoGrande(int ecfHandle);
	int ECF_GetEmLinha(int ecfHandle, int timeOut);
	int ECF_GetEstado(int ecfHandle);
	int ECF_GetFormaPagamento(int ecfHandle, ACBrECFInterop.FormaPagamentoRec formaPagamento, int index);
	int ECF_GetFPGCount(int ecfHandle, IntByReference value);
	int ECF_GetGavetaAberta(int ecfHandle);
	int ECF_GetGavetaSinalInvertido(int ecfHandle);
	int ECF_GetGrandeTotal(int ecfHandle, DoubleByReference value);
	int ECF_GetHorarioVerao(int ecfHandle);
	int ECF_GetIdentificaConsumidorRodape(int ecfHandle);
	int ECF_GetIE(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetIgnorarTagsFormatacao(int ecfHandle);
	int ECF_GetIM(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetIntervaloAposComando(int ecfHandle);
	int ECF_GetLinhasEntreCupons(int ecfHandle);
	int ECF_GetMaxLinhasBuffer(int ecfHandle);
	int ECF_GetMemoParams(int ecfHandle, ByteBuffer linha, int bufferLen, int index);
	int ECF_GetMemoParamsLineCount(int ecfHandle);
	int ECF_GetMFAdicional(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetMFD(int ecfHandle);
	int ECF_GetModelo(int ecfHandle);
	int ECF_GetModeloStr(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCCF(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCDC(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCOO(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCOOInicial(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCRO(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCRZ(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumCupom(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumECF(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumGNF(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumGRG(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumLoja(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumSerie(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumSerieMFD(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetNumUltItem(int ecfHandle);
	int ECF_GetNumVersao(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetOperador(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetPAF(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetPaginaDeCodigo(int ecfHandle);
	int ECF_GetParamDescontoISSQN(int ecfHandle);
	int ECF_GetPausaRelatorio(int ecfHandle);
	int ECF_GetPoucoPapel(int ecfHandle);
	int ECF_GetRelatoriosGerenciais(int ecfHandle, ACBrECFInterop.RelatorioGerencialRec relatorio, int index);
	int ECF_GetRespostaComando(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetRFDID(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetSubModeloECF(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetSubTotal(int ecfHandle, DoubleByReference value);
	int ECF_GetTermica(int ecfHandle);
	int ECF_GetTotalAcrescimos(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalAcrescimosISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalCancelamentos(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalCancelamentosISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalDescontos(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalDescontosISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalIsencao(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalIsencaoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalNaoFiscal(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalNaoTributado(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalNaoTributadoISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalPago(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalSubstituicaoTributaria(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalSubstituicaoTributariaISSQN(int ecfHandle, DoubleByReference value);
	int ECF_GetTotalTroco(int ecfHandle, DoubleByReference value);
	int ECF_GetUltimoErro(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetUsuarioAtual(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_GetVendaBruta(int ecfHandle, DoubleByReference value);
	int ECF_IdentificaConsumidor(int ecfHandle, String cpfCnpj, String nome, String endereco);
	int ECF_IdentificaOperador(int ecfHandle, String nome);
	int ECF_IdentificaPAF(int ecfHandle, String nomeVersao, String md5);
	int ECF_ImprimeCheque(int ecfHandle, String Banco, double Valor, String Favorecido, String Cidade, double Data, String Observacao);
	int ECF_InfoRodapeCupom_GetCupomMania(int ecfHandle);
	int ECF_InfoRodapeCupom_GetDav(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_InfoRodapeCupom_GetDavOs(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_InfoRodapeCupom_GetMD5(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_InfoRodapeCupom_GetMinasLegal(int ecfHandle);
	int ECF_InfoRodapeCupom_GetParaibaLegal(int ecfHandle);
	int ECF_InfoRodapeCupom_GetPreVenda(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_InfoRodapeCupom_NotaLegalDF_GetImprimir(int ecfHandle);
	int ECF_InfoRodapeCupom_NotaLegalDF_GetProgramaDeCredito(int ecfHandle);
	int ECF_InfoRodapeCupom_NotaLegalDF_GetValorICMS(int ecfHandle, DoubleByReference value);
	int ECF_InfoRodapeCupom_NotaLegalDF_GetValorISS(int ecfHandle, DoubleByReference value);
	int ECF_InfoRodapeCupom_NotaLegalDF_SetImprimir(int ecfHandle, boolean value);
	int ECF_InfoRodapeCupom_NotaLegalDF_SetProgramaDeCredito(int ecfHandle, boolean value);
	int ECF_InfoRodapeCupom_NotaLegalDF_SetValorICMS(int ecfHandle, double value);
	int ECF_InfoRodapeCupom_NotaLegalDF_SetValorISS(int ecfHandle, double value);
	int ECF_InfoRodapeCupom_SetCupomMania(int ecfHandle, boolean value);
	int ECF_InfoRodapeCupom_SetDav(int ecfHandle, String value);
	int ECF_InfoRodapeCupom_SetDavOs(int ecfHandle, String value);
	int ECF_InfoRodapeCupom_SetMD5(int ecfHandle, String value);
	int ECF_InfoRodapeCupom_SetMinasLegal(int ecfHandle, boolean value);
	int ECF_InfoRodapeCupom_SetParaibaLegal(int ecfHandle, boolean value);
	int ECF_InfoRodapeCupom_SetPreVenda(int ecfHandle, String value);
	int ECF_LegendaInmetroProximoItem(int ecfHandle);
	int ECF_LeituraCMC7(int ecfHandle, ByteBuffer buffer, int bufferLen);
	int ECF_LeituraMemoriaFiscalArquivoData(int ecfHandle, double dataInicial, double dataFinal, String nomeArquivo, boolean simplificada);
	int ECF_LeituraMemoriaFiscalArquivoReducao(int ecfHandle, int reducaoInicial, int reducaoFinal, String nomeArquivo, boolean simplificada);
	int ECF_LeituraMemoriaFiscalData(int ecfHandle, double dataInicial, double dataFinal, boolean simplificada);
	int ECF_LeituraMemoriaFiscalReducao(int ecfHandle, int reducaoInicial, int reducaoFinal, boolean simplificada);
	int ECF_LeituraMemoriaFiscalSerialData(int ecfHandle, double dataInicial, double dataFinal, boolean simplificada, ByteBuffer buffer, int bufferLen);
	int ECF_LeituraMemoriaFiscalSerialReducao(int ecfHandle, int reducaoInicial, int reducaoFinal, boolean simplificada, ByteBuffer buffer, int bufferLen);
	int ECF_LeituraX(int ecfHandle);
	int ECF_LerTotaisAliquota(int ecfHandle);
	int ECF_LerTotaisComprovanteNaoFiscal(int ecfHandle);
	int ECF_LerTotaisFormaPagamento(int ecfHandle);
	int ECF_LerTotaisRelatoriosGerenciais(int ecfHandle);
	int ECF_LinhaCupomVinculado(int ecfHandle, String linha);
	int ECF_LinhaRelatorioGerencial(int ecfHandle, String linha, int indiceBMP);
	int ECF_MudaArredondamento(int ecfHandle, boolean arredonda);
	int ECF_MudaHorarioVerao(int ecfHandle);
	int ECF_PafMF_GerarCAT52(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFC_Cotepe1704(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFC_Cotepe1704_CRZ(int ecfHandle, int CRZInicial, int CRZFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFC_Espelho(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFC_Espelho_CRZ(int ecfHandle, int CRZInicial, int CRZFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFC_Impressao(int ecfHandle, double DataInicial, double DataFinal);
	int ECF_PafMF_LMFC_Impressao_CRZ(int ecfHandle, int CRZInicial, int CRZFinal);
	int ECF_PafMF_LMFS_Espelho(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFS_Espelho_CRZ(int ecfHandle, int CRZInicial, int CRZFinal, String CaminhoArquivo);
	int ECF_PafMF_LMFS_Impressao(int ecfHandle, double DataInicial, double DataFinal);
	int ECF_PafMF_LMFS_Impressao_CRZ(int ecfHandle, int CRZInicial, int CRZFinal);
	int ECF_PafMF_LX_Impressao(int ecfHandle);
	int ECF_PafMF_MFD_Cotepe1704(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_MFD_Cotepe1704_COO(int ecfHandle, int COOInicial, int COOFinal, String CaminhoArquivo);
	int ECF_PafMF_MFD_Espelho(int ecfHandle, double DataInicial, double DataFinal, String CaminhoArquivo);
	int ECF_PafMF_MFD_Espelho_COO(int ecfHandle, int COOInicial, int COOFinal, String CaminhoArquivo);
	int ECF_PafMF_RelDAVEmitidos(int ecfHandle, ACBrECFInterop.DAVsRec DAVs[], int index, String TituloRelatorio, int IndiceRelatorio);
	int ECF_PafMF_RelIdentificacaoPafECF(int ecfHandle, int aacHandle, int IndiceRelatorio);
	int ECF_PafMF_RelMeiosPagamento(int ecfHandle, ACBrECFInterop.FormaPagamentoRec formasPagamento[], int count, String TituloRelatorio, int IndiceRelatorio);
	int ECF_PafMF_RelParametrosConfiguracao(int ecfHandle, int aacHandle, int IndiceRelatorio);
	int ECF_PreparaTEF(int ecfHandle);
	int ECF_ProgramaAliquota(int ecfHandle, double aliquota, char tipo, String posicao);
	int ECF_ProgramaComprovanteNaoFiscal(int ecfHandle, String descricao, String tipo, String posicao);
	int ECF_ProgramaFormaPagamento(int ecfHandle, String descricao, boolean permiteVinculado, String posicao);
	int ECF_ProgramaRelatoriosGerenciais(int ecfHandle, String descricao, String posicao);
	int ECF_PulaLinhas(int ecfHandle, int numLinhas);
	int ECF_ReducaoZ(int ecfHandle, double data);
	int ECF_RegistraItemNaoFiscal(int ecfHandle, String codCNF, double value, String obs);
	int ECF_ReimpressaoVinculado(int ecfHandle);
	int ECF_RelatorioGerencial(int ecfHandle, String linhas[], int linhasCount, int Via, int Indice);
	int ECF_Sangria(int ecfHandle, double valor, String obs, String DescricaoCNF, String DescricaoFPG, int indicebmp);
	int ECF_SetAAC(int ecfHandle, int aacHandle);
	int ECF_SetAguardaImpressao(int ecfHandle, boolean aguardaImpressao);
	int ECF_SetArqLOG(int ecfHandle, String arqLog);
	int ECF_SetArredondaItemMFD(int ecfHandle, boolean arredonda);
	int ECF_SetArredondaPorQtd(int ecfHandle, boolean arredonda);
	int ECF_SetComandoLOG(int ecfHandle, String comandoLog);
	int ECF_SetDecimaisPreco(int ecfHandle, int decimaisPreco);
	int ECF_SetDecimaisQtd(int ecfHandle, int decimaisQtd);
	int ECF_SetDescricaoGrande(int ecfHandle, boolean descricaoGrande);
	int ECF_SetEAD(int ecfHandle, int eadHandle);
	int ECF_SetGavetaSinalInvertido(int ecfHandle, boolean gavetaSinalInvertido);
	int ECF_SetIgnorarTagsFormatacao(int ecfHandle, boolean ignorar);
	int ECF_SetIntervaloAposComando(int ecfHandle, int intervalo);
	int ECF_SetLinhasEntreCupons(int ecfHandle, int linhasEntreCupons);
	int ECF_SetMaxLinhasBuffer(int ecfHandle, int maxLinhas);
	int ECF_SetMemoParams(int ecfHandle, String linhas[], int count);
	int ECF_SetModelo(int ecfHandle, int modelo);
	int ECF_SetOnAguardandoRespostaChange(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesAbreCupom(int ecfHandle, ACBrECFInterop.AbreCupomCallback method);
	int ECF_SetOnAntesAbreCupomVinculado(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesAbreNaoFiscal(int ecfHandle, ACBrECFInterop.AbreCupomCallback method);
	int ECF_SetOnAntesAbreRelatorioGerencial(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnAntesCancelaCupom(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesCancelaItemNaoFiscal(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnAntesCancelaItemVendido(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnAntesCancelaNaoFiscal(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesEfetuaPagamento(int ecfHandle, ACBrECFInterop.EfetuaPagamentoCallback method);
	int ECF_SetOnAntesEfetuaPagamentoNaoFiscal(int ecfHandle, ACBrECFInterop.EfetuaPagamentoCallback method);
	int ECF_SetOnAntesFechaCupom(int ecfHandle, ACBrECFInterop.FechaCupomCallback method);
	int ECF_SetOnAntesFechaNaoFiscal(int ecfHandle, ACBrECFInterop.FechaCupomCallback method);
	int ECF_SetOnAntesFechaRelatorio(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesLeituraX(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesReducaoZ(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnAntesSangria(int ecfHandle, ACBrECFInterop.SangriaSuprimentoCallback method);
	int ECF_SetOnAntesSubtotalizaCupom(int ecfHandle, ACBrECFInterop.SubtotalizaCupomCallback method);
	int ECF_SetOnAntesSubtotalizaNaoFiscal(int ecfHandle, ACBrECFInterop.SubtotalizaCupomCallback method);
	int ECF_SetOnAntesSuprimento(int ecfHandle, ACBrECFInterop.SangriaSuprimentoCallback method);
	int ECF_SetOnAntesVendeItem(int ecfHandle, ACBrECFInterop.VendeItemCallback method);
	int ECF_SetOnBobinaAdicionaLinhas(int ecfHandle, ACBrECFInterop.BobinaAdicionaLinhasCallback method);
	int ECF_SetOnChangeEstado(int ecfHandle, ACBrECFInterop.ChangeEstadoCallback method);
	int ECF_SetOnChequeEstado(int ecfHandle, ACBrECFInterop.ChequeEstadoCallback method);
	int ECF_SetOnDepoisAbreCupom(int ecfHandle, ACBrECFInterop.AbreCupomCallback method);
	int ECF_SetOnDepoisAbreCupomVinculado(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisAbreNaoFiscal(int ecfHandle, ACBrECFInterop.AbreCupomCallback method);
	int ECF_SetOnDepoisAbreRelatorioGerencial(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnDepoisCancelaCupom(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisCancelaItemNaoFiscal(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnDepoisCancelaItemVendido(int ecfHandle, ACBrECFInterop.IntArgumentCallback method);
	int ECF_SetOnDepoisCancelaNaoFiscal(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisEfetuaPagamento(int ecfHandle, ACBrECFInterop.EfetuaPagamentoCallback method);
	int ECF_SetOnDepoisEfetuaPagamentoNaoFiscal(int ecfHandle, ACBrECFInterop.EfetuaPagamentoCallback method);
	int ECF_SetOnDepoisFechaCupom(int ecfHandle, ACBrECFInterop.FechaCupomCallback method);
	int ECF_SetOnDepoisFechaNaoFiscal(int ecfHandle, ACBrECFInterop.FechaCupomCallback method);
	int ECF_SetOnDepoisFechaRelatorio(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisLeituraX(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisReducaoZ(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnDepoisSangria(int ecfHandle, ACBrECFInterop.SangriaSuprimentoCallback method);
	int ECF_SetOnDepoisSubtotalizaCupom(int ecfHandle, ACBrECFInterop.SubtotalizaCupomCallback method);
	int ECF_SetOnDepoisSubtotalizaNaoFiscal(int ecfHandle, ACBrECFInterop.SubtotalizaCupomCallback method);
	int ECF_SetOnDepoisSuprimento(int ecfHandle, ACBrECFInterop.SangriaSuprimentoCallback method);
	int ECF_SetOnDepoisVendeItem(int ecfHandle, ACBrECFInterop.VendeItemCallback method);
	int ECF_SetOnErrorAbreCupom(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorAbreCupomVinculado(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorAbreNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorAbreRelatorioGerencial(int ecfHandle, ACBrECFInterop.OnErrorRelatorioCallback method);
	int ECF_SetOnErrorCancelaCupom(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorCancelaItemNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorCancelaItemVendido(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorCancelaNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorEfetuaPagamento(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorEfetuaPagamentoNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorFechaCupom(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorFechaNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorFechaRelatorio(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorLeituraX(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorReducaoZ(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorSangria(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorSemPapel(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOnErrorSubtotalizaCupom(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorSubtotalizaNaoFiscal(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorSuprimento(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnErrorVendeItem(int ecfHandle, ACBrECFInterop.OnErrorCallback method);
	int ECF_SetOnMsgAguarde(int ecfHandle, ACBrECFInterop.StringCallback method);
	int ECF_SetOnMsgRetentar(int ecfHandle, ACBrECFInterop.OnMsgRetentarCallback method);
	int ECF_SetOnPAFCalcEAD(int ecfHandle, ACBrECFInterop.StringCallback method);
	int ECF_SetOnPAFGetKeyRSA(int ecfHandle, ACBrECFInterop.GetKeyCallback method);
	int ECF_SetOnPoucoPapel(int ecfHandle, ACBrECFInterop.NoArgumentCallback method);
	int ECF_SetOperador(int ecfHandle, String operador);
	int ECF_SetPaginaDeCodigo(int ecfHandle, int pagina);
	int ECF_SetPausaRelatorio(int ecfHandle, int pausa);
	int ECF_SetRFD(int ecfHandle, int rfdHandle);
	int ECF_SubtotalizaCupom(int ecfHandle, double descontoAcrescimo, String mensagemRodape);
	int ECF_SubtotalizaNaoFiscal(int ecfHandle, double descontoAcrescimo, String mensagemRodape);
	int ECF_Suprimento(int ecfHandle, double valor, String obs, String DescricaoCNF, String DescricaoFPG, int indicebmp);
	int ECF_TestaPodeAbrirCupom(int ecfHandle);
	int ECF_VendeItem(int ecfHandle, String codigo, String descricao, String aliquotaICMS, double qtd, double valorUnitario, double descontoPorc, String unidade, String tipoDescontoAcrescimo, String descontoAcrescimo, int CodDepartamento);
}
