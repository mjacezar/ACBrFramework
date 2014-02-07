package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.SituacaoDocto;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Resumo de movimento diario (codigo 18)
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:02:58, revisao: $Id$
 */
public class RegistroD400 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos informados (codigos 13, 14, 15 e 16).
     */
    private Collection<RegistroD410> registroD410 = new ArrayList<RegistroD410>();     
    /**
     * Complemento dos documentos informados (codigos 13, 14, 15 e 16).
     */
    private Collection<RegistroD420> registroD420 = new ArrayList<RegistroD420>();     
    /**
     * Codigo do participante (campo 02 do Registro 0150): - agencia, filial ou posto.
     */
    private String COD_PART;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1,
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
     * Numero do documento fiscal resumo.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor acumulado dos descontos.
     */
    private double VL_DESC;
    /**
     * Valor acumulado da prestacao de servico.
     */
    private double VL_SERV;
    /**
     * Valor total da base de calculo do ICMS.
     */
    private double VL_BC_ICMS;
    /**
     * Valor total do ICMS.
     */
    private double VL_ICMS;
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
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Documentos informados (codigos 13, 14, 15 e 16).
     * @return the registroD410
     */
    public Collection<RegistroD410> getRegistroD410() {
        return registroD410;
    }

    /**
     * Complemento dos documentos informados (codigos 13, 14, 15 e 16).
     * @return the registroD420
     */
    public Collection<RegistroD420> getRegistroD420() {
        return registroD420;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - agencia, filial ou posto.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - agencia, filial ou posto.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1,
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1,
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
     * Numero do documento fiscal resumo.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal resumo.
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
     * Valor acumulado dos descontos.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor acumulado dos descontos.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor acumulado da prestacao de servico.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor acumulado da prestacao de servico.
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
    }

    /**
     * Valor total da base de calculo do ICMS.
     * @return the VL_BC_ICMS
     */
    public double getVL_BC_ICMS() {
        return VL_BC_ICMS;
    }

    /**
     * Valor total da base de calculo do ICMS.
     * @param VL_BC_ICMS the VL_BC_ICMS to set
     */
    public void setVL_BC_ICMS(double VL_BC_ICMS) {
        this.VL_BC_ICMS = VL_BC_ICMS;
    }

    /**
     * Valor total do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor total do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
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
    // </editor-fold>    
    
}