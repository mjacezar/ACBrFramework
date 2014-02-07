package jACBrFramework.sped.blocoD;

import jACBrFramework.sintegra.TipoOperacao;
import jACBrFramework.sped.Emitente;
import jACBrFramework.sped.SituacaoDocto;
import jACBrFramework.sped.TipoFrete;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Nota fiscal de servico de transporte (codigo 07) e conhecimentos de transporte
 * rodoviario de cargas (codigo 08), conhecimento de transporte de cargas avulso 
 * (codigo 8B), aquaviario de cargas (codigo 09), aereo (codigo 10), ferroviario 
 * de cargas (codigo 11), multimodal de cargas (codigo 26), nota fiscal de transporte 
 * ferroviario de carga (codigo 27) e conhecimento de transporte eletronico - CT-e (codigo 57). 
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:26:50, revisao: $Id$
 */
public class RegistroD100 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento - nota fiscal de servicos de transporte (codigo 07). 
     */
    private Collection<RegistroD110> registroD110 = new ArrayList<RegistroD110>();     
    /**
     * Complemento do conhecimento rodoviario de cargas (codigo 08) e conhecimento de 
     * transportes de carga avulso (codigo 8B).
     */
    private Collection<RegistroD130> registroD130 = new ArrayList<RegistroD130>();     
    /**
     * Complemento do conhecimento aquaviario de cargas (codigo 09).
     */
    private Collection<RegistroD140> registroD140 = new ArrayList<RegistroD140>();     
    /**
     * Complemento do conhecimento aereo (codigo 10).
     */
    private Collection<RegistroD150> registroD150 = new ArrayList<RegistroD150>();     
    /**
     * Carga transportada (codigo 08, 8B, 09, 10, 11, 26 e 27).
     */
    private Collection<RegistroD160> registroD160 = new ArrayList<RegistroD160>();     
    /**
     * Complemento do conhecimento multimodal de cargas (codigo 26).
     */
    private Collection<RegistroD170> registroD170 = new ArrayList<RegistroD170>();     
    /**
     * Modais (codigo 26).
     */
    private Collection<RegistroD180> registroD180 = new ArrayList<RegistroD180>();     
    /**
     * Registro analitico dos documentos (codigos 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
     */
    private Collection<RegistroD190> registroD190 = new ArrayList<RegistroD190>();     
    /**
     * Observacoes do lancamento fiscal.
     */
    private Collection<RegistroD195> registroD195 = new ArrayList<RegistroD195>();     
    /**
     * Indicador do tipo de operacao.
     */
    private TipoOperacao IND_OPER;
    /**
     * Indicador do emitente do documento fiscal.
     */
    private Emitente IND_EMIT;
    /**
     * Codigo do participante (campo 02 do Registro 0150):
     *  - do prestador de servico, no caso de aquisicao de servico;
     *  - do tomador do servico, no caso de prestacao de servicos.
     */
    private String COD_PART;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
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
     * Chave do Conhecimento de Transporte Eletronico.
     */
    private String CHV_CTE;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Data da aquisicao ou da prestacao do serviço.
     */
    private Date DT_A_P;
    /**
     * Tipo de Conhecimento de Transporte Eletronico conforme definido no Manual de Integracao do CT-e.
     */
    private String TP_CT_e;
    /**
     * Chave do CT-e de referencia cujos valores foram complementados (opção "1" 
     * do campo anterior) ou cujo debito foi anulado(opção "2" do campo anterior).
     */
    private String CHV_CTE_REF;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Indicador do tipo do frete.
     */
    private TipoFrete IND_FRT;
    /**
     * Valor total da prestacao de servico.
     */
    private double VL_SERV;
    /**
     * Valor da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor nao-tributado.
     */
    private double VL_NT;
    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     */
    private String COD_INF;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Itens do documento - nota fiscal de servicos de transporte (codigo 07).
     * @return the registroD110
     */
    public Collection<RegistroD110> getRegistroD110() {
        return registroD110;
    }

    /**
     * Complemento do conhecimento rodoviario de cargas (codigo 08) e conhecimento de
     * transportes de carga avulso (codigo 8B).
     * @return the registroD130
     */
    public Collection<RegistroD130> getRegistroD130() {
        return registroD130;
    }

    /**
     * Complemento do conhecimento aquaviario de cargas (codigo 09).
     * @return the registroD140
     */
    public Collection<RegistroD140> getRegistroD140() {
        return registroD140;
    }

    /**
     * Complemento do conhecimento aereo (codigo 10).
     * @return the registroD150
     */
    public Collection<RegistroD150> getRegistroD150() {
        return registroD150;
    }

    /**
     * Carga transportada (codigo 08, 8B, 09, 10, 11, 26 e 27).
     * @return the registroD160
     */
    public Collection<RegistroD160> getRegistroD160() {
        return registroD160;
    }

    /**
     * Complemento do conhecimento multimodal de cargas (codigo 26).
     * @return the registroD170
     */
    public Collection<RegistroD170> getRegistroD170() {
        return registroD170;
    }

    /**
     * Modais (codigo 26).
     * @return the registroD180
     */
    public Collection<RegistroD180> getRegistroD180() {
        return registroD180;
    }

    /**
     * Registro analitico dos documentos (codigos 07, 08, 8B, 09, 10, 11, 26, 27 e 57).
     * @return the registroD190
     */
    public Collection<RegistroD190> getRegistroD190() {
        return registroD190;
    }

    /**
     * Observacoes do lancamento fiscal.
     * @return the registroD195
     */
    public Collection<RegistroD195> getRegistroD195() {
        return registroD195;
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
     * Indicador do emitente do documento fiscal.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do emitente do documento fiscal.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do prestador de servico, no caso de aquisicao de servico;
     * - do tomador do servico, no caso de prestacao de servicos.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do prestador de servico, no caso de aquisicao de servico;
     * - do tomador do servico, no caso de prestacao de servicos.
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
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @return the COD_SIT
     */
    public SituacaoDocto getCOD_SIT() {
        return COD_SIT;
    }

    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
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
     * Chave do Conhecimento de Transporte Eletronico.
     * @return the CHV_CTE
     */
    public String getCHV_CTE() {
        return CHV_CTE;
    }

    /**
     * Chave do Conhecimento de Transporte Eletronico.
     * @param CHV_CTE the CHV_CTE to set
     */
    public void setCHV_CTE(String CHV_CTE) {
        this.CHV_CTE = CHV_CTE;
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
     * Data da aquisicao ou da prestacao do serviço.
     * @return the DT_A_P
     */
    public Date getDT_A_P() {
        return DT_A_P;
    }

    /**
     * Data da aquisicao ou da prestacao do serviço.
     * @param DT_A_P the DT_A_P to set
     */
    public void setDT_A_P(Date DT_A_P) {
        this.DT_A_P = DT_A_P;
    }

    /**
     * Tipo de Conhecimento de Transporte Eletronico conforme definido no Manual de Integracao do CT-e.
     * @return the TP_CT_e
     */
    public String getTP_CT_e() {
        return TP_CT_e;
    }

    /**
     * Tipo de Conhecimento de Transporte Eletronico conforme definido no Manual de Integracao do CT-e.
     * @param TP_CT_e the TP_CT_e to set
     */
    public void setTP_CT_e(String TP_CT_e) {
        this.TP_CT_e = TP_CT_e;
    }

    /**
     * Chave do CT-e de referencia cujos valores foram complementados (opção "1"
     * do campo anterior) ou cujo debito foi anulado(opção "2" do campo anterior).
     * @return the CHV_CTE_REF
     */
    public String getCHV_CTE_REF() {
        return CHV_CTE_REF;
    }

    /**
     * Chave do CT-e de referencia cujos valores foram complementados (opção "1"
     * do campo anterior) ou cujo debito foi anulado(opção "2" do campo anterior).
     * @param CHV_CTE_REF the CHV_CTE_REF to set
     */
    public void setCHV_CTE_REF(String CHV_CTE_REF) {
        this.CHV_CTE_REF = CHV_CTE_REF;
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
     * Indicador do tipo do frete.
     * @return the IND_FRT
     */
    public TipoFrete getIND_FRT() {
        return IND_FRT;
    }

    /**
     * Indicador do tipo do frete.
     * @param IND_FRT the IND_FRT to set
     */
    public void setIND_FRT(TipoFrete IND_FRT) {
        this.IND_FRT = IND_FRT;
    }

    /**
     * Valor total da prestacao de servico.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor total da prestacao de servico.
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
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
     * Valor nao-tributado.
     * @return the VL_NT
     */
    public double getVL_NT() {
        return VL_NT;
    }

    /**
     * Valor nao-tributado.
     * @param VL_NT the VL_NT to set
     */
    public void setVL_NT(double VL_NT) {
        this.VL_NT = VL_NT;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @return the COD_INF
     */
    public String getCOD_INF() {
        return COD_INF;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @param COD_INF the COD_INF to set
     */
    public void setCOD_INF(String COD_INF) {
        this.COD_INF = COD_INF;
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
    // </editor-fold>
    
}