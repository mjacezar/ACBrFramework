package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Informacao complementar da nota fiscal (codigo 01, 1B, 04 e 55)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:38:54, revisao: $Id$
 */
public class RegistroC110 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registros do arquivo.
     */
    private Collection<RegistroC111> registroC111 = new ArrayList<RegistroC111>();     
    /**
     * Documento de arrecadacao diferenciado.
     */
    private Collection<RegistroC112> registroC112 = new ArrayList<RegistroC112>();     
    /**
     * Documento fiscal referenciado.
     */
    private Collection<RegistroC113> registroC113 = new ArrayList<RegistroC113>();     
    /**
     * Cupom fiscal referenciado.
     */
    private Collection<RegistroC114> registroC114 = new ArrayList<RegistroC114>();     
    /**
     * Local de coleta e/ou entrega (codigos 01, 1B e 04)
     */
    private Collection<RegistroC115> registroC115 = new ArrayList<RegistroC115>();     
    /**
     * Cupom Fiscal Eletronico Referenciado.
     */
    private Collection<RegistroC116> registroC116 = new ArrayList<RegistroC116>();   
    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     */
    private String COD_INF;
    /**
     * Descricao complementar do codigo de referencia.
     */
    private String TXT_COMPL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Registros do arquivo.
     * @return the registroC111
     */
    public Collection<RegistroC111> getRegistroC111() {
        return registroC111;
    }

    /**
     * Documento de arrecadacao diferenciado.
     * @return the registroC112
     */
    public Collection<RegistroC112> getRegistroC112() {
        return registroC112;
    }

    /**
     * Documento fiscal referenciado.
     * @return the registroC113
     */
    public Collection<RegistroC113> getRegistroC113() {
        return registroC113;
    }

    /**
     * Cupom fiscal referenciado.
     * @return the registroC114
     */
    public Collection<RegistroC114> getRegistroC114() {
        return registroC114;
    }

    /**
     * Local de coleta e/ou entrega (codigos 01, 1B e 04)
     * @return the registroC115
     */
    public Collection<RegistroC115> getRegistroC115() {
        return registroC115;
    }

    /**
     * Cupom Fiscal Eletronico Referenciado.
     * @return the registroC116
     */
    public Collection<RegistroC116> getRegistroC116() {
        return registroC116;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @return the COD_INF
     */
    public String getCOD_INF() {
        return COD_INF;
    }

    /**
     * Codigo da informacao complementar do documento fiscal (campo 02 do Registro 0450).
     * @param COD_INF the COD_INF to set
     */
    public void setCOD_INF(String COD_INF) {
        this.COD_INF = COD_INF;
    }

    /**
     * Descricao complementar do codigo de referencia.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricao complementar do codigo de referencia.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }
    // </editor-fold>

}