package jACBrFramework.sped.bloco0;

/**
 * Tabela de observacoes do lancamento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:43:37, revisao: $Id$
 */
public class Registro0460 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Codigo da Observacao do lancamento fiscal. 
     */
    private String COD_OBS;
    /**
     * Descricao da observacao vinculada ao lancamento  fiscal.
     */
    private String TXT;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Codigo da Observacao do lancamento fiscal.
     * @return the COD_OBS
     */
    public String getCOD_OBS() {
        return COD_OBS;
    }

    /**
     * Codigo da Observacao do lancamento fiscal.
     * @param COD_OBS the COD_OBS to set
     */
    public void setCOD_OBS(String COD_OBS) {
        this.COD_OBS = COD_OBS;
    }

    /**
     * Descricao da observacao vinculada ao lancamento  fiscal.
     * @return the TXT
     */
    public String getTXT() {
        return TXT;
    }

    /**
     * Descricao da observacao vinculada ao lancamento  fiscal.
     * @param TXT the TXT to set
     */
    public void setTXT(String TXT) {
        this.TXT = TXT;
    }
    // </editor-fold>

}