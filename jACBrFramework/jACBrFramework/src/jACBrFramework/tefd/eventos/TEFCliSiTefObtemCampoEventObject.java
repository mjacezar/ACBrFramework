package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.tefd.TefCliSiTefOperacaoCampo;
import java.nio.ByteBuffer;
import java.util.EventObject;

/**
 * Evento para obtencao do campo.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 13:11:40, revisao: $Id$
 */
public class TEFCliSiTefObtemCampoEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -3354588000373466291L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo a ser exibido.
     */
    private String titulo;
    /**
     * Tamanho minimo.
     */
    private int tamanhoMinimo;
    /**
     * Tamanho maximo.
     */
    private int tamanhoMaximo;
    /**
     * Tipo do campo.
     */
    private int tipoCampo;
    /**
     * Operacao.
     */
    private TefCliSiTefOperacaoCampo operacao;
    /**
     * Resposta.
     */
    private ByteBuffer resposta;
    /**
     * Tamanho do resposta.
     */
    private int tamanhoResposta;
    /** 
     * Digitado.
     */
    private IntByReference digitado;
    /**
     * Voltar ao menu.
     */
    private IntByReference voltarMenu;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public TEFCliSiTefObtemCampoEventObject(Object pSource, String pTitulo,
            int pTamanhoMinimo, int pTamanhoMaximo, int pTipoCampo, TefCliSiTefOperacaoCampo pOperacao) {
        super(pSource);
        this.titulo = pTitulo;
        this.tamanhoMinimo = pTamanhoMinimo;
        this.tamanhoMaximo = pTamanhoMaximo;
        this.tipoCampo = pTipoCampo;
        this.operacao = pOperacao;
        this.resposta = ByteBuffer.allocate(256);
        this.digitado = new IntByReference();
        this.voltarMenu = new IntByReference();
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
     * Tamanho minimo.
     * @return the tamanhoMinimo
     */
    public int getTamanhoMinimo() {
        return tamanhoMinimo;
    }

    /**
     * Tamanho maximo.
     * @return the tamanhoMaximo
     */
    public int getTamanhoMaximo() {
        return tamanhoMaximo;
    }

    /**
     * Tipo do campo.
     * @return the tipoCampo
     */
    public int getTipoCampo() {
        return tipoCampo;
    }

    /**
     * Operacao.
     * @return the operacao
     */
    public TefCliSiTefOperacaoCampo getOperacao() {
        return operacao;
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
     * Tamanho do resposta.
     * @return the tamanhoResposta
     */
    public int getTamanhoResposta() {
        return tamanhoResposta;
    }

    /**
     * Tamanho do resposta.
     * @param tamanhoResposta the tamanhoResposta to set
     */
    public void setTamanhoResposta(int tamanhoResposta) {
        this.tamanhoResposta = tamanhoResposta;
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

    /**
     * Voltar ao menu.
     * @return the voltarMenu
     */
    public IntByReference getVoltarMenu() {
        return voltarMenu;
    }

    /**
     * Voltar ao menu.
     * @param voltarMenu the voltarMenu to set
     */
    public void setVoltarMenu(IntByReference voltarMenu) {
        this.voltarMenu = voltarMenu;
    }
    // </editor-fold>

}