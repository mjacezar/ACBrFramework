package jACBrFramework.paf;

import java.util.Date;

/**
 * Detalhe do DAV.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:39:23, revisao: $Id$
 */
public final class ACBrPAFRegistroD4 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Numero do DAV onde esta contido este item.
     */
    private String numeroDAV;
    /**
     * Data da alteracao.
     */
    private Date dataAlteracao;
    /**
     * Hora da alteracao.
     */
    private Date horaAlteracao;
    /**
     * Codigo do produto ou servico registrado no documento.
     */
    private String codigoProdutoServico;
    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     */
    private String descricao;
    /**
     * Quantidade.
     */
    private double quantidade;
    /**
     * Unidade de medida.
     */
    private String unidade;
    /**
     * Valor unitario do produto ou servico.
     */
    private double valorUnitario;
    /**
     * Valor do desconto incidente sobre o valor do item.
     */
    private double descontoSobreItem;
    /**
     * Valor do acrescimo incidente sobre o valor do item.
     */
    private double acrescimoSobreItem;
    /**
     * Valor total liquido do item.
     */
    private double valorTotalLiquido;
    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     */
    private String situacaoTributaria;
    /**
     * Valor da aliquota.
     */
    private double aliquota;
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do 
     * cancelamento do item no documento auxiliar de venda.
     */
    private String indicadorCancelamento;
    /**
     * Parâmetro de numero de casas decimais da quantidade.
     */
    private int casasDecimaisQtd;
    /**
     * Parametro de numero de casas decimais de valor unitario.
     */
    private int casasDecimaisVlrUn;
    /**
     * Tipo da alteracao.
     */
    private String tipoAlteracao; 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero do DAV onde esta contido este item.
     * @return the numeroDAV
     */
    public String getNumeroDAV() {
        return numeroDAV;
    }

    /**
     * Numero do DAV onde esta contido este item.
     * @param numeroDAV the numeroDAV to set
     */
    public void setNumeroDAV(String numeroDAV) {
        this.numeroDAV = numeroDAV;
    }

    /**
     * Data da alteracao.
     * @return the dataAlteracao
     */
    public Date getDataAlteracao() {
        return dataAlteracao;
    }

    /**
     * Data da alteracao.
     * @param dataAlteracao the dataAlteracao to set
     */
    public void setDataAlteracao(Date dataAlteracao) {
        this.dataAlteracao = dataAlteracao;
    }

    /**
     * Hora da alteracao.
     * @return the horaAlteracao
     */
    public Date getHoraAlteracao() {
        return horaAlteracao;
    }

    /**
     * Hora da alteracao.
     * @param horaAlteracao the horaAlteracao to set
     */
    public void setHoraAlteracao(Date horaAlteracao) {
        this.horaAlteracao = horaAlteracao;
    }

    /**
     * Codigo do produto ou servico registrado no documento.
     * @return the codigoProdutoServico
     */
    public String getCodigoProdutoServico() {
        return codigoProdutoServico;
    }

    /**
     * Codigo do produto ou servico registrado no documento.
     * @param codigoProdutoServico the codigoProdutoServico to set
     */
    public void setCodigoProdutoServico(String codigoProdutoServico) {
        this.codigoProdutoServico = codigoProdutoServico;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     * @param descricao the descricao to set
     */
    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    /**
     * Quantidade.
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade.
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Unidade de medida.
     * @return the unidade
     */
    public String getUnidade() {
        return unidade;
    }

    /**
     * Unidade de medida.
     * @param unidade the unidade to set
     */
    public void setUnidade(String unidade) {
        this.unidade = unidade;
    }

    /**
     * Valor unitario do produto ou servico.
     * @return the valorUnitario
     */
    public double getValorUnitario() {
        return valorUnitario;
    }

    /**
     * Valor unitario do produto ou servico.
     * @param valorUnitario the valorUnitario to set
     */
    public void setValorUnitario(double valorUnitario) {
        this.valorUnitario = valorUnitario;
    }

    /**
     * Valor do desconto incidente sobre o valor do item.
     * @return the descontoSobreItem
     */
    public double getDescontoSobreItem() {
        return descontoSobreItem;
    }

    /**
     * Valor do desconto incidente sobre o valor do item.
     * @param descontoSobreItem the descontoSobreItem to set
     */
    public void setDescontoSobreItem(double descontoSobreItem) {
        this.descontoSobreItem = descontoSobreItem;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @return the acrescimoSobreItem
     */
    public double getAcrescimoSobreItem() {
        return acrescimoSobreItem;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @param acrescimoSobreItem the acrescimoSobreItem to set
     */
    public void setAcrescimoSobreItem(double acrescimoSobreItem) {
        this.acrescimoSobreItem = acrescimoSobreItem;
    }

    /**
     * Valor total liquido do item.
     * @return the valorTotalLiquido
     */
    public double getValorTotalLiquido() {
        return valorTotalLiquido;
    }

    /**
     * Valor total liquido do item.
     * @param valorTotalLiquido the valorTotalLiquido to set
     */
    public void setValorTotalLiquido(double valorTotalLiquido) {
        this.valorTotalLiquido = valorTotalLiquido;
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
     * Valor da aliquota.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Valor da aliquota.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }
    
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do
     * cancelamento do item no documento auxiliar de venda.
     * @return the indicadorCancelamento
     */
    public String getIndicadorCancelamento() {
        return indicadorCancelamento;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, a marcacao do
     * cancelamento do item no documento auxiliar de venda.
     * @param indicadorCancelamento the indicadorCancelamento to set
     */
    public void setIndicadorCancelamento(String indicadorCancelamento) {
        this.indicadorCancelamento = indicadorCancelamento;
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
     * @param casasDecimaisVlrUn the casasDecimaisVlUn to set
     */
    public void setCasasDecimaisVlrUn(int casasDecimaisVlrUn) {
        this.casasDecimaisVlrUn = casasDecimaisVlrUn;
    }

    /**
     * Tipo da alteracao.
     * @return the tipoAlteracao
     */
    public String getTipoAlteracao() {
        return tipoAlteracao;
    }

    /**
     * Tipo da alteracao.
     * @param tipoAlteracao the tipoAlteracao to set
     */
    public void setTipoAlteracao(String tipoAlteracao) {
        this.tipoAlteracao = tipoAlteracao;
    }
    // </editor-fold>         

}