package jACBrFramework.paf;

/**
 * Detalhe do Cupom Fiscal, Nota Fiscal de Venda a Consumidor ou Bilhete de Passagem.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 18:09:56, revisao: $Id$
 */
public final class ACBrPAFRegistroR5 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Numero do contador do respectivo documento emitido.
     */
    private int numContador;
    /**
     * Numero do item registrado no documento.
     */
    private int numItem;
    /**
     * Codigo do produto ou servico registrado no documento.
     */
    private String codItem;
    /**
     * Descricaão do produto ou servic constante no Cupom Fiscal.
     */
    private String descricaoItem;
    /**
     * Quantidade comercializada.
     */
    private double qtdeItem;
    /**
     * Unidade de medida.
     */
    private String unidadeMedida;
    /**
     * Valor unitario do produto ou servico.
     */
    private double valorUnitario;
    /**
     * Valor do desconto incidente sobre o valor do item.
     */
    private double descontoItem;
    /**
     * Valor do acrescimo incidente sobre o valor do item.
     */
    private double acrescimoItem;
    /**
     * Valor total liquido do item.
     */
    private double valorTotalLiquidoItem;
    /**
     * Cidigo do totalizador relativo ao produto ou servico.
     */
    private String codTotalizadorParcial;
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento total 
     * do item no documento. Informar "P" quando ocorrer o cancelamento parcial do item.
     */
    private String indCancelamento;
    /**
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     */
    private double qtdeCancelada;
    /**
     * Valor cancelado, no caso de cancelamento parcial de item.
     */
    private double valorCancelamento;
    /**
     * Valor do cancelamento de acrescimo no item.
     */
    private double valorCancelamentoAcresc;
    /**
     * Indicador de Arredondamento ou Truncamento relativo a regra de calculo do 
     * valor total liquido do item, sendo "T" para truncamento ou "A" para arredondamento.
     */
    private String iat;
    /**
     * Indicador de Producao Propria ou de Terceiro relativo a mercadoria, sendo
     * "P" para mercadoria de producao própria ou "T" para mercadoria produzida por terceiros.
     */
    private String ippt;
    /**
     * Parametro de numero de casas decimais da quantidade.
     */
    private int numCasasDecimaisEmQtde;
    /**
     * Parametro de numero de casas decimais de valor unitario.
     */
    private int numCasasDecimaisEmValor;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero do contador do respectivo documento emitido.
     * @return the numContador
     */
    public int getNumContador() {
        return numContador;
    }

    /**
     * Numero do contador do respectivo documento emitido.
     * @param numContador the numContador to set
     */
    public void setNumContador(int numContador) {
        this.numContador = numContador;
    }

    /**
     * Numero do item registrado no documento.
     * @return the numItem
     */
    public int getNumItem() {
        return numItem;
    }

    /**
     * Numero do item registrado no documento.
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
     * Descricaão do produto ou servic constante no Cupom Fiscal.
     * @return the descricaoItem
     */
    public String getDescricaoItem() {
        return descricaoItem;
    }

    /**
     * Descricaão do produto ou servic constante no Cupom Fiscal.
     * @param descricaoItem the descricaoItem to set
     */
    public void setDescricaoItem(String descricaoItem) {
        this.descricaoItem = descricaoItem;
    }

    /**
     * Quantidade comercializada.
     * @return the qtdeItem
     */
    public double getQtdeItem() {
        return qtdeItem;
    }

    /**
     * Quantidade comercializada.
     * @param qtdeItem the qtdeItem to set
     */
    public void setQtdeItem(double qtdeItem) {
        this.qtdeItem = qtdeItem;
    }

    /**
     * Unidade de medida.
     * @return the unidadeMedida
     */
    public String getUnidadeMedida() {
        return unidadeMedida;
    }

    /**
     * Unidade de medida.
     * @param unidadeMedida the unidadeMedida to set
     */
    public void setUnidadeMedida(String unidadeMedida) {
        this.unidadeMedida = unidadeMedida;
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
     * @return the descontoItem
     */
    public double getDescontoItem() {
        return descontoItem;
    }

    /**
     * Valor do desconto incidente sobre o valor do item.
     * @param descontoItem the descontoItem to set
     */
    public void setDescontoItem(double descontoItem) {
        this.descontoItem = descontoItem;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @return the acrescimoItem
     */
    public double getAcrescimoItem() {
        return acrescimoItem;
    }

    /**
     * Valor do acrescimo incidente sobre o valor do item.
     * @param acrescimoItem the acrescimoItem to set
     */
    public void setAcrescimoItem(double acrescimoItem) {
        this.acrescimoItem = acrescimoItem;
    }

    /**
     * Valor total liquido do item.
     * @return the valorTotalLiquidoItem
     */
    public double getValorTotalLiquidoItem() {
        return valorTotalLiquidoItem;
    }

    /**
     * Valor total liquido do item.
     * @param valorTotalLiquidoItem the valorTotalLiquidoItem to set
     */
    public void setValorTotalLiquidoItem(double valorTotalLiquidoItem) {
        this.valorTotalLiquidoItem = valorTotalLiquidoItem;
    }

    /**
     * Cidigo do totalizador relativo ao produto ou servico.
     * @return the codTotalizadorParcial
     */
    public String getCodTotalizadorParcial() {
        return codTotalizadorParcial;
    }

    /**
     * Cidigo do totalizador relativo ao produto ou servico.
     * @param codTotalizadorParcial the codTotalizadorParcial to set
     */
    public void setCodTotalizadorParcial(String codTotalizadorParcial) {
        this.codTotalizadorParcial = codTotalizadorParcial;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento total
     * do item no documento. Informar "P" quando ocorrer o cancelamento parcial do item.
     * @return the indCancelamento
     */
    public String getIndCancelamento() {
        return indCancelamento;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento total
     * do item no documento. Informar "P" quando ocorrer o cancelamento parcial do item.
     * @param indCancelamento the indCancelamento to set
     */
    public void setIndCancelamento(String indCancelamento) {
        this.indCancelamento = indCancelamento;
    }

    /**
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     * @return the qtdeCancelada
     */
    public double getQtdeCancelada() {
        return qtdeCancelada;
    }

    /**
     * Quantidade cancelada, no caso de cancelamento parcial de item.
     * @param qtdeCancelada the qtdeCancelada to set
     */
    public void setQtdeCancelada(double qtdeCancelada) {
        this.qtdeCancelada = qtdeCancelada;
    }

    /**
     * Valor cancelado, no caso de cancelamento parcial de item.
     * @return the valorCancelamento
     */
    public double getValorCancelamento() {
        return valorCancelamento;
    }

    /**
     * Valor cancelado, no caso de cancelamento parcial de item.
     * @param valorCancelamento the valorCancelamento to set
     */
    public void setValorCancelamento(double valorCancelamento) {
        this.valorCancelamento = valorCancelamento;
    }

    /**
     * Valor do cancelamento de acrescimo no item.
     * @return the valorCancelamentoAcresc
     */
    public double getValorCancelamentoAcresc() {
        return valorCancelamentoAcresc;
    }

    /**
     * Valor do cancelamento de acrescimo no item.
     * @param valorCancelamentoAcresc the valorCancelamentoAcresc to set
     */
    public void setValorCancelamentoAcresc(double valorCancelamentoAcresc) {
        this.valorCancelamentoAcresc = valorCancelamentoAcresc;
    }

    /**
     * Indicador de Arredondamento ou Truncamento relativo a regra de calculo do
     * valor total liquido do item, sendo "T" para truncamento ou "A" para arredondamento.
     * @return the iat
     */
    public String getIat() {
        return iat;
    }

    /**
     * Indicador de Arredondamento ou Truncamento relativo a regra de calculo do
     * valor total liquido do item, sendo "T" para truncamento ou "A" para arredondamento.
     * @param iat the iat to set
     */
    public void setIat(String iat) {
        this.iat = iat;
    }

    /**
     * Indicador de Producao Propria ou de Terceiro relativo a mercadoria, sendo
     * "P" para mercadoria de producao própria ou "T" para mercadoria produzida por terceiros.
     * @return the ippt
     */
    public String getIppt() {
        return ippt;
    }

    /**
     * Indicador de Producao Propria ou de Terceiro relativo a mercadoria, sendo
     * "P" para mercadoria de producao própria ou "T" para mercadoria produzida por terceiros.
     * @param ippt the ippt to set
     */
    public void setIppt(String ippt) {
        this.ippt = ippt;
    }

    /**
     * Parametro de numero de casas decimais da quantidade.
     * @return the numCasasDecimaisEmQtde
     */
    public int getNumCasasDecimaisEmQtde() {
        return numCasasDecimaisEmQtde;
    }

    /**
     * Parametro de numero de casas decimais da quantidade.
     * @param numCasasDecimaisEmQtde the numCasasDecimaisEmQtde to set
     */
    public void setNumCasasDecimaisEmQtde(int numCasasDecimaisEmQtde) {
        this.numCasasDecimaisEmQtde = numCasasDecimaisEmQtde;
    }

    /**
     * Parametro de numero de casas decimais de valor unitario.
     * @return the numCasasDecimaisEmValor
     */
    public int getNumCasasDecimaisEmValor() {
        return numCasasDecimaisEmValor;
    }

    /**
     * Parametro de numero de casas decimais de valor unitario.
     * @param numCasasDecimaisEmValor the numCasasDecimaisEmValor to set
     */
    public void setNumCasasDecimaisEmValor(int numCasasDecimaisEmValor) {
        this.numCasasDecimaisEmValor = numCasasDecimaisEmValor;
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