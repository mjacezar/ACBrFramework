package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Evento de realizacao de pagamento.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:07:08, revisao: $Id$
 */
public class ComandaECFPagamentoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 3386762163782354951L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indice da ECF.
     */
    private String indiceEcf;
    /**
     * Valor da transacao.
     */
    private double valor;
    /**
     * Retorno da ECF.
     */
    private IntByReference retornoEcf;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComandaECFPagamentoEventObject(Object pSource, String pIndiceEcf, double pValor) {
        super(pSource);
        this.indiceEcf = pIndiceEcf;
        this.valor = pValor;
        this.retornoEcf = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Indice da ECF.
     * @return the indiceEcf
     */
    public String getIndiceEcf() {
        return indiceEcf;
    }

    /**
     * Valor da transacao.
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Retorno da ECF.
     * @return the retornoEcf
     */
    public IntByReference getRetornoEcf() {
        return retornoEcf;
    }

    /**
     * Retorno da ECF.
     * @param retornoEcf the retornoEcf to set
     */
    public void setRetornoEcf(IntByReference retornoEcf) {
        this.retornoEcf = retornoEcf;
    }
    // </editor-fold>    

}