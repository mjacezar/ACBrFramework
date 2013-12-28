package jACBrFramework.paf;

/**
 * Detalhe do Cupom Fiscal e do Documento Nao Fiscal - Meio de Pagamento.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 18:21:58, revisao: $Id$
 */
public final class ACBrPAFRegistroR7 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Numero do Contador de Cupom Fiscal relativo ao respectivo Cupom Fiscal emitido.
     */
    private int ccf;
    /**
     * Numero do Contador Geral Nao Fiscal relativo ao respectivo Comprovante Nao Fiscal emitido.
     */
    private int gnf;
    /**
     * Descricao do totalizador parcial de meio de pagamento.
     */
    private String meioPagamento;
    /**
     * Valor do pagamento efetuado.
     */
    private double valorPago;
    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o estorno do pagamento, 
     * ou "P" para estorno parcial do pagamento.
     */
    private String indEstorno;
    /**
     * Valor do estorno efetuado.
     */
    private double valorEstorno;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Numero do Contador de Cupom Fiscal relativo ao respectivo Cupom Fiscal emitido.
     * @return the ccf
     */
    public int getCcf() {
        return ccf;
    }

    /**
     * Numero do Contador de Cupom Fiscal relativo ao respectivo Cupom Fiscal emitido.
     * @param ccf the ccf to set
     */
    public void setCcf(int ccf) {
        this.ccf = ccf;
    }

    /**
     * Numero do Contador Geral Nao Fiscal relativo ao respectivo Comprovante Nao Fiscal emitido.
     * @return the gnf
     */
    public int getGnf() {
        return gnf;
    }

    /**
     * Numero do Contador Geral Nao Fiscal relativo ao respectivo Comprovante Nao Fiscal emitido.
     * @param gnf the gnf to set
     */
    public void setGnf(int gnf) {
        this.gnf = gnf;
    }

    /**
     * Descricao do totalizador parcial de meio de pagamento.
     * @return the meioPagamento
     */
    public String getMeioPagamento() {
        return meioPagamento;
    }

    /**
     * Descricao do totalizador parcial de meio de pagamento.
     * @param meioPagamento the meioPagamento to set
     */
    public void setMeioPagamento(String meioPagamento) {
        this.meioPagamento = meioPagamento;
    }

    /**
     * Valor do pagamento efetuado.
     * @return the valorPago
     */
    public double getValorPago() {
        return valorPago;
    }

    /**
     * Valor do pagamento efetuado.
     * @param valorPago the valorPago to set
     */
    public void setValorPago(double valorPago) {
        this.valorPago = valorPago;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o estorno do pagamento,
     * ou "P" para estorno parcial do pagamento.
     * @return the indEstorno
     */
    public String getIndEstorno() {
        return indEstorno;
    }

    /**
     * Informar "S" ou "N", conforme tenha ocorrido ou nao, o estorno do pagamento,
     * ou "P" para estorno parcial do pagamento.
     * @param indEstorno the indEstorno to set
     */
    public void setIndEstorno(String indEstorno) {
        this.indEstorno = indEstorno;
    }

    /**
     * Valor do estorno efetuado.
     * @return the valorEstorno
     */
    public double getValorEstorno() {
        return valorEstorno;
    }

    /**
     * Valor do estorno efetuado.
     * @param valorEstorno the valorEstorno to set
     */
    public void setValorEstorno(double valorEstorno) {
        this.valorEstorno = valorEstorno;
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