package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.ReqEstado;
import java.util.EventObject;

/**
 * Evento de mudanca no estado da requisicao.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:59:21, revisao: $Id$
 */
public class MudaEstadoReqEventObject extends EventObject {    
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 3545648478621097615L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Estado da requisicao.
     */
    private ReqEstado estadoReq;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public MudaEstadoReqEventObject(Object pSource, ReqEstado pEstadoReq) {
        super(pSource);
        this.estadoReq = pEstadoReq;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Estado da requisicao.
     * @return the estadoReq
     */
    public ReqEstado getEstadoReq() {
        return estadoReq;
    }
    // </editor-fold>    

}