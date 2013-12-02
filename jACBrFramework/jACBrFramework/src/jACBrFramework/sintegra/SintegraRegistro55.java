package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Guia Nacional de Recolhimento de Tributos Estaduais - GNRE
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:36:04, revisao: $Id$
 */
public class SintegraRegistro55 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * Valor recolhido (com 2 decimais).
     */
    private double valor;
    /**
     * Agencia onde foi efetuado o recolhimento.
     */
    private int agencia;
    /**
     * Codigo do banco onde foi efetuado o recolhimento.
     */
    private int banco;
    /**
     * Preencher com o conteudo do campo 15 da GNRE.
     */
    private String numeroConvenio;
    /**
     * Inscricao estadual na unidade da Federacao destinataria do contribuinte substituto tributario.
     */
    private String inscricao;
    /**
     * Mes e ano referente a ocorrencia do fato gerador, formato MMAAAA.
     */
    private String mesAno;
    /**
     * CNPJ do contribuinte substituto tributario.
     */
    private String cnpj;
    /**
     * Sigla da unidade da Federacao do contribuinte substituto tributario.
     */
    private String uf;
    /**
     * Numero de autenticacao bancaria do documento de arrecadacao.
     */
    private String numero;
    /**
     * Data do pagamento do documento de arrecadacao.
     */
    private Date dataPagamento;
    /**
     * Data do vencimento do ICMS substituído
     */
    private Date vencimento;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">          
    /**
     * Valor recolhido (com 2 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor recolhido (com 2 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Agencia onde foi efetuado o recolhimento.
     * @return the agencia
     */
    public int getAgencia() {
        return agencia;
    }

    /**
     * Agencia onde foi efetuado o recolhimento.
     * @param agencia the agencia to set
     */
    public void setAgencia(int agencia) {
        this.agencia = agencia;
    }

    /**
     * Codigo do banco onde foi efetuado o recolhimento.
     * @return the banco
     */
    public int getBanco() {
        return banco;
    }

    /**
     * Codigo do banco onde foi efetuado o recolhimento.
     * @param banco the banco to set
     */
    public void setBanco(int banco) {
        this.banco = banco;
    }

    /**
     * Preencher com o conteudo do campo 15 da GNRE.
     * @return the numeroConvenio
     */
    public String getNumeroConvenio() {
        return numeroConvenio;
    }

    /**
     * Preencher com o conteudo do campo 15 da GNRE.
     * @param numeroConvenio the numeroConvenio to set
     */
    public void setNumeroConvenio(String numeroConvenio) {
        this.numeroConvenio = numeroConvenio;
    }

    /**
     * Inscricao estadual na unidade da Federacao destinataria do contribuinte substituto tributario.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual na unidade da Federacao destinataria do contribuinte substituto tributario.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Mes e ano referente a ocorrencia do fato gerador, formato MMAAAA.
     * @return the mesAno
     */
    public String getMesAno() {
        return mesAno;
    }

    /**
     * Mes e ano referente a ocorrencia do fato gerador, formato MMAAAA.
     * @param mesAno the mesAno to set
     */
    public void setMesAno(String mesAno) {
        this.mesAno = mesAno;
    }

    /**
     * CNPJ do contribuinte substituto tributario.
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ do contribuinte substituto tributario.
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Sigla da unidade da Federacao do contribuinte substituto tributario.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Sigla da unidade da Federacao do contribuinte substituto tributario.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * Numero de autenticacao bancaria do documento de arrecadacao.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero de autenticacao bancaria do documento de arrecadacao.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Data do pagamento do documento de arrecadacao.
     * @return the dataPagamento
     */
    public Date getDataPagamento() {
        return dataPagamento;
    }

    /**
     * Data do pagamento do documento de arrecadacao.
     * @param dataPagamento the dataPagamento to set
     */
    public void setDataPagamento(Date dataPagamento) {
        this.dataPagamento = dataPagamento;
    }

    /**
     * Data do vencimento do ICMS substituído
     * @return the vencimento
     */
    public Date getVencimento() {
        return vencimento;
    }

    /**
     * Data do vencimento do ICMS substituído
     * @param vencimento the vencimento to set
     */
    public void setVencimento(Date vencimento) {
        this.vencimento = vencimento;
    }
    // </editor-fold>
    
}