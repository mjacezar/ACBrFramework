package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Reducao Z (codigo 02, 2D e 6).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:07:50, revisao: $Id$
 */
public class RegistroC405 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * PIS e Cofins totalizados no dia (codigo 02 e 2D).
     */
    private Collection<RegistroC410> registroC410 = new ArrayList<RegistroC410>();    
    /**
     * Registro dos totalizadores parciais da reducao Z (cod 02, 2D e 60).
     */
    private Collection<RegistroC420> registroC420 = new ArrayList<RegistroC420>();    
    /**
     * Documento fiscal emitido por ECF (codigo 02, 2D e 60).
     */
    private Collection<RegistroC460> registroC460 = new ArrayList<RegistroC460>();    
    /**
     * Registro analitico do movimento diario (codigo 02, 2D e 60).
     */
    private Collection<RegistroC490> registroC490 = new ArrayList<RegistroC490>();    
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
     * PIS e Cofins totalizados no dia (codigo 02 e 2D).
     * @return the registroC410
     */
    public Collection<RegistroC410> getRegistroC410() {
        return registroC410;
    }

    /**
     * Registro dos totalizadores parciais da reducao Z (cod 02, 2D e 60).
     * @return the registroC420
     */
    public Collection<RegistroC420> getRegistroC420() {
        return registroC420;
    }

    /**
     * Documento fiscal emitido por ECF (codigo 02, 2D e 60).
     * @return the registroC460
     */
    public Collection<RegistroC460> getRegistroC460() {
        return registroC460;
    }

    /**
     * Registro analitico do movimento diario (codigo 02, 2D e 60).
     * @return the registroC490
     */
    public Collection<RegistroC490> getRegistroC490() {
        return registroC490;
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