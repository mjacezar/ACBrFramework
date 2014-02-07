package jACBrFramework.sped.bloco1;

/**
 * Utilizacao de creditos fiscais - ICMS.
 *
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:43:38, revisao: $Id$
 */
public class Registro1210 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo de utilizacao do credito, conforme tabela indicada no item 5.5.
     */
    private String TIPO_UTIL;
    /**
     * Numero do documento utilizado na baixa de creditos.
     */
    private String NR_DOC;
    /**
     * Total de credito utilizado.
     */
    private double VL_CRED_UTIL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Tipo de utilizacao do credito, conforme tabela indicada no item 5.5.
     * @return the TIPO_UTIL
     */
    public String getTIPO_UTIL() {
        return TIPO_UTIL;
    }

    /**
     * Tipo de utilizacao do credito, conforme tabela indicada no item 5.5.
     * @param TIPO_UTIL the TIPO_UTIL to set
     */
    public void setTIPO_UTIL(String TIPO_UTIL) {
        this.TIPO_UTIL = TIPO_UTIL;
    }

    /**
     * Numero do documento utilizado na baixa de creditos.
     * @return the NR_DOC
     */
    public String getNR_DOC() {
        return NR_DOC;
    }

    /**
     * Numero do documento utilizado na baixa de creditos.
     * @param NR_DOC the NR_DOC to set
     */
    public void setNR_DOC(String NR_DOC) {
        this.NR_DOC = NR_DOC;
    }

    /**
     * Total de credito utilizado.
     * @return the VL_CRED_UTIL
     */
    public double getVL_CRED_UTIL() {
        return VL_CRED_UTIL;
    }

    /**
     * Total de credito utilizado.
     * @param VL_CRED_UTIL the VL_CRED_UTIL to set
     */
    public void setVL_CRED_UTIL(double VL_CRED_UTIL) {
        this.VL_CRED_UTIL = VL_CRED_UTIL;
    }
    // </editor-fold>

}