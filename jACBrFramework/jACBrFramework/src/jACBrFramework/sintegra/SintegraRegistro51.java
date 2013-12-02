package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Total de nota fiscal quanto ao IPI.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:35:34, revisao: $Id$
 */
public class SintegraRegistro51 {

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
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     */
    private String estado;
    /**
     * Montante do IPI (com 2 decimais).
     */
    private double valorIpi;
    /**
     * Valor total da nota fiscal (com 2 decimais).
     */
    private double valorContabil;
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
     * Situacao da nota fiscal.
     */
    private String situacao;
    /**
     * Valor amparado por isencao ou nao incidencia do IPI (com 2 decimais).
     */
    private double valorIsentas;
    /**
     * Valor que nao confira debito ou credito do IPI (com 2 decimais).
     */
    private double valorOutras;    
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
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @return the estado
     */
    public String getEstado() {
        return estado;
    }

    /**
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @param estado the estado to set
     */
    public void setEstado(String estado) {
        this.estado = estado;
    }

    /**
     * Montante do IPI (com 2 decimais).
     * @return the valorIpi
     */
    public double getValorIpi() {
        return valorIpi;
    }

    /**
     * Montante do IPI (com 2 decimais).
     * @param valorIpi the valorIpi to set
     */
    public void setValorIpi(double valorIpi) {
        this.valorIpi = valorIpi;
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
     * Valor amparado por isencao ou nao incidencia do IPI (com 2 decimais).
     * @return the valorIsentas
     */
    public double getValorIsentas() {
        return valorIsentas;
    }

    /**
     * Valor amparado por isencao ou nao incidencia do IPI (com 2 decimais).
     * @param valorIsentas the valorIsentas to set
     */
    public void setValorIsentas(double valorIsentas) {
        this.valorIsentas = valorIsentas;
    }

    /**
     * Valor que nao confira debito ou credito do IPI (com 2 decimais).
     * @return the valorOutras
     */
    public double getValorOutras() {
        return valorOutras;
    }

    /**
     * Valor que nao confira debito ou credito do IPI (com 2 decimais).
     * @param valorOutras the valorOutras to set
     */
    public void setValorOutras(double valorOutras) {
        this.valorOutras = valorOutras;
    }
    // </editor-fold>
    
}