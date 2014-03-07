package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.Req;
import java.util.EventObject;

/**
 * Evento acionado antes de finalizar requisicao.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 11:33:18, revisao: $Id$
 */
public class AntesFinalizarRequisicaoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -6175625793441829048L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Handler associado a requisicao.
     */
    private Req req;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AntesFinalizarRequisicaoEventObject(Object pSource, Req pReq) {
        super(pSource);
        this.req = pReq;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Handler associado a requisicao.
     * @return the req
     */
    public Req getReq() {
        return req;
    }
    // </editor-fold>    

}