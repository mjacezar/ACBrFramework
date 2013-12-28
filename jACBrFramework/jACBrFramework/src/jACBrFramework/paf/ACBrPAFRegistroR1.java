package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Identificacao do ECF, do Usuario, do PAF-ECF e da Empresa Desenvolvedora e Dados do Arquivo.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 08:33:10, revisao: $Id$
 */
public final class ACBrPAFRegistroR1 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro R2.
     */
    private Collection<ACBrPAFRegistroR2> registrosR2 = new ArrayList<ACBrPAFRegistroR2>();
    /**
     * Registro R4.
     */
    private Collection<ACBrPAFRegistroR4> registrosR4 = new ArrayList<ACBrPAFRegistroR4>();
    /**
     * Registro R6.
     */
    private Collection<ACBrPAFRegistroR6> registrosR6 = new ArrayList<ACBrPAFRegistroR6>();    
    /**
     * Numero de fabricaCao do ECF.
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
     * Versao atual do Software Basico do ECF gravada na MF.
     */
    private String versaoSb;
    /**
     * Data de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     */
    private Date dtInstalacaoSb;
    /**
     * Horario de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     */
    private Date horaInstalacaoSb;
    /**
     * No. de ordem sequencial do ECF no estabelecimento usuario.
     */
    private int numSeqEcf;
    /**
     * CNPJ do estabelecimento usuario do ECF.
     */
    private String cnpj;
    /**
     * Inscricao Estadual do estabelecimento usuario.
     */
    private String inscEstadual;
    /**
     * CNPJ da empresa desenvolvedora do PAF-ECF.
     */
    private String cnpjSh;
    /**
     * Inscricao Estadual da empresa desenvolvedora do PAF-ECF, se houver.
     */
    private String inscEstadualSh;
    /**
     * Inscricao Municipal da empresa desenvolvedora do PAF-ECF, se houver.
     */
    private String inscMunicipalSh;
    /**
     * Denominacao da empresa desenvolvedora do PAF-ECF.
     */
    private String nomeSh;
    /**
     * Nome Comercial do PAF-ECF.
     */
    private String nomePaf;
    /**
     * Versao atual do PAF-ECF.
     */
    private String versaoPaf;
    /**
     * Codigo MD-5 da lista de arquivos autenticados.
     */
    private String codigoMd5;
    /**
     * Data do inicio do periodo informado no arquivo.
     */
    private Date dataInicial;
    /**
     * Data do fim do periodo informado no arquivo.
     */
    private Date dataFim;
    /**
     * Versao da Especificacao de Requisitos do PAF-ECF.
     */
    private String versaoRequisitosPaf;
    /**
     * Indica inclusao/exclusao.
     */
    private boolean inclusaoExclusao;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro R2.
     * @return the registrosR2
     */
    public Collection<ACBrPAFRegistroR2> getRegistrosR2() {
        return registrosR2;
    }

    /**
     * Registro R4.
     * @return the registrosR4
     */
    public Collection<ACBrPAFRegistroR4> getRegistrosR4() {
        return registrosR4;
    }

    /**
     * Registro R6.
     * @return the registrosR6
     */
    public Collection<ACBrPAFRegistroR6> getRegistrosR6() {
        return registrosR6;
    }

    /**
     * Numero de fabricaCao do ECF.
     * @return the numFabricacao
     */
    public String getNumFabricacao() {
        return numFabricacao;
    }

    /**
     * Numero de fabricaCao do ECF.
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
     * Versao atual do Software Basico do ECF gravada na MF.
     * @return the versaoSb
     */
    public String getVersaoSb() {
        return versaoSb;
    }

    /**
     * Versao atual do Software Basico do ECF gravada na MF.
     * @param versaoSb the versaoSb to set
     */
    public void setVersaoSb(String versaoSb) {
        this.versaoSb = versaoSb;
    }

    /**
     * Data de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     * @return the dtInstalacaoSb
     */
    public Date getDtInstalacaoSb() {
        return dtInstalacaoSb;
    }

    /**
     * Data de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     * @param dtInstalacaoSb the dtInstalacaoSb to set
     */
    public void setDtInstalacaoSb(Date dtInstalacaoSb) {
        this.dtInstalacaoSb = dtInstalacaoSb;
    }

    /**
     * Horario de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     * @return the horaInstalacaoSb
     */
    public Date getHoraInstalacaoSb() {
        return horaInstalacaoSb;
    }

    /**
     * Horario de instalacao da versao atual do Software Basico gravada na Memoria Fiscal do ECF.
     * @param horaInstalacaoSb the horaInstalacaoSb to set
     */
    public void setHoraInstalacaoSb(Date horaInstalacaoSb) {
        this.horaInstalacaoSb = horaInstalacaoSb;
    }

    /**
     * No. de ordem sequencial do ECF no estabelecimento usuario.
     * @return the numSeqEcf
     */
    public int getNumSeqEcf() {
        return numSeqEcf;
    }

    /**
     * No. de ordem sequencial do ECF no estabelecimento usuario.
     * @param numSeqEcf the numSeqEcf to set
     */
    public void setNumSeqEcf(int numSeqEcf) {
        this.numSeqEcf = numSeqEcf;
    }

    /**
     * CNPJ do estabelecimento usuario do ECF.
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ do estabelecimento usuario do ECF.
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Inscricao Estadual do estabelecimento usuario.
     * @return the inscEstadual
     */
    public String getInscEstadual() {
        return inscEstadual;
    }

    /**
     * Inscricao Estadual do estabelecimento usuario.
     * @param inscEstadual the inscEstadual to set
     */
    public void setInscEstadual(String inscEstadual) {
        this.inscEstadual = inscEstadual;
    }

    /**
     * CNPJ da empresa desenvolvedora do PAF-ECF.
     * @return the cnpjSh
     */
    public String getCnpjSh() {
        return cnpjSh;
    }

    /**
     * CNPJ da empresa desenvolvedora do PAF-ECF.
     * @param cnpjSh the cnpjSh to set
     */
    public void setCnpjSh(String cnpjSh) {
        this.cnpjSh = cnpjSh;
    }

    /**
     * Inscricao Estadual da empresa desenvolvedora do PAF-ECF, se houver.
     * @return the inscEstadualSh
     */
    public String getInscEstadualSh() {
        return inscEstadualSh;
    }

    /**
     * Inscricao Estadual da empresa desenvolvedora do PAF-ECF, se houver.
     * @param inscEstadualSh the inscEstadualSh to set
     */
    public void setInscEstadualSh(String inscEstadualSh) {
        this.inscEstadualSh = inscEstadualSh;
    }

    /**
     * Inscricao Municipal da empresa desenvolvedora do PAF-ECF, se houver.
     * @return the inscMunicipalSh
     */
    public String getInscMunicipalSh() {
        return inscMunicipalSh;
    }

    /**
     * Inscricao Municipal da empresa desenvolvedora do PAF-ECF, se houver.
     * @param inscMunicipalSh the inscMunicipalSh to set
     */
    public void setInscMunicipalSh(String inscMunicipalSh) {
        this.inscMunicipalSh = inscMunicipalSh;
    }

    /**
     * Denominacao da empresa desenvolvedora do PAF-ECF.
     * @return the nomeSh
     */
    public String getNomeSh() {
        return nomeSh;
    }

    /**
     * Denominacao da empresa desenvolvedora do PAF-ECF.
     * @param nomeSh the nomeSh to set
     */
    public void setNomeSh(String nomeSh) {
        this.nomeSh = nomeSh;
    }

    /**
     * Nome Comercial do PAF-ECF.
     * @return the nomePaf
     */
    public String getNomePaf() {
        return nomePaf;
    }

    /**
     * Nome Comercial do PAF-ECF.
     * @param nomePaf the nomePaf to set
     */
    public void setNomePaf(String nomePaf) {
        this.nomePaf = nomePaf;
    }

    /**
     * Versao atual do PAF-ECF.
     * @return the versaoPaf
     */
    public String getVersaoPaf() {
        return versaoPaf;
    }

    /**
     * Versao atual do PAF-ECF.
     * @param versaoPaf the versaoPaf to set
     */
    public void setVersaoPaf(String versaoPaf) {
        this.versaoPaf = versaoPaf;
    }

    /**
     * Codigo MD-5 da lista de arquivos autenticados.
     * @return the codigoMd5
     */
    public String getCodigoMd5() {
        return codigoMd5;
    }

    /**
     * Codigo MD-5 da lista de arquivos autenticados.
     * @param codigoMd5 the codigoMd5 to set
     */
    public void setCodigoMd5(String codigoMd5) {
        this.codigoMd5 = codigoMd5;
    }

    /**
     * Data do inicio do periodo informado no arquivo.
     * @return the dataInicial
     */
    public Date getDataInicial() {
        return dataInicial;
    }

    /**
     * Data do inicio do periodo informado no arquivo.
     * @param dataInicial the dataInicial to set
     */
    public void setDataInicial(Date dataInicial) {
        this.dataInicial = dataInicial;
    }

    /**
     * Data do fim do periodo informado no arquivo.
     * @return the dataFim
     */
    public Date getDataFim() {
        return dataFim;
    }

    /**
     * Data do fim do periodo informado no arquivo.
     * @param dataFim the dataFim to set
     */
    public void setDataFim(Date dataFim) {
        this.dataFim = dataFim;
    }

    /**
     * Versao da Especificacao de Requisitos do PAF-ECF.
     * @return the versaoRequisitosPaf
     */
    public String getVersaoRequisitosPaf() {
        return versaoRequisitosPaf;
    }

    /**
     * Versao da Especificacao de Requisitos do PAF-ECF.
     * @param versaoRequisitosPaf the versaoRequisitosPaf to set
     */
    public void setVersaoRequisitosPaf(String versaoRequisitosPaf) {
        this.versaoRequisitosPaf = versaoRequisitosPaf;
    }

    /**
     * Indica inclusao/exclusao.
     * @return the inclusaoExclusao
     */
    public boolean isInclusaoExclusao() {
        return inclusaoExclusao;
    }

    /**
     * Indica inclusao/exclusao.
     * @param inclusaoExclusao the inclusaoExclusao to set
     */
    public void setInclusaoExclusao(boolean inclusaoExclusao) {
        this.inclusaoExclusao = inclusaoExclusao;
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