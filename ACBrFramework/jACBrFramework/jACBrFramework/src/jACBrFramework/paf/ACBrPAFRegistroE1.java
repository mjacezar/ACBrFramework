package jACBrFramework.paf;

import java.util.Date;

/**
 * Identificacao do estabelecimento usuario do PAF-ECF e do ECF responsavel por 
 * indicar o momento da atualizacao do estoque.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 14:41:09, revisao: $Id$
 */
public final class ACBrPAFRegistroE1 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Razao Social do estabelecimento.
     */
    private String razaoSocial;
    /**
     * Unidade Federativa.
     */
    private String uf;
    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     */
    private String cnpj;
    /**
     * Inscricao Estadual do estabelecimento.
     */
    private String inscEstadual;
    /**
     * Inscricao Municipal do estabelecimento.
     */
    private String inscMunicipal;
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
     * Data e hora da atualizacao do estoque.
     */
    private Date dataEstoque;
    /**
     * Indica registro valido.
     */
    private boolean registroValido;
    /**
     * Indica exclusao.
     */
    private boolean inclusaoExclusao;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
    /**
     * Razao Social do estabelecimento.
     * @return the razaoSocial
     */
    public String getRazaoSocial() {
        return razaoSocial;
    }

    /**
     * Razao Social do estabelecimento.
     * @param razaoSocial the razaoSocial to set
     */
    public void setRazaoSocial(String razaoSocial) {
        this.razaoSocial = razaoSocial;
    }

    /**
     * Unidade Federativa.
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Unidade Federativa.
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Inscricao Estadual do estabelecimento.
     * @return the inscEstadual
     */
    public String getInscEstadual() {
        return inscEstadual;
    }

    /**
     * Inscricao Estadual do estabelecimento.
     * @param inscEstadual the inscEstadual to set
     */
    public void setInscEstadual(String inscEstadual) {
        this.inscEstadual = inscEstadual;
    }

    /**
     * Inscricao Municipal do estabelecimento.
     * @return the inscMunicipal
     */
    public String getInscMunicipal() {
        return inscMunicipal;
    }

    /**
     * Inscricao Municipal do estabelecimento.
     * @param inscMunicipal the inscMunicipal to set
     */
    public void setInscMunicipal(String inscMunicipal) {
        this.inscMunicipal = inscMunicipal;
    }

    /**
     * Numero de fabricação do ECF responsavel pela atualização do estoque.
     * @return the numFabricacao
     */
    public String getNumFabricacao() {
        return numFabricacao;
    }

    /**
     * Numero de fabricação do ECF responsavel pela atualização do estoque.
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
     * Data e hora da atualizacao do estoque.
     * @return the dataEstoque
     */
    public Date getDataEstoque() {
        return dataEstoque;
    }

    /**
     * Data e hora da atualizacao do estoque.
     * @param dataEstoque the dataEstoque to set
     */
    public void setDataEstoque(Date dataEstoque) {
        this.dataEstoque = dataEstoque;
    }

    /**
     * Indica registro valido.
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Indica registro valido.
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }

    /**
     * Indica exclusao.
     * @return the inclusaoExclusao
     */
    public boolean isInclusaoExclusao() {
        return inclusaoExclusao;
    }

    /**
     * Indica exclusao.
     * @param inclusaoExclusao the inclusaoExclusao to set
     */
    public void setInclusaoExclusao(boolean inclusaoExclusao) {
        this.inclusaoExclusao = inclusaoExclusao;
    }
    // </editor-fold>
    
}