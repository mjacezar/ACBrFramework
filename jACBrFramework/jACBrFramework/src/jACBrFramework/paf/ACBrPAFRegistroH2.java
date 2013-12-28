package jACBrFramework.paf;

import java.util.Date;

/**
 * Identificacao do titulo, do adquirente e da credenciadora.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:34:04, revisao: $Id$
 */
public final class ACBrPAFRegistroH2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Identificacao da credenciadora do cartao.
     */
    private String cnpjCredenciadoraCartao;
    /**
     * Contador de Ordem de Operacaão do Cupom Fiscal onde o troco foi registrado.
     */
    private int coo;
    /**
     * No. do contador do respectivo documento emitido.
     */
    private int ccf;
    /**
     * Valor do troco, para o meio de pagamento cartao de credito ou debito.
     */
    private double vlrTroco;
    /**
     * Data da emissao do Cupom Fiscal.
     */
    private Date dataTroco;
    /**
     * CPF do adquirente do titulo decaptalizacao.
     */
    private String cpfAdquirente;
    /**
     * No. do titulo de captalizacao adquirido.
     */
    private String numTitulo;
    /**
     * Se true o registro e valido.
     */
    private boolean RegistroValido;        
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Identificacao da credenciadora do cartao.
     * @return the cnpjCredenciadoraCartao
     */
    public String getCnpjCredenciadoraCartao() {
        return cnpjCredenciadoraCartao;
    }

    /**
     * Identificacao da credenciadora do cartao.
     * @param cnpjCredenciadoraCartao the cnpjCredenciadoraCartao to set
     */
    public void setCnpjCredenciadoraCartao(String cnpjCredenciadoraCartao) {
        this.cnpjCredenciadoraCartao = cnpjCredenciadoraCartao;
    }

    /**
     * Contador de Ordem de Operacaão do Cupom Fiscal onde o troco foi registrado.
     * @return the coo
     */
    public int getCoo() {
        return coo;
    }

    /**
     * Contador de Ordem de Operacaão do Cupom Fiscal onde o troco foi registrado.
     * @param coo the coo to set
     */
    public void setCoo(int coo) {
        this.coo = coo;
    }

    /**
     * No. do contador do respectivo documento emitido.
     * @return the ccf
     */
    public int getCcf() {
        return ccf;
    }

    /**
     * No. do contador do respectivo documento emitido.
     * @param ccf the ccf to set
     */
    public void setCcf(int ccf) {
        this.ccf = ccf;
    }

    /**
     * Valor do troco, para o meio de pagamento cartao de credito ou debito.
     * @return the vlrTroco
     */
    public double getVlrTroco() {
        return vlrTroco;
    }

    /**
     * Valor do troco, para o meio de pagamento cartao de credito ou debito.
     * @param vlrTroco the vlrTroco to set
     */
    public void setVlrTroco(double vlrTroco) {
        this.vlrTroco = vlrTroco;
    }

    /**
     * Data da emissao do Cupom Fiscal.
     * @return the dataTroco
     */
    public Date getDataTroco() {
        return dataTroco;
    }

    /**
     * Data da emissao do Cupom Fiscal.
     * @param dataTroco the dataTroco to set
     */
    public void setDataTroco(Date dataTroco) {
        this.dataTroco = dataTroco;
    }

    /**
     * CPF do adquirente do titulo decaptalizacao.
     * @return the cpfAdquirente
     */
    public String getCpfAdquirente() {
        return cpfAdquirente;
    }

    /**
     * CPF do adquirente do titulo decaptalizacao.
     * @param cpfAdquirente the cpfAdquirente to set
     */
    public void setCpfAdquirente(String cpfAdquirente) {
        this.cpfAdquirente = cpfAdquirente;
    }

    /**
     * No. do titulo de captalizacao adquirido.
     * @return the numTitulo
     */
    public String getNumTitulo() {
        return numTitulo;
    }

    /**
     * No. do titulo de captalizacao adquirido.
     * @param numTitulo the numTitulo to set
     */
    public void setNumTitulo(String numTitulo) {
        this.numTitulo = numTitulo;
    }

    /**
     * Se true o registro e valido.
     * @return the RegistroValido
     */
    public boolean isRegistroValido() {
        return RegistroValido;
    }

    /**
     * Se true o registro e valido.
     * @param RegistroValido the RegistroValido to set
     */
    public void setRegistroValido(boolean RegistroValido) {
        this.RegistroValido = RegistroValido;
    }
    // </editor-fold>           

}