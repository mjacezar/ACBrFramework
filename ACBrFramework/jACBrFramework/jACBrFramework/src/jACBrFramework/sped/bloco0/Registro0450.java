package jACBrFramework.sped.bloco0;

/**
 * Tabela de informacao complementar do documento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:40:35, revisao: $Id$
 */
public class Registro0450 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Codigo da informacao complementar do documento fiscal. 
     */
    private String COD_INF;
    /**
     * Texto livre da informacao complementar existente no documento fiscal, 
     * inclusive especie de normas legais, poder normativo, numero, capitulacao, 
     * data e demais referencias pertinentes com indicacao referentes ao tributo.
     */
    private String TXT;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Codigo da informacao complementar do documento fiscal.
     * @return the COD_INF
     */
    public String getCOD_INF() {
        return COD_INF;
    }

    /**
     * Codigo da informacao complementar do documento fiscal.
     * @param COD_INF the COD_INF to set
     */
    public void setCOD_INF(String COD_INF) {
        this.COD_INF = COD_INF;
    }

    /**
     * Texto livre da informacao complementar existente no documento fiscal,
     * inclusive especie de normas legais, poder normativo, numero, capitulacao,
     * data e demais referencias pertinentes com indicacao referentes ao tributo.
     * @return the TXT
     */
    public String getTXT() {
        return TXT;
    }

    /**
     * Texto livre da informacao complementar existente no documento fiscal,
     * inclusive especie de normas legais, poder normativo, numero, capitulacao,
     * data e demais referencias pertinentes com indicacao referentes ao tributo.
     * @param TXT the TXT to set
     */
    public void setTXT(String TXT) {
        this.TXT = TXT;
    }
    // </editor-fold>
    
}