package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.tefd.OperacaoECF;
import jACBrFramework.tefd.Resp;
import java.util.EventObject;

/**
 * Evento de controle de comunicacao com a ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 13:17:13, revisao: $Id$
 */
public class ComandaECFEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 9183076507202427806L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Operacao realizada.
     */
    private OperacaoECF operacao;
    /**
     * Resposta obtida.
     */
    private Resp resp;
    /**
     * Retorno da ECF.
     */
    private IntByReference retornoEcf;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComandaECFEventObject(Object pSource, OperacaoECF pOperacao, Resp pResp) {
        super(pSource);
        this.operacao = pOperacao;
        this.resp = pResp;
        this.retornoEcf = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Operacao realizada.
     * @return the operacao
     */
    public OperacaoECF getOperacao() {
        return operacao;
    }

    /**
     * Resposta obtida.
     * @return the resp
     */
    public Resp getResp() {
        return resp;
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