package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.DoctoArrecada;
import java.util.Date;

/**
 * Documento de arrecadacao diferenciado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:47:21, revisao: $Id$
 */
public class RegistroC112 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do modelo do documento de arrecadacao.
     */
    private DoctoArrecada COD_DA;
    /**
     * Unidade federada beneficiaria do recolhimento.
     */
    private String UF;
    /**
     * Numero do documento de arrecadacao.
     */
    private String NUM_DA;
    /**
     * Codigo completo da autenticacao bancaria.
     */
    private String COD_AUT;
    /**
     * Valor do total do documento de arrecadacao (principal, atualizacao monetaria, juros e multa).
     */
    private double VL_DA;
    /**
     * Data de vencimento do documento de arrecadacao.
     */
    private Date DT_VCTO;
    /**
     * Data de pagamento do documento de arrecadacao, ou data do vencimento, no caso de ICMS antecipado a recolher.
     */
    private Date DT_PGTO;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do modelo do documento de arrecadacao.
     * @return the COD_DA
     */
    public DoctoArrecada getCOD_DA() {
        return COD_DA;
    }

    /**
     * Codigo do modelo do documento de arrecadacao.
     * @param COD_DA the COD_DA to set
     */
    public void setCOD_DA(DoctoArrecada COD_DA) {
        this.COD_DA = COD_DA;
    }

    /**
     * Unidade federada beneficiaria do recolhimento.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Unidade federada beneficiaria do recolhimento.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
    }

    /**
     * Numero do documento de arrecadacao.
     * @return the NUM_DA
     */
    public String getNUM_DA() {
        return NUM_DA;
    }

    /**
     * Numero do documento de arrecadacao.
     * @param NUM_DA the NUM_DA to set
     */
    public void setNUM_DA(String NUM_DA) {
        this.NUM_DA = NUM_DA;
    }

    /**
     * Codigo completo da autenticacao bancaria.
     * @return the COD_AUT
     */
    public String getCOD_AUT() {
        return COD_AUT;
    }

    /**
     * Codigo completo da autenticacao bancaria.
     * @param COD_AUT the COD_AUT to set
     */
    public void setCOD_AUT(String COD_AUT) {
        this.COD_AUT = COD_AUT;
    }

    /**
     * Valor do total do documento de arrecadacao (principal, atualizacao monetaria, juros e multa).
     * @return the VL_DA
     */
    public double getVL_DA() {
        return VL_DA;
    }

    /**
     * Valor do total do documento de arrecadacao (principal, atualizacao monetaria, juros e multa).
     * @param VL_DA the VL_DA to set
     */
    public void setVL_DA(double VL_DA) {
        this.VL_DA = VL_DA;
    }

    /**
     * Data de vencimento do documento de arrecadacao.
     * @return the DT_VCTO
     */
    public Date getDT_VCTO() {
        return DT_VCTO;
    }

    /**
     * Data de vencimento do documento de arrecadacao.
     * @param DT_VCTO the DT_VCTO to set
     */
    public void setDT_VCTO(Date DT_VCTO) {
        this.DT_VCTO = DT_VCTO;
    }

    /**
     * Data de pagamento do documento de arrecadacao, ou data do vencimento, no caso de ICMS antecipado a recolher.
     * @return the DT_PGTO
     */
    public Date getDT_PGTO() {
        return DT_PGTO;
    }

    /**
     * Data de pagamento do documento de arrecadacao, ou data do vencimento, no caso de ICMS antecipado a recolher.
     * @param DT_PGTO the DT_PGTO to set
     */
    public void setDT_PGTO(Date DT_PGTO) {
        this.DT_PGTO = DT_PGTO;
    }
    // </editor-fold>

}