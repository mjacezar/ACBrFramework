package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Resumo diario das notas fiscais de venda a consumidor (codigo 02).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:35:03, revisao: $Id$
 */
public class RegistroC300 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos cancelados de notas fiscais de venda a consumidor (codigo 02).
     */
    private Collection<RegistroC310> registroC310 = new ArrayList<RegistroC310>();     
    /**
     * Itens de resumo diario dos documentos (codigo 02).
     */
    private Collection<RegistroC320> registroC320 = new ArrayList<RegistroC320>();     
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Numero do documento fiscal inicial.
     */
    private String NUM_DOC_INI;
    /**
     * Numero do documento fiscal final.
     */
    private String NUM_DOC_FIN;
    /**
     * Data da emissao dos documentos fiscais.
     */
    private Date DT_DOC;
    /**
     * Valor total dos documentos,
     */
    private double VL_DOC;
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
     * Documentos cancelados de notas fiscais de venda a consumidor (codigo 02).
     * @return the registroC310
     */
    public Collection<RegistroC310> getRegistroC310() {
        return registroC310;
    }

    /**
     * Itens de resumo diario dos documentos (codigo 02).
     * @return the registroC320
     */
    public Collection<RegistroC320> getRegistroC320() {
        return registroC320;
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
     * Numero do documento fiscal inicial.
     * @return the NUM_DOC_INI
     */
    public String getNUM_DOC_INI() {
        return NUM_DOC_INI;
    }

    /**
     * Numero do documento fiscal inicial.
     * @param NUM_DOC_INI the NUM_DOC_INI to set
     */
    public void setNUM_DOC_INI(String NUM_DOC_INI) {
        this.NUM_DOC_INI = NUM_DOC_INI;
    }

    /**
     * Numero do documento fiscal final.
     * @return the NUM_DOC_FIN
     */
    public String getNUM_DOC_FIN() {
        return NUM_DOC_FIN;
    }

    /**
     * Numero do documento fiscal final.
     * @param NUM_DOC_FIN the NUM_DOC_FIN to set
     */
    public void setNUM_DOC_FIN(String NUM_DOC_FIN) {
        this.NUM_DOC_FIN = NUM_DOC_FIN;
    }

    /**
     * Data da emissao dos documentos fiscais.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao dos documentos fiscais.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Valor total dos documentos,
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total dos documentos,
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
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