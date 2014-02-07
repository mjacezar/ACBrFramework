package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Registro dos totalizadores parciais da reducao Z (codigos 2E, 13, 14, 15 e 16).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 16:32:31, revisao: $Id$
 */
public class RegistroD365 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Complemento dos documentos informados (codigo 13, 14, 15, 16 e 2E).
     */
    private Collection<RegistroD370> registroD370 = new ArrayList<RegistroD370>();
    /**
     * Codigo do totalizador, conforme Tabela 4.4.6.
     */
    private String COD_TOT_PAR;
    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     */
    private double VLR_ACUM_TOT;
    /**
     * Numero do totalizador quando ocorrer mais de uma situacao com a mesma carga tributaria efetiva.
     */
    private String NR_TOT;
    /**
     * Descricao da situacao tributaria relativa ao totalizador parcial, quando 
     * houver mais de um com a mesma carga tributaria efetiva.
     */
    private String DESCR_NR_TOT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Complemento dos documentos informados (codigo 13, 14, 15, 16 e 2E).
     * @return the registroD370
     */
    public Collection<RegistroD370> getRegistroD370() {
        return registroD370;
    }

    /**
     * Codigo do totalizador, conforme Tabela 4.4.6.
     * @return the COD_TOT_PAR
     */
    public String getCOD_TOT_PAR() {
        return COD_TOT_PAR;
    }

    /**
     * Codigo do totalizador, conforme Tabela 4.4.6.
     * @param COD_TOT_PAR the COD_TOT_PAR to set
     */
    public void setCOD_TOT_PAR(String COD_TOT_PAR) {
        this.COD_TOT_PAR = COD_TOT_PAR;
    }

    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     * @return the VLR_ACUM_TOT
     */
    public double getVLR_ACUM_TOT() {
        return VLR_ACUM_TOT;
    }

    /**
     * Valor acumulado no totalizador, relativo a respectiva Reducao Z.
     * @param VLR_ACUM_TOT the VLR_ACUM_TOT to set
     */
    public void setVLR_ACUM_TOT(double VLR_ACUM_TOT) {
        this.VLR_ACUM_TOT = VLR_ACUM_TOT;
    }

    /**
     * Numero do totalizador quando ocorrer mais de uma situacao com a mesma carga tributaria efetiva.
     * @return the NR_TOT
     */
    public String getNR_TOT() {
        return NR_TOT;
    }

    /**
     * Numero do totalizador quando ocorrer mais de uma situacao com a mesma carga tributaria efetiva.
     * @param NR_TOT the NR_TOT to set
     */
    public void setNR_TOT(String NR_TOT) {
        this.NR_TOT = NR_TOT;
    }

    /**
     * Descricao da situacao tributaria relativa ao totalizador parcial, quando
     * houver mais de um com a mesma carga tributaria efetiva.
     * @return the DESCR_NR_TOT
     */
    public String getDESCR_NR_TOT() {
        return DESCR_NR_TOT;
    }

    /**
     * Descricao da situacao tributaria relativa ao totalizador parcial, quando
     * houver mais de um com a mesma carga tributaria efetiva.
     * @param DESCR_NR_TOT the DESCR_NR_TOT to set
     */
    public void setDESCR_NR_TOT(String DESCR_NR_TOT) {
        this.DESCR_NR_TOT = DESCR_NR_TOT;
    }
    // </editor-fold>    
    
}