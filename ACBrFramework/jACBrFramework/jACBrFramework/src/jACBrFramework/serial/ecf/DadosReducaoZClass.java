package jACBrFramework.serial.ecf;

import com.sun.jna.ptr.DoubleByReference;
import jACBrFramework.ACBrException;
import jACBrFramework.OleDate;
import jACBrFramework.interop.ACBrECFInterop;
import java.nio.ByteBuffer;
import java.util.Date;

/**
 * Responsavel pela obtencao das informacoes da reducao Z.
 * 
 * @author Jose Mauro
 * @version Criado em: 17/12/2013 13:59:58, revisao: $Id$
 */
public class DadosReducaoZClass {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Instancia ECF para obter o handler.
     */
    ACBrECF ecf = null;
    /**
     * Comprovantes nao fiscais.
     */
    private ComprovanteNaoFiscal[] comprovantesNaoFiscais;
    /**
     * Aliquotas de ICMS.
     */
    private Aliquota[] icms;
    /**
     * Relatorios gerenciais.
     */
    private RelatorioGerencial[] relatoriosGerenciais;
    /**
     * Aliquotas de ISS.
     */
    private Aliquota[] issqn;
    /**
     * Formas de pagamento.
     */
    private FormaPagamento[] formasPagamento;    
    /**
     * Buffer para leitura dos dados.
     */
    protected final int STR_BUFFER_LEN = 256;
    // </editor-fold>       
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    /**
     * Cria um novo objeto para manipulacao dados da ECF.
     * 
     * @param pEcf instancia para auxiliar a comunicacao com o Acbr.
     */
    DadosReducaoZClass(ACBrECF pEcf) throws ACBrException {
        this.ecf = pEcf;
        carregaComprovantesNaoFiscais();
        carregaICMS();
        carregaRelatoriosGerenciais();
        carregaISSQN();
        carregaMeiosDePagamento();
    }
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Components Methods">   
    /**
     * Carrega as informacoes dos comprovantes nao fiscais.
     * 
     * @throws ACBrException 
     */
    private void carregaComprovantesNaoFiscais() throws ACBrException {
        int lCount = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCNFCount(ecf.getHandle());
        ecf.checkResult(lCount);

        comprovantesNaoFiscais = new ComprovanteNaoFiscal[lCount];
        for (int i = 0; i < lCount; i++) {
            ACBrECFInterop.ComprovanteNaoFiscalRec lRecord = new ACBrECFInterop.ComprovanteNaoFiscalRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCNF(ecf.getHandle(), lRecord, i);
            ecf.checkResult(ret);
            comprovantesNaoFiscais[i] = new ComprovanteNaoFiscal(
                    ecf.fromUTF8(lRecord.Indice),
                    ecf.fromUTF8(lRecord.Descricao),
                    ecf.fromUTF8(lRecord.FormaPagamento),
                    lRecord.Contador,
                    lRecord.PermiteVinculado,
                    lRecord.Total);
        }
    }
    
    /**
     * Carrega as informacoes das aliquotas de ICMS.
     * 
     * @throws ACBrException 
     */
    private void carregaICMS() throws ACBrException {
        int lCount = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetICMSCount(ecf.getHandle());
        ecf.checkResult(lCount);

        icms = new Aliquota[lCount];
        for (int i = 0; i < lCount; i++) {
            ACBrECFInterop.AliquotaRec lRecord = new ACBrECFInterop.AliquotaRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetICMS(ecf.getHandle(), lRecord, i);
            ecf.checkResult(ret);

            icms[i] = new Aliquota(ecf.fromUTF8(lRecord.Indice), lRecord.Aliquota, 
                    lRecord.Tipo, lRecord.Total, lRecord.Sequencia);
        }
    }    
    
    /**
     * Carrega as informacoes dos relatorios gerenciais.
     * 
     * @throws ACBrException 
     */
    private void carregaRelatoriosGerenciais() throws ACBrException {
        int lCount = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetRGCount(ecf.getHandle());
        ecf.checkResult(lCount);

        relatoriosGerenciais = new RelatorioGerencial[lCount];
        for (int i = 0; i < lCount; i++) {
            ACBrECFInterop.RelatorioGerencialRec lRecord = new ACBrECFInterop.RelatorioGerencialRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetRG(ecf.getHandle(), lRecord, i);
            ecf.checkResult(ret);
            
            relatoriosGerenciais[i] = new RelatorioGerencial(
                    ecf.fromUTF8(lRecord.Indice), ecf.fromUTF8(lRecord.Descricao), lRecord.Contador);
        }
    }    
    
    /**
     * Carrega as informacoes das aliquotas de ISSQN.
     * 
     * @throws ACBrException 
     */    
    private void carregaISSQN() throws ACBrException {
        int lCount = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetISSQNCount(ecf.getHandle());
        ecf.checkResult(lCount);

        issqn = new Aliquota[lCount];
        for (int i = 0; i < lCount; i++) {
            ACBrECFInterop.AliquotaRec lRecord = new ACBrECFInterop.AliquotaRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetISSQN(ecf.getHandle(), lRecord, i);
            ecf.checkResult(ret);

            issqn[i] = new Aliquota(ecf.fromUTF8(lRecord.Indice), lRecord.Aliquota, 
                    lRecord.Tipo, lRecord.Total, lRecord.Sequencia);            
        }
    }    
    
    /**
     * Carrega as informacoes dos meios de pagamento.
     * 
     * @throws ACBrException 
     */
    private void carregaMeiosDePagamento() throws ACBrException {
        int lCount = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetFPGCount(ecf.getHandle());
        ecf.checkResult(lCount);

        formasPagamento = new FormaPagamento[lCount];
        for (int i = 0; i < lCount; i++) {
            ACBrECFInterop.FormaPagamentoRec lRecord = new ACBrECFInterop.FormaPagamentoRec();
            int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetFPG(ecf.getHandle(), lRecord, i);
            ecf.checkResult(ret);

            formasPagamento[i] = new FormaPagamento(ecf.fromUTF8(lRecord.Indice), 
                    ecf.fromUTF8(lRecord.Descricao), lRecord.PermiteVinculado, 
                    lRecord.Total, OleDate.fromOADate(lRecord.Data), ecf.fromUTF8(lRecord.TipoDoc));
        }
    }    

    /**
     * Monta os dados da reducao Z.
     * 
     * @return dados da reducao Z.
     * @throws ACBrException 
     */
    public String montaDadosReducaoZ() throws ACBrException {
        final int lBufferLen = 16384;
        ByteBuffer lDadosReducaoZ = ByteBuffer.allocate(lBufferLen);

        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_MontaDadosReducaoZ(
                ecf.getHandle(), lDadosReducaoZ, lBufferLen);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lDadosReducaoZ, ret);
    }    
    
    /**
     * Realiza o carregamento das informacoes dos totalizadores.
     * 
     * @throws ACBrException 
     */
    public void calculaValoresVirtuais() throws ACBrException {
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_CalculaValoresVirtuais(ecf.getHandle());
        ecf.checkResult(ret);

        carregaComprovantesNaoFiscais();
        carregaICMS();
        carregaRelatoriosGerenciais();
        carregaISSQN();
        carregaMeiosDePagamento();
    }    
    
    /**
     * Obtem o contador de ordem da operacao.
     * 
     * @return 
     */
    public int getCoo() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCOO(ecf.getHandle());
    }
    
    /**
     * Obtem o contador de fita-detalhe.
     * 
     * @return 
     */
    public int getCfd() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCFD(ecf.getHandle());
    }    
    
    /**
     * Obtem o contador gral de operacao nao-fiscal.
     * 
     * @return 
     */
    public int getGnfc() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetGNFC(ecf.getHandle());
    }      
    
    /**
     * Obtem o contador de reinicio de operacao.
     * 
     * @return 
     */
    public int getCro() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCRO(ecf.getHandle());
    }      

    /**
     * Obtem o contador de reducao Z.
     * 
     * @return 
     */
    public int getCrz() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCRZ(ecf.getHandle());
    }      

    /**
     * Obtem o contador geral de relatorio gerencial.
     * 
     * @return 
     */
    public int getGrg() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetGRG(ecf.getHandle());
    }      

    /**
     * Obtem o contador geral de operacoes nao fiscais.
     * 
     * @return 
     */
    public int getGnf() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetGNF(ecf.getHandle());
    }      

    /**
     * Obtem o contador de cupom fiscal cancelado.
     * 
     * @return 
     */
    public int getCfc() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCFC(ecf.getHandle());
    }      

    /**
     * Obtem o contador de cupom fiscal.
     * 
     * @return 
     */
    public int getCcf() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCCF(ecf.getHandle());
    }      

    /**
     * Obtem o contador de comprovante de credito ou debito.
     * 
     * @return 
     */
    public int getCdc() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCDC(ecf.getHandle());
    }      

    /**
     * Obtem o contador de comprovante de credito ou debito.
     * 
     * @return 
     */
    public int getCcdc() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCCDC(ecf.getHandle());
    }      

    /**
     * Obtem o contador de cancelamento nao fiscal.
     * 
     * @return 
     */
    public int getNcn() {
        return ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNCN(ecf.getHandle());
    }      
    
    /**
     * Obtem a data e hora da emissao da reducao Z.
     * 
     * @return
     * @throws ACBrException 
     */
    public Date getDataHoraEmissao() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDataHoraEmissao(ecf.getHandle(), lData);
        ecf.checkResult(ret);
        return OleDate.fromOADate(lData.getValue());
    }

    /**
     * Obtem a data e hora da impressora.
     * 
     * @return
     * @throws ACBrException 
     */
    public Date getDataDaImpressora() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDataDaImpressora(ecf.getHandle(), lData);
        ecf.checkResult(ret);
        return OleDate.fromOADate(lData.getValue());
    }

    /**
     * Obtem a data do movimento.
     * 
     * @return
     * @throws ACBrException 
     */
    public Date getDataDoMovimento() throws ACBrException {
        DoubleByReference lData = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDataDoMovimento(ecf.getHandle(), lData);
        ecf.checkResult(ret);
        return OleDate.fromOADate(lData.getValue());
    }
    
    /**
     * Obtem o numero do COO Inicial.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroCOOInicial() throws ACBrException {
        ByteBuffer lCooInicial = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNumeroCOOInicial(ecf.getHandle(), lCooInicial, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lCooInicial, ret);
    }     

    /**
     * Obtem o numero da Ecf.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroDoECF() throws ACBrException {
        ByteBuffer lNumEcf = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNumeroDoECF(ecf.getHandle(), lNumEcf, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lNumEcf, ret);
    }     

    /**
     * Obtem o numero da serie.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroDeSerie() throws ACBrException {
        ByteBuffer lNumSerie = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNumeroDeSerie(ecf.getHandle(), lNumSerie, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lNumSerie, ret);
    }     
    
    /**
     * Obtem o numero da serie MFD.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroDeSerieMFD() throws ACBrException {
        ByteBuffer lNumSerieMFD = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNumeroDeSerieMFD(ecf.getHandle(), lNumSerieMFD, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lNumSerieMFD, ret);
    }     

    /**
     * Obtem o numero da loja.
     * 
     * @return
     * @throws ACBrException 
     */
    public String getNumeroDaLoja() throws ACBrException {
        ByteBuffer lNumLoja = ByteBuffer.allocate(STR_BUFFER_LEN);
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNumeroDaLoja(ecf.getHandle(), lNumLoja, STR_BUFFER_LEN);
        ecf.checkResult(ret);   
        return ecf.fromUTF8(lNumLoja, ret);
    }     
    
    /**
     * Obtem o valor de GT.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorGrandeTotal() throws ACBrException {
        DoubleByReference lValorGt = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetValorGrandeTotal(ecf.getHandle(), lValorGt);
        ecf.checkResult(ret);
        return lValorGt.getValue();
    }   
    
    /**
     * Obtem o valor de venda bruta.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorVendaBruta() throws ACBrException {
        DoubleByReference lVendaBruta = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetValorVendaBruta(ecf.getHandle(), lVendaBruta);
        ecf.checkResult(ret);
        return lVendaBruta.getValue();
    }   

    /**
     * Obtem o valor de venda liquida.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getValorVendaLiquida() throws ACBrException {
        DoubleByReference lVendaLiquida = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetVendaLiquida(ecf.getHandle(), lVendaLiquida);
        ecf.checkResult(ret);
        return lVendaLiquida.getValue();
    }  
    
    /**
     * Obtem o valor total de troco.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getTotalTroco() throws ACBrException {
        DoubleByReference lValorTroco = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetTotalTroco(ecf.getHandle(), lValorTroco);
        ecf.checkResult(ret);
        return lValorTroco.getValue();
    }  
    
    /**
     * Obtem o total de operacoes nao fiscais.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getTotalOperacaoNaoFiscal() throws ACBrException {
        DoubleByReference lTotNaoFiscal = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetTotalOperacaoNaoFiscal(ecf.getHandle(), lTotNaoFiscal);
        ecf.checkResult(ret);
        return lTotNaoFiscal.getValue();
    }   
    
    /**
     * Obtem o valor total de acrescimos nas operacoes nao fiscais.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getAcrescimoOPNF() throws ACBrException {
        DoubleByReference lAcresNaoFiscal = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetAcrescimoOPNF(ecf.getHandle(), lAcresNaoFiscal);
        ecf.checkResult(ret);
        return lAcresNaoFiscal.getValue();
    } 
    
    /**
     * Obtem o valor total de descontos nas operacoes nao fiscais.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getDescontoOPNF() throws ACBrException {
        DoubleByReference lDescNaoFiscal = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDescontoOPNF(ecf.getHandle(), lDescNaoFiscal);
        ecf.checkResult(ret);
        return lDescNaoFiscal.getValue();
    } 
    
    /**
     * Obtem o valor total de cancelamento de operacoes nao fiscais.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getCancelamentoOPNF() throws ACBrException {
        DoubleByReference lCancelNaoFiscal = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCancelamentoOPNF(ecf.getHandle(), lCancelNaoFiscal);
        ecf.checkResult(ret);
        return lCancelNaoFiscal.getValue();
    }   
    
    /**
     * Obtem o acrescimo de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getAcrescimoICMS() throws ACBrException {
        DoubleByReference lAcresICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetAcrescimoICMS(ecf.getHandle(), lAcresICMS);
        ecf.checkResult(ret);
        return lAcresICMS.getValue();
    }   
    
    /**
     * Obtem o desconto de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getDescontoICMS() throws ACBrException {
        DoubleByReference lDescICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDescontoICMS(ecf.getHandle(), lDescICMS);
        ecf.checkResult(ret);
        return lDescICMS.getValue();
    }   
    
    /**
     * Obtem o valor ST de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getSubstituicaoTributariaICMS() throws ACBrException {
        DoubleByReference lStICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetSubstituicaoTributariaICMS(ecf.getHandle(), lStICMS);
        ecf.checkResult(ret);
        return lStICMS.getValue();
    }  
    
    /**
     * Obtem o valor nao tributado de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getNaoTributadoICMS() throws ACBrException {
        DoubleByReference lNaoTributadoICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNaoTributadoICMS(ecf.getHandle(), lNaoTributadoICMS);
        ecf.checkResult(ret);
        return lNaoTributadoICMS.getValue();
    }   
       
    /**
     * Obtem o valor isento de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getIsentoICMS() throws ACBrException {
        DoubleByReference lIsentoICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetIsentoICMS(ecf.getHandle(), lIsentoICMS);
        ecf.checkResult(ret);
        return lIsentoICMS.getValue();
    }  
    
    /**
     * Obtem o valor de cancelamento de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getCancelamentoICMS() throws ACBrException {
        DoubleByReference lCancelICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCancelamentoICMS(ecf.getHandle(), lCancelICMS);
        ecf.checkResult(ret);
        return lCancelICMS.getValue();
    } 
    
    /**
     * Obtem o valor total de ICMS.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getTotalICMS() throws ACBrException {
        DoubleByReference lTotalICMS = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetTotalICMS(ecf.getHandle(), lTotalICMS);
        ecf.checkResult(ret);
        return lTotalICMS.getValue();
    }  
    
    /**
     * Obtem o acrescimo de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getAcrescimoISSQN() throws ACBrException {
        DoubleByReference lAcresISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetAcrescimoISSQN(ecf.getHandle(), lAcresISSQN);
        ecf.checkResult(ret);
        return lAcresISSQN.getValue();
    }  
    
    /**
     * Obtem o desconto de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getDescontoISSQN() throws ACBrException {
        DoubleByReference lDescISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetDescontoISSQN(ecf.getHandle(), lDescISSQN);
        ecf.checkResult(ret);
        return lDescISSQN.getValue();
    }   
    
    /**
     * Obtem o valor ST de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getSubstituicaoTributariaISSQN() throws ACBrException {
        DoubleByReference lStISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetSubstituicaoTributariaISSQN(ecf.getHandle(), lStISSQN);
        ecf.checkResult(ret);
        return lStISSQN.getValue();
    }  
    
    /**
     * Obtem o valor nao tributado de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getNaoTributadoISSQN() throws ACBrException {
        DoubleByReference lNaoTributadoISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetNaoTributadoISSQN(ecf.getHandle(), lNaoTributadoISSQN);
        ecf.checkResult(ret);
        return lNaoTributadoISSQN.getValue();
    }  
    
    /**
     * Obtem o valor isento de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getIsentoISSQN() throws ACBrException {
        DoubleByReference lIsentoISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetIsentoISSQN(ecf.getHandle(), lIsentoISSQN);
        ecf.checkResult(ret);
        return lIsentoISSQN.getValue();
    }  
    
    /**
     * Obtem o valor de cancelamento de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getCancelamentoISSQN() throws ACBrException {
        DoubleByReference lCancelISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetCancelamentoISSQN(ecf.getHandle(), lCancelISSQN);
        ecf.checkResult(ret);
        return lCancelISSQN.getValue();
    }   
    
    /**
     * Obtem o valor total de ISSQN.
     * 
     * @return
     * @throws ACBrException 
     */
    public double getTotalISSQN() throws ACBrException {
        DoubleByReference lTotalISSQN = new DoubleByReference();
        int ret = ACBrECFInterop.INSTANCE.ECF_DadosReducaoZClass_GetTotalISSQN(ecf.getHandle(), lTotalISSQN);
        ecf.checkResult(ret);
        return lTotalISSQN.getValue();
    }   
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Comprovantes nao fiscais.
     * @return the comprovantesNaoFiscais
     */
    public ComprovanteNaoFiscal[] getComprovantesNaoFiscais() {
        return comprovantesNaoFiscais;
    }

    /**
     * Aliquotas de ICMS.
     * @return the icms
     */
    public Aliquota[] getIcms() {
        return icms;
    }

    /**
     * Relatorios gerenciais.
     * @return the relatoriosGerenciais
     */
    public RelatorioGerencial[] getRelatoriosGerenciais() {
        return relatoriosGerenciais;
    }

    /**
     * Aliquotas de ISS.
     * @return the issqn
     */
    public Aliquota[] getIssqn() {
        return issqn;
    }

    /**
     * Formas de pagamento.
     * @return the formasPagamento
     */
    public FormaPagamento[] getFormasPagamento() {
        return formasPagamento;
    }
    // </editor-fold>
    
}