package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Observacoes do lancamento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 15:13:27, revisao: $Id$
 */
public class RegistroD195 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Outras obrigacoes tributarias, ajustes e informacoes de valores provenientes de documento fiscal.
     */
    private Collection<RegistroD197> registroD197 = new ArrayList<RegistroD197>();     
    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     */
    private String COD_OBS;
    /**
     * Descricao complementar do codigo de observacao.
     */
    private String TXT_COMPL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Outras obrigacoes tributarias, ajustes e informacoes de valores provenientes de documento fiscal.
     * @return the registroD197
     */
    public Collection<RegistroD197> getRegistroD197() {
        return registroD197;
    }

    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     * @return the COD_OBS
     */
    public String getCOD_OBS() {
        return COD_OBS;
    }

    /**
     * Codigo da observacao do lancamento fiscal (campo 02 do Registro 0460).
     * @param COD_OBS the COD_OBS to set
     */
    public void setCOD_OBS(String COD_OBS) {
        this.COD_OBS = COD_OBS;
    }

    /**
     * Descricao complementar do codigo de observacao.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricao complementar do codigo de observacao.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }
    // </editor-fold>    
    
}