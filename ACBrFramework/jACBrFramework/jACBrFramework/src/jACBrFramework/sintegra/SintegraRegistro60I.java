package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Item : Item do documento fiscal emitido por PDV ou ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:36:51, revisao: $Id$
 */
public class SintegraRegistro60I {

    // <editor-fold defaultstate="collapsed" desc="Attributes">          
    /**
     * Numero de serie de fabricacao do equipamento.
     */
    private String numSerie;
    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     */
    private String stAliquota;
    /**
     * Data de emissao do documento fiscal.
     */
    private Date emissao;
    /**
     * Valor unitario do produto (com 3 decimais).
     */
    private double valor;
    /**
     * Codigo da mercadoria/produto ou serviço do informante.
     */
    private String codigo;
    /**
     * Montante do imposto.
     */
    private double valorIcms;
    /**
     * Quantidade da mercadoria/produto (com 3 decimais).
     */
    private double quantidade;
    /**
     * Montante do Imposto (2 decimais).
     */
    private double baseCalculo;
    /**
     * Numero de ordem do item no documento fiscal.
     */
    private int item;
    /**
     * Numero do Contador de Ordem de Operacao (COO).
     */
    private String cupom;
    /**
     * Codigo do modelo do documento fiscal.
     */
    private String modeloDoc;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
   
    /**
     * Numero de serie de fabricacao do equipamento.
     * @return the numSerie
     */
    public String getNumSerie() {
        return numSerie;
    }

    /**
     * Numero de serie de fabricacao do equipamento.
     * @param numSerie the numSerie to set
     */
    public void setNumSerie(String numSerie) {
        this.numSerie = numSerie;
    }

    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     * @return the stAliquota
     */
    public String getStAliquota() {
        return stAliquota;
    }

    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     * @param stAliquota the stAliquota to set
     */
    public void setStAliquota(String stAliquota) {
        this.stAliquota = stAliquota;
    }

    /**
     * Data de emissao do documento fiscal.
     * @return the emissao
     */
    public Date getEmissao() {
        return emissao;
    }

    /**
     * Data de emissao do documento fiscal.
     * @param emissao the emissao to set
     */
    public void setEmissao(Date emissao) {
        this.emissao = emissao;
    }

    /**
     * Valor unitario do produto (com 3 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor unitario do produto (com 3 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Codigo da mercadoria/produto ou serviço do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo da mercadoria/produto ou serviço do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Montante do imposto.
     * @return the valorIcms
     */
    public double getValorIcms() {
        return valorIcms;
    }

    /**
     * Montante do imposto.
     * @param valorIcms the valorIcms to set
     */
    public void setValorIcms(double valorIcms) {
        this.valorIcms = valorIcms;
    }

    /**
     * Quantidade da mercadoria/produto (com 3 decimais).
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade da mercadoria/produto (com 3 decimais).
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Montante do Imposto (2 decimais).
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Montante do Imposto (2 decimais).
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Numero de ordem do item no documento fiscal.
     * @return the item
     */
    public int getItem() {
        return item;
    }

    /**
     * Numero de ordem do item no documento fiscal.
     * @param item the item to set
     */
    public void setItem(int item) {
        this.item = item;
    }

    /**
     * Numero do Contador de Ordem de Operacao (COO).
     * @return the cupom
     */
    public String getCupom() {
        return cupom;
    }

    /**
     * Numero do Contador de Ordem de Operacao (COO).
     * @param cupom the cupom to set
     */
    public void setCupom(String cupom) {
        this.cupom = cupom;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @return the modeloDoc
     */
    public String getModeloDoc() {
        return modeloDoc;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @param modeloDoc the modeloDoc to set
     */
    public void setModeloDoc(String modeloDoc) {
        this.modeloDoc = modeloDoc;
    }
    // </editor-fold>
    
}