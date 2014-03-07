package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Informa bloquei de mouse e teclado.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 11:36:30, revisao: $Id$
 */
public class BloqueiaMouseTecladoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 4622946108727474660L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indica bloqueio das transacoes.
     */
    private int bloqueia;
    /**
     * Handler para resposta tratado.
     */
    private IntByReference tratado;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public BloqueiaMouseTecladoEventObject(Object pSource, int pBloqueia) {
        super(pSource);
        this.bloqueia = pBloqueia;
        this.tratado = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Indica bloqueio das transacoes.
     * @return the bloqueia
     */
    public int getBloqueia() {
        return bloqueia;
    }

    /**
     * Handler para resposta tratado.
     * @return the tratado
     */
    public IntByReference getTratado() {
        return tratado;
    }

    /**
     * Handler para resposta tratado.
     * @param tratado the tratado to set
     */
    public void setTratado(IntByReference tratado) {
        this.tratado = tratado;
    }
    // </editor-fold>    

}