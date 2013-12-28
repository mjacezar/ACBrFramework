package jACBrFramework.paf;

/**
 * Identificacao do PAF-ECF.
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:43:17, revisao: $Id$
 */
public final class ACBrPAFRegistroN2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero do Laudo de Analise Funcional.
     */
    private String laudo;
    /**
     * Nome do aplicativo indicado no Laudo de Analise Tecnica.
     */
    private String nome;
    /**
     * Versao atual do aplicativo indicado no Laudo de Analise Tecnica.
     */
    private String versao;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero do Laudo de Analise Funcional.
     * @return the laudo
     */
    public String getLaudo() {
        return laudo;
    }

    /**
     * Numero do Laudo de Analise Funcional.
     * @param laudo the laudo to set
     */
    public void setLaudo(String laudo) {
        this.laudo = laudo;
    }

    /**
     * Nome do aplicativo indicado no Laudo de Analise Tecnica.
     * @return the nome
     */
    public String getNome() {
        return nome;
    }

    /**
     * Nome do aplicativo indicado no Laudo de Analise Tecnica.
     * @param nome the nome to set
     */
    public void setNome(String nome) {
        this.nome = nome;
    }

    /**
     * Versao atual do aplicativo indicado no Laudo de Analise Tecnica.
     * @return the versao
     */
    public String getVersao() {
        return versao;
    }

    /**
     * Versao atual do aplicativo indicado no Laudo de Analise Tecnica.
     * @param versao the versao to set
     */
    public void setVersao(String versao) {
        this.versao = versao;
    }
    // </editor-fold>           
    
}