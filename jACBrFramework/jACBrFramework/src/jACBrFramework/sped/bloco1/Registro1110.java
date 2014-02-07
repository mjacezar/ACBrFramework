package jACBrFramework.sped.bloco1;

import java.util.Date;

/**
 * Operacoes de exportacao indireta - mercadorias de terceiros.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 14:55:14, revisao: $Id$
 */
public class Registro1110 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante-Fornecedor da Mercadoria destinada a exportação (campo 02 do Registro 0150).
     */
    private String COD_PART;
    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal recebido com fins especificos de exportacao.
     */
    private String SER;
    /**
     * Numero do documento fiscal recebido com fins especificos de exportacao.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal recebido com fins especificos de exportacao.
     */
    private Date DT_DOC;
    /**
     * Chave da Nota Fiscal Eletronica.
     */
    private String CHV_NFE;
    /**
     * Numero do Memorando de Exportacao.
     */
    private String NR_MEMO;
    /**
     * Quantidade do item efetivamente exportado.
     */
    private double QTD;
    /**
     * UNID do item  (Campo 02 do registro 0190).
     */
    private String UNID;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Codigo do participante-Fornecedor da Mercadoria destinada a exportação (campo 02 do Registro 0150).
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante-Fornecedor da Mercadoria destinada a exportação (campo 02 do Registro 0150).
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie do documento fiscal recebido com fins especificos de exportacao.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal recebido com fins especificos de exportacao.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Numero do documento fiscal recebido com fins especificos de exportacao.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal recebido com fins especificos de exportacao.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Data da emissao do documento fiscal recebido com fins especificos de exportacao.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do documento fiscal recebido com fins especificos de exportacao.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Chave da Nota Fiscal Eletronica.
     * @return the CHV_NFE
     */
    public String getCHV_NFE() {
        return CHV_NFE;
    }

    /**
     * Chave da Nota Fiscal Eletronica.
     * @param CHV_NFE the CHV_NFE to set
     */
    public void setCHV_NFE(String CHV_NFE) {
        this.CHV_NFE = CHV_NFE;
    }

    /**
     * Numero do Memorando de Exportacao.
     * @return the NR_MEMO
     */
    public String getNR_MEMO() {
        return NR_MEMO;
    }

    /**
     * Numero do Memorando de Exportacao.
     * @param NR_MEMO the NR_MEMO to set
     */
    public void setNR_MEMO(String NR_MEMO) {
        this.NR_MEMO = NR_MEMO;
    }

    /**
     * Quantidade do item efetivamente exportado.
     * @return the QTD
     */
    public double getQTD() {
        return QTD;
    }

    /**
     * Quantidade do item efetivamente exportado.
     * @param QTD the QTD to set
     */
    public void setQTD(double QTD) {
        this.QTD = QTD;
    }

    /**
     * UNID do item  (Campo 02 do registro 0190).
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * UNID do item  (Campo 02 do registro 0190).
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }
    // </editor-fold>
    
}