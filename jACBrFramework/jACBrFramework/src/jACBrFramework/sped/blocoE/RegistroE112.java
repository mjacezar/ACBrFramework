package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.OrigemProcesso;

/**
 * Informacoes adicionais dos ajutes da apuracao do ICMS.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:12:53, revisao: $Id$
 */
public class RegistroE112 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero do documento de arrecadacao estadual, se houver.
     */
    private String NUM_DA;
    /**
     * Numero do processo ao qual o ajuste esta vinculado, se houver.
     */
    private String NUM_PROC;
    /**
     * Indicador da origem do processo.
     */
    private OrigemProcesso IND_PROC;
    /**
     * Descricao resumida do processo que embasou o lançamento.
     */
    private String PROC;
    /**
     * Descricao complementar.
     */
    private String TXT_COMPL;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero do documento de arrecadacao estadual, se houver.
     * @return the NUM_DA
     */
    public String getNUM_DA() {
        return NUM_DA;
    }

    /**
     * Numero do documento de arrecadacao estadual, se houver.
     * @param NUM_DA the NUM_DA to set
     */
    public void setNUM_DA(String NUM_DA) {
        this.NUM_DA = NUM_DA;
    }

    /**
     * Numero do processo ao qual o ajuste esta vinculado, se houver.
     * @return the NUM_PROC
     */
    public String getNUM_PROC() {
        return NUM_PROC;
    }

    /**
     * Numero do processo ao qual o ajuste esta vinculado, se houver.
     * @param NUM_PROC the NUM_PROC to set
     */
    public void setNUM_PROC(String NUM_PROC) {
        this.NUM_PROC = NUM_PROC;
    }

    /**
     * Indicador da origem do processo.
     * @return the IND_PROC
     */
    public OrigemProcesso getIND_PROC() {
        return IND_PROC;
    }

    /**
     * Indicador da origem do processo.
     * @param IND_PROC the IND_PROC to set
     */
    public void setIND_PROC(OrigemProcesso IND_PROC) {
        this.IND_PROC = IND_PROC;
    }

    /**
     * Descricao resumida do processo que embasou o lançamento.
     * @return the PROC
     */
    public String getPROC() {
        return PROC;
    }

    /**
     * Descricao resumida do processo que embasou o lançamento.
     * @param PROC the PROC to set
     */
    public void setPROC(String PROC) {
        this.PROC = PROC;
    }

    /**
     * Descricao complementar.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricao complementar.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }
    // </editor-fold>    
    
}