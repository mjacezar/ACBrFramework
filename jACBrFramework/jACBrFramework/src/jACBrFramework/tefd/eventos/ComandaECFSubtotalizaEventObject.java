package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Evento acionado ao subtotalizar o cupom.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:14:04, revisao: $Id$
 */
public class ComandaECFSubtotalizaEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 165127898399702421L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Valor do desconto/acrescimo.
     */
    private double descAcres;
    /**
     * Retorno da ECF.
     */
    private IntByReference retornoEcf;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComandaECFSubtotalizaEventObject(Object pSource, double pDescAcres) {
        super(pSource);
        this.descAcres = pDescAcres;
        this.retornoEcf = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Valor do desconto/acrescimo.
     * @return the descAcres
     */
    public double getDescAcres() {
        return descAcres;
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