package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Carga transportada (codigo 08, 8B, 09, 10, 11, 26 e 27).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:40:18, revisao: $Id$
 */
public class RegistroD160 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Local da coleta e entrega (codigo 08, 8B, 09, 10, 11, 26 e 27).
     */
    private Collection<RegistroD161> registroD161 = new ArrayList<RegistroD161>(); 
    /**
     * Identificacao dos documentos fiscais (codigo 08, 8B, 09, 10, 11, 26 e 27).
     */
    private Collection<RegistroD162> registroD162 = new ArrayList<RegistroD162>();     
    /**
     * Identificacao do numero do despacho.
     */
    private String DESPACHO;
    /**
     * CNPJ ou CPF do remetente das mercadorias que constam na nota fiscal.
     */
    private String CNPJ_CPF_REM;
    /**
     * Inscricao Estadual do remetente das mercadorias que constam na nota fiscal.
     */
    private String IE_REM;
    /**
     * Codigo do Municipio de origem, conforme tabela IBGE.
     */
    private String COD_MUN_ORI;
    /**
     * CNPJ ou CPF do destinatario das mercadorias que constam na nota fiscal.
     */
    private String CNPJ_CPF_DEST;
    /**
     * Inscricao Estadual do destinatario das mercadorias que constam na nota fiscal.
     */
    private String IE_DEST;
    /**
     * Codigo do Municipio de destino, conforme tabela IBGE.
     */
    private String COD_MUN_DEST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Local da coleta e entrega (codigo 08, 8B, 09, 10, 11, 26 e 27).
     * @return the registroD161
     */
    public Collection<RegistroD161> getRegistroD161() {
        return registroD161;
    }

    /**
     * Identificacao dos documentos fiscais (codigo 08, 8B, 09, 10, 11, 26 e 27).
     * @return the registroD162
     */
    public Collection<RegistroD162> getRegistroD162() {
        return registroD162;
    }

    /**
     * Identificacao do numero do despacho.
     * @return the DESPACHO
     */
    public String getDESPACHO() {
        return DESPACHO;
    }

    /**
     * Identificacao do numero do despacho.
     * @param DESPACHO the DESPACHO to set
     */
    public void setDESPACHO(String DESPACHO) {
        this.DESPACHO = DESPACHO;
    }

    /**
     * CNPJ ou CPF do remetente das mercadorias que constam na nota fiscal.
     * @return the CNPJ_CPF_REM
     */
    public String getCNPJ_CPF_REM() {
        return CNPJ_CPF_REM;
    }

    /**
     * CNPJ ou CPF do remetente das mercadorias que constam na nota fiscal.
     * @param CNPJ_CPF_REM the CNPJ_CPF_REM to set
     */
    public void setCNPJ_CPF_REM(String CNPJ_CPF_REM) {
        this.CNPJ_CPF_REM = CNPJ_CPF_REM;
    }

    /**
     * Inscricao Estadual do remetente das mercadorias que constam na nota fiscal.
     * @return the IE_REM
     */
    public String getIE_REM() {
        return IE_REM;
    }

    /**
     * Inscricao Estadual do remetente das mercadorias que constam na nota fiscal.
     * @param IE_REM the IE_REM to set
     */
    public void setIE_REM(String IE_REM) {
        this.IE_REM = IE_REM;
    }

    /**
     * Codigo do Municipio de origem, conforme tabela IBGE.
     * @return the COD_MUN_ORI
     */
    public String getCOD_MUN_ORI() {
        return COD_MUN_ORI;
    }

    /**
     * Codigo do Municipio de origem, conforme tabela IBGE.
     * @param COD_MUN_ORI the COD_MUN_ORI to set
     */
    public void setCOD_MUN_ORI(String COD_MUN_ORI) {
        this.COD_MUN_ORI = COD_MUN_ORI;
    }

    /**
     * CNPJ ou CPF do destinatario das mercadorias que constam na nota fiscal.
     * @return the CNPJ_CPF_DEST
     */
    public String getCNPJ_CPF_DEST() {
        return CNPJ_CPF_DEST;
    }

    /**
     * CNPJ ou CPF do destinatario das mercadorias que constam na nota fiscal.
     * @param CNPJ_CPF_DEST the CNPJ_CPF_DEST to set
     */
    public void setCNPJ_CPF_DEST(String CNPJ_CPF_DEST) {
        this.CNPJ_CPF_DEST = CNPJ_CPF_DEST;
    }

    /**
     * Inscricao Estadual do destinatario das mercadorias que constam na nota fiscal.
     * @return the IE_DEST
     */
    public String getIE_DEST() {
        return IE_DEST;
    }

    /**
     * Inscricao Estadual do destinatario das mercadorias que constam na nota fiscal.
     * @param IE_DEST the IE_DEST to set
     */
    public void setIE_DEST(String IE_DEST) {
        this.IE_DEST = IE_DEST;
    }

    /**
     * Codigo do Municipio de destino, conforme tabela IBGE.
     * @return the COD_MUN_DEST
     */
    public String getCOD_MUN_DEST() {
        return COD_MUN_DEST;
    }

    /**
     * Codigo do Municipio de destino, conforme tabela IBGE.
     * @param COD_MUN_DEST the COD_MUN_DEST to set
     */
    public void setCOD_MUN_DEST(String COD_MUN_DEST) {
        this.COD_MUN_DEST = COD_MUN_DEST;
    }
    // </editor-fold>    
    
}