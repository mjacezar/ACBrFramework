package jACBrFramework.sintegra;

/**
 * Itens das notas fiscais.
 *
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:35:57, revisao: $Id$
 */
public class SintegraRegistro54 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * Aliquota utilizada no cálculo do ICMS (com 2 decimais).
     */
    private double aliquota;
    /**
     * Base de calculo do ICMS de retencao na substituicao tributaria (com 2
     * decimais).
     */
    private double baseST;
    /**
     * Base de calculo do ICMS (com 2 decimais).
     */
    private double baseCalculo;
    /**
     * Quantidade do produto(com 3 decimais).
     */
    private double quantidade;
    /**
     * Valor do desconto concedido no item (com 2 decimais).
     */
    private double valorDescontoDespesa;
    /**
     * Valor do IPI (com 2 decimais).
     */
    private double valorIpi;
    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com
     * 2 decimais.
     */
    private double valor;
    /**
     * Numero de ordem do item na nota fiscal.
     */
    private int numeroItem;
    /**
     * Codigo da situacao tributaria.
     */
    private String cst;
    /**
     * Codigo do produto ou serviço do informante.
     */
    private String codigo;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String cfop;
    /**
     * Descricao do item.
     */
    private String descricao;
    /**
     * CNPJ do remetente nas entradas e do destinatario nas saidas.
     */
    private String cpfCnpj;
    /**
     * Numero da nota fiscal.
     */
    private String numero;
    /**
     * Codigo do modelo da nota fiscal.
     */
    private String modelo;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Aliquota utilizada no cálculo do ICMS (com 2 decimais).
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota utilizada no cálculo do ICMS (com 2 decimais).
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Base de calculo do ICMS de retencao na substituicao tributaria (com 2
     * decimais).
     * @return the baseST
     */
    public double getBaseST() {
        return baseST;
    }

    /**
     * Base de calculo do ICMS de retencao na substituicao tributaria (com 2
     * decimais).
     * @param baseST the baseST to set
     */
    public void setBaseST(double baseST) {
        this.baseST = baseST;
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
     * Quantidade do produto(com 3 decimais).
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade do produto(com 3 decimais).
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Valor do desconto concedido no item (com 2 decimais).
     * @return the valorDescontoDespesa
     */
    public double getValorDescontoDespesa() {
        return valorDescontoDespesa;
    }

    /**
     * Valor do desconto concedido no item (com 2 decimais).
     * @param valorDescontoDespesa the valorDescontoDespesa to set
     */
    public void setValorDescontoDespesa(double valorDescontoDespesa) {
        this.valorDescontoDespesa = valorDescontoDespesa;
    }

    /**
     * Valor do IPI (com 2 decimais).
     * @return the valorIpi
     */
    public double getValorIpi() {
        return valorIpi;
    }

    /**
     * Valor do IPI (com 2 decimais).
     * @param valorIpi the valorIpi to set
     */
    public void setValorIpi(double valorIpi) {
        this.valorIpi = valorIpi;
    }

    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com
     * 2 decimais.
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com
     * 2 decimais.
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Numero de ordem do item na nota fiscal.
     * @return the numeroItem
     */
    public int getNumeroItem() {
        return numeroItem;
    }

    /**
     * Numero de ordem do item na nota fiscal.
     * @param numeroItem the numeroItem to set
     */
    public void setNumeroItem(int numeroItem) {
        this.numeroItem = numeroItem;
    }

    /**
     * Codigo da situacao tributaria.
     * @return the cst
     */
    public String getCst() {
        return cst;
    }

    /**
     * Codigo da situacao tributaria.
     * @param cst the cst to set
     */
    public void setCst(String cst) {
        this.cst = cst;
    }

    /**
     * Codigo do produto ou serviço do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do produto ou serviço do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
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

    //TODO Modificadores de acesso alterado porque o arquivo nao contem descricao.
    /**
     * Descricao do item.
     * @return the descricao
     */
    String getDescricao() {
        return descricao;
    }

    /**
     * Descricao do item.
     * @param descricao the descricao to set
     */
    void setDescricao(String descricao) {
        this.descricao = descricao;
    }

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
    // </editor-fold>
    
}