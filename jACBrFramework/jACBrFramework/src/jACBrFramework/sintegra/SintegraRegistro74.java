package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Registro de inventario.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:52, revisao: $Id$
 */
public class SintegraRegistro74 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">        
    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com 2 decimais
     */
    private double valorProduto;
    /**
     * Codigo de posse das mercadorias Inventariadas.
     */
    private String codigoPosse;
    /**
     * Inscricao estadual do possuidor da mercadoria de propriedade do informante, 
     * ou do proprietario da mercadoria em poder do informante.
     */
    private String inscricaoPossuidor;
    /**
     * Codigo do produto do informante.
     */
    private String codigo;
    /**
     * CNPJ do possuidor da mercadoria de propriedade do informante, ou do 
     * proprietario da mercadoria em poder do informante.
     */
    private String cnpjPossuidor;
    /**
     * Unidade da Federacao do possuidor da mercadoria de propriedade do informante, 
     * ou do proprietario da mercadoria em poder do informante.
     */
    private String ufPossuidor;
    /**
     * Data do inventario.
     */
    private Date data;
    /**
     * Quantidade do produto(com 3 decimais).
     */
    private double quantidade;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com 2 decimais
     * @return the valorProduto
     */
    public double getValorProduto() {
        return valorProduto;
    }

    /**
     * Valor bruto do produto (valor unitario multiplicado por quantidade) - com 2 decimais
     * @param valorProduto the valorProduto to set
     */
    public void setValorProduto(double valorProduto) {
        this.valorProduto = valorProduto;
    }

    /**
     * Codigo de posse das mercadorias Inventariadas.
     * @return the codigoPosse
     */
    public String getCodigoPosse() {
        return codigoPosse;
    }

    /**
     * Codigo de posse das mercadorias Inventariadas.
     * @param codigoPosse the codigoPosse to set
     */
    public void setCodigoPosse(String codigoPosse) {
        this.codigoPosse = codigoPosse;
    }

    /**
     * Inscricao estadual do possuidor da mercadoria de propriedade do informante,
     * ou do proprietario da mercadoria em poder do informante.
     * @return the inscricaoPossuidor
     */
    public String getInscricaoPossuidor() {
        return inscricaoPossuidor;
    }

    /**
     * Inscricao estadual do possuidor da mercadoria de propriedade do informante,
     * ou do proprietario da mercadoria em poder do informante.
     * @param inscricaoPossuidor the inscricaoPossuidor to set
     */
    public void setInscricaoPossuidor(String inscricaoPossuidor) {
        this.inscricaoPossuidor = inscricaoPossuidor;
    }

    /**
     * Codigo do produto do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do produto do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * CNPJ do possuidor da mercadoria de propriedade do informante, ou do
     * proprietario da mercadoria em poder do informante.
     * @return the cnpjPossuidor
     */
    public String getCnpjPossuidor() {
        return cnpjPossuidor;
    }

    /**
     * CNPJ do possuidor da mercadoria de propriedade do informante, ou do
     * proprietario da mercadoria em poder do informante.
     * @param cnpjPossuidor the cnpjPossuidor to set
     */
    public void setCnpjPossuidor(String cnpjPossuidor) {
        this.cnpjPossuidor = cnpjPossuidor;
    }

    /**
     * Unidade da Federacao do possuidor da mercadoria de propriedade do informante,
     * ou do proprietario da mercadoria em poder do informante.
     * @return the ufPossuidor
     */
    public String getUfPossuidor() {
        return ufPossuidor;
    }

    /**
     * Unidade da Federacao do possuidor da mercadoria de propriedade do informante,
     * ou do proprietario da mercadoria em poder do informante.
     * @param ufPossuidor the ufPossuidor to set
     */
    public void setUfPossuidor(String ufPossuidor) {
        this.ufPossuidor = ufPossuidor;
    }

    /**
     * Data do inventario.
     * @return the data
     */
    public Date getData() {
        return data;
    }

    /**
     * Data do inventario.
     * @param data the data to set
     */
    public void setData(Date data) {
        this.data = data;
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
    // </editor-fold>   
    
}