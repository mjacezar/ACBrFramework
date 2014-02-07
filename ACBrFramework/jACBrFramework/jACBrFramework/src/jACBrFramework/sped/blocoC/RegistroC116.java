package jACBrFramework.sped.blocoC;

import java.util.Date;

/**
 * Cupom Fiscal Eletronico Referenciado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:21:59, revisao: $Id$
 */
public class RegistroC116 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Numero de Serie do equipamento SAT.
     */
    private String NR_SAT;
    /**
     * Chave do Cupom Fiscal Eletronico.
     */
    private String CHV_CFE;
    /**
     * Numero do cupom fiscal eleronico.
     */
    private String NUM_CFE;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Numero de Serie do equipamento SAT.
     * @return the NR_SAT
     */
    public String getNR_SAT() {
        return NR_SAT;
    }

    /**
     * Numero de Serie do equipamento SAT.
     * @param NR_SAT the NR_SAT to set
     */
    public void setNR_SAT(String NR_SAT) {
        this.NR_SAT = NR_SAT;
    }

    /**
     * Chave do Cupom Fiscal Eletronico.
     * @return the CHV_CFE
     */
    public String getCHV_CFE() {
        return CHV_CFE;
    }

    /**
     * Chave do Cupom Fiscal Eletronico.
     * @param CHV_CFE the CHV_CFE to set
     */
    public void setCHV_CFE(String CHV_CFE) {
        this.CHV_CFE = CHV_CFE;
    }

    /**
     * Numero do cupom fiscal eleronico.
     * @return the NUM_CFE
     */
    public String getNUM_CFE() {
        return NUM_CFE;
    }

    /**
     * Numero do cupom fiscal eleronico.
     * @param NUM_CFE the NUM_CFE to set
     */
    public void setNUM_CFE(String NUM_CFE) {
        this.NUM_CFE = NUM_CFE;
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