package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Informacoes de exportacoes.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:38:31, revisao: $Id$
 */
public class SintegraRegistro85 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Num. da declaracao de exportacao.
     */
    private String declaracao;
    /**
     * Data da declaracao de exportacao.
     */
    private Date dataDeclaracao;
    /**
     * Natureza da Exportacao.
     */
    private NaturezaExportacao naturezaExportacao;
    /**
     * Num. do registro de Exportacao.
     */
    private String registroExportacao;
    /**
     * Data do Registro de Exportacao.
     */
    private Date dataRegistro;
    /**
     * Num. do conhecimento de embarque.
     */
    private String conhecimento;
    /**
     * Data do conhecimento de embarque.
     */
    private Date dataConhecimento;
    /**
     * Informacao do tipo de conhecimento de transporte.
     * (Preencher conforme tabela do SISCOMEX)
     */
    private String tipoConhecimento;
    /**
     * Codigo do pais de destino da mercadoria.
     * (Preencher conforme tabela do SISCOMEX)
     */
    private String pais;
    /**
     * Data da averbacao da declaracao de exportacao.
     */
    private Date dataAverbacao;
    /**
     * Numero de nota fiscal de exportaca emitida pelo exportador.
     */
    private String numeroNotaFiscal;
    /**
     * Data da emissao da NF de exportacao.
     */
    private Date dataNotaFiscal;
    /**
     * Codigo do modelo da NF.
     */
    private String modelo;
    /**
     * Serie da Nota Fiscal.
     */
    private String serie;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Num. da declaracao de exportacao.
     * @return the declaracao
     */
    public String getDeclaracao() {
        return declaracao;
    }

    /**
     * Num. da declaracao de exportacao.
     * @param declaracao the declaracao to set
     */
    public void setDeclaracao(String declaracao) {
        this.declaracao = declaracao;
    }

    /**
     * Data da declaracao de exportacao.
     * @return the dataDeclaracao
     */
    public Date getDataDeclaracao() {
        return dataDeclaracao;
    }

    /**
     * Data da declaracao de exportacao.
     * @param dataDeclaracao the dataDeclaracao to set
     */
    public void setDataDeclaracao(Date dataDeclaracao) {
        this.dataDeclaracao = dataDeclaracao;
    }

    /**
     * Natureza da Exportacao.
     * @return the naturezaExportacao
     */
    public NaturezaExportacao getNaturezaExportacao() {
        return naturezaExportacao;
    }

    /**
     * Natureza da Exportacao.
     * @param naturezaExportacao the naturezaExportacao to set
     */
    public void setNaturezaExportacao(NaturezaExportacao naturezaExportacao) {
        this.naturezaExportacao = naturezaExportacao;
    }

    /**
     * Num. do registro de Exportacao.
     * @return the registroExportacao
     */
    public String getRegistroExportacao() {
        return registroExportacao;
    }

    /**
     * Num. do registro de Exportacao.
     * @param registroExportacao the registroExportacao to set
     */
    public void setRegistroExportacao(String registroExportacao) {
        this.registroExportacao = registroExportacao;
    }

    /**
     * Data do Registro de Exportacao.
     * @return the dataRegistro
     */
    public Date getDataRegistro() {
        return dataRegistro;
    }

    /**
     * Data do Registro de Exportacao.
     * @param dataRegistro the dataRegistro to set
     */
    public void setDataRegistro(Date dataRegistro) {
        this.dataRegistro = dataRegistro;
    }

    /**
     * Num. do conhecimento de embarque.
     * @return the conhecimento
     */
    public String getConhecimento() {
        return conhecimento;
    }

    /**
     * Num. do conhecimento de embarque.
     * @param conhecimento the conhecimento to set
     */
    public void setConhecimento(String conhecimento) {
        this.conhecimento = conhecimento;
    }

    /**
     * Data do conhecimento de embarque.
     * @return the dataConhecimento
     */
    public Date getDataConhecimento() {
        return dataConhecimento;
    }

    /**
     * Data do conhecimento de embarque.
     * @param dataConhecimento the dataConhecimento to set
     */
    public void setDataConhecimento(Date dataConhecimento) {
        this.dataConhecimento = dataConhecimento;
    }

    /**
     * Informacao do tipo de conhecimento de transporte.
     * (Preencher conforme tabela do SISCOMEX)
     * @return the tipoConhecimento
     */
    public String getTipoConhecimento() {
        return tipoConhecimento;
    }

    /**
     * Informacao do tipo de conhecimento de transporte.
     * (Preencher conforme tabela do SISCOMEX)
     * @param tipoConhecimento the tipoConhecimento to set
     */
    public void setTipoConhecimento(String tipoConhecimento) {
        this.tipoConhecimento = tipoConhecimento;
    }

    /**
     * Codigo do pais de destino da mercadoria.
     * (Preencher conforme tabela do SISCOMEX)
     * @return the pais
     */
    public String getPais() {
        return pais;
    }

    /**
     * Codigo do pais de destino da mercadoria.
     * (Preencher conforme tabela do SISCOMEX)
     * @param pais the pais to set
     */
    public void setPais(String pais) {
        this.pais = pais;
    }

    /**
     * Data da averbacao da declaracao de exportacao.
     * @return the dataAverbacao
     */
    public Date getDataAverbacao() {
        return dataAverbacao;
    }

    /**
     * Data da averbacao da declaracao de exportacao.
     * @param dataAverbacao the dataAverbacao to set
     */
    public void setDataAverbacao(Date dataAverbacao) {
        this.dataAverbacao = dataAverbacao;
    }

    /**
     * Numero de nota fiscal de exportaca emitida pelo exportador.
     * @return the numeroNotaFiscal
     */
    public String getNumeroNotaFiscal() {
        return numeroNotaFiscal;
    }

    /**
     * Numero de nota fiscal de exportaca emitida pelo exportador.
     * @param numeroNotaFiscal the numeroNotaFiscal to set
     */
    public void setNumeroNotaFiscal(String numeroNotaFiscal) {
        this.numeroNotaFiscal = numeroNotaFiscal;
    }

    /**
     * Data da emissao da NF de exportacao.
     * @return the dataNotaFiscal
     */
    public Date getDataNotaFiscal() {
        return dataNotaFiscal;
    }

    /**
     * Data da emissao da NF de exportacao.
     * @param dataNotaFiscal the dataNotaFiscal to set
     */
    public void setDataNotaFiscal(Date dataNotaFiscal) {
        this.dataNotaFiscal = dataNotaFiscal;
    }

    /**
     * Codigo do modelo da NF.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo da NF.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Serie da Nota Fiscal.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie da Nota Fiscal.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }    
    // </editor-fold>      
    
}