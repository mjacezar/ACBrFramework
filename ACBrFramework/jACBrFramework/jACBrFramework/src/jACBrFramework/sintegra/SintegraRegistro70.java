package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Nota fiscal de servico de transporte.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:39, revisao: $Id$
 */
public class SintegraRegistro70 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Montante do imposto (com duas decimais).
     */
    private double icms;
    /**
     * Valor total do documento fiscal (com 2 decimais).
     */
    private double valorContabil;
    /**
     * Sigla da unidade da Federacao do emitente do documento, no caso de 
     * aquisicao de servico, ou do tomador do serviço, no caso de emissao do documento.
     */
    private String uf;
    /**
     * Valor amparado por isencao ou nao incidencia (com duas decimais).
     */
    private double isentas;
    /**
     * Subserie do documento.
     */
    private String subSerie;
    /**
     * Serie do documento.
     */
    private String serie;
    /**
     * Data de emissao para o prestador, ou data de utilizacao do serviço para o tomador.
     */
    private Date dataDocumento;
    /**
     * Codigo do modelo do documento fiscal.
     */
    private String modelo;
    /**
     * CNPJ do emitente do documento, no caso de aquisicao de servico; CNPJ do 
     * tomador do servico, no caso de emissao do documento.
     */
    private String cpfCnpj;
    /**
     * Codigo Fiscal de Operacao e Prestacao - Um registro para cada CFOP do 
     * documento fiscal.
     */
    private String cfop;
    /**
     * Numero do documento.
     */
    private String numero;
    /**
     * Inscricao estadual do emitente do documento, no caso de aquisicao de 
     * servico; Inscricao estadual do tomador do serviço, no caso de emissao do documento.
     */
    private String inscricao;
    /**
     * Situacao do documento fiscal.
     */
    private String situacao;
    /**
     * Valor que nao confira debito ou credito do ICMS (com duas decimais).
     */
    private double outras;
    /**
     * Base de calculo do ICMS (com duas decimais).
     */
    private double baseCalculo;
    /**
     * Modalidade do frete.
     */
    private ModalidadeFrete cifFobOutros;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
   
    /**
     * Montante do imposto (com duas decimais).
     * @return the icms
     */
    public double getIcms() {
        return icms;
    }

    /**
     * Montante do imposto (com duas decimais).
     * @param icms the icms to set
     */
    public void setIcms(double icms) {
        this.icms = icms;
    }

    /**
     * Valor total do documento fiscal (com 2 decimais).
     * @return the valorContabil
     */
    public double getValorContabil() {
        return valorContabil;
    }

    /**
     * Valor total do documento fiscal (com 2 decimais).
     * @param valorContabil the valorContabil to set
     */
    public void setValorContabil(double valorContabil) {
        this.valorContabil = valorContabil;
    }

    /**
     * Sigla da unidade da Federacao do emitente do documento, no caso de
     * aquisicao de servico, ou do tomador do serviço, no caso de emissao do documento.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Sigla da unidade da Federacao do emitente do documento, no caso de
     * aquisicao de servico, ou do tomador do serviço, no caso de emissao do documento.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * Valor amparado por isencao ou nao incidencia (com duas decimais).
     * @return the isentas
     */
    public double getIsentas() {
        return isentas;
    }

    /**
     * Valor amparado por isencao ou nao incidencia (com duas decimais).
     * @param isentas the isentas to set
     */
    public void setIsentas(double isentas) {
        this.isentas = isentas;
    }

    /**
     * Subserie do documento.
     * @return the subSerie
     */
    public String getSubSerie() {
        return subSerie;
    }

    /**
     * Subserie do documento.
     * @param subSerie the subSerie to set
     */
    public void setSubSerie(String subSerie) {
        this.subSerie = subSerie;
    }

    /**
     * Serie do documento.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie do documento.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Data de emissao para o prestador, ou data de utilizacao do serviço para o tomador.
     * @return the dataDocumento
     */
    public Date getDataDocumento() {
        return dataDocumento;
    }

    /**
     * Data de emissao para o prestador, ou data de utilizacao do serviço para o tomador.
     * @param dataDocumento the dataDocumento to set
     */
    public void setDataDocumento(Date dataDocumento) {
        this.dataDocumento = dataDocumento;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * CNPJ do emitente do documento, no caso de aquisicao de servico; CNPJ do
     * tomador do servico, no caso de emissao do documento.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ do emitente do documento, no caso de aquisicao de servico; CNPJ do
     * tomador do servico, no caso de emissao do documento.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao - Um registro para cada CFOP do
     * documento fiscal.
     * @return the cfop
     */
    public String getCfop() {
        return cfop;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao - Um registro para cada CFOP do
     * documento fiscal.
     * @param cfop the cfop to set
     */
    public void setCfop(String cfop) {
        this.cfop = cfop;
    }

    /**
     * Numero do documento.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero do documento.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Inscricao estadual do emitente do documento, no caso de aquisicao de
     * servico; Inscricao estadual do tomador do serviço, no caso de emissao do documento.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual do emitente do documento, no caso de aquisicao de
     * servico; Inscricao estadual do tomador do serviço, no caso de emissao do documento.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Situacao do documento fiscal.
     * @return the situacao
     */
    public String getSituacao() {
        return situacao;
    }

    /**
     * Situacao do documento fiscal.
     * @param situacao the situacao to set
     */
    public void setSituacao(String situacao) {
        this.situacao = situacao;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS (com duas decimais).
     * @return the outras
     */
    public double getOutras() {
        return outras;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS (com duas decimais).
     * @param outras the outras to set
     */
    public void setOutras(double outras) {
        this.outras = outras;
    }

    /**
     * Base de calculo do ICMS (com duas decimais).
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS (com duas decimais).
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Modalidade do frete.
     * @return the cifFobOutros
     */
    public ModalidadeFrete getCifFobOutros() {
        return cifFobOutros;
    }

    /**
     * Modalidade do frete.
     * @param cifFobOutros the cifFobOutros to set
     */
    public void setCifFobOutros(ModalidadeFrete cifFobOutros) {
        this.cifFobOutros = cifFobOutros;
    }
    // </editor-fold>      
    
}