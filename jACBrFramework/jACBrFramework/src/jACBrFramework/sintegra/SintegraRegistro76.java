package jACBrFramework.sintegra;

import java.util.Date;

/**
 *  Nota fiscal de servicos de comunicacao e telecomunicacoes.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:38:14, revisao: $Id$
 */
public class SintegraRegistro76 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Valor amparado por isencao ou nao-incidencia.
     */
    private double isentas;
    /**
     * Valor total da nota fiscal.
     */
    private double valorTotal;
    /**
     * Montante do imposto.
     */
    private double icms;
    /**
     * Base de calculo do ICMS.
     */
    private double baseCalculo;
    /**
     * Valor que nao confira debito ou credito do ICMS.
     */
    private double outras;
    /**
     * Codigo do modelo da nota fiscal.
     */
    private int modelo;
    /**
     * Numero da nota fiscal.
     */
    private int numero;
    /**
     * Situacao da nota fiscal.
     */
    private String situacao;
    /**
     * Inscricao estadual do tomador do servico.
     */
    private String inscricao;
    /**
     * Subserie da nota fiscal.
     */
    private String subSerie;
    /**
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     */
    private String uf;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String cfop;
    /**
     * CNPJ/CPF do tomador do servico.
     */
    private String cpfCnpj;
    /**
     * Data de emissao na saida ou de recebimento na entrada.
     */
    private Date dataDocumento;
    /**
     * Codigo da identificacao do tipo de receita.
     */
    private int tipoReceita;
    /**
     * Aliquota do ICMS (valor inteiro).
     */
    private int aliquota;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Valor amparado por isencao ou nao-incidencia.
     * @return the isentas
     */
    public double getIsentas() {
        return isentas;
    }

    /**
     * Valor amparado por isencao ou nao-incidencia.
     * @param isentas the isentas to set
     */
    public void setIsentas(double isentas) {
        this.isentas = isentas;
    }

    /**
     * Valor total da nota fiscal.
     * @return the valorTotal
     */
    public double getValorTotal() {
        return valorTotal;
    }

    /**
     * Valor total da nota fiscal.
     * @param valorTotal the valorTotal to set
     */
    public void setValorTotal(double valorTotal) {
        this.valorTotal = valorTotal;
    }

    /**
     * Montante do imposto.
     * @return the icms
     */
    public double getIcms() {
        return icms;
    }

    /**
     * Montante do imposto.
     * @param icms the icms to set
     */
    public void setIcms(double icms) {
        this.icms = icms;
    }

    /**
     * Base de calculo do ICMS.
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS.
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS.
     * @return the outras
     */
    public double getOutras() {
        return outras;
    }

    /**
     * Valor que nao confira debito ou credito do ICMS.
     * @param outras the outras to set
     */
    public void setOutras(double outras) {
        this.outras = outras;
    }

    /**
     * Codigo do modelo da nota fiscal.
     * @return the modelo
     */
    public int getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo da nota fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(int modelo) {
        this.modelo = modelo;
    }

    /**
     * Numero da nota fiscal.
     * @return the numero
     */
    public int getNumero() {
        return numero;
    }

    /**
     * Numero da nota fiscal.
     * @param numero the numero to set
     */
    public void setNumero(int numero) {
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
     * Subserie da nota fiscal.
     * @return the subSerie
     */
    public String getSubSerie() {
        return subSerie;
    }

    /**
     * Subserie da nota fiscal.
     * @param subSerie the subSerie to set
     */
    public void setSubSerie(String subSerie) {
        this.subSerie = subSerie;
    }

    /**
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Sigla da unidade da Federacao do remetente nas entradas e do destinatario nas saidas.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
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
     * CNPJ/CPF do tomador do servico.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ/CPF do tomador do servico.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
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

    /**
     * Codigo da identificacao do tipo de receita.
     * @return the tipoReceita
     */
    public int getTipoReceita() {
        return tipoReceita;
    }

    /**
     * Codigo da identificacao do tipo de receita.
     * @param tipoReceita the tipoReceita to set
     */
    public void setTipoReceita(int tipoReceita) {
        this.tipoReceita = tipoReceita;
    }

    /**
     * Aliquota do ICMS (valor inteiro).
     * @return the aliquota
     */
    public int getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do ICMS (valor inteiro).
     * @param aliquota the aliquota to set
     */
    public void setAliquota(int aliquota) {
        this.aliquota = aliquota;
    }
    // </editor-fold>        
    
}