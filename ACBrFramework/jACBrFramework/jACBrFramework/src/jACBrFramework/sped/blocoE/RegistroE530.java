package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.OrigemDocto;
import jACBrFramework.sped.TipoAjuste;

/**
 * Ajustes da apuracao do IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:10:02, revisao: $Id$
 */
public class RegistroE530 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de ajuste.
     */
    private TipoAjuste IND_AJ;
    /**
     * Valor do ajuste.
     */
    private double VL_AJ;
    /**
     * Codigo do ajuste da apuracao, conforme a Tabela indicada no item 4.5.4.
     */
    private String COD_AJ;
    /**
     * Indicador da origem do documento vinculado ao ajuste.
     */
    private OrigemDocto IND_DOC;
    /**
     * Numero do documento / processo / declaracao ao qual o ajuste esta vinculado, se houver.
     */
    private String NUM_DOC;
    /**
     * Descricao resumida do ajuste.
     */
    private String DESCR_AJ;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de ajuste.
     * @return the IND_AJ
     */
    public TipoAjuste getIND_AJ() {
        return IND_AJ;
    }

    /**
     * Indicador do tipo de ajuste.
     * @param IND_AJ the IND_AJ to set
     */
    public void setIND_AJ(TipoAjuste IND_AJ) {
        this.IND_AJ = IND_AJ;
    }

    /**
     * Valor do ajuste.
     * @return the VL_AJ
     */
    public double getVL_AJ() {
        return VL_AJ;
    }

    /**
     * Valor do ajuste.
     * @param VL_AJ the VL_AJ to set
     */
    public void setVL_AJ(double VL_AJ) {
        this.VL_AJ = VL_AJ;
    }

    /**
     * Codigo do ajuste da apuracao, conforme a Tabela indicada no item 4.5.4.
     * @return the COD_AJ
     */
    public String getCOD_AJ() {
        return COD_AJ;
    }

    /**
     * Codigo do ajuste da apuracao, conforme a Tabela indicada no item 4.5.4.
     * @param COD_AJ the COD_AJ to set
     */
    public void setCOD_AJ(String COD_AJ) {
        this.COD_AJ = COD_AJ;
    }

    /**
     * Indicador da origem do documento vinculado ao ajuste.
     * @return the IND_DOC
     */
    public OrigemDocto getIND_DOC() {
        return IND_DOC;
    }

    /**
     * Indicador da origem do documento vinculado ao ajuste.
     * @param IND_DOC the IND_DOC to set
     */
    public void setIND_DOC(OrigemDocto IND_DOC) {
        this.IND_DOC = IND_DOC;
    }

    /**
     * Numero do documento / processo / declaracao ao qual o ajuste esta vinculado, se houver.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento / processo / declaracao ao qual o ajuste esta vinculado, se houver.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Descricao resumida do ajuste.
     * @return the DESCR_AJ
     */
    public String getDESCR_AJ() {
        return DESCR_AJ;
    }

    /**
     * Descricao resumida do ajuste.
     * @param DESCR_AJ the DESCR_AJ to set
     */
    public void setDESCR_AJ(String DESCR_AJ) {
        this.DESCR_AJ = DESCR_AJ;
    }
    // </editor-fold>    
    
}