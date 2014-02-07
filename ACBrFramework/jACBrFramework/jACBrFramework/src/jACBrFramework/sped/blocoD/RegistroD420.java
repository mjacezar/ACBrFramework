package jACBrFramework.sped.blocoD;

/**
 * Complemento dos documentos informados (codigos 13, 14, 15 e 16).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 17:11:31, revisao: $Id$
 */
public class RegistroD420 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * Valor total da prestacao de servico.
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
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     * @return the COD_MUN_ORIG
     */
    public String getCOD_MUN_ORIG() {
        return COD_MUN_ORIG;
    }

    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     * @param COD_MUN_ORIG the COD_MUN_ORIG to set
     */
    public void setCOD_MUN_ORIG(String COD_MUN_ORIG) {
        this.COD_MUN_ORIG = COD_MUN_ORIG;
    }

    /**
     * Valor total da prestacao de servico.
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor total da prestacao de servico.
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
    // </editor-fold>    

}