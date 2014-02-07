package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Itens do documento - nota fiscal de servicos de transporte (codigo 07). 
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:27:01, revisao: $Id$
 */
public class RegistroD110 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Complemento da nota fiscal de servicos de transporte (codigo 07).
     */
    private Collection<RegistroD120> registroD120 = new ArrayList<RegistroD120>();     
    /**
     * Numero sequencial do item no documento fiscal.
     */
    private int NUN_ITEM;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;
    /**
     * Valor do servico .
     */
    private double VL_SERV;
    /**
     * Outros valores.
     */
    private double VL_OUT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Complemento da nota fiscal de servicos de transporte (codigo 07).
     * @return the registroD120
     */
    public Collection<RegistroD120> getRegistroD120() {
        return registroD120;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @return the NUN_ITEM
     */
    public int getNUN_ITEM() {
        return NUN_ITEM;
    }

    /**
     * Numero sequencial do item no documento fiscal.
     * @param NUN_ITEM the NUN_ITEM to set
     */
    public void setNUN_ITEM(int NUN_ITEM) {
        this.NUN_ITEM = NUN_ITEM;
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
     * Valor do servico .
     * @return the VL_SERV
     */
    public double getVL_SERV() {
        return VL_SERV;
    }

    /**
     * Valor do servico .
     * @param VL_SERV the VL_SERV to set
     */
    public void setVL_SERV(double VL_SERV) {
        this.VL_SERV = VL_SERV;
    }

    /**
     * Outros valores.
     * @return the VL_OUT
     */
    public double getVL_OUT() {
        return VL_OUT;
    }

    /**
     * Outros valores.
     * @param VL_OUT the VL_OUT to set
     */
    public void setVL_OUT(double VL_OUT) {
        this.VL_OUT = VL_OUT;
    }
    // </editor-fold>    
    
}