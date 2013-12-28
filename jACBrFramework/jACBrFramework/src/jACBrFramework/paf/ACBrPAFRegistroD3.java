package jACBrFramework.paf;

import java.util.Date;

/**
 * Detalhe do DAV.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:56:10, revisao: $Id$
 */
public final class ACBrPAFRegistroD3 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">  
    /**
     * Data de inclusao do item no DAV.
     */
    private Date dataInclucao;
    /**
     * Numero sequencial do item registrado no documento.
     */
    private int numItem;
    /**
     * Codigo do produto ou servico registrado no documento.
     */
    private String codItem;
    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     */
    private String descrItem;
    /**
     * Quantidade.
     */
    private double qtdeItem;
    /**
     * Unidade de medida.
     */
    private String unidItem;
    /**
     * Valor unitario do produto ou servico.
     */
    private double valorItem;
    /**
     * Valor do desconto incidente sobre o valor do item.
     */
    private double valorDesconto;
    /**
     * Valor do acrescimo incidente sobre o valor do item.
     */
    private double valorAcrescimo;
    /**
     * Valor total liquido do item.
     */
    private double valorTotal;
    /**
     * Parâmetro de numero de casas decimais da quantidade.
     */
    private int casasDecimaisQtd;
    /**
     * Parametro de numero de casas decimais de valor unitario.
     */
    private int casasDecimaisVlrUn;
    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     */
    private String situacaoTributaria;
    /**
     * Aliquota, conforme item 7.2.1.6.
     */
    private double aliquota;
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do 
     * cancelamento do item no documento auxiliar de venda.
     */
    private String indCancelamento;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Data de inclusao do item no DAV.
     * @return the dataInclucao
     */
    public Date getDataInclucao() {
        return dataInclucao;
    }

    /**
     * Data de inclusao do item no DAV.
     * @param dataInclucao the dataInclucao to set
     */
    public void setDataInclucao(Date dataInclucao) {
        this.dataInclucao = dataInclucao;
    }

    /**
     * Numero sequencial do item registrado no documento.
     * @return the numItem
     */
    public int getNumItem() {
        return numItem;
    }

    /**
     * Numero sequencial do item registrado no documento.
     * @param numItem the numItem to set
     */
    public void setNumItem(int numItem) {
        this.numItem = numItem;
    }

    /**
     * Codigo do produto ou servico registrado no documento.
     * @return the codItem
     */
    public String getCodItem() {
        return codItem;
    }

    /**
     * Codigo do produto ou servico registrado no documento.
     * @param codItem the codItem to set
     */
    public void setCodItem(String codItem) {
        this.codItem = codItem;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     * @return the descrItem
     */
    public String getDescrItem() {
        return descrItem;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     * @param descrItem the descrItem to set
     */
    public void setDescrItem(String descrItem) {
        this.descrItem = descrItem;
    }

    /**
     * Quantidade.
     * @return the qtdeItem
     */
    public double getQtdeItem() {
        return qtdeItem;
    }

    /**
     * Quantidade.
     * @param qtdeItem the qtdeItem to set
     */
    public void setQtdeItem(double qtdeItem) {
        this.qtdeItem = qtdeItem;
    }

    /**
     * Unidade de medida.
     * @return the unidItem
     */
    public String getUnidItem() {
        return unidItem;
    }

    /**
     * Unidade de medida.
     * @param unidItem the unidItem to set
     */
    public void setUnidItem(String unidItem) {
        this.unidItem = unidItem;
    }

    /**
     * Valor unitario do produto ou servico.
     * @return the valorItem
     */
    public double getValorItem() {
        return valorItem;
    }

    /**
     * Valor unitario do produto ou servico.
     * @param valorItem the valorItem to set
     */
    public void setValorItem(double valorItem) {
        this.valorItem = valorItem;
    }

    /**
     * Valor do desconto incidente sobre o valor do item.
     * @return the valorDesconto
     */
    public double getValorDesconto() {
        return valorDesconto;
    }

    /**
     * Valor do desconto incidente sobre o valor do item.
     * @param valorDesconto the valorDesconto to set
     */
    public void setValorDesconto(double valorDesconto) {
        this.valorDesconto = valorDesconto;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @return the valorAcrescimo
     */
    public double getValorAcrescimo() {
        return valorAcrescimo;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @param valorAcrescimo the valorAcrescimo to set
     */
    public void setValorAcrescimo(double valorAcrescimo) {
        this.valorAcrescimo = valorAcrescimo;
    }

    /**
     * Valor total liquido do item.
     * @return the valorTotal
     */
    public double getValorTotal() {
        return valorTotal;
    }

    /**
     * Valor total liquido do item.
     * @param valorTotal the valorTotal to set
     */
    public void setValorTotal(double valorTotal) {
        this.valorTotal = valorTotal;
    }

    /**
     * Parâmetro de numero de casas decimais da quantidade.
     * @return the casasDecimaisQtd
     */
    public int getCasasDecimaisQtd() {
        return casasDecimaisQtd;
    }

    /**
     * Parâmetro de numero de casas decimais da quantidade.
     * @param casasDecimaisQtd the casasDecimaisQtd to set
     */
    public void setCasasDecimaisQtd(int casasDecimaisQtd) {
        this.casasDecimaisQtd = casasDecimaisQtd;
    }

    /**
     * Parametro de numero de casas decimais de valor unitario.
     * @return the casasDecimaisVlrUn
     */
    public int getCasasDecimaisVlrUn() {
        return casasDecimaisVlrUn;
    }

    /**
     * Parametro de numero de casas decimais de valor unitario.
     * @param casasDecimaisVlrUn the casasDecimaisVlrUn to set
     */
    public void setCasasDecimaisVlrUn(int casasDecimaisVlrUn) {
        this.casasDecimaisVlrUn = casasDecimaisVlrUn;
    }

    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     * @return the situacaoTributaria
     */
    public String getSituacaoTributaria() {
        return situacaoTributaria;
    }

    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     * @param situacaoTributaria the situacaoTributaria to set
     */
    public void setSituacaoTributaria(String situacaoTributaria) {
        this.situacaoTributaria = situacaoTributaria;
    }

    /**
     * Aliquota, conforme item 7.2.1.6.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota, conforme item 7.2.1.6.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do
     * cancelamento do item no documento auxiliar de venda.
     * @return the indCancelamento
     */
    public String getIndCancelamento() {
        return indCancelamento;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do
     * cancelamento do item no documento auxiliar de venda.
     * @param indCancelamento the indCancelamento to set
     */
    public void setIndCancelamento(String indCancelamento) {
        this.indCancelamento = indCancelamento;
    }

    /**
     * Se true o registro e valido.
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Se true o registro e valido.
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }
    // </editor-fold>             

}