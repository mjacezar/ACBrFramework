package jACBrFramework.sped.blocoC;

/**
 * Informacoes complementares ST (codigo 01).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 16:28:42, revisao: $Id$
 */
public class RegistroC179 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Valor da base de calculo ST na origem/destino em operacoes interestaduais.
     */
    private double BC_ST_ORIG_DEST;
    /**
     * Valor do ICMS-ST a repassar/deduzir em operacoes interestaduais.
     */
    private double ICMS_ST_REP;
    /**
     * Valor do ICMS-ST a complementar a UF de destino.
     */
    private double ICMS_ST_COMPL;
    /**
     * Valor da BC de retencao em remessa promovida por Substituido intermediario.
     */
    private double BC_RET;
    /**
     * Valor da parcela do imposto retido em remessa promovida por substituido intermediario.
     */
    private double ICMS_RET;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Valor da base de calculo ST na origem/destino em operacoes interestaduais.
     * @return the BC_ST_ORIG_DEST
     */
    public double getBC_ST_ORIG_DEST() {
        return BC_ST_ORIG_DEST;
    }

    /**
     * Valor da base de calculo ST na origem/destino em operacoes interestaduais.
     * @param BC_ST_ORIG_DEST the BC_ST_ORIG_DEST to set
     */
    public void setBC_ST_ORIG_DEST(double BC_ST_ORIG_DEST) {
        this.BC_ST_ORIG_DEST = BC_ST_ORIG_DEST;
    }

    /**
     * Valor do ICMS-ST a repassar/deduzir em operacoes interestaduais.
     * @return the ICMS_ST_REP
     */
    public double getICMS_ST_REP() {
        return ICMS_ST_REP;
    }

    /**
     * Valor do ICMS-ST a repassar/deduzir em operacoes interestaduais.
     * @param ICMS_ST_REP the ICMS_ST_REP to set
     */
    public void setICMS_ST_REP(double ICMS_ST_REP) {
        this.ICMS_ST_REP = ICMS_ST_REP;
    }

    /**
     * Valor do ICMS-ST a complementar a UF de destino.
     * @return the ICMS_ST_COMPL
     */
    public double getICMS_ST_COMPL() {
        return ICMS_ST_COMPL;
    }

    /**
     * Valor do ICMS-ST a complementar a UF de destino.
     * @param ICMS_ST_COMPL the ICMS_ST_COMPL to set
     */
    public void setICMS_ST_COMPL(double ICMS_ST_COMPL) {
        this.ICMS_ST_COMPL = ICMS_ST_COMPL;
    }

    /**
     * Valor da BC de retencao em remessa promovida por Substituido intermediario.
     * @return the BC_RET
     */
    public double getBC_RET() {
        return BC_RET;
    }

    /**
     * Valor da BC de retencao em remessa promovida por Substituido intermediario.
     * @param BC_RET the BC_RET to set
     */
    public void setBC_RET(double BC_RET) {
        this.BC_RET = BC_RET;
    }

    /**
     * Valor da parcela do imposto retido em remessa promovida por substituido intermediario.
     * @return the ICMS_RET
     */
    public double getICMS_RET() {
        return ICMS_RET;
    }

    /**
     * Valor da parcela do imposto retido em remessa promovida por substituido intermediario.
     * @param ICMS_RET the ICMS_RET to set
     */
    public void setICMS_RET(double ICMS_RET) {
        this.ICMS_RET = ICMS_RET;
    }
    // </editor-fold>

}