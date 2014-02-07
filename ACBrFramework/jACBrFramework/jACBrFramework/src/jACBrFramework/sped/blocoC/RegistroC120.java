package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.DoctoImporta;

/**
 * Complemento de documento - operacoes de importacao (codigo 01 e 55)
 *  
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:31:46, revisao: $Id$
 */
public class RegistroC120 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documento de importacao.
     */
    private DoctoImporta COD_DOC_IMP;
    /**
     * Numero do documento de Importacao.
     */
    private String NUM_DOC__IMP;
    /**
     * Valor pago de PIS na importacao.
     */
    private double PIS_IMP;
    /**
     * Valor pago de COFINS na importacao.
     */
    private double COFINS_IMP;
    /**
     * Numero do Ato Concessorio do regime Drawback.
     */
    private String NUM_ACDRAW;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Documento de importacao.
     * @return the COD_DOC_IMP
     */
    public DoctoImporta getCOD_DOC_IMP() {
        return COD_DOC_IMP;
    }

    /**
     * Documento de importacao.
     * @param COD_DOC_IMP the COD_DOC_IMP to set
     */
    public void setCOD_DOC_IMP(DoctoImporta COD_DOC_IMP) {
        this.COD_DOC_IMP = COD_DOC_IMP;
    }

    /**
     * Numero do documento de Importacao.
     * @return the NUM_DOC__IMP
     */
    public String getNUM_DOC__IMP() {
        return NUM_DOC__IMP;
    }

    /**
     * Numero do documento de Importacao.
     * @param NUM_DOC__IMP the NUM_DOC__IMP to set
     */
    public void setNUM_DOC__IMP(String NUM_DOC__IMP) {
        this.NUM_DOC__IMP = NUM_DOC__IMP;
    }

    /**
     * Valor pago de PIS na importacao.
     * @return the PIS_IMP
     */
    public double getPIS_IMP() {
        return PIS_IMP;
    }

    /**
     * Valor pago de PIS na importacao.
     * @param PIS_IMP the PIS_IMP to set
     */
    public void setPIS_IMP(double PIS_IMP) {
        this.PIS_IMP = PIS_IMP;
    }

    /**
     * Valor pago de COFINS na importacao.
     * @return the COFINS_IMP
     */
    public double getCOFINS_IMP() {
        return COFINS_IMP;
    }

    /**
     * Valor pago de COFINS na importacao.
     * @param COFINS_IMP the COFINS_IMP to set
     */
    public void setCOFINS_IMP(double COFINS_IMP) {
        this.COFINS_IMP = COFINS_IMP;
    }

    /**
     * Numero do Ato Concessorio do regime Drawback.
     * @return the NUM_ACDRAW
     */
    public String getNUM_ACDRAW() {
        return NUM_ACDRAW;
    }

    /**
     * Numero do Ato Concessorio do regime Drawback.
     * @param NUM_ACDRAW the NUM_ACDRAW to set
     */
    public void setNUM_ACDRAW(String NUM_ACDRAW) {
        this.NUM_ACDRAW = NUM_ACDRAW;
    }
    // </editor-fold>

}