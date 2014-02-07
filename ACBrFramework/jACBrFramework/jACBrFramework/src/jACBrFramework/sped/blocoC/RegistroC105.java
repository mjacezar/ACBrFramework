package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.TipoOperacaoST;

/**
 * Operacoes com ICMS ST recolhido para UF diversa do destinatario do documento fiscal (Codigo 55).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:32:40, revisao: $Id$
 */
public class RegistroC105 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de operacao.
     */
    private TipoOperacaoST OPER;
    /**
     * Sigla da UF de destino do ICMS_ST.
     */
    private String UF;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de operacao.
     * @return the OPER
     */
    public TipoOperacaoST getOPER() {
        return OPER;
    }

    /**
     * Indicador do tipo de operacao.
     * @param OPER the OPER to set
     */
    public void setOPER(TipoOperacaoST OPER) {
        this.OPER = OPER;
    }

    /**
     * Sigla da UF de destino do ICMS_ST.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da UF de destino do ICMS_ST.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
    }
    // </editor-fold>
    
}