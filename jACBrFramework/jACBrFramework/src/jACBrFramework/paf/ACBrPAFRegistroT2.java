package jACBrFramework.paf;

import java.util.Date;

/**
 * Movimento Diario - Transporte de Passageiros.
 * 
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 08:56:55, revisao: $Id$
 */
public final class ACBrPAFRegistroT2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Data a que se refere o movimento informado.
     */
    private Date dataMovimento;
    /**
     * Tipo do documento a que se refere o movimento informado, conforme item 7.2.1.3.
     */
    private String tipoDocumento;
    /**
     * Serie do bilhete de passagem, no caso deste tipo de documento.
     */
    private String serie;
    /**
     * No. do primeiro bilhete de passagem emitido no dia informado no campo 03, 
     * no caso deste tipo de documento.
     */
    private int numeroBilheteInicial;
    /**
     * No. do ultimo bilhete de passagem emitido no dia informado no campo 03,
     * no caso deste tipo de documento.
     */
    private int numeroBilheteFinal;
    /**
     * Numero de fabricacao do ECF, no caso de documento emitido por este equipamento.
     */
    private String numEcf;
    /**
     * No. do Contador de Reducao Z relativo ao documento Reducao Z emitido pelo 
     * ECF informado no campo 08 no dia informado no campo 03.
     */
    private int crz;
    /**
     * CFOP relativo ao movimento informado.
     */
    private String cfop;
    /**
     * Valor contabil do movimento informado.
     */
    private double valorContabil;
    /**
     * Base de Calculo relativa ao movimento informado.
     */
    private double valorBaseCalculo;
    /**
     * Aliquota do ICMS incidente sobre o movimento informado.
     */
    private double aliquota;
    /**
     * Valor do ICMS incidente sobre o movimento informado.
     */
    private double valorImposto;
    /**
     * Valor das prestacoes isentas do ICMS relativas ao movimento informado.
     */
    private double valorIsentas;
    /**
     * Valor de outras situacoes tributarias relativas ao movimento informado.
     */
    private double valorOutras;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Data a que se refere o movimento informado.
     * @return the dataMovimento
     */
    public Date getDataMovimento() {
        return dataMovimento;
    }

    /**
     * Data a que se refere o movimento informado.
     * @param dataMovimento the dataMovimento to set
     */
    public void setDataMovimento(Date dataMovimento) {
        this.dataMovimento = dataMovimento;
    }

    /**
     * Tipo do documento a que se refere o movimento informado, conforme item 7.2.1.3.
     * @return the tipoDocumento
     */
    public String getTipoDocumento() {
        return tipoDocumento;
    }

    /**
     * Tipo do documento a que se refere o movimento informado, conforme item 7.2.1.3.
     * @param tipoDocumento the tipoDocumento to set
     */
    public void setTipoDocumento(String tipoDocumento) {
        this.tipoDocumento = tipoDocumento;
    }

    /**
     * Serie do bilhete de passagem, no caso deste tipo de documento.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie do bilhete de passagem, no caso deste tipo de documento.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * No. do primeiro bilhete de passagem emitido no dia informado no campo 03,
     * no caso deste tipo de documento.
     * @return the numeroBilheteInicial
     */
    public int getNumeroBilheteInicial() {
        return numeroBilheteInicial;
    }

    /**
     * No. do primeiro bilhete de passagem emitido no dia informado no campo 03,
     * no caso deste tipo de documento.
     * @param numeroBilheteInicial the numeroBilheteInicial to set
     */
    public void setNumeroBilheteInicial(int numeroBilheteInicial) {
        this.numeroBilheteInicial = numeroBilheteInicial;
    }

    /**
     * No. do ultimo bilhete de passagem emitido no dia informado no campo 03,
     * no caso deste tipo de documento.
     * @return the numeroBilheteFinal
     */
    public int getNumeroBilheteFinal() {
        return numeroBilheteFinal;
    }

    /**
     * No. do ultimo bilhete de passagem emitido no dia informado no campo 03,
     * no caso deste tipo de documento.
     * @param numeroBilheteFinal the numeroBilheteFinal to set
     */
    public void setNumeroBilheteFinal(int numeroBilheteFinal) {
        this.numeroBilheteFinal = numeroBilheteFinal;
    }

    /**
     * Numero de fabricacao do ECF, no caso de documento emitido por este equipamento.
     * @return the numEcf
     */
    public String getNumEcf() {
        return numEcf;
    }

    /**
     * Numero de fabricacao do ECF, no caso de documento emitido por este equipamento.
     * @param numEcf the numEcf to set
     */
    public void setNumEcf(String numEcf) {
        this.numEcf = numEcf;
    }

    /**
     * No. do Contador de Reducao Z relativo ao documento Reducao Z emitido pelo
     * ECF informado no campo 08 no dia informado no campo 03.
     * @return the crz
     */
    public int getCrz() {
        return crz;
    }

    /**
     * No. do Contador de Reducao Z relativo ao documento Reducao Z emitido pelo
     * ECF informado no campo 08 no dia informado no campo 03.
     * @param crz the crz to set
     */
    public void setCrz(int crz) {
        this.crz = crz;
    }

    /**
     * CFOP relativo ao movimento informado.
     * @return the cfop
     */
    public String getCfop() {
        return cfop;
    }

    /**
     * CFOP relativo ao movimento informado.
     * @param cfop the cfop to set
     */
    public void setCfop(String cfop) {
        this.cfop = cfop;
    }

    /**
     * Valor contabil do movimento informado.
     * @return the valorContabil
     */
    public double getValorContabil() {
        return valorContabil;
    }

    /**
     * Valor contabil do movimento informado.
     * @param valorContabil the valorContabil to set
     */
    public void setValorContabil(double valorContabil) {
        this.valorContabil = valorContabil;
    }

    /**
     * Base de Calculo relativa ao movimento informado.
     * @return the valorBaseCalculo
     */
    public double getValorBaseCalculo() {
        return valorBaseCalculo;
    }

    /**
     * Base de Calculo relativa ao movimento informado.
     * @param valorBaseCalculo the valorBaseCalculo to set
     */
    public void setValorBaseCalculo(double valorBaseCalculo) {
        this.valorBaseCalculo = valorBaseCalculo;
    }

    /**
     * Aliquota do ICMS incidente sobre o movimento informado.
     * @return the aliquota
     */
    public double getAliquota() {
        return aliquota;
    }

    /**
     * Aliquota do ICMS incidente sobre o movimento informado.
     * @param aliquota the aliquota to set
     */
    public void setAliquota(double aliquota) {
        this.aliquota = aliquota;
    }

    /**
     * Valor do ICMS incidente sobre o movimento informado.
     * @return the valorImposto
     */
    public double getValorImposto() {
        return valorImposto;
    }

    /**
     * Valor do ICMS incidente sobre o movimento informado.
     * @param valorImposto the valorImposto to set
     */
    public void setValorImposto(double valorImposto) {
        this.valorImposto = valorImposto;
    }

    /**
     * Valor das prestacoes isentas do ICMS relativas ao movimento informado.
     * @return the valorIsentas
     */
    public double getValorIsentas() {
        return valorIsentas;
    }

    /**
     * Valor das prestacoes isentas do ICMS relativas ao movimento informado.
     * @param valorIsentas the valorIsentas to set
     */
    public void setValorIsentas(double valorIsentas) {
        this.valorIsentas = valorIsentas;
    }

    /**
     * Valor de outras situacoes tributarias relativas ao movimento informado.
     * @return the valorOutras
     */
    public double getValorOutras() {
        return valorOutras;
    }

    /**
     * Valor de outras situacoes tributarias relativas ao movimento informado.
     * @param valorOutras the valorOutras to set
     */
    public void setValorOutras(double valorOutras) {
        this.valorOutras = valorOutras;
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