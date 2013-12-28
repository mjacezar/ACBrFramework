package jACBrFramework.paf;

import java.util.Date;

/**
 * Relacao das mercadorias em estoque.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:25:50, revisao: $Id$
 */
public final class ACBrPAFRegistroE3 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Numero de fabricacao do ECF responsavel pela atualizacao do estoque.
     */
    private String numFabricacao;
    /**
     * Letra indicativa de MF adicional.
     */
    private String mfAdicional;
    /**
     * Tipo de ECF.
     */
    private String tipoEcf;
    /**
     * Marca do ECF.
     */
    private String marcaEcf;
    /**
     * Modelo do ECF.
     */
    private String modeloEcf;
    /**
     * Data da atualizacao do estoque.
     */
    private Date dataEstoque;
    /**
     * Hora da atualizacao do estoque.
     */
    private Date horaEstoque;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero de fabricacao do ECF responsavel pela atualizacao do estoque.
     * @return the numFabricacao
     */
    public String getNumFabricacao() {
        return numFabricacao;
    }

    /**
     * Numero de fabricacao do ECF responsavel pela atualizacao do estoque.
     * @param numFabricacao the numFabricacao to set
     */
    public void setNumFabricacao(String numFabricacao) {
        this.numFabricacao = numFabricacao;
    }

    /**
     * Letra indicativa de MF adicional.
     * @return the mfAdicional
     */
    public String getMfAdicional() {
        return mfAdicional;
    }

    /**
     * Letra indicativa de MF adicional.
     * @param mfAdicional the mfAdicional to set
     */
    public void setMfAdicional(String mfAdicional) {
        this.mfAdicional = mfAdicional;
    }

    /**
     * Tipo de ECF.
     * @return the tipoEcf
     */
    public String getTipoEcf() {
        return tipoEcf;
    }

    /**
     * Tipo de ECF.
     * @param tipoEcf the tipoEcf to set
     */
    public void setTipoEcf(String tipoEcf) {
        this.tipoEcf = tipoEcf;
    }

    /**
     * Marca do ECF.
     * @return the marcaEcf
     */
    public String getMarcaEcf() {
        return marcaEcf;
    }

    /**
     * Marca do ECF.
     * @param marcaEcf the marcaEcf to set
     */
    public void setMarcaEcf(String marcaEcf) {
        this.marcaEcf = marcaEcf;
    }

    /**
     * Modelo do ECF.
     * @return the modeloEcf
     */
    public String getModeloEcf() {
        return modeloEcf;
    }

    /**
     * Modelo do ECF.
     * @param modeloEcf the modeloEcf to set
     */
    public void setModeloEcf(String modeloEcf) {
        this.modeloEcf = modeloEcf;
    }

    /**
     * Data da atualizacao do estoque.
     * @return the dataEstoque
     */
    public Date getDataEstoque() {
        return dataEstoque;
    }

    /**
     * Data da atualizacao do estoque.
     * @param dataEstoque the dataEstoque to set
     */
    public void setDataEstoque(Date dataEstoque) {
        this.dataEstoque = dataEstoque;
    }

    /**
     * Hora da atualizacao do estoque.
     * @return the horaEstoque
     */
    public Date getHoraEstoque() {
        return horaEstoque;
    }

    /**
     * Hora da atualizacao do estoque.
     * @param horaEstoque the horaEstoque to set
     */
    public void setHoraEstoque(Date horaEstoque) {
        this.horaEstoque = horaEstoque;
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