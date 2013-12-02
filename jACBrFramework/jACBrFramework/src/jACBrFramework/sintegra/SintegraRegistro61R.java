package jACBrFramework.sintegra;

/**
 * Resumo Mensal por Item : Registro de mercadoria/produto ou serviço comercializados atraves 
 * de nota fiscal de venda a consumidor nao emitida por ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:29, revisao: $Id$
 */
public class SintegraRegistro61R {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Aliquota do ICMS do produto.
     */
    private double aliquota;
    /**
     * Valor bruto do produto - valor acumulado da venda do produto no mes (com 2 decimais).
     */
    private double valor;
    /**
     * Quantidade do produto acumulada vendida no mes (com 3 decimais).
     */
    private double qtd;
    /**
     * Mes e ano de emissao dos documentos fiscais.
     */
    private String mesAno;
    /**
     * Codigo do produto do informante.
     */
    private String codigo;
    /**
     * Base de calculo do ICMS do valor acumulado no mes (com 2 decimais).
     */
    private double baseCalculo;    
   // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Aliquota do ICMS do produto.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do ICMS do produto.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Valor bruto do produto - valor acumulado da venda do produto no mes (com 2 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor bruto do produto - valor acumulado da venda do produto no mes (com 2 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }

    /**
     * Quantidade do produto acumulada vendida no mes (com 3 decimais).
     * @return the qtd
     */
    public double getQtd() {
        return qtd;
    }

    /**
     * Quantidade do produto acumulada vendida no mes (com 3 decimais).
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
     * Base de calculo do ICMS do valor acumulado no mes (com 2 decimais).
     * @return the baseCalculo
     */
    public double getBaseCalculo() {
        return baseCalculo;
    }

    /**
     * Base de calculo do ICMS do valor acumulado no mes (com 2 decimais).
     * @param baseCalculo the baseCalculo to set
     */
    public void setBaseCalculo(double baseCalculo) {
        this.baseCalculo = baseCalculo;
    }
    // </editor-fold>          

}