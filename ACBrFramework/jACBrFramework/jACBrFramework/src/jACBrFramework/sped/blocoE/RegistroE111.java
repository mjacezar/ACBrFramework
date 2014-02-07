package jACBrFramework.sped.blocoE;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Ajuste/Beneficio/Incentivo da apuracao do ICMS.
 *  
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:12:36, revisao: $Id$
 */
public class RegistroE111 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Informacoes adicionais dos ajutes da apuracao do ICMS.
     */
    private Collection<RegistroE112> registroE112 = new ArrayList<RegistroE112>(); 
    /**
     * Informacoes adicionais dos ajustes da apuracao do ICMS - Identificacao dos documentos fiscais.
     */
    private Collection<RegistroE113> registroE113 = new ArrayList<RegistroE113>();     
    /**
     * Codigo do ajuste da apuracao e deducao, conforme a Tabela indicada no item 5.1.1.
     */
    private String COD_AJ_APUR;
    /**
     * Descricao complementar do ajuste da apuracao.
     */
    private String DESCR_COMPL_AJ;
    /**
     * Valor do ajuste da apuracao.
     */
    private double VL_AJ_APUR;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Informacoes adicionais dos ajutes da apuracao do ICMS.
     * @return the registroE112
     */
    public Collection<RegistroE112> getRegistroE112() {
        return registroE112;
    }

    /**
     * Informacoes adicionais dos ajustes da apuracao do ICMS - Identificacao dos documentos fiscais.
     * @return the registroE113
     */
    public Collection<RegistroE113> getRegistroE113() {
        return registroE113;
    }

    /**
     * Codigo do ajuste da apuracao e deducao, conforme a Tabela indicada no item 5.1.1.
     * @return the COD_AJ_APUR
     */
    public String getCOD_AJ_APUR() {
        return COD_AJ_APUR;
    }

    /**
     * Codigo do ajuste da apuracao e deducao, conforme a Tabela indicada no item 5.1.1.
     * @param COD_AJ_APUR the COD_AJ_APUR to set
     */
    public void setCOD_AJ_APUR(String COD_AJ_APUR) {
        this.COD_AJ_APUR = COD_AJ_APUR;
    }

    /**
     * Descricao complementar do ajuste da apuracao.
     * @return the DESCR_COMPL_AJ
     */
    public String getDESCR_COMPL_AJ() {
        return DESCR_COMPL_AJ;
    }

    /**
     * Descricao complementar do ajuste da apuracao.
     * @param DESCR_COMPL_AJ the DESCR_COMPL_AJ to set
     */
    public void setDESCR_COMPL_AJ(String DESCR_COMPL_AJ) {
        this.DESCR_COMPL_AJ = DESCR_COMPL_AJ;
    }

    /**
     * Valor do ajuste da apuracao.
     * @return the VL_AJ_APUR
     */
    public double getVL_AJ_APUR() {
        return VL_AJ_APUR;
    }

    /**
     * Valor do ajuste da apuracao.
     * @param VL_AJ_APUR the VL_AJ_APUR to set
     */
    public void setVL_AJ_APUR(double VL_AJ_APUR) {
        this.VL_AJ_APUR = VL_AJ_APUR;
    }
    // </editor-fold>    
    
}