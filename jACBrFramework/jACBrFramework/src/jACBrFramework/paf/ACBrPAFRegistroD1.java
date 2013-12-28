package jACBrFramework.paf;

/**
 * Identificação do estabelecimento usuario do PAF-ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:37:09, revisao: $Id$
 */
public final class ACBrPAFRegistroD1 {

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
    // </editor-fold>        

}