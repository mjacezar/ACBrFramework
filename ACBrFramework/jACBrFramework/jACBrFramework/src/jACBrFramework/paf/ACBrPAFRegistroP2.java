package jACBrFramework.paf;

/**
 * Relacao das mercadorias e servicos.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:50:41, revisao: $Id$
 */
public final class ACBrPAFRegistroP2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Codigo da mercadoria ou servico.
     */
    private String codMercadoriaServico;
    /**
     * Descricao da mercadoria ou servico.
     */
    private String descMercadoriaServico;
    /**
     * Unidade de medida.
     */
    private String unidadeMedida;
    /**
     * Indicador de Arredondamento ou Truncamento, conforme item 7.2.1.3.
     */
    private String iat;
    /**
     * Indicador de Producao Propria ou de Terceiro, conforme item 7.2.1.4.
     */
    private String ippt;
    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     */
    private String st;
    /**
     * Aliquota, conforme item 7.2.1.6.
     */
    private double aliquota;
    /**
     * Valor unitario.
     */
    private double valorUnitario;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;                        
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Codigo da mercadoria ou servico.
     * @return the codMercadoriaServico
     */
    public String getCodMercadoriaServico() {
        return codMercadoriaServico;
    }

    /**
     * Codigo da mercadoria ou servico.
     * @param codMercadoriaServico the codMercadoriaServico to set
     */
    public void setCodMercadoriaServico(String codMercadoriaServico) {
        this.codMercadoriaServico = codMercadoriaServico;
    }

    /**
     * Descricao da mercadoria ou servico.
     * @return the descMercadoriaServico
     */
    public String getDescMercadoriaServico() {
        return descMercadoriaServico;
    }

    /**
     * Descricao da mercadoria ou servico.
     * @param descMercadoriaServico the descMercadoriaServico to set
     */
    public void setDescMercadoriaServico(String descMercadoriaServico) {
        this.descMercadoriaServico = descMercadoriaServico;
    }

    /**
     * Unidade de medida.
     * @return the unidadeMedida
     */
    public String getUnidadeMedida() {
        return unidadeMedida;
    }

    /**
     * Unidade de medida.
     * @param unidadeMedida the unidadeMedida to set
     */
    public void setUnidadeMedida(String unidadeMedida) {
        this.unidadeMedida = unidadeMedida;
    }

    /**
     * Indicador de Arredondamento ou Truncamento, conforme item 7.2.1.3.
     * @return the iat
     */
    public String getIat() {
        return iat;
    }

    /**
     * Indicador de Arredondamento ou Truncamento, conforme item 7.2.1.3.
     * @param iat the iat to set
     */
    public void setIat(String iat) {
        this.iat = iat;
    }

    /**
     * Indicador de Producao Propria ou de Terceiro, conforme item 7.2.1.4.
     * @return the ippt
     */
    public String getIppt() {
        return ippt;
    }

    /**
     * Indicador de Producao Propria ou de Terceiro, conforme item 7.2.1.4.
     * @param ippt the ippt to set
     */
    public void setIppt(String ippt) {
        this.ippt = ippt;
    }

    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     * @return the st
     */
    public String getSt() {
        return st;
    }

    /**
     * Codigo da Situacao Tributaria conforme tabela constante no item 7.2.1.5.
     * @param st the st to set
     */
    public void setSt(String st) {
        this.st = st;
    }

    /**
     * Aliquota, conforme item 7.2.1.6.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota, conforme item 7.2.1.6.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Valor unitario.
     * @return the valorUnitario
     */
    public double getValorUnitario() {
        return valorUnitario;
    }

    /**
     * Valor unitario.
     * @param valorUnitario the valorUnitario to set
     */
    public void setValorUnitario(double valorUnitario) {
        this.valorUnitario = valorUnitario;
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