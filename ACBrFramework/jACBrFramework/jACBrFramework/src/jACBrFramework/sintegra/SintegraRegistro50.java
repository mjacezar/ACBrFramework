package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Notas fiscais de compras e vendas.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:35:28, revisao: $Id$
 */
public class SintegraRegistro50 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * CNPJ do remetente nas entradas e do destinatario nas saidas.
     */
    private String cpfCnpj;
    /**
     * Inscricao estadual do remetente nas entradas e do destinatario nas saidas.
     */
    private String inscricao;
    /**
     * Sigla da Unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     */
    private String uf;
    /**
     * Situacao da nota fiscal.
     */
    private String situacao;
    /**
     * Aliquota do ICMS (com 2 decimais).
     */
    private double aliquota;
    /**
     * Valor amparado por isencao ou nao incidencia (com 2 decimais).
     */
    private double isentas;
    /**
     * Montante do imposto (com 2 decimais).
     */
    private double icms;
    /**
     * Valor total da nota fiscal (com 2 decimais).
     */
    private double valorContabil;
    /**
     * Base de calculo do ICMS (com 2 decimais).
     */
    private double baseCalculo;
    /**
     * Valor que nao confira debito ou credito do ICMS (com 2 decimais).
     */
    private double outras;
    /**
     * Emitente da nota fiscal (P-próprio/T-terceiros)
     */
    private TipoEmitenteNotaFiscal emissorDocumento;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String cfop;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    /**
     * Codigo do modelo da nota fiscal.
     */
    private String modelo;
    /**
     * Numero da nota fiscal.
     */
    private String numero;
    /**
     * Data de emissao na saida ou de recebimento na entrada.
     */
    private Date dataDocumento;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        
    /**
     * CNPJ do remetente nas entradas e do destinatario nas saidas.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ do remetente nas entradas e do destinatario nas saidas.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
    }

    /**
     * Inscricao estadual do remetente nas entradas e do destinatario nas saidas.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual do remetente nas entradas e do destinatario nas saidas.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Sigla da Unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Sigla da Unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * Situacao da nota fiscal.
     * @return the situacao
     */
    public String getSituacao() {
        return situacao;
    }

    /**
     * Situacao da nota fiscal.
     * @param situacao the situacao to set
     */
    public void setSituacao(String situacao) {
        this.situacao = situacao;
    }

    /**
     * Aliquota do ICMS (com 2 decimais).
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do ICMS (com 2 decimais).
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Valor amparado por isencao ou nao incidencia (com 2 decimais).
     * @return the isentas
     */
    public double getIsentas() {
        return isentas;
    }

    /**
     * Valor amparado por isencao ou nao incidencia (com 2 decimais).
     * @param isentas the isentas to set
     */
    public void setIsentas(double isentas) {
        this.isentas = isentas;
    }

    /**
     * Montante do imposto (com 2 decimais).
     * @return the icms
     */
    public double getIcms() {
        return icms;
    }

    /**
     * Montante do imposto (com 2 decimais).
     * @param icms the icms to set
     */
    public void setIcms(double icms) {
        this.icms = icms;
    }

    /**
     * Valor total da nota fiscal (com 2 decimais).
     * @return the valorContabil
     */
    public double getValorContabil() {
        return valorContabil;
    }

    /**
     * Valor total da nota fiscal (com 2 decimais).
     * @param valorContabil the valorContabil to set
     */
    public void setValorContabil(double valorContabil) {
        this.valorContabil = valorContabil;
    }

    /**
     * Base de calculo do ICMS (com 2 decimais).
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS (com 2 decimais).
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS (com 2 decimais).
     * @return the outras
     */
    public double getOutras() {
        return outras;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS (com 2 decimais).
     * @param outras the outras to set
     */
    public void setOutras(double outras) {
        this.outras = outras;
    }

    /**
     * Emitente da nota fiscal (P-próprio/T-terceiros)
     * @return the emissorDocumento
     */
    public TipoEmitenteNotaFiscal getEmissorDocumento() {
        return emissorDocumento;
    }

    /**
     * Emitente da nota fiscal (P-próprio/T-terceiros)
     * @param emissorDocumento the emissorDocumento to set
     */
    public void setEmissorDocumento(TipoEmitenteNotaFiscal emissorDocumento) {
        this.emissorDocumento = emissorDocumento;
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
     * Codigo do modelo da nota fiscal.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo da nota fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
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
     * Data de emissao na saida ou de recebimento na entrada.
     * @return the dataDocumento
     */
    public Date getDataDocumento() {
        return dataDocumento;
    }

    /**
     * Data de emissao na saida ou de recebimento na entrada.
     * @param dataDocumento the dataDocumento to set
     */
    public void setDataDocumento(Date dataDocumento) {
        this.dataDocumento = dataDocumento;
    }
    // </editor-fold>
    
}