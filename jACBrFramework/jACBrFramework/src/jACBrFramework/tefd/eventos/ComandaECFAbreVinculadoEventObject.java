package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Acionado ao abrir cupom vinculado.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 13:11:26, revisao: $Id$
 */
public class ComandaECFAbreVinculadoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -2215483382246756842L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Contador de ordem da operacao.
     */
    private String coo;
    /**
     * Indica da ECF.
     */
    private String indiceEcf;
    /**
     * Valor da operacao.
     */
    private double valor;
    /**
     * Retorno da ECF.
     */
    private IntByReference retornoEcf;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComandaECFAbreVinculadoEventObject(Object pSource, String pCoo, String pIndiceEcf,
            double pValor) {
        super(pSource);
        this.coo = pCoo;
        this.indiceEcf = pIndiceEcf;
        this.valor = pValor;
        this.retornoEcf = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Contador de ordem da operacao.
     * @return the coo
     */
    public String getCoo() {
        return coo;
    }

    /**
     * Indica da ECF.
     * @return the indiceEcf
     */
    public String getIndiceEcf() {
        return indiceEcf;
    }

    /**
     * Valor da operacao.
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