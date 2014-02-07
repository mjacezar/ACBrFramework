package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.Emitente;
import jACBrFramework.sped.TipoTitulo;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Fatura (codigo 01)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 13:40:39, revisao: $Id$
 */
public class RegistroC140 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Vencimento da fatura (codigo 01).
     */
    private Collection<RegistroC141> registroC141 = new ArrayList<RegistroC141>();     
    /**
     * Indicador do emitente do titulo.
     */
    private Emitente IND_EMIT;
    /**
     * Indicador do tipo de titulo de credito.
     */
    private TipoTitulo IND_TIT;
    /**
     * Descricao complementar do titulo de credito.
     */
    private String DESC_TIT;
    /**
     * Numero ou codigo identificador do titulo de credito.
     */
    private String NUM_TIT;
    /**
     * Quantidade de parcelas a receber/pagar.
     */
    private int QTD_PARC;
    /**
     * Valor total dos titulos de creditos.
     */
    private double VL_TIT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Vencimento da fatura (codigo 01).
     * @return the registroC141
     */
    public Collection<RegistroC141> getRegistroC141() {
        return registroC141;
    }

    /**
     * Indicador do emitente do titulo.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do emitente do titulo.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Indicador do tipo de titulo de credito.
     * @return the IND_TIT
     */
    public TipoTitulo getIND_TIT() {
        return IND_TIT;
    }

    /**
     * Indicador do tipo de titulo de credito.
     * @param IND_TIT the IND_TIT to set
     */
    public void setIND_TIT(TipoTitulo IND_TIT) {
        this.IND_TIT = IND_TIT;
    }

    /**
     * Descricao complementar do titulo de credito.
     * @return the DESC_TIT
     */
    public String getDESC_TIT() {
        return DESC_TIT;
    }

    /**
     * Descricao complementar do titulo de credito.
     * @param DESC_TIT the DESC_TIT to set
     */
    public void setDESC_TIT(String DESC_TIT) {
        this.DESC_TIT = DESC_TIT;
    }

    /**
     * Numero ou codigo identificador do titulo de credito.
     * @return the NUM_TIT
     */
    public String getNUM_TIT() {
        return NUM_TIT;
    }

    /**
     * Numero ou codigo identificador do titulo de credito.
     * @param NUM_TIT the NUM_TIT to set
     */
    public void setNUM_TIT(String NUM_TIT) {
        this.NUM_TIT = NUM_TIT;
    }

    /**
     * Quantidade de parcelas a receber/pagar.
     * @return the QTD_PARC
     */
    public int getQTD_PARC() {
        return QTD_PARC;
    }

    /**
     * Quantidade de parcelas a receber/pagar.
     * @param QTD_PARC the QTD_PARC to set
     */
    public void setQTD_PARC(int QTD_PARC) {
        this.QTD_PARC = QTD_PARC;
    }

    /**
     * Valor total dos titulos de creditos.
     * @return the VL_TIT
     */
    public double getVL_TIT() {
        return VL_TIT;
    }

    /**
     * Valor total dos titulos de creditos.
     * @param VL_TIT the VL_TIT to set
     */
    public void setVL_TIT(double VL_TIT) {
        this.VL_TIT = VL_TIT;
    }
    // </editor-fold>
    
}