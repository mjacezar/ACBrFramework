package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Mesa/Conta de cliente.
 *
 * @author Jose Mauro
 * @version Criado em: 04/08/2014 18:03:07, revisao: $Id$
 */
public final class ACBrPAFRegistroS2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Registro S3.
     */
    private Collection<ACBrPAFRegistroS3> registrosS3 = new ArrayList<ACBrPAFRegistroS3>();
    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     */
    private String cnpj;
    /**
     * Data e hora da abertura da Mesa ou Conta de Cliente.
     */
    private Date dtHrAbertura;
    /**
     * Numero da mesa do cliente.
     */
    private String numMesa;
    /**
     * "A" para Aberta ou "F" para Fechada.
     */
    private String situacao;
    /**
     * Valor Total.
     */
    private double vlrTotal;
    /**
     * Mesa Contador de Ordem de Operacao do Relatorio Gerencial de Conferencia de Mesa.
     */
    private String cooConfMesa;
    /**
     * Numero de fabricacao do ECF que emitiu o Relatorio Gerencial Conferencia de Mesa.
     */
    private String numFabricacaoEcfConfMesa;
    /**
     * Contador de Ordem de Operacao do Cupom Fiscal;
     */
    private String coo;
    /**
     * NUmero de fabricaCAo do ECF que emitiu o Cupom Fiscal.
     */
    private String numFabricacaoEcf;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    

    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     *
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ do estabelecimento usuario do PAF-ECF.
     *
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Data e hora da abertura da Mesa ou Conta de Cliente.
     *
     * @return the dtHrAbertura
     */
    public Date getDtHrAbertura() {
        return dtHrAbertura;
    }

    /**
     * Data e hora da abertura da Mesa ou Conta de Cliente.
     *
     * @param dtHrAbertura the dtHrAbertura to set
     */
    public void setDtHrAbertura(Date dtHrAbertura) {
        this.dtHrAbertura = dtHrAbertura;
    }

    /**
     * Numero da Mesa do Cliente.
     *
     * @return the numMesa
     */
    public String getNumMesa() {
        return numMesa;
    }

    /**
     * Numero da Mesa do Cliente.
     *
     * @param numMesa the numMesa to set
     */
    public void setNumMesa(String numMesa) {
        this.numMesa = numMesa;
    }

    /**
     * "A" para Aberta ou "F" para Fechada.
     *
     * @return the situacao
     */
    public String getSituacao() {
        return situacao;
    }

    /**
     * "A" para Aberta ou "F" para Fechada.
     *
     * @param situacao the situacao to set
     */
    public void setSituacao(String situacao) {
        this.situacao = situacao;
    }

    /**
     * Valor Total.
     *
     * @return the vlrTotal
     */
    public double getVlrTotal() {
        return vlrTotal;
    }

    /**
     * Valor Total.
     *
     * @param vlrTotal the vlrTotal to set
     */
    public void setVlrTotal(double vlrTotal) {
        this.vlrTotal = vlrTotal;
    }

    /**
     * Mesa Contador de Ordem de Operacao do Relatorio Gerencial de Conferencia de Mesa.
     *
     * @return the cooConfMesa
     */
    public String getCooConfMesa() {
        return cooConfMesa;
    }

    /**
     * Mesa Contador de Ordem de Operacao do Relatorio Gerencial de Conferencia de Mesa.
     *
     * @param cooConfMesa the cooConfMesa to set
     */
    public void setCooConfMesa(String cooConfMesa) {
        this.cooConfMesa = cooConfMesa;
    }

    /**
     * Numero de fabricacao do ECF que emitiu o Relatorio Gerencial Conferencia de Mesa.
     *
     * @return the numFabricacaoEcfConfMesa
     */
    public String getNumFabricacaoEcfConfMesa() {
        return numFabricacaoEcfConfMesa;
    }

    /**
     * Numero de fabricacao do ECF que emitiu o Relatorio Gerencial Conferencia de Mesa.
     *
     * @param numFabricacaoEcfConfMesa the numFabricacaoEcfConfMesa to set
     */
    public void setNumFabricacaoEcfConfMesa(String numFabricacaoEcfConfMesa) {
        this.numFabricacaoEcfConfMesa = numFabricacaoEcfConfMesa;
    }

    /**
     * Contador de Ordem de Operacao do Cupom Fiscal;
     *
     * @return the coo
     */
    public String getCoo() {
        return coo;
    }

    /**
     * Contador de Ordem de Operacao do Cupom Fiscal;
     *
     * @param coo the coo to set
     */
    public void setCoo(String coo) {
        this.coo = coo;
    }

    /**
     * NUmero de fabricaCAo do ECF que emitiu o Cupom Fiscal.
     *
     * @return the numFabricacaoEcf
     */
    public String getNumFabricacaoEcf() {
        return numFabricacaoEcf;
    }

    /**
     * NUmero de fabricaCAo do ECF que emitiu o Cupom Fiscal.
     *
     * @param numFabricacaoEcf the numFabricacaoEcf to set
     */
    public void setNumFabricacaoEcf(String numFabricacaoEcf) {
        this.numFabricacaoEcf = numFabricacaoEcf;
    }

    /**
     * Registro SS.
     *
     * @return the registrosSS
     */
    public Collection<ACBrPAFRegistroS3> getRegistrosS3() {
        return registrosS3;
    }

    /**
     * Se true o registro e valido.
     *
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Se true o registro e valido.
     *
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }
    // </editor-fold>  
}