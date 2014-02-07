package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Observacoes do lancamento fiscal (codigo 01, 1B, 04 e 55).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 17:06:14, revisao: $Id$
 */
public class RegistroC195 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Outras obrigacoes tributarias, ajustes e informacoes de valores provenientes 
     * de documento fiscal.
     */
    private Collection<RegistroC197> registroC197 = new ArrayList<RegistroC197>();     
    /**
     * Codigo da observacao do lançamento fiscal (campo 02 do Registro 0460).
     */
    private String COD_OBS;
    /**
     * Descricaão complementar do codigo de observacao.
     */
    private String TXT_COMPL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Outras obrigacoes tributarias, ajustes e informacoes de valores provenientes
     * de documento fiscal.
     * @return the registroC197
     */
    public Collection<RegistroC197> getRegistroC197() {
        return registroC197;
    }

    /**
     * Codigo da observacao do lançamento fiscal (campo 02 do Registro 0460).
     * @return the COD_OBS
     */
    public String getCOD_OBS() {
        return COD_OBS;
    }

    /**
     * Codigo da observacao do lançamento fiscal (campo 02 do Registro 0460).
     * @param COD_OBS the COD_OBS to set
     */
    public void setCOD_OBS(String COD_OBS) {
        this.COD_OBS = COD_OBS;
    }

    /**
     * Descricaão complementar do codigo de observacao.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricaão complementar do codigo de observacao.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }
    // </editor-fold>
    
}