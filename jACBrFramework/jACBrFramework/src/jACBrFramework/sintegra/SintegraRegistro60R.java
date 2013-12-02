package jACBrFramework.sintegra;

/**
 *  Registro de mercadoria/produto ou serviço processado em ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:08, revisao: $Id$
 */
public class SintegraRegistro60R {

    // <editor-fold defaultstate="collapsed" desc="Attributes">              
    /**
     * Base de calculo do ICMS –valor acumulado no mes (com 2 decimais)
     */
    private double baseCalculo;
    /**
     * Valor liquido (valor bruto diminuido do desconto) da mercadoria/produto ou servico acumulado no mês (com 2 decimais).
     */
    private double valor;
    /**
     * Quantidade da mercadoria/produto no mes (com 3 decimais).
     */
    private double qtd;
    /**
     * Mes e ano de emissao dos documentos fiscais.
     */
    private String mesAno;
    /**
     * Codigo da mercadoria/produto ou servico do informante.
     */
    private String codigo;
    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     */
    private String aliquota;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Base de calculo do ICMS –valor acumulado no mes (com 2 decimais)
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS –valor acumulado no mes (com 2 decimais)
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }

    /**
     * Valor liquido (valor bruto diminuido do desconto) da mercadoria/produto ou servico acumulado no mês (com 2 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor liquido (valor bruto diminuido do desconto) da mercadoria/produto ou servico acumulado no mês (com 2 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Quantidade da mercadoria/produto no mes (com 3 decimais).
     * @return the qtd
     */
    public double getQtd() {
        return qtd;
    }

    /**
     * Quantidade da mercadoria/produto no mes (com 3 decimais).
     * @param qtd the qtd to set
     */
    public void setQtd(double qtd) {
        this.qtd = qtd;
    }

    /**
     * Mes e ano de emissao dos documentos fiscais.
     * @return the mesAno
     */
    public String getMesAno() {
        return mesAno;
    }

    /**
     * Mes e ano de emissao dos documentos fiscais.
     * @param mesAno the mesAno to set
     */
    public void setMesAno(String mesAno) {
        this.mesAno = mesAno;
    }

    /**
     * Codigo da mercadoria/produto ou servico do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo da mercadoria/produto ou servico do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     * @return the aliquota
     */
    public String getAliquota() {
        return aliquota;
    }

    /**
     * Identificador da situacao tributaria/aliquota do ICMS (com 2 decimais).
     * @param aliquota the aliquota to set
     */
    public void setAliquota(String aliquota) {
        this.aliquota = aliquota;
    }
    // </editor-fold>    
    
}