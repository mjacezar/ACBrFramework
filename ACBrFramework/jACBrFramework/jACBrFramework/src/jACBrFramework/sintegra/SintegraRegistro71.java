package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Informacoes da carga transportada.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:45, revisao: $Id$
 */
public class SintegraRegistro71 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">        
    /**
     * CNPJ do tomador do servico.
     */
    private String cpfCnpj;
    /**
     * Inscricao estadual do tomador do servico.
     */
    private String inscricao;
    /**
     * Data de emissao do conhecimento.
     */
    private Date dataDocumento;
    /**
     * Modelo do conhecimento.
     */
    private String modelo;
    /**
     * Serie do conhecimento.
     */
    private String serie;
    /**
     * Subserie do conhecimento.
     */
    private String subSerie;
    /**
     * Numero do conhecimento.
     */
    private String numero;
    /**
     * Unidade da Federacao do tomador do servico.
     */
    private String uf;
    /**
     * Unidade da Federacao do remetente, se o destinatario for o tomador ou 
     * unidade da Federacao do destinatario, se o remetente for o tomador.
     */
    private String ufNF;
    /**
     * CNPJ do remetente, se o destinatario for o tomador ou CNPJ do destinatario, 
     * se o remetente for o tomador.
     */
    private String cpfCnpjNF;
    /**
     * Inscricao estadual do remetente, se o destinatario for o tomador ou 
     * Inscricao estadual do destinataio, se o remetente for o tomador.
     */
    private String inscricaoNF;
    /**
     * Data de emissao da nota fiscal que acoberta a carga transportada.
     */
    private Date dataNF;
    /**
     * Modelo da nota fiscal que acoberta a carga transportada.
     */
    private String modeloNF;
    /**
     * Serie da nota fiscal que acoberta a carga transportada.
     */
    private String serieNF;
    /**
     * Numero da nota fiscal que acoberta a carga transportada.
     */
    private String numeroNF;
    /**
     * Valor total da nota fiscal que acoberta a carga transportada.
     */
    private double valorNF;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  

    /**
     * CNPJ do tomador do servico.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ do tomador do servico.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
    }

    /**
     * Inscricao estadual do tomador do servico.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual do tomador do servico.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Data de emissao do conhecimento.
     * @return the dataDocumento
     */
    public Date getDataDocumento() {
        return dataDocumento;
    }

    /**
     * Data de emissao do conhecimento.
     * @param dataDocumento the dataDocumento to set
     */
    public void setDataDocumento(Date dataDocumento) {
        this.dataDocumento = dataDocumento;
    }

    /**
     * Modelo do conhecimento.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Modelo do conhecimento.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Serie do conhecimento.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie do conhecimento.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Subserie do conhecimento.
     * @return the subSerie
     */
    public String getSubSerie() {
        return subSerie;
    }

    /**
     * Subserie do conhecimento.
     * @param subSerie the subSerie to set
     */
    public void setSubSerie(String subSerie) {
        this.subSerie = subSerie;
    }

    /**
     * Numero do conhecimento.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero do conhecimento.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Unidade da Federacao do tomador do servico.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Unidade da Federacao do tomador do servico.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * Unidade da Federacao do remetente, se o destinatario for o tomador ou
     * unidade da Federacao do destinatario, se o remetente for o tomador.
     * @return the ufNF
     */
    public String getUfNF() {
        return ufNF;
    }

    /**
     * Unidade da Federacao do remetente, se o destinatario for o tomador ou
     * unidade da Federacao do destinatario, se o remetente for o tomador.
     * @param ufNF the ufNF to set
     */
    public void setUfNF(String ufNF) {
        this.ufNF = ufNF;
    }

    /**
     * CNPJ do remetente, se o destinatario for o tomador ou CNPJ do destinatario,
     * se o remetente for o tomador.
     * @return the cpfCnpjNF
     */
    public String getCpfCnpjNF() {
        return cpfCnpjNF;
    }

    /**
     * CNPJ do remetente, se o destinatario for o tomador ou CNPJ do destinatario,
     * se o remetente for o tomador.
     * @param cpfCnpjNF the cpfCnpjNF to set
     */
    public void setCpfCnpjNF(String cpfCnpjNF) {
        this.cpfCnpjNF = cpfCnpjNF;
    }

    /**
     * Inscricao estadual do remetente, se o destinatario for o tomador ou
     * Inscricao estadual do destinataio, se o remetente for o tomador.
     * @return the inscricaoNF
     */
    public String getInscricaoNF() {
        return inscricaoNF;
    }

    /**
     * Inscricao estadual do remetente, se o destinatario for o tomador ou
     * Inscricao estadual do destinataio, se o remetente for o tomador.
     * @param inscricaoNF the inscricaoNF to set
     */
    public void setInscricaoNF(String inscricaoNF) {
        this.inscricaoNF = inscricaoNF;
    }

    /**
     * Data de emissao da nota fiscal que acoberta a carga transportada.
     * @return the dataNF
     */
    public Date getDataNF() {
        return dataNF;
    }

    /**
     * Data de emissao da nota fiscal que acoberta a carga transportada.
     * @param dataNF the dataNF to set
     */
    public void setDataNF(Date dataNF) {
        this.dataNF = dataNF;
    }

    /**
     * Modelo da nota fiscal que acoberta a carga transportada.
     * @return the modeloNF
     */
    public String getModeloNF() {
        return modeloNF;
    }

    /**
     * Modelo da nota fiscal que acoberta a carga transportada.
     * @param modeloNF the modeloNF to set
     */
    public void setModeloNF(String modeloNF) {
        this.modeloNF = modeloNF;
    }

    /**
     * Serie da nota fiscal que acoberta a carga transportada.
     * @return the serieNF
     */
    public String getSerieNF() {
        return serieNF;
    }

    /**
     * Serie da nota fiscal que acoberta a carga transportada.
     * @param serieNF the serieNF to set
     */
    public void setSerieNF(String serieNF) {
        this.serieNF = serieNF;
    }

    /**
     * Numero da nota fiscal que acoberta a carga transportada.
     * @return the numeroNF
     */
    public String getNumeroNF() {
        return numeroNF;
    }

    /**
     * Numero da nota fiscal que acoberta a carga transportada.
     * @param numeroNF the numeroNF to set
     */
    public void setNumeroNF(String numeroNF) {
        this.numeroNF = numeroNF;
    }

    /**
     * Valor total da nota fiscal que acoberta a carga transportada.
     * @return the valorNF
     */
    public double getValorNF() {
        return valorNF;
    }

    /**
     * Valor total da nota fiscal que acoberta a carga transportada.
     * @param valorNF the valorNF to set
     */
    public void setValorNF(double valorNF) {
        this.valorNF = valorNF;
    }
    // </editor-fold>   
    
}