package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Reducao Z (codigos 2E, 13, 14, 15 e 16).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 16:30:03, revisao: $Id$
 */
public class RegistroD355 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * PIS e Cofins totalizados no dia (codigo 2E, 13, 14, 15 e 16).
     */
    private Collection<RegistroD360> registroD360 = new ArrayList<RegistroD360>(); 
    /**
     * Registro dos totalizadores parciais da reducao Z (codigos 2E, 13, 14, 15 e 16).
     */
    private Collection<RegistroD365> registroD365 = new ArrayList<RegistroD365>(); 
    /**
     * Registro analitico do movimento diario (codigos 13, 14, 15, 16 e 2E).
     */
    private Collection<RegistroD390> registroD390 = new ArrayList<RegistroD390>();     
    /**
     * Data do movimento a que se refere a Reducao Z.
     */
    private Date DT_DOC;
    /**
     * Posicao do Contador de Reinicio de Operacao.
     */
    private int CRO;
    /**
     * Posicao do Contador de Reducao Z.
     */
    private int CRZ;
    /**
     * Numero do Contador de Ordem de Operacao do ultimo documento emitido no dia. 
     * (Numero do COO na Reducao Z)
     */
    private int NUM_COO_FIN;
    /**
     * Valor do Grande Total final.
     */
    private double GT_FIN;
    /**
     * Valor da venda bruta.
     */
    private double VL_BRT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * PIS e Cofins totalizados no dia (codigo 2E, 13, 14, 15 e 16).
     * @return the registroD360
     */
    public Collection<RegistroD360> getRegistroD360() {
        return registroD360;
    }

    /**
     * Registro dos totalizadores parciais da reducao Z (codigos 2E, 13, 14, 15 e 16).
     * @return the registroD365
     */
    public Collection<RegistroD365> getRegistroD365() {
        return registroD365;
    }

    /**
     * Registro analitico do movimento diario (codigos 13, 14, 15, 16 e 2E).
     * @return the registroD390
     */
    public Collection<RegistroD390> getRegistroD390() {
        return registroD390;
    }

    /**
     * Data do movimento a que se refere a Reducao Z.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data do movimento a que se refere a Reducao Z.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Posicao do Contador de Reinicio de Operacao.
     * @return the CRO
     */
    public int getCRO() {
        return CRO;
    }

    /**
     * Posicao do Contador de Reinicio de Operacao.
     * @param CRO the CRO to set
     */
    public void setCRO(int CRO) {
        this.CRO = CRO;
    }

    /**
     * Posicao do Contador de Reducao Z.
     * @return the CRZ
     */
    public int getCRZ() {
        return CRZ;
    }

    /**
     * Posicao do Contador de Reducao Z.
     * @param CRZ the CRZ to set
     */
    public void setCRZ(int CRZ) {
        this.CRZ = CRZ;
    }

    /**
     * Numero do Contador de Ordem de Operacao do ultimo documento emitido no dia.
     * (Numero do COO na Reducao Z)
     * @return the NUM_COO_FIN
     */
    public int getNUM_COO_FIN() {
        return NUM_COO_FIN;
    }

    /**
     * Numero do Contador de Ordem de Operacao do ultimo documento emitido no dia.
     * (Numero do COO na Reducao Z)
     * @param NUM_COO_FIN the NUM_COO_FIN to set
     */
    public void setNUM_COO_FIN(int NUM_COO_FIN) {
        this.NUM_COO_FIN = NUM_COO_FIN;
    }

    /**
     * Valor do Grande Total final.
     * @return the GT_FIN
     */
    public double getGT_FIN() {
        return GT_FIN;
    }

    /**
     * Valor do Grande Total final.
     * @param GT_FIN the GT_FIN to set
     */
    public void setGT_FIN(double GT_FIN) {
        this.GT_FIN = GT_FIN;
    }

    /**
     * Valor da venda bruta.
     * @return the VL_BRT
     */
    public double getVL_BRT() {
        return VL_BRT;
    }

    /**
     * Valor da venda bruta.
     * @param VL_BRT the VL_BRT to set
     */
    public void setVL_BRT(double VL_BRT) {
        this.VL_BRT = VL_BRT;
    }
    // </editor-fold>
    
}