package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.nio.ByteBuffer;
import java.util.EventObject;

/**
 * Evento para obtencao do campo.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 09:02:07, revisao: $Id$
 */
public class TEFVeSPagueObtemCampoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -7845006194605602981L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo a ser exibido.
     */
    private String titulo;
    /**
     * Mascara.
     */
    private String mascara;
    /**
     * Tipo do campo.
     */
    private int tipo;
    /**
     * Resposta.
     */
    private ByteBuffer resposta;
    /** 
     * Digitado.
     */
    private IntByReference digitado;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public TEFVeSPagueObtemCampoEventObject(Object pSource, String pTitulo, String pMascara, char pTipo) {
        super(pSource);
        this.titulo = pTitulo;
        this.mascara = pMascara;
        this.tipo = pTipo;
        this.resposta = ByteBuffer.allocate(256);
        this.digitado = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Tipo a ser exibido.
     * @return the titulo
     */
    public String getTitulo() {
        return titulo;
    }

    /**
     * Mascara.
     * @return the mascara
     */
    public String getMascara() {
        return mascara;
    }

    /**
     * Tipo do campo.
     * @return the tipo
     */
    public int getTipo() {
        return tipo;
    }

    /**
     * Resposta.
     * @return the resposta
     */
    public ByteBuffer getResposta() {
        return resposta;
    }

    /**
     * Resposta.
     * @param resposta the resposta to set
     */
    public void setResposta(ByteBuffer resposta) {
        this.resposta = resposta;
    }

    /**
     * Digitado.
     * @return the digitado
     */
    public IntByReference getDigitado() {
        return digitado;
    }

    /**
     * Digitado.
     * @param digitado the digitado to set
     */
    public void setDigitado(IntByReference digitado) {
        this.digitado = digitado;
    }
    // </editor-fold>

}