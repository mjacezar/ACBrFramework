package jACBrFramework.aac;

import java.util.EventObject;

/**
 * Evento acionado no processo de criptografia.
 * 
 * @author Jose Mauro
 * @version Criado em: 16/12/2013 16:32:44, revisao: $Id$
 */
public class AACCryptEventObject extends EventObject {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Conteudo do Arquivo.
     */
    private String conteudoArquivo;
    /**
     * Resposta da criptografia.
     */
    private String resposta;
    // </editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public AACCryptEventObject(Object pSource, String pConteudoArquivo, String pResposta) {
        super(pSource);
        this.conteudoArquivo = pConteudoArquivo;
        this.resposta = pResposta;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Conteudo do Arquivo.
     * @return the conteudoArquivo
     */
    public String getConteudoArquivo() {
        return conteudoArquivo;
    }

    /**
     * Resposta da criptografia.
     * @return the resposta
     */
    public String getResposta() {
        return resposta;
    }

    /**
     * Resposta da criptografia.
     * @param resposta the resposta to set
     */
    public void setResposta(String resposta) {
        this.resposta = resposta;
    }
    // </editor-fold>       
    
}