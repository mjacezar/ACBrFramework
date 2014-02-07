package jACBrFramework.sped.blocoH;

import jACBrFramework.sped.MotivoInventario;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Totais do inventario.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 15:33:33, revisao: $Id$
 */
public class RegistroH005 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Inventario.
     */
    private Collection<RegistroH010> registroH010 = new ArrayList<RegistroH010>();     
    /**
     * Data do inventario.
     */
    private Date DT_INV;
    /**
     * Valor total do estoque.
     */
    private double VL_INV;
    /**
     * Informe o motivo do Inventario.
     */
    private MotivoInventario MOT_INV;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Inventario.
     * @return the registroH010
     */
    public Collection<RegistroH010> getRegistroH010() {
        return registroH010;
    }

    /**
     * Data do inventario.
     * @return the DT_INV
     */
    public Date getDT_INV() {
        return DT_INV;
    }

    /**
     * Data do inventario.
     * @param DT_INV the DT_INV to set
     */
    public void setDT_INV(Date DT_INV) {
        this.DT_INV = DT_INV;
    }

    /**
     * Valor total do estoque.
     * @return the VL_INV
     */
    public double getVL_INV() {
        return VL_INV;
    }

    /**
     * Valor total do estoque.
     * @param VL_INV the VL_INV to set
     */
    public void setVL_INV(double VL_INV) {
        this.VL_INV = VL_INV;
    }

    /**
     * Informe o motivo do Inventario.
     * @return the MOT_INV
     */
    public MotivoInventario getMOT_INV() {
        return MOT_INV;
    }

    /**
     * Informe o motivo do Inventario.
     * @param MOT_INV the MOT_INV to set
     */
    public void setMOT_INV(MotivoInventario MOT_INV) {
        this.MOT_INV = MOT_INV;
    }
    // </editor-fold>    
    
}