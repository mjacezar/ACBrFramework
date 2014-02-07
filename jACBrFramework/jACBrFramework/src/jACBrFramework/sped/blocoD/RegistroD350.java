package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Equipamento ECF (codigos 2E, 13, 14, 15 e 16).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 16:29:51, revisao: $Id$
 */
public class RegistroD350 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Reducao Z (codigos 2E, 13, 14, 15 e 16).
     */
    private Collection<RegistroD355> registroD355 = new ArrayList<RegistroD355>();     
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
     * Reducao Z (codigos 2E, 13, 14, 15 e 16).
     * @return the registroD355
     */
    public Collection<RegistroD355> getRegistroD355() {
        return registroD355;
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