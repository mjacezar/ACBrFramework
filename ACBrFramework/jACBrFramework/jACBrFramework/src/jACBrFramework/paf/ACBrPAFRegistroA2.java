package jACBrFramework.paf;

import java.util.Date;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 15:52:13, revisao: $Id$
 */
public final class ACBrPAFRegistroA2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;
    /**
     * Data do movimento.
     */
    private Date data;
    /**
     * Meio de pagamento registrado nos documentos emitidos (Dinheiro, Cheque, 
     * Cartao de Credito, Cartao de Debito, etc.).
     */
    private String meioPagamento;
    /**
     * Codigo do tipo de documento a que se refere o pagamento.
     */
    private CodigoTipoDocumento codigoTipoDocumento;
    /**
     * Valor total do meio de pagamento acumulado no dia.
     */
    private double valor;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        
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

    /**
     * Data do movimento.
     * @return the data
     */
    public Date getData() {
        return data;
    }

    /**
     * Data do movimento.
     * @param data the data to set
     */
    public void setData(Date data) {
        this.data = data;
    }

    /**
     * Meio de pagamento registrado nos documentos emitidos (Dinheiro, Cheque,
     * Cartao de Credito, Cartao de Debito, etc.).
     * @return the meioPagamento
     */
    public String getMeioPagamento() {
        return meioPagamento;
    }

    /**
     * Meio de pagamento registrado nos documentos emitidos (Dinheiro, Cheque,
     * Cartao de Credito, Cartao de Debito, etc.).
     * @param meioPagamento the meioPagamento to set
     */
    public void setMeioPagamento(String meioPagamento) {
        this.meioPagamento = meioPagamento;
    }

    /**
     * Codigo do tipo de documento a que se refere o pagamento.
     * @return the codigoTipoDocumento
     */
    public CodigoTipoDocumento getCodigoTipoDocumento() {
        return codigoTipoDocumento;
    }

    /**
     * Codigo do tipo de documento a que se refere o pagamento.
     * @param codigoTipoDocumento the codigoTipoDocumento to set
     */
    public void setCodigoTipoDocumento(CodigoTipoDocumento codigoTipoDocumento) {
        this.codigoTipoDocumento = codigoTipoDocumento;
    }

    /**
     * Valor total do meio de pagamento acumulado no dia.
     * @return the valor
     */
    public double getValor() {
        return valor;
    }

    /**
     * Valor total do meio de pagamento acumulado no dia.
     * @param valor the valor to set
     */
    public void setValor(double valor) {
        this.valor = valor;
    }
    // </editor-fold>
    
}