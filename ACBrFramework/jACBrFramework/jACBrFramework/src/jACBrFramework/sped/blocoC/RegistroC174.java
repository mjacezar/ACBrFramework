package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.TipoArmaFogo;

/**
 * Operacoes com armas de fogo (codigo 01)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:30:26, revisao: $Id$
 */
public class RegistroC174 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo da arma de fogo.
     */
    private TipoArmaFogo IND_ARM;
    /**
     * Numeracao de serie de fabricacao da arma.
     */
    private String NUM_ARM;
    /**
     * Descricao da arma, compreendendo: numero do cano, calibre, marca, capacidade 
     * de cartuchos, tipo de funcionamento, quantidade de canos, comprimento, 
     * tipo de alma, quantidade e sentido das raias e demais elementos que permitam 
     * sua perfeita identificacao.
     */
    private String DESCR_COMPL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Tipo da arma de fogo.
     * @return the IND_ARM
     */
    public TipoArmaFogo getIND_ARM() {
        return IND_ARM;
    }

    /**
     * Tipo da arma de fogo.
     * @param IND_ARM the IND_ARM to set
     */
    public void setIND_ARM(TipoArmaFogo IND_ARM) {
        this.IND_ARM = IND_ARM;
    }

    /**
     * Numeracao de serie de fabricacao da arma.
     * @return the NUM_ARM
     */
    public String getNUM_ARM() {
        return NUM_ARM;
    }

    /**
     * Numeracao de serie de fabricacao da arma.
     * @param NUM_ARM the NUM_ARM to set
     */
    public void setNUM_ARM(String NUM_ARM) {
        this.NUM_ARM = NUM_ARM;
    }

    /**
     * Descricao da arma, compreendendo: numero do cano, calibre, marca, capacidade
     * de cartuchos, tipo de funcionamento, quantidade de canos, comprimento,
     * tipo de alma, quantidade e sentido das raias e demais elementos que permitam
     * sua perfeita identificacao.
     * @return the DESCR_COMPL
     */
    public String getDESCR_COMPL() {
        return DESCR_COMPL;
    }

    /**
     * Descricao da arma, compreendendo: numero do cano, calibre, marca, capacidade
     * de cartuchos, tipo de funcionamento, quantidade de canos, comprimento,
     * tipo de alma, quantidade e sentido das raias e demais elementos que permitam
     * sua perfeita identificacao.
     * @param DESCR_COMPL the DESCR_COMPL to set
     */
    public void setDESCR_COMPL(String DESCR_COMPL) {
        this.DESCR_COMPL = DESCR_COMPL;
    }
    // </editor-fold>

}