package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.RespostasPendentes;
import java.util.EventObject;

/**
 * Evento acionado antes de cancelar a transacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 11:29:44, revisao: $Id$
 */
public class AntesCancelarTransacaoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 5938819023863653922L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Handler associado a resposta pendente.
     */
    private RespostasPendentes respostaPendente;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AntesCancelarTransacaoEventObject(Object pSource, RespostasPendentes pRespostaPendente) {
        super(pSource);
        this.respostaPendente = pRespostaPendente;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Handler associado a resposta pendente.
     * @return the respostaPendente
     */
    public RespostasPendentes getRespostaPendente() {
        return respostaPendente;
    }
    // </editor-fold>    

}