package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Nota fiscal de venda a consumidor (codigo 02).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:52:44, revisao: $Id$
 */
public class RegistroC350 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento (codigo 02).
     */
    private Collection<RegistroC370> registroC370 = new ArrayList<RegistroC370>();     
    /**
     * Registro analitico das notas fiscais de venda a consumidor (codigo 02).
     */
    private Collection<RegistroC390> registroC390 = new ArrayList<RegistroC390>();     
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB_SER;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * CNPJ ou CPF do destinatario.
     */
    private String CNPJ_CPF;
    /**
     * Valor das mercadorias constantes no documento fiscal.
     */
    private double VL_MERC;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;
    /**
     * Valor total do desconto.
     */
    private double VL_DESC;
    /**
     * Valor total do PIS.
     */
    private double VL_PIS;
    /**
     * Valor total da COFINS.
     */
    private double VL_COFINS;
    /**
     * Codigo da conta analitica contabil debitada/creditada.
     */
    private String COD_CTA;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Itens do documento (codigo 02).
     * @return the registroC370
     */
    public Collection<RegistroC370> getRegistroC370() {
        return registroC370;
    }

    /**
     * Registro analitico das notas fiscais de venda a consumidor (codigo 02).
     * @return the registroC390
     */
    public Collection<RegistroC390> getRegistroC390() {
        return registroC390;
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
     * @return the SUB_SER
     */
    public String getSUB_SER() {
        return SUB_SER;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB_SER the SUB_SER to set
     */
    public void setSUB_SER(String SUB_SER) {
        this.SUB_SER = SUB_SER;
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
     * CNPJ ou CPF do destinatario.
     * @return the CNPJ_CPF
     */
    public String getCNPJ_CPF() {
        return CNPJ_CPF;
    }

    /**
     * CNPJ ou CPF do destinatario.
     * @param CNPJ_CPF the CNPJ_CPF to set
     */
    public void setCNPJ_CPF(String CNPJ_CPF) {
        this.CNPJ_CPF = CNPJ_CPF;
    }

    /**
     * Valor das mercadorias constantes no documento fiscal.
     * @return the VL_MERC
     */
    public double getVL_MERC() {
        return VL_MERC;
    }

    /**
     * Valor das mercadorias constantes no documento fiscal.
     * @param VL_MERC the VL_MERC to set
     */
    public void setVL_MERC(double VL_MERC) {
        this.VL_MERC = VL_MERC;
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
     * Valor total do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor total do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor total da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor total da COFINS.
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