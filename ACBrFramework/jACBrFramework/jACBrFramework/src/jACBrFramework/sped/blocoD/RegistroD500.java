package jACBrFramework.sped.blocoD;

import jACBrFramework.sintegra.TipoOperacao;
import jACBrFramework.sped.Emitente;
import jACBrFramework.sped.SituacaoDocto;
import jACBrFramework.sped.TipoAssinante;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Nota fiscal de servico de comunicacao (codigo 21) e nota fiscal de servico de
 * telecomunicacao (codigo 22).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:21:39, revisao: $Id$
 */
public class RegistroD500 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento - Nota Fiscal de Servico de comunicacao (codigo 21) e
     * servico de telecomunicacao (codigo 22).
     */
    private Collection<RegistroD510> registroD510 = new ArrayList<RegistroD510>();     
    /**
     * Terminal faturado.
     */
    private Collection<RegistroD530> registroD530 = new ArrayList<RegistroD530>();     
    /**
     * Registro analitico do documento (codigo 21 e 22).
     */
    private Collection<RegistroD590> registroD590 = new ArrayList<RegistroD590>();     
    /**
     * Indicador do tipo de operacao.
     */
    private TipoOperacao IND_OPER;
    /**
     * Indicador do IND_EMIT do documento fiscal.
     */
    private Emitente IND_EMIT;
    /**
     * Codigo do participante (campo 02 do Registro 0150):
     *  - do prestador do servico, no caso de aquisicao; 
     *  - do tomador do servico, no caso de prestacao.
     */
    private String COD_PART;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Çodigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     */
    private SituacaoDocto COD_SIT;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Data da entrada (aquisicao) ou da saida (prestação do servico).
     */
    private Date DT_A_P;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Valor da prestacao de servicos.
     */
    private double VL_SERV;
    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     */
    private double VL_SERV_NT;
    /**
     * Valores cobrados em nome de terceiros.
     */
    private double VL_TERC;
    /**
     * Valor de outras despesas indicadas no documento fiscal.
     */
    private double VL_DA;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS.
     */
    private double VL_ICMS;
    /**
     * Codigo da informacao complementar (campo 02 do Registro 0450).
     */
    private String COD_INF;
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;
    /**
     * Codigo do Tipo de Assinante.
     */
    private TipoAssinante TP_ASSINANTE;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Itens do documento - Nota Fiscal de Servico de comunicacao (codigo 21) e
     * servico de telecomunicacao (codigo 22).
     * @return the registroD510
     */
    public Collection<RegistroD510> getRegistroD510() {
        return registroD510;
    }

    /**
     * Terminal faturado.
     * @return the registroD530
     */
    public Collection<RegistroD530> getRegistroD530() {
        return registroD530;
    }

    /**
     * Registro analitico do documento (codigo 21 e 22).
     * @return the registroD590
     */
    public Collection<RegistroD590> getRegistroD590() {
        return registroD590;
    }

    /**
     * Indicador do tipo de operacao.
     * @return the IND_OPER
     */
    public TipoOperacao getIND_OPER() {
        return IND_OPER;
    }

    /**
     * Indicador do tipo de operacao.
     * @param IND_OPER the IND_OPER to set
     */
    public void setIND_OPER(TipoOperacao IND_OPER) {
        this.IND_OPER = IND_OPER;
    }

    /**
     * Indicador do IND_EMIT do documento fiscal.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do IND_EMIT do documento fiscal.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do prestador do servico, no caso de aquisicao;
     * - do tomador do servico, no caso de prestacao.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do prestador do servico, no caso de aquisicao;
     * - do tomador do servico, no caso de prestacao.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Çodigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @return the COD_SIT
     */
    public SituacaoDocto getCOD_SIT() {
        return COD_SIT;
    }

    /**
     * Çodigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @param COD_SIT the COD_SIT to set
     */
    public void setCOD_SIT(SituacaoDocto COD_SIT) {
        this.COD_SIT = COD_SIT;
    }

    /**
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Numero do documento fiscal.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Data da entrada (aquisicao) ou da saida (prestação do servico).
     * @return the DT_A_P
     */
    public Date getDT_A_P() {
        return DT_A_P;
    }

    /**
     * Data da entrada (aquisicao) ou da saida (prestação do servico).
     * @param DT_A_P the DT_A_P to set
     */
    public void setDT_A_P(Date DT_A_P) {
        this.DT_A_P = DT_A_P;
    }

    /**
     * Valor total do documento fiscal.
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total do documento fiscal.
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
    }

    /**
     * Valor total do desconto.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total do desconto.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor da prestacao de servicos.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor da prestacao de servicos.
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
    }

    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     * @return the VL_SERV_NT
     */
    public double getVL_SERV_NT() {
        return VL_SERV_NT;
    }

    /**
     * Valor total dos servicos nao-tributados pelo ICMS.
     * @param VL_SERV_NT the VL_SERV_NT to set
     */
    public void setVL_SERV_NT(double VL_SERV_NT) {
        this.VL_SERV_NT = VL_SERV_NT;
    }

    /**
     * Valores cobrados em nome de terceiros.
     * @return the VL_TERC
     */
    public double getVL_TERC() {
        return VL_TERC;
    }

    /**
     * Valores cobrados em nome de terceiros.
     * @param VL_TERC the VL_TERC to set
     */
    public void setVL_TERC(double VL_TERC) {
        this.VL_TERC = VL_TERC;
    }

    /**
     * Valor de outras despesas indicadas no documento fiscal.
     * @return the VL_DA
     */
    public double getVL_DA() {
        return VL_DA;
    }

    /**
     * Valor de outras despesas indicadas no documento fiscal.
     * @param VL_DA the VL_DA to set
     */
    public void setVL_DA(double VL_DA) {
        this.VL_DA = VL_DA;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Codigo da informacao complementar (campo 02 do Registro 0450).
     * @return the COD_INF
     */
    public String getCOD_INF() {
        return COD_INF;
    }

    /**
     * Codigo da informacao complementar (campo 02 do Registro 0450).
     * @param COD_INF the COD_INF to set
     */
    public void setCOD_INF(String COD_INF) {
        this.COD_INF = COD_INF;
    }

    /**
     * Valor do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analitica contabil debitada/creditada.
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }

    /**
     * Codigo do Tipo de Assinante.
     * @return the TP_ASSINANTE
     */
    public TipoAssinante getTP_ASSINANTE() {
        return TP_ASSINANTE;
    }

    /**
     * Codigo do Tipo de Assinante.
     * @param TP_ASSINANTE the TP_ASSINANTE to set
     */
    public void setTP_ASSINANTE(TipoAssinante TP_ASSINANTE) {
        this.TP_ASSINANTE = TP_ASSINANTE;
    }
    // </editor-fold>    
    
}