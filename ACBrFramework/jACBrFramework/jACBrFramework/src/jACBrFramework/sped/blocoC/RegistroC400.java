package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Equipamento ECF (codigo 02, 2D e 60).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:07:39, revisao: $Id$
 */
public class RegistroC400 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Reducao Z (codigo 02, 2D e 6).
     */
    private Collection<RegistroC405> registroC405 = new ArrayList<RegistroC405>();     
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Modelo do equipamento.
     */
    private String ECF_MOD;
    /**
     * Numero de serie de fabricacao do ECF.
     */
    private String ECF_FAB;
    /**
     * Numero do caixa atribuido ao ECF.
     */
    private String ECF_CX;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Reducao Z (codigo 02, 2D e 6).
     * @return the registroC405
     */
    public Collection<RegistroC405> getRegistroC405() {
        return registroC405;
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
     * Modelo do equipamento.
     * @return the ECF_MOD
     */
    public String getECF_MOD() {
        return ECF_MOD;
    }

    /**
     * Modelo do equipamento.
     * @param ECF_MOD the ECF_MOD to set
     */
    public void setECF_MOD(String ECF_MOD) {
        this.ECF_MOD = ECF_MOD;
    }

    /**
     * Numero de serie de fabricacao do ECF.
     * @return the ECF_FAB
     */
    public String getECF_FAB() {
        return ECF_FAB;
    }

    /**
     * Numero de serie de fabricacao do ECF.
     * @param ECF_FAB the ECF_FAB to set
     */
    public void setECF_FAB(String ECF_FAB) {
        this.ECF_FAB = ECF_FAB;
    }

    /**
     * Numero do caixa atribuido ao ECF.
     * @return the ECF_CX
     */
    public String getECF_CX() {
        return ECF_CX;
    }

    /**
     * Numero do caixa atribuido ao ECF.
     * @param ECF_CX the ECF_CX to set
     */
    public void setECF_CX(String ECF_CX) {
        this.ECF_CX = ECF_CX;
    }
    // </editor-fold>
    
}