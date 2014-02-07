package jACBrFramework.sped.blocoC;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Identificacao do equipamento SAT-CF-e.
 *  
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 11:46:32, revisao: $Id$
 */
public class RegistroC860 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Resumo diario do CF-e-SAT (codigo 59) por equipamento SAT-CF-e.
     */
    private Collection<RegistroC890> registroC890 = new ArrayList<RegistroC890>();    
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Numero de Serie do equipamento SAT.
     */
    private String NR_SAT;
    /**
     * Data de emissao dos documentos fiscais.
     */
    private Date DT_DOC;
    /**
     * Numero do documento inicial.
     */
    private String DOC_INI;
    /**
     * Numero do documento final.
     */
    private String DOC_FIN;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Resumo diario do CF-e-SAT (codigo 59) por equipamento SAT-CF-e.
     * @return the registroC890
     */
    public Collection<RegistroC890> getRegistroC890() {
        return registroC890;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Numero de Serie do equipamento SAT.
     * @return the NR_SAT
     */
    public String getNR_SAT() {
        return NR_SAT;
    }

    /**
     * Numero de Serie do equipamento SAT.
     * @param NR_SAT the NR_SAT to set
     */
    public void setNR_SAT(String NR_SAT) {
        this.NR_SAT = NR_SAT;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Numero do documento inicial.
     * @return the DOC_INI
     */
    public String getDOC_INI() {
        return DOC_INI;
    }

    /**
     * Numero do documento inicial.
     * @param DOC_INI the DOC_INI to set
     */
    public void setDOC_INI(String DOC_INI) {
        this.DOC_INI = DOC_INI;
    }

    /**
     * Numero do documento final.
     * @return the DOC_FIN
     */
    public String getDOC_FIN() {
        return DOC_FIN;
    }

    /**
     * Numero do documento final.
     * @param DOC_FIN the DOC_FIN to set
     */
    public void setDOC_FIN(String DOC_FIN) {
        this.DOC_FIN = DOC_FIN;
    }
    // </editor-fold>    
    
}