package jACBrFramework.sintegra;

/**
 * Servicos de comunicacao e telecomunicacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:38:24, revisao: $Id$
 */
public class SintegraRegistro77 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Quantidade do servico (com 3 decimais).
     */
    private double quantidade;
    /**
     * Valor bruto do servico (valor unitario multiplicado por quantidade).
     */
    private double valorServico;
    /**
     * Valor do desconto concedido no item.
     */
    private double valorDesconto;
    /**
     * Base de calculo do ICMS.
     */
    private double baseCalculo;
    /**
     * Codigo do modelo da nota fiscal.
     */
    private int modelo;
    /**
     * Numero da nota fiscal.
     */
    private int numero;
    /**
     * Codigo que designa o usuario final na rede do informante.
     */
    private int numeroTerminal;
    /**
     * Numero de ordem do item na nota fiscal.
     */
    private int numeroItem;
    /**
     * Aliquota utilizada.
     */
    private int aliquota;
    /**
     * CNPJ/MF da operadora de destino.
     */
    private String cnpjMF;
    /**
     * Codigo Fiscal de operacao e prestacao.
     */
    private String cfop;
    /**
     * Código do serviço do informante.
     */
    private String codigo;
    /**
     * Subserie da nota fiscal.
     */
    private String subSerie;
    /**
     * CNPJ/CPF do tomador do servico.
     */
    private String cpfCnpj;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    /**
     * Codigo da identificacao do tipo de receita.
     */
    private int TipoReceita;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Quantidade do servico (com 3 decimais).
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade do servico (com 3 decimais).
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Valor bruto do servico (valor unitario multiplicado por quantidade).
     * @return the valorServico
     */
    public double getValorServico() {
        return valorServico;
    }

    /**
     * Valor bruto do servico (valor unitario multiplicado por quantidade).
     * @param valorServico the valorServico to set
     */
    public void setValorServico(double valorServico) {
        this.valorServico = valorServico;
    }

    /**
     * Valor do desconto concedido no item.
     * @return the valorDesconto
     */
    public double getValorDesconto() {
        return valorDesconto;
    }

    /**
     * Valor do desconto concedido no item.
     * @param valorDesconto the valorDesconto to set
     */
    public void setValorDesconto(double valorDesconto) {
        this.valorDesconto = valorDesconto;
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
     * Codigo que designa o usuario final na rede do informante.
     * @return the numeroTerminal
     */
    public int getNumeroTerminal() {
        return numeroTerminal;
    }

    /**
     * Codigo que designa o usuario final na rede do informante.
     * @param numeroTerminal the numeroTerminal to set
     */
    public void setNumeroTerminal(int numeroTerminal) {
        this.numeroTerminal = numeroTerminal;
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
     * Aliquota utilizada.
     * @return the aliquota
     */
    public int getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota utilizada.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(int aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * CNPJ/MF da operadora de destino.
     * @return the cnpjMF
     */
    public String getCnpjMF() {
        return cnpjMF;
    }

    /**
     * CNPJ/MF da operadora de destino.
     * @param cnpjMF the cnpjMF to set
     */
    public void setCnpjMF(String cnpjMF) {
        this.cnpjMF = cnpjMF;
    }

    /**
     * Codigo Fiscal de operacao e prestacao.
     * @return the cfop
     */
    public String getCfop() {
        return cfop;
    }

    /**
     * Codigo Fiscal de operacao e prestacao.
     * @param cfop the cfop to set
     */
    public void setCfop(String cfop) {
        this.cfop = cfop;
    }

    /**
     * Código do serviço do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Código do serviço do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
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
     * Codigo da identificacao do tipo de receita.
     * @return the TipoReceita
     */
    public int getTipoReceita() {
        return TipoReceita;
    }

    /**
     * Codigo da identificacao do tipo de receita.
     * @param TipoReceita the TipoReceita to set
     */
    public void setTipoReceita(int TipoReceita) {
        this.TipoReceita = TipoReceita;
    }
    // </editor-fold>       
    
}