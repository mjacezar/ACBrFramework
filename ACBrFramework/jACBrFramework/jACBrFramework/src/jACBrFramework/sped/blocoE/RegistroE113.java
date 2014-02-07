package jACBrFramework.sped.blocoE;

import java.util.Date;

/**
 * Informacoes adicionais dos ajustes da apuracao do ICMS - Identificacao dos documentos fiscais.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:45:48, revisao: $Id$
 */
public class RegistroE113 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150):
     *  - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
     *  - do adquirente, no caso de saidas.
     */
    private String COD_PART;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    //TODO Ver campo.
    /**
     * Chave nota fiscal eletronica.
     */
    private String CHV_NFE;
    /**
     * Codigo do item (campo 02 do Registro 0200)
     */
    private String COD_ITEM;
    /**
     * Valor do ajuste para a operacao/item.
     */
    private double VL_AJ_ITEM;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
     * - do adquirente, no caso de saidas.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - do emitente do documento ou do remetente das mercadorias, no caso de entradas;
     * - do adquirente, no caso de saidas.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

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
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
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

    /**
     * Chave nota fiscal eletronica.
     * @return the CHV_NFE
     */
    public String getCHV_NFE() {
        return CHV_NFE;
    }

    /**
     * Chave nota fiscal eletronica.
     * @param CHV_NFE the CHV_NFE to set
     */
    public void setCHV_NFE(String CHV_NFE) {
        this.CHV_NFE = CHV_NFE;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200)
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200)
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Valor do ajuste para a operacao/item.
     * @return the VL_AJ_ITEM
     */
    public double getVL_AJ_ITEM() {
        return VL_AJ_ITEM;
    }

    /**
     * Valor do ajuste para a operacao/item.
     * @param VL_AJ_ITEM the VL_AJ_ITEM to set
     */
    public void setVL_AJ_ITEM(double VL_AJ_ITEM) {
        this.VL_AJ_ITEM = VL_AJ_ITEM;
    }
    // </editor-fold>    
    
}