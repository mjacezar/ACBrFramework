package jACBrFramework.sped.blocoC;

import java.util.Date;

/**
 * Complemento de Item - Ressarcimento de ICMS em operacoes com Substituicao 
 * Tributaria (codigo 01,55) nas operacoes de entradas.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:42:21, revisao: $Id$
 */
public class RegistroC176 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do modelo do documento fiscal relativa a ultima entrada.
     */
    private String COD_MOD_ULT_E;
    /**
     * Numero do documento fiscal relativa a ultima entrada.
     */
    private String NUM_DOC_ULT_E;
    /**
     * Serie do documento fiscal relativa a ultima entrada.
     */
    private String SER_ULT_E;
    /**
     * Data relativa a ultima entrada da mercadoria.
     */
    private Date DT_ULT_E;
    /**
     * Codigo do participante (do emitente do documento relativa a ultima entrada).
     */
    private String COD_PART_ULT_E;
    /**
     * Quantidade do item relativa a ultima entrada.
     */
    private double QUANT_ULT_E;
    /**
     * Valor unitario da mercadoria constante na NF relativa a ultima entrada 
     * inclusive despesas acessorias.
     */
    private double VL_UNIT_ULT_E;
    /**
     * Valor unitario da base de calculo do imposto pago por substituicao.
     */
    private double VL_UNIT_BC_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do modelo do documento fiscal relativa a ultima entrada.
     * @return the COD_MOD_ULT_E
     */
    public String getCOD_MOD_ULT_E() {
        return COD_MOD_ULT_E;
    }

    /**
     * Codigo do modelo do documento fiscal relativa a ultima entrada.
     * @param COD_MOD_ULT_E the COD_MOD_ULT_E to set
     */
    public void setCOD_MOD_ULT_E(String COD_MOD_ULT_E) {
        this.COD_MOD_ULT_E = COD_MOD_ULT_E;
    }

    /**
     * Numero do documento fiscal relativa a ultima entrada.
     * @return the NUM_DOC_ULT_E
     */
    public String getNUM_DOC_ULT_E() {
        return NUM_DOC_ULT_E;
    }

    /**
     * Numero do documento fiscal relativa a ultima entrada.
     * @param NUM_DOC_ULT_E the NUM_DOC_ULT_E to set
     */
    public void setNUM_DOC_ULT_E(String NUM_DOC_ULT_E) {
        this.NUM_DOC_ULT_E = NUM_DOC_ULT_E;
    }

    /**
     * Serie do documento fiscal relativa a ultima entrada.
     * @return the SER_ULT_E
     */
    public String getSER_ULT_E() {
        return SER_ULT_E;
    }

    /**
     * Serie do documento fiscal relativa a ultima entrada.
     * @param SER_ULT_E the SER_ULT_E to set
     */
    public void setSER_ULT_E(String SER_ULT_E) {
        this.SER_ULT_E = SER_ULT_E;
    }

    /**
     * Data relativa a ultima entrada da mercadoria.
     * @return the DT_ULT_E
     */
    public Date getDT_ULT_E() {
        return DT_ULT_E;
    }

    /**
     * Data relativa a ultima entrada da mercadoria.
     * @param DT_ULT_E the DT_ULT_E to set
     */
    public void setDT_ULT_E(Date DT_ULT_E) {
        this.DT_ULT_E = DT_ULT_E;
    }

    /**
     * Codigo do participante (do emitente do documento relativa a ultima entrada).
     * @return the COD_PART_ULT_E
     */
    public String getCOD_PART_ULT_E() {
        return COD_PART_ULT_E;
    }

    /**
     * Codigo do participante (do emitente do documento relativa a ultima entrada).
     * @param COD_PART_ULT_E the COD_PART_ULT_E to set
     */
    public void setCOD_PART_ULT_E(String COD_PART_ULT_E) {
        this.COD_PART_ULT_E = COD_PART_ULT_E;
    }

    /**
     * Quantidade do item relativa a ultima entrada.
     * @return the QUANT_ULT_E
     */
    public double getQUANT_ULT_E() {
        return QUANT_ULT_E;
    }

    /**
     * Quantidade do item relativa a ultima entrada.
     * @param QUANT_ULT_E the QUANT_ULT_E to set
     */
    public void setQUANT_ULT_E(double QUANT_ULT_E) {
        this.QUANT_ULT_E = QUANT_ULT_E;
    }

    /**
     * Valor unitario da mercadoria constante na NF relativa a ultima entrada
     * inclusive despesas acessorias.
     * @return the VL_UNIT_ULT_E
     */
    public double getVL_UNIT_ULT_E() {
        return VL_UNIT_ULT_E;
    }

    /**
     * Valor unitario da mercadoria constante na NF relativa a ultima entrada
     * inclusive despesas acessorias.
     * @param VL_UNIT_ULT_E the VL_UNIT_ULT_E to set
     */
    public void setVL_UNIT_ULT_E(double VL_UNIT_ULT_E) {
        this.VL_UNIT_ULT_E = VL_UNIT_ULT_E;
    }

    /**
     * Valor unitario da base de calculo do imposto pago por substituicao.
     * @return the VL_UNIT_BC_ST
     */
    public double getVL_UNIT_BC_ST() {
        return VL_UNIT_BC_ST;
    }

    /**
     * Valor unitario da base de calculo do imposto pago por substituicao.
     * @param VL_UNIT_BC_ST the VL_UNIT_BC_ST to set
     */
    public void setVL_UNIT_BC_ST(double VL_UNIT_BC_ST) {
        this.VL_UNIT_BC_ST = VL_UNIT_BC_ST;
    }
    // </editor-fold>    

}