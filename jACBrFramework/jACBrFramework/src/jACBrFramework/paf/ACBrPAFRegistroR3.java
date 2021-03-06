package jACBrFramework.paf;

/**
 * Detalhe da Reducao Z.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 17:59:09, revisao: $Id$
 */
public final class ACBrPAFRegistroR3 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">  
    /**
     * Codigo do totalizador.
     */
    private String codTotalizadorParcial;
    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     */
    private double valorAcumulado;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Codigo do totalizador.
     * @return the codTotalizadorParcial
     */
    public String getCodTotalizadorParcial() {
        return codTotalizadorParcial;
    }

    /**
     * Codigo do totalizador.
     * @param codTotalizadorParcial the codTotalizadorParcial to set
     */
    public void setCodTotalizadorParcial(String codTotalizadorParcial) {
        this.codTotalizadorParcial = codTotalizadorParcial;
    }

    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     * @return the valorAcumulado
     */
    public double getValorAcumulado() {
        return valorAcumulado;
    }

    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     * @param valorAcumulado the valorAcumulado to set
     */
    public void setValorAcumulado(double valorAcumulado) {
        this.valorAcumulado = valorAcumulado;
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