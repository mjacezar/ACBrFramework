package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Evento aguarda resposta.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 11:22:00, revisao: $Id$
 */
public class AguardaRespEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 7989434192726826345L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Arquivo.
     */
    private String arquivo;
    /**
     * Timeout em segundos.
     */
    private int timeoutEmSegundos;
    /**
     * Handle associado a acao de interrupcao.
     */
    private IntByReference interromper;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AguardaRespEventObject(Object pSource, String pArquivo, int pTimeoutEmSegundos) {
        super(pSource);
        this.arquivo = pArquivo;
        this.timeoutEmSegundos = pTimeoutEmSegundos;
        this.interromper = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Arquivo.
     * @return the arquivo
     */
    public String getArquivo() {
        return arquivo;
    }

    /**
     * Timeout em segundos.
     * @return the timeoutEmSegundos
     */
    public int getTimeoutEmSegundos() {
        return timeoutEmSegundos;
    }

    /**
     * Handle associado a acao de interrupcao.
     * @return the interromper
     */
    public IntByReference getInterromper() {
        return interromper;
    }

    /**
     * Handle associado a acao de interrupcao.
     * @param interromper the interromper to set
     */
    public void setInterromper(IntByReference interromper) {
        this.interromper = interromper;
    }
    // </editor-fold>    

}