package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Cupom Fiscal, Nota Fiscal de Venda a Consumidor ou Bilhete de Passagem.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 08:24:53, revisao: $Id$
 */
public final class ACBrPAFRegistroR4 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro R5.
     */
    private Collection<ACBrPAFRegistroR5> registrosR5 = new ArrayList<ACBrPAFRegistroR5>();
    /**
     * Registro R7.
     */
    private Collection<ACBrPAFRegistroR7> registrosR7 = new ArrayList<ACBrPAFRegistroR7>();
    /**
     * No. de ordem do usuario do ECF.
     */
    private int numeroUsuario;
    /**
     * No. do contador do respectivo documento emitido.
     */
    private int numContador;
    /**
     * No. do COO relativo ao respectivo documento.
     */
    private int coo;
    /**
     * Data de inicio da emissao do documento impressa no cabecalho do documento.
     */
    private Date dataInicioEmissao;
    /**
     * Valor total do documento.
     */
    private double subTotalDocumento; 
    /**
     * Valor do desconto ou Percentual aplicado sobre o valor do subtotal do documento.
     */
    private double descontoSobreSubtotal;
    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     */
    private String tipoDesconto;
    /**
     * Valor do acrescimo ou Percentual aplicado sobre o valor do subtotal do documento.
     */
    private double acrescimoSobreSubtotal;
    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     */
    private String tipoAcrescimo;
    /**
     * Valor total do Cupom Fiscal apos desconto/acrescimo, com duas casas decimais.
     */
    private double valorTotalLiquido;
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento do documento.
     */
    private String indCancelamento;
    /**
     * Valor do cancelamento de acrescimo no subtotal.
     */
    private double valorCancelamento;
    /**
     * Indicador de ordem de aplicacao de desconto/acrescimo em Subtotal. 
     * "D" ou "A" caso tenha ocorrido primeiro desconto ou acrescimo, respectivamente.
     */
    private String ordemAplicacaoDescAcres;
    /**
     * Nome do Cliente.
     */
    private String nomeCliente;
    /**
     * CPF ou CNPJ do adquirente.
     */
    private String cnpjCpf;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro R5.
     * @return the registrosR5
     */
    public Collection<ACBrPAFRegistroR5> getRegistrosR5() {
        return registrosR5;
    }

    /**
     * Registro R7.
     * @return the registrosR7
     */
    public Collection<ACBrPAFRegistroR7> getRegistrosR7() {
        return registrosR7;
    }

    /**
     * No. de ordem do usuario do ECF.
     * @return the numeroUsuario
     */
    public int getNumeroUsuario() {
        return numeroUsuario;
    }

    /**
     * No. de ordem do usuario do ECF.
     * @param numeroUsuario the numeroUsuario to set
     */
    public void setNumeroUsuario(int numeroUsuario) {
        this.numeroUsuario = numeroUsuario;
    }

    /**
     * No. do contador do respectivo documento emitido.
     * @return the numContador
     */
    public int getNumContador() {
        return numContador;
    }

    /**
     * No. do contador do respectivo documento emitido.
     * @param numContador the numContador to set
     */
    public void setNumContador(int numContador) {
        this.numContador = numContador;
    }

    /**
     * No. do COO relativo ao respectivo documento.
     * @return the coo
     */
    public int getCoo() {
        return coo;
    }

    /**
     * No. do COO relativo ao respectivo documento.
     * @param coo the coo to set
     */
    public void setCoo(int coo) {
        this.coo = coo;
    }

    /**
     * Data de inicio da emissao do documento impressa no cabecalho do documento.
     * @return the dataInicioEmissao
     */
    public Date getDataInicioEmissao() {
        return dataInicioEmissao;
    }

    /**
     * Data de inicio da emissao do documento impressa no cabecalho do documento.
     * @param dataInicioEmissao the dataInicioEmissao to set
     */
    public void setDataInicioEmissao(Date dataInicioEmissao) {
        this.dataInicioEmissao = dataInicioEmissao;
    }

    /**
     * Valor total do documento.
     * @return the subTotalDocumento
     */
    public double getSubTotalDocumento() {
        return subTotalDocumento;
    }

    /**
     * Valor total do documento.
     * @param subTotalDocumento the subTotalDocumento to set
     */
    public void setSubTotalDocumento(double subTotalDocumento) {
        this.subTotalDocumento = subTotalDocumento;
    }

    /**
     * Valor do desconto ou Percentual aplicado sobre o valor do subtotal do documento.
     * @return the descontoSobreSubtotal
     */
    public double getDescontoSobreSubtotal() {
        return descontoSobreSubtotal;
    }

    /**
     * Valor do desconto ou Percentual aplicado sobre o valor do subtotal do documento.
     * @param descontoSobreSubtotal the descontoSobreSubtotal to set
     */
    public void setDescontoSobreSubtotal(double descontoSobreSubtotal) {
        this.descontoSobreSubtotal = descontoSobreSubtotal;
    }

    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     * @return the tipoDesconto
     */
    public String getTipoDesconto() {
        return tipoDesconto;
    }

    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     * @param tipoDesconto the tipoDesconto to set
     */
    public void setTipoDesconto(String tipoDesconto) {
        this.tipoDesconto = tipoDesconto;
    }

    /**
     * Valor do acrescimo ou Percentual aplicado sobre o valor do subtotal do documento.
     * @return the acrescimoSobreSubtotal
     */
    public double getAcrescimoSobreSubtotal() {
        return acrescimoSobreSubtotal;
    }

    /**
     * Valor do acrescimo ou Percentual aplicado sobre o valor do subtotal do documento.
     * @param acrescimoSobreSubtotal the acrescimoSobreSubtotal to set
     */
    public void setAcrescimoSobreSubtotal(double acrescimoSobreSubtotal) {
        this.acrescimoSobreSubtotal = acrescimoSobreSubtotal;
    }

    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     * @return the tipoAcrescimo
     */
    public String getTipoAcrescimo() {
        return tipoAcrescimo;
    }

    /**
     * Informar "V" para valor monetario ou "P" para percentual.
     * @param tipoAcrescimo the tipoAcrescimo to set
     */
    public void setTipoAcrescimo(String tipoAcrescimo) {
        this.tipoAcrescimo = tipoAcrescimo;
    }

    /**
     * Valor total do Cupom Fiscal apos desconto/acrescimo, com duas casas decimais.
     * @return the valorTotalLiquido
     */
    public double getValorTotalLiquido() {
        return valorTotalLiquido;
    }

    /**
     * Valor total do Cupom Fiscal apos desconto/acrescimo, com duas casas decimais.
     * @param valorTotalLiquido the valorTotalLiquido to set
     */
    public void setValorTotalLiquido(double valorTotalLiquido) {
        this.valorTotalLiquido = valorTotalLiquido;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento do documento.
     * @return the indCancelamento
     */
    public String getIndCancelamento() {
        return indCancelamento;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o cancelamento do documento.
     * @param indCancelamento the indCancelamento to set
     */
    public void setIndCancelamento(String indCancelamento) {
        this.indCancelamento = indCancelamento;
    }

    /**
     * Valor do cancelamento de acrescimo no subtotal.
     * @return the valorCancelamento
     */
    public double getValorCancelamento() {
        return valorCancelamento;
    }

    /**
     * Valor do cancelamento de acrescimo no subtotal.
     * @param valorCancelamento the valorCancelamento to set
     */
    public void setValorCancelamento(double valorCancelamento) {
        this.valorCancelamento = valorCancelamento;
    }

    /**
     * Indicador de ordem de aplicacao de desconto/acrescimo em Subtotal.
     * "D" ou "A" caso tenha ocorrido primeiro desconto ou acrescimo, respectivamente.
     * @return the ordemAplicacaoDescAcres
     */
    public String getOrdemAplicacaoDescAcres() {
        return ordemAplicacaoDescAcres;
    }

    /**
     * Indicador de ordem de aplicacao de desconto/acrescimo em Subtotal.
     * "D" ou "A" caso tenha ocorrido primeiro desconto ou acrescimo, respectivamente.
     * @param ordemAplicacaoDescAcres the ordemAplicacaoDescAcres to set
     */
    public void setOrdemAplicacaoDescAcres(String ordemAplicacaoDescAcres) {
        this.ordemAplicacaoDescAcres = ordemAplicacaoDescAcres;
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
     * @return the cnpjCpf
     */
    public String getCnpjCpf() {
        return cnpjCpf;
    }

    /**
     * CPF ou CNPJ do adquirente.
     * @param cnpjCpf the cnpjCpf to set
     */
    public void setCnpjCpf(String cnpjCpf) {
        this.cnpjCpf = cnpjCpf;
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