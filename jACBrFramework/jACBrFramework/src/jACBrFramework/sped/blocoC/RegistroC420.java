package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Registro dos totalizadores parciais da reducao Z (cod 02, 2D e 60).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:10:20, revisao: $Id$
 */
public class RegistroC420 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Resumo de itens de movimento diario (codigo 02 e 2D). 
     */
    private Collection<RegistroC425> registroC425 = new ArrayList<RegistroC425>();     
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
    private int NR_TOT;
    /**
     * Descricao da situacao tributaria relativa ao totalizador parcial, quando 
     * houver mais de um com a mesma carga tributaria efetiva.
     */
    private String DESCR_NR_TOT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Resumo de itens de movimento diario (codigo 02 e 2D).
     * @return the registroC425
     */
    public Collection<RegistroC425> getRegistroC425() {
        return registroC425;
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
    public int getNR_TOT() {
        return NR_TOT;
    }

    /**
     * Numero do totalizador quando ocorrer mais de uma situacao com a mesma carga tributaria efetiva.
     * @param NR_TOT the NR_TOT to set
     */
    public void setNR_TOT(int NR_TOT) {
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