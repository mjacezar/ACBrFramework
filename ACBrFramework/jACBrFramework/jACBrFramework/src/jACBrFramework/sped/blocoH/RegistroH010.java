package jACBrFramework.sped.blocoH;

import jACBrFramework.sped.PosseItem;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Inventario.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:33:44, revisao: $Id$
 */
public class RegistroH010 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Informacao complementar do Inventario.
     */
    private Collection<RegistroH020> registroH020 = new ArrayList<RegistroH020>();     
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Unidade do item.
     */
    private String UNID;
    /**
     * Quantidade do item.
     */
    private double QTD;
    /**
     * Valor unitario do item.
     */
    private double VL_UNIT;
    /**
     * Valor do item.
     */
    private double VL_ITEM;
    /**
     * Indicador de propriedade/posse do item.
     */
    private PosseItem IND_PROP;
    /**
     * Codigo do participante (campo 02 do Registro 0150): 
     *  - proprietario/possuidor que nao seja o informante do arquivo.
     */
    private String COD_PART;
    /**
     * Descricao complementar.
     */
    private String TXT_COMPL;
    /**
     * Codigo da conta analítica contabil debitada/creditada.
     */
    private String COD_CTA;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Informacao complementar do Inventario.
     * @return the registroH020
     */
    public Collection<RegistroH020> getRegistroH020() {
        return registroH020;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Unidade do item.
     * @return the UNID
     */
    public String getUNID() {
        return UNID;
    }

    /**
     * Unidade do item.
     * @param UNID the UNID to set
     */
    public void setUNID(String UNID) {
        this.UNID = UNID;
    }

    /**
     * Quantidade do item.
     * @return the QTD
     */
    public double getQTD() {
        return QTD;
    }

    /**
     * Quantidade do item.
     * @param QTD the QTD to set
     */
    public void setQTD(double QTD) {
        this.QTD = QTD;
    }

    /**
     * Valor unitario do item.
     * @return the VL_UNIT
     */
    public double getVL_UNIT() {
        return VL_UNIT;
    }

    /**
     * Valor unitario do item.
     * @param VL_UNIT the VL_UNIT to set
     */
    public void setVL_UNIT(double VL_UNIT) {
        this.VL_UNIT = VL_UNIT;
    }

    /**
     * Valor do item.
     * @return the VL_ITEM
     */
    public double getVL_ITEM() {
        return VL_ITEM;
    }

    /**
     * Valor do item.
     * @param VL_ITEM the VL_ITEM to set
     */
    public void setVL_ITEM(double VL_ITEM) {
        this.VL_ITEM = VL_ITEM;
    }

    /**
     * Indicador de propriedade/posse do item.
     * @return the IND_PROP
     */
    public PosseItem getIND_PROP() {
        return IND_PROP;
    }

    /**
     * Indicador de propriedade/posse do item.
     * @param IND_PROP the IND_PROP to set
     */
    public void setIND_PROP(PosseItem IND_PROP) {
        this.IND_PROP = IND_PROP;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - proprietario/possuidor que nao seja o informante do arquivo.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150):
     * - proprietario/possuidor que nao seja o informante do arquivo.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Descricao complementar.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricao complementar.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }

    /**
     * Codigo da conta analítica contabil debitada/creditada.
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analítica contabil debitada/creditada.
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }
    // </editor-fold>    
    
}