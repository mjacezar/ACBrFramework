package jACBrFramework.sped.blocoE;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Ajuste/Beneficio/Incentivo da apuracao do ICMS Substituicao Tributaria.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:21:58, revisao: $Id$
 */
public class RegistroE220 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Informacoes adicionais dos ajustes da apuracao do ICMS Substituicao Tributaria.
     */
    private Collection<RegistroE230> registroE230 = new ArrayList<RegistroE230>(); 
    /**
     * Informacoes adicionais dos ajutes da apuracao do ICMS Substituicao Tributaria 
     * - Identificacao dos Documentos Fiscais.
     */
    private Collection<RegistroE240> registroE240 = new ArrayList<RegistroE240>();     
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
     * Informacoes adicionais dos ajustes da apuracao do ICMS Substituicao Tributaria.
     * @return the registroE230
     */
    public Collection<RegistroE230> getRegistroE230() {
        return registroE230;
    }

    /**
     * Informacoes adicionais dos ajutes da apuracao do ICMS Substituicao Tributaria
     * - Identificacao dos Documentos Fiscais.
     * @return the registroE240
     */
    public Collection<RegistroE240> getRegistroE240() {
        return registroE240;
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