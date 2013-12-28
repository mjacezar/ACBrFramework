package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Relacao dos DAV emitidos.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:38:22, revisao: $Id$
 */
public final class ACBrPAFRegistroD2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Registro D3.
     */
    private Collection<ACBrPAFRegistroD3> registrosD3 = new ArrayList<ACBrPAFRegistroD3>();    
    /**
     * Registro D4.
     */
    private Collection<ACBrPAFRegistroD4> registrosD4 = new ArrayList<ACBrPAFRegistroD4>();    
    /**
     * No. de fabricacao do ECF.
     */
    private String numFabricacao;
    /**
     * Letra indicativa de MF adicional.
     */
    private String mfAdicional;
    /**
     * Tipo do ECF.
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
     * Contador de Ordem de Operacao do documento onde o DAV foi impresso pelo ECF.
     */
    private String coo;
    /**
     * Numero do DAV emitido.
     */
    private String numDav;
    /**
     * Data de emissao do DAV.
     */
    private Date dataDav;
    /**
     * Titulo atribuido ao DAV de acordo com sua funcao. Ex: Orcamento, Pedido, etc.
     */
    private String tituloDav;
    /**
     * Valor total do DAV emitido.
     */
    private double valorTotalDav;
    /**
     * Contador de Ordem de Operacao do documento fiscal vinculado.
     */
    private String cooDocFiscalVenda;
    /**
     * Numero sequencial do ECF emissor do documento fiscal vinculado.
     */
    private String numeroEcf;
    /**
     * Nome do Cliente.
     */
    private String nomeCliente;
    /**
     * CPF ou CNPJ do adquirente.
     */
    private String cpfCnpj;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro D3.
     * @return the registrosD3
     */
    public Collection<ACBrPAFRegistroD3> getRegistrosD3() {
        return registrosD3;
    }

    /**
     * Registro D4.
     * @return the registrosD4
     */
    public Collection<ACBrPAFRegistroD4> getRegistrosD4() {
        return registrosD4;
    }

    /**
     * No. de fabricacao do ECF.
     * @return the numFabricacao
     */
    public String getNumFabricacao() {
        return numFabricacao;
    }

    /**
     * No. de fabricacao do ECF.
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
     * Tipo do ECF.
     * @return the tipoEcf
     */
    public String getTipoEcf() {
        return tipoEcf;
    }

    /**
     * Tipo do ECF.
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
     * Contador de Ordem de Operacao do documento onde o DAV foi impresso pelo ECF.
     * @return the coo
     */
    public String getCoo() {
        return coo;
    }

    /**
     * Contador de Ordem de Operacao do documento onde o DAV foi impresso pelo ECF.
     * @param coo the coo to set
     */
    public void setCoo(String coo) {
        this.coo = coo;
    }

    /**
     * Numero do DAV emitido.
     * @return the numDav
     */
    public String getNumDav() {
        return numDav;
    }

    /**
     * Numero do DAV emitido.
     * @param numDav the numDav to set
     */
    public void setNumDav(String numDav) {
        this.numDav = numDav;
    }

    /**
     * Data de emissao do DAV.
     * @return the dataDav
     */
    public Date getDataDav() {
        return dataDav;
    }

    /**
     * Data de emissao do DAV.
     * @param dataDav the dataDav to set
     */
    public void setDataDav(Date dataDav) {
        this.dataDav = dataDav;
    }

    /**
     * Titulo atribuido ao DAV de acordo com sua funcao. Ex: Orcamento, Pedido, etc.
     * @return the tituloDav
     */
    public String getTituloDav() {
        return tituloDav;
    }

    /**
     * Titulo atribuido ao DAV de acordo com sua funcao. Ex: Orcamento, Pedido, etc.
     * @param tituloDav the tituloDav to set
     */
    public void setTituloDav(String tituloDav) {
        this.tituloDav = tituloDav;
    }

    /**
     * Valor total do DAV emitido.
     * @return the valorTotalDav
     */
    public double getValorTotalDav() {
        return valorTotalDav;
    }

    /**
     * Valor total do DAV emitido.
     * @param valorTotalDav the valorTotalDav to set
     */
    public void setValorTotalDav(double valorTotalDav) {
        this.valorTotalDav = valorTotalDav;
    }

    /**
     * Contador de Ordem de Operacao do documento fiscal vinculado.
     * @return the cooDocFiscalVenda
     */
    public String getCooDocFiscalVenda() {
        return cooDocFiscalVenda;
    }

    /**
     * Contador de Ordem de Operacao do documento fiscal vinculado.
     * @param cooDocFiscalVenda the cooDocFiscalVenda to set
     */
    public void setCooDocFiscalVenda(String cooDocFiscalVenda) {
        this.cooDocFiscalVenda = cooDocFiscalVenda;
    }

    /**
     * Numero sequencial do ECF emissor do documento fiscal vinculado.
     * @return the numeroEcf
     */
    public String getNumeroEcf() {
        return numeroEcf;
    }

    /**
     * Numero sequencial do ECF emissor do documento fiscal vinculado.
     * @param numeroEcf the numeroEcf to set
     */
    public void setNumeroEcf(String numeroEcf) {
        this.numeroEcf = numeroEcf;
    }

    /**
     * Nome do Cliente.
     * @return the nomeCliente
     */
    public String getNomeCliente() {
        return nomeCliente;
    }

    /**
     * Nome do Cliente.
     * @param nomeCliente the nomeCliente to set
     */
    public void setNomeCliente(String nomeCliente) {
        this.nomeCliente = nomeCliente;
    }

    /**
     * CPF ou CNPJ do adquirente.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CPF ou CNPJ do adquirente.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
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