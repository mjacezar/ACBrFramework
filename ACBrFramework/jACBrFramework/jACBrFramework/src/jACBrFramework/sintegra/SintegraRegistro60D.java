package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Resumo Diario : Registro de mercadoria/produto ou serviço constante em documento 
 * fiscal emitido por PDV ou ECF
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:36:39, revisao: $Id$
 */
public class SintegraRegistro60D {

    // <editor-fold defaultstate="collapsed" desc="Attributes">          
    /**
     * Numero de serie de fabricacao do equipamento.
     */
    private String numSerie;
    /**
     * Identificador da situacao tributaria /alíquota do ICMS (com 2 decimais).
     */
    private String stAliquota;
    /**
     * Data de emissao dos documentos fiscais.
     */
    private Date emissao;
    /**
     * Valor liquido (valor bruto diminuido dos descontos) da mercadoria/produto acumulado no dia (com 2 decimais)
     */
    private double valor;
    /**
     * Codigo da mercadoria /produto ou servico do informante.
     */
    private String codigo;
    /**
     * Montante do imposto.
     */
    private double valorIcms;
    /**
     * Quantidade comercializada da mercadoria/produto no dia (com 3 decimais).
     */
    private double quantidade;
    /**
     * Base de calculo do ICMS – valor acumulado no dia (com 2 decimais)
     */
    private double baseCalculo;    
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
     * Identificador da situacao tributaria /alíquota do ICMS (com 2 decimais).
     * @return the stAliquota
     */
    public String getStAliquota() {
        return stAliquota;
    }

    /**
     * Identificador da situacao tributaria /alíquota do ICMS (com 2 decimais).
     * @param stAliquota the stAliquota to set
     */
    public void setStAliquota(String stAliquota) {
        this.stAliquota = stAliquota;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @return the emissao
     */
    public Date getEmissao() {
        return emissao;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @param emissao the emissao to set
     */
    public void setEmissao(Date emissao) {
        this.emissao = emissao;
    }

    /**
     * Valor liquido (valor bruto diminuido dos descontos) da mercadoria/produto acumulado no dia (com 2 decimais)
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor liquido (valor bruto diminuido dos descontos) da mercadoria/produto acumulado no dia (com 2 decimais)
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Codigo da mercadoria /produto ou servico do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo da mercadoria /produto ou servico do informante.
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
     * Quantidade comercializada da mercadoria/produto no dia (com 3 decimais).
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade comercializada da mercadoria/produto no dia (com 3 decimais).
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Base de calculo do ICMS – valor acumulado no dia (com 2 decimais)
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS – valor acumulado no dia (com 2 decimais)
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }
    // </editor-fold>
    
}