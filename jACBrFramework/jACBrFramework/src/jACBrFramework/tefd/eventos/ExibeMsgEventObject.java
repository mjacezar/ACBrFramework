package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.tefd.OperacaoMensagem;
import java.util.EventObject;

/**
 * Evento para exibicao da mensagem.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:24:13, revisao: $Id$
 */
public class ExibeMsgEventObject extends EventObject {    
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = -3881237765954980428L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Operacao.
     */
    private OperacaoMensagem operacao;
    /**
     * Mensagem.
     */
    private String mensagem;
    /**
     * Resultado modal.
     */
    private IntByReference aModalResult;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ExibeMsgEventObject(Object pSource, OperacaoMensagem pOperacao,
            String pMensagem) {
        super(pSource);
        this.operacao = pOperacao;
        this.mensagem = pMensagem;
        this.aModalResult = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Operacao.
     * @return the operacao
     */
    public OperacaoMensagem getOperacao() {
        return operacao;
    }

    /**
     * Mensagem.
     * @return the mensagem
     */
    public String getMensagem() {
        return mensagem;
    }

    /**
     * Resultado modal.
     * @return the aModalResult
     */
    public IntByReference getaModalResult() {
        return aModalResult;
    }

    /**
     * Resultado modal.
     * @param aModalResult the aModalResult to set
     */
    public void setaModalResult(IntByReference aModalResult) {
        this.aModalResult = aModalResult;
    }
    // </editor-fold>    

}