package jACBrFramework.sped.blocoC;

/**
 * Operacoes com produtos sujeitos a tributacao de IPI por unidade ou quantidade de produto. 
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 16:25:34, revisao: $Id$
 */
public class RegistroC178 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da classe de enquadramento do IPI, conforme Tabela 4.5.1.
     */
    private String CL_ENQ;
    /**
     * Valor por unidade padrao de tributacao.
     */
    private double VL_UNID;
    /**
     * Quantidade total de produtos na unidade padrao de tributacao.
     */
    private double QUANT_PAD;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da classe de enquadramento do IPI, conforme Tabela 4.5.1.
     * @return the CL_ENQ
     */
    public String getCL_ENQ() {
        return CL_ENQ;
    }

    /**
     * Codigo da classe de enquadramento do IPI, conforme Tabela 4.5.1.
     * @param CL_ENQ the CL_ENQ to set
     */
    public void setCL_ENQ(String CL_ENQ) {
        this.CL_ENQ = CL_ENQ;
    }

    /**
     * Valor por unidade padrao de tributacao.
     * @return the VL_UNID
     */
    public double getVL_UNID() {
        return VL_UNID;
    }

    /**
     * Valor por unidade padrao de tributacao.
     * @param VL_UNID the VL_UNID to set
     */
    public void setVL_UNID(double VL_UNID) {
        this.VL_UNID = VL_UNID;
    }

    /**
     * Quantidade total de produtos na unidade padrao de tributacao.
     * @return the QUANT_PAD
     */
    public double getQUANT_PAD() {
        return QUANT_PAD;
    }

    /**
     * Quantidade total de produtos na unidade padrao de tributacao.
     * @param QUANT_PAD the QUANT_PAD to set
     */
    public void setQUANT_PAD(double QUANT_PAD) {
        this.QUANT_PAD = QUANT_PAD;
    }
    // </editor-fold>    
    
}