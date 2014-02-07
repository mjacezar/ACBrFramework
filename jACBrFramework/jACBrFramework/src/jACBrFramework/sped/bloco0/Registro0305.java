package jACBrFramework.sped.bloco0;

/**
 * Informacoes sobre a utilizacao do bem.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:03:41, revisao: $Id$
 */
public class Registro0305 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Codigo do centro de custo onde o bem esta sendo ou sera utilizado (campo 03 do Registro 0600).
     */
    private String COD_CCUS;
    /**
     * Descricao sucinta da funcao do bem na atividade do estabelecimento.
     */
    private String FUNC;
    /**
     * Vida util estimada do bem, em numero de meses.
     */
    private int VIDA_UTIL;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">       
    /**
     * Codigo do centro de custo onde o bem esta sendo ou sera utilizado (campo 03 do Registro 0600).
     * @return the COD_CCUS
     */
    public String getCOD_CCUS() {
        return COD_CCUS;
    }

    /**
     * Codigo do centro de custo onde o bem esta sendo ou sera utilizado (campo 03 do Registro 0600).
     * @param COD_CCUS the COD_CCUS to set
     */
    public void setCOD_CCUS(String COD_CCUS) {
        this.COD_CCUS = COD_CCUS;
    }

    /**
     * Descricao sucinta da funcao do bem na atividade do estabelecimento.
     * @return the FUNC
     */
    public String getFUNC() {
        return FUNC;
    }

    /**
     * Descricao sucinta da funcao do bem na atividade do estabelecimento.
     * @param FUNC the FUNC to set
     */
    public void setFUNC(String FUNC) {
        this.FUNC = FUNC;
    }

    /**
     * Vida util estimada do bem, em numero de meses.
     * @return the VIDA_UTIL
     */
    public int getVIDA_UTIL() {
        return VIDA_UTIL;
    }

    /**
     * Vida util estimada do bem, em numero de meses.
     * @param VIDA_UTIL the VIDA_UTIL to set
     */
    public void setVIDA_UTIL(int VIDA_UTIL) {
        this.VIDA_UTIL = VIDA_UTIL;
    }
    // </editor-fold>
    
}