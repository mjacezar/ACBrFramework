package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:14:10, revisao: $Id$
 */
public final class ACBrPAFRegistroMercadoria {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Insumos.
     */
    private Collection<ACBrPAFRegistroInsumo> insumos = new ArrayList<ACBrPAFRegistroInsumo>();    
    /**
     * Descricao do item.
     */
    private String descricao;
    /**
     * Codigo do item.
     */
    private String codigo;
    /**
     * Aliquota do item.
     */
    private double aliquota;
    /**
     * Unidade do item.
     */
    private String unidade;
    /**
     * Quantidade do item.
     */
    private double quantidade;
    /**
     * Codigo EAN.
     */
    private String ean;
    /**
     * Codigo da Situacao Tributaria.
     */
    private String cst;
    /**
     * Valor unitario.
     */
    private double vlrUnitario;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Insumos.
     * @return the insumos
     */
    public Collection<ACBrPAFRegistroInsumo> getInsumos() {
        return insumos;
    }

    /**
     * Descricao do item.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Descricao do item.
     * @param descricao the descricao to set
     */
    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    /**
     * Codigo do item.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do item.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Aliquota do item.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do item.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Unidade do item.
     * @return the unidade
     */
    public String getUnidade() {
        return unidade;
    }

    /**
     * Unidade do item.
     * @param unidade the unidade to set
     */
    public void setUnidade(String unidade) {
        this.unidade = unidade;
    }

    /**
     * Quantidade do item.
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade do item.
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Codigo EAN.
     * @return the ean
     */
    public String getEan() {
        return ean;
    }

    /**
     * Codigo EAN.
     * @param ean the ean to set
     */
    public void setEan(String ean) {
        this.ean = ean;
    }

    /**
     * Codigo da Situacao Tributaria.
     * @return the cst
     */
    public String getCst() {
        return cst;
    }

    /**
     * Codigo da Situacao Tributaria.
     * @param cst the cst to set
     */
    public void setCst(String cst) {
        this.cst = cst;
    }

    /**
     * Valor unitario.
     * @return the vlrUnitario
     */
    public double getVlrUnitario() {
        return vlrUnitario;
    }

    /**
     * Valor unitario.
     * @param vlrUnitario the vlrUnitario to set
     */
    public void setVlrUnitario(double vlrUnitario) {
        this.vlrUnitario = vlrUnitario;
    }
    // </editor-fold>  
    
}