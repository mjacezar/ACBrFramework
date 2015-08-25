package jACBrFramework.paf;

/**
 * Itens da mesa/conta do cliente.
 *
 * @author Jose Mauro
 * @version Criado em: 04/08/2014 18:11:03, revisao: $Id$
 */
public final class ACBrPAFRegistroS3 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Codigo do produto ou servico registrado no documento.
     */
    private String codItem;
    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     */
    private String descItem;
    /**
     * Quantidade comercializada, sem a separacao das casas decimais.
     */
    private double quantidade;
    /**
     * Unidade de medida.
     */
    private String unidadeMedida;
    /**
     * Valor unitario do produto ou servico, com duas casas decimais.
     */
    private double vlrUnitario;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;

    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Codigo do produto ou servico registrado no documento.
     *
     * @return the codItem
     */
    public String getCodItem() {
        return codItem;
    }

    /**
     * Codigo do produto ou servico registrado no documento.
     *
     * @param codItem the codItem to set
     */
    public void setCodItem(String codItem) {
        this.codItem = codItem;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     *
     * @return the descItem
     */
    public String getDescItem() {
        return descItem;
    }

    /**
     * Descricao do produto ou servico constante no Cupom Fiscal.
     *
     * @param descItem the descItem to set
     */
    public void setDescItem(String descItem) {
        this.descItem = descItem;
    }

    /**
     * Quantidade comercializada, sem a separacao das casas decimais.
     *
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade comercializada, sem a separacao das casas decimais.
     *
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Unidade de medida.
     *
     * @return the unidadeMedida
     */
    public String getUnidadeMedida() {
        return unidadeMedida;
    }

    /**
     * Unidade de medida.
     *
     * @param unidadeMedida the unidadeMedida to set
     */
    public void setUnidadeMedida(String unidadeMedida) {
        this.unidadeMedida = unidadeMedida;
    }

    /**
     * Valor unitario do produto ou servico, com duas casas decimais.
     *
     * @return the vlrUnitario
     */
    public double getVlrUnitario() {
        return vlrUnitario;
    }

    /**
     * Valor unitario do produto ou servico, com duas casas decimais.
     *
     * @param vlrUnitario the vlrUnitario to set
     */
    public void setVlrUnitario(double vlrUnitario) {
        this.vlrUnitario = vlrUnitario;
    }

    /**
     * Se true o registro e valido.
     *
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Se true o registro e valido.
     *
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }
    // </editor-fold>  
}