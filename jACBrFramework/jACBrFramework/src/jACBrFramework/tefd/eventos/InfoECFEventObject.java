package jACBrFramework.tefd.eventos;

import jACBrFramework.tefd.InfoECF;
import java.nio.ByteBuffer;
import java.util.EventObject;

/**
 * Evento para as informacoes do ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 06/03/2014 14:53:27, revisao: $Id$
 */
public class InfoECFEventObject extends EventObject {    
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 526886697896540616L;    
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Operacao.
     */
    private InfoECF operacao;
    /**
     * Retorno da ECF.
     */
    private ByteBuffer retornoEcf;
    /**
     * Tamanho do Retorno.
     */
    private int tamanhoRetorno;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public InfoECFEventObject(Object pSource, InfoECF pOperacao) {
        super(pSource);
        this.operacao = pOperacao;
    }
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Methods">
    //TODO Ver os metodos aqui.
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Operacao.
     * @return the operacao
     */
    public InfoECF getOperacao() {
        return operacao;
    }

    /**
     * Retorno da ECF.
     * @return the retornoEcf
     */
    public ByteBuffer getRetornoEcf() {
        return retornoEcf;
    }

    /**
     * Retorno da ECF.
     * @param retornoEcf the retornoEcf to set
     */
    public void setRetornoEcf(ByteBuffer retornoEcf) {
        this.retornoEcf = retornoEcf;
    }

    /**
     * Tamanho do Retorno.
     * @return the tamanhoRetorno
     */
    public int getTamanhoRetorno() {
        return tamanhoRetorno;
    }

    /**
     * Tamanho do Retorno.
     * @param tamanhoRetorno the tamanhoRetorno to set
     */
    public void setTamanhoRetorno(int tamanhoRetorno) {
        this.tamanhoRetorno = tamanhoRetorno;
    }
    // </editor-fold>    

}