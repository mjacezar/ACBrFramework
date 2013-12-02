package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Analitico: Identificador de cada situacao tributaria no final do dia de cada ECF.
 *
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:36:28, revisao: $Id$
 */
public class SintegraRegistro60A {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * Numero de serie de fabricacao do equipamento.
     */
    private String numSerie;
    /**
     * Identificador da situacao tributaria/aliquota do ICMS.
     */
    private String aliquota;
    /**
     * Data de emissao dos documentos fiscais.
     */
    private Date emissao;
    /**
     * Valor acumulado no final do dia no totalizador parcial da situacao tributaria/aliquota indicada no campo 05 (com 2 decimais).
     */
    private double valor;    
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
     * Identificador da situacao tributaria/aliquota do ICMS.
     * @return the aliquota
     */
    public String getAliquota() {
        return aliquota;
    }

    /**
     * Identificador da situacao tributaria/aliquota do ICMS.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(String aliquota) {
        this.aliquota = aliquota;
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
     * Valor acumulado no final do dia no totalizador parcial da situacao tributaria/aliquota indicada no campo 05 (com 2 decimais).
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor acumulado no final do dia no totalizador parcial da situacao tributaria/aliquota indicada no campo 05 (com 2 decimais).
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }
    // </editor-fold>
    
}