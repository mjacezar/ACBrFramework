package jACBrFramework.sped.blocoC;

import java.util.Date;

/**
 * Cupom fiscal referenciado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 11:07:52, revisao: $Id$
 */
public class RegistroC114 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do modelo do documento fiscal, conforme a tabela indicada no item 4.1.1.
     */
    private String COD_MOD;
    /**
     * Numero de serie de fabricacao do ECF.
     */
    private String ECF_FAB;
    /**
     * Numero do caixa atribuido ao ECF.
     */
    private String ECF_CX;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do modelo do documento fiscal, conforme a tabela indicada no item 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a tabela indicada no item 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Numero de serie de fabricacao do ECF.
     * @return the ECF_FAB
     */
    public String getECF_FAB() {
        return ECF_FAB;
    }

    /**
     * Numero de serie de fabricacao do ECF.
     * @param ECF_FAB the ECF_FAB to set
     */
    public void setECF_FAB(String ECF_FAB) {
        this.ECF_FAB = ECF_FAB;
    }

    /**
     * Numero do caixa atribuido ao ECF.
     * @return the ECF_CX
     */
    public String getECF_CX() {
        return ECF_CX;
    }

    /**
     * Numero do caixa atribuido ao ECF.
     * @param ECF_CX the ECF_CX to set
     */
    public void setECF_CX(String ECF_CX) {
        this.ECF_CX = ECF_CX;
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
    // </editor-fold>
    
}