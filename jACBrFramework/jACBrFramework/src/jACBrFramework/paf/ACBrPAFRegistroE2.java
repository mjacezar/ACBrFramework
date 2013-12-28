package jACBrFramework.paf;

/**
 * Relacao das mercadorias em estoque.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:21:51, revisao: $Id$
 */
public final class ACBrPAFRegistroE2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da mercadoria ou produto cadastrado na tabela a que se refere o requisito XI.
     */
    private String codMercadoria;
    /**
     * Descricao da mercadoria ou produto cadastrada na tabela a que se refere o requisito XI.
     */
    private String descMercadoria;
    /**
     * Unidade de medida cadastrada na tabela a que se refere o requisito XI.
     */
    private String unidadeMedida;
    /**
     * Quantidade da mercadoria ou produto constante no estoque.
     */
    private double qtdeEstoque;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Codigo da mercadoria ou produto cadastrado na tabela a que se refere o requisito XI.
     * @return the codMercadoria
     */
    public String getCodMercadoria() {
        return codMercadoria;
    }

    /**
     * Codigo da mercadoria ou produto cadastrado na tabela a que se refere o requisito XI.
     * @param codMercadoria the codMercadoria to set
     */
    public void setCodMercadoria(String codMercadoria) {
        this.codMercadoria = codMercadoria;
    }

    /**
     * Descricao da mercadoria ou produto cadastrada na tabela a que se refere o requisito XI.
     * @return the descMercadoria
     */
    public String getDescMercadoria() {
        return descMercadoria;
    }

    /**
     * Descricao da mercadoria ou produto cadastrada na tabela a que se refere o requisito XI.
     * @param descMercadoria the descMercadoria to set
     */
    public void setDescMercadoria(String descMercadoria) {
        this.descMercadoria = descMercadoria;
    }

    /**
     * Unidade de medida cadastrada na tabela a que se refere o requisito XI.
     * @return the unidadeMedida
     */
    public String getUnidadeMedida() {
        return unidadeMedida;
    }

    /**
     * Unidade de medida cadastrada na tabela a que se refere o requisito XI.
     * @param unidadeMedida the unidadeMedida to set
     */
    public void setUnidadeMedida(String unidadeMedida) {
        this.unidadeMedida = unidadeMedida;
    }

    /**
     * Quantidade da mercadoria ou produto constante no estoque.
     * @return the qtdeEstoque
     */
    public double getQtdeEstoque() {
        return qtdeEstoque;
    }

    /**
     * Quantidade da mercadoria ou produto constante no estoque.
     * @param qtdeEstoque the qtdeEstoque to set
     */
    public void setQtdeEstoque(double qtdeEstoque) {
        this.qtdeEstoque = qtdeEstoque;
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