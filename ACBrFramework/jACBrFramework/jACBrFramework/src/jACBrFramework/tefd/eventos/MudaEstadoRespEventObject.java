package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.RespEstado;
import java.util.EventObject;

/**
 * Evento de mudanca no estado da resposta.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 15:03:26, revisao: $Id$
 */
public class MudaEstadoRespEventObject extends EventObject {    
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -1265007382644510197L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Estado da resposta.
     */
    private RespEstado estadoResp;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public MudaEstadoRespEventObject(Object pSource, RespEstado pEstadoResp) {
        super(pSource);
        this.estadoResp = pEstadoResp;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Estado da resposta.
     * @return the estadoResp
     */
    public RespEstado getEstadoResp() {
        return estadoResp;
    }
    // </editor-fold>    

}