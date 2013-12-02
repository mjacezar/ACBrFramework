package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Substituicao tributaria.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:35:41, revisao: $Id$
 */
public class SintegraRegistro53 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * CNPJ do contribuinte Substituido.
     */
    private String cpfCnpj;
    /**
     * Inscricao estadual do Contribuinte substituido.
     */
    private String inscricao;
    /**
     * Sigla da unidade da Federacao do contribuinte substituido.
     */
    private String estado;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    /**
     * Data de emissao na saida ou recebimento na entrada.
     */
    private Date dataDocumento;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String cfop;
    /**
     * Numero da nota fiscal.
     */
    private String numero;
    /**
     * Situacao a nota fiscal.
     */
    private String situacao;
    /**
     * Codigo que identifica o tipo da antecipacao tributaria.
     */
    private String codigoAntecipacao;
    /**
     * Base de calculo de retencao do ICMS (com 2 decimais).
     */
    private double baseST;
    /**
     * Codigo do modelo da nota Fiscal.
     */
    private String modelo;
    /**
     * Emitente da Nota Fiscal (P-proprio / T-terceiros).
     */
    private TipoEmitenteNotaFiscal emitente;
    /**
     * Soma das despesas acessorias (frete, seguro e outras - com 2 decimais).
     */
    private double despesas;
    /**
     * ICMS retido pelo substituto (com 2 decimais).
     */
    private double icmsRetido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * CNPJ do contribuinte Substituido.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ do contribuinte Substituido.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
    }

    /**
     * Inscricao estadual do Contribuinte substituido.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual do Contribuinte substituido.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Sigla da unidade da Federacao do contribuinte substituido.
     * @return the estado
     */
    public String getEstado() {
        return estado;
    }

    /**
     * Sigla da unidade da Federacao do contribuinte substituido.
     * @param estado the estado to set
     */
    public void setEstado(String estado) {
        this.estado = estado;
    }

    /**
     * Serie da nota fiscal.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie da nota fiscal.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Data de emissao na saida ou recebimento na entrada.
     * @return the dataDocumento
     */
    public Date getDataDocumento() {
        return dataDocumento;
    }

    /**
     * Data de emissao na saida ou recebimento na entrada.
     * @param dataDocumento the dataDocumento to set
     */
    public void setDataDocumento(Date dataDocumento) {
        this.dataDocumento = dataDocumento;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @return the cfop
     */
    public String getCfop() {
        return cfop;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @param cfop the cfop to set
     */
    public void setCfop(String cfop) {
        this.cfop = cfop;
    }

    /**
     * Numero da nota fiscal.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero da nota fiscal.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Situacao a nota fiscal.
     * @return the situacao
     */
    public String getSituacao() {
        return situacao;
    }

    /**
     * Situacao a nota fiscal.
     * @param situacao the situacao to set
     */
    public void setSituacao(String situacao) {
        this.situacao = situacao;
    }

    /**
     * Codigo que identifica o tipo da antecipacao tributaria.
     * @return the codigoAntecipacao
     */
    public String getCodigoAntecipacao() {
        return codigoAntecipacao;
    }

    /**
     * Codigo que identifica o tipo da antecipacao tributaria.
     * @param codigoAntecipacao the codigoAntecipacao to set
     */
    public void setCodigoAntecipacao(String codigoAntecipacao) {
        this.codigoAntecipacao = codigoAntecipacao;
    }

    /**
     * Base de calculo de retencao do ICMS (com 2 decimais).
     * @return the baseST
     */
    public double getBaseST() {
        return baseST;
    }

    /**
     * Base de calculo de retencao do ICMS (com 2 decimais).
     * @param baseST the baseST to set
     */
    public void setBaseST(double baseST) {
        this.baseST = baseST;
    }

    /**
     * Codigo do modelo da nota Fiscal.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo da nota Fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Emitente da Nota Fiscal (P-proprio / T-terceiros).
     * @return the emitente
     */
    public TipoEmitenteNotaFiscal getEmitente() {
        return emitente;
    }

    /**
     * Emitente da Nota Fiscal (P-proprio / T-terceiros).
     * @param emitente the emitente to set
     */
    public void setEmitente(TipoEmitenteNotaFiscal emitente) {
        this.emitente = emitente;
    }

    /**
     * Soma das despesas acessorias (frete, seguro e outras - com 2 decimais).
     * @return the despesas
     */
    public double getDespesas() {
        return despesas;
    }

    /**
     * Soma das despesas acessorias (frete, seguro e outras - com 2 decimais).
     * @param despesas the despesas to set
     */
    public void setDespesas(double despesas) {
        this.despesas = despesas;
    }

    /**
     * ICMS retido pelo substituto (com 2 decimais).
     * @return the icmsRetido
     */
    public double getIcmsRetido() {
        return icmsRetido;
    }

    /**
     * ICMS retido pelo substituto (com 2 decimais).
     * @param icmsRetido the icmsRetido to set
     */
    public void setIcmsRetido(double icmsRetido) {
        this.icmsRetido = icmsRetido;
    }
    // </editor-fold>
    
}