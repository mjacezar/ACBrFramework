package jACBrFramework.sped.blocoG;

import jACBrFramework.sped.Emitente;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Identificacao do documento fiscal.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:54:11, revisao: $Id$
 */
public class RegistroG130 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Identificacao do Item do Documento Fiscal.
     */
    private Collection<RegistroG140> registroG140 = new ArrayList<RegistroG140>();    
    /**
     * Indicador do emitente do documento fiscal.
     */
    private Emitente IND_EMIT;
    /**
     * Codigo do participante.
     */
    private String COD_PART;
    /**
     * Codigo do modelo de documento fiscal, conforme tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SERIE;
    /**
     * Numero de documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Chave do documento fiscal eletronico.
     */
    private String CHV_NFE_CTE;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;   
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Identificacao do Item do Documento Fiscal.
     * @return the registroG140
     */
    public Collection<RegistroG140> getRegistroG140() {
        return registroG140;
    }

    /**
     * Indicador do emitente do documento fiscal.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do emitente do documento fiscal.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do modelo de documento fiscal, conforme tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo de documento fiscal, conforme tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie do documento fiscal.
     * @return the SERIE
     */
    public String getSERIE() {
        return SERIE;
    }

    /**
     * Serie do documento fiscal.
     * @param SERIE the SERIE to set
     */
    public void setSERIE(String SERIE) {
        this.SERIE = SERIE;
    }

    /**
     * Numero de documento fiscal.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero de documento fiscal.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Chave do documento fiscal eletronico.
     * @return the CHV_NFE_CTE
     */
    public String getCHV_NFE_CTE() {
        return CHV_NFE_CTE;
    }

    /**
     * Chave do documento fiscal eletronico.
     * @param CHV_NFE_CTE the CHV_NFE_CTE to set
     */
    public void setCHV_NFE_CTE(String CHV_NFE_CTE) {
        this.CHV_NFE_CTE = CHV_NFE_CTE;
    }

    /**
     * Data da emissao do documento fiscal.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do documento fiscal.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }
    // </editor-fold>    
    
}