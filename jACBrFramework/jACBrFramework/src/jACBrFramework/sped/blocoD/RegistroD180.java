package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.Emitente;
import java.util.Date;

/**
 * Modais (codigo 26).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 15:02:10, revisao: $Id$
 */
public class RegistroD180 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero de ordem sequencial do modal.
     */
    private String NUM_SEQ;
    /**
     * Indicador do emitente do documento fiscal.
     */
    private Emitente IND_EMIT;
    /**
     * CNPJ ou CPF do participante emitente do modal.
     */
    private String CNPJ_EMIT;
    /**
     * Sigla da unidade da federacao do participante emitente do modal.
     */
    private String UF_EMIT;
    /**
     * Inscricao Estadual do participante emitente do modal.
     */
    private String IE_EMIT;
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * CNPJ/CPF do participante tomador do serviçc.
     */
    private String CNPJ_CPF_TOM;
    /**
     * Sigla da unidade da federacao do participante tomador do servico.
     */
    private String UF_TOM;
    /**
     * Inscricao Estadual do participante tomador do servico.
     */
    private String IE_TOM;
    /**
     * Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior).
     */
    private String COD_MUN_DEST;
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Subserie do documento fiscal.
     */
    private String SUB;
    /**
     * Numero do documento fiscal.
     */
    private String NUM_DOC;
    /**
     * Data da emissao do documento fiscal.
     */
    private Date DT_DOC;
    /**
     * Valor total do documento fiscal.
     */
    private double VL_DOC;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero de ordem sequencial do modal.
     * @return the NUM_SEQ
     */
    public String getNUM_SEQ() {
        return NUM_SEQ;
    }

    /**
     * Numero de ordem sequencial do modal.
     * @param NUM_SEQ the NUM_SEQ to set
     */
    public void setNUM_SEQ(String NUM_SEQ) {
        this.NUM_SEQ = NUM_SEQ;
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
     * CNPJ ou CPF do participante emitente do modal.
     * @return the CNPJ_EMIT
     */
    public String getCNPJ_EMIT() {
        return CNPJ_EMIT;
    }

    /**
     * CNPJ ou CPF do participante emitente do modal.
     * @param CNPJ_EMIT the CNPJ_EMIT to set
     */
    public void setCNPJ_EMIT(String CNPJ_EMIT) {
        this.CNPJ_EMIT = CNPJ_EMIT;
    }

    /**
     * Sigla da unidade da federacao do participante emitente do modal.
     * @return the UF_EMIT
     */
    public String getUF_EMIT() {
        return UF_EMIT;
    }

    /**
     * Sigla da unidade da federacao do participante emitente do modal.
     * @param UF_EMIT the UF_EMIT to set
     */
    public void setUF_EMIT(String UF_EMIT) {
        this.UF_EMIT = UF_EMIT;
    }

    /**
     * Inscricao Estadual do participante emitente do modal.
     * @return the IE_EMIT
     */
    public String getIE_EMIT() {
        return IE_EMIT;
    }

    /**
     * Inscricao Estadual do participante emitente do modal.
     * @param IE_EMIT the IE_EMIT to set
     */
    public void setIE_EMIT(String IE_EMIT) {
        this.IE_EMIT = IE_EMIT;
    }

    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     * @return the COD_MUN_ORIG
     */
    public String getCOD_MUN_ORIG() {
        return COD_MUN_ORIG;
    }

    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     * @param COD_MUN_ORIG the COD_MUN_ORIG to set
     */
    public void setCOD_MUN_ORIG(String COD_MUN_ORIG) {
        this.COD_MUN_ORIG = COD_MUN_ORIG;
    }

    /**
     * CNPJ/CPF do participante tomador do serviçc.
     * @return the CNPJ_CPF_TOM
     */
    public String getCNPJ_CPF_TOM() {
        return CNPJ_CPF_TOM;
    }

    /**
     * CNPJ/CPF do participante tomador do serviçc.
     * @param CNPJ_CPF_TOM the CNPJ_CPF_TOM to set
     */
    public void setCNPJ_CPF_TOM(String CNPJ_CPF_TOM) {
        this.CNPJ_CPF_TOM = CNPJ_CPF_TOM;
    }

    /**
     * Sigla da unidade da federacao do participante tomador do servico.
     * @return the UF_TOM
     */
    public String getUF_TOM() {
        return UF_TOM;
    }

    /**
     * Sigla da unidade da federacao do participante tomador do servico.
     * @param UF_TOM the UF_TOM to set
     */
    public void setUF_TOM(String UF_TOM) {
        this.UF_TOM = UF_TOM;
    }

    /**
     * Inscricao Estadual do participante tomador do servico.
     * @return the IE_TOM
     */
    public String getIE_TOM() {
        return IE_TOM;
    }

    /**
     * Inscricao Estadual do participante tomador do servico.
     * @param IE_TOM the IE_TOM to set
     */
    public void setIE_TOM(String IE_TOM) {
        this.IE_TOM = IE_TOM;
    }

    /**
     * Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior).
     * @return the COD_MUN_DEST
     */
    public String getCOD_MUN_DEST() {
        return COD_MUN_DEST;
    }

    /**
     * Codigo do municipio de destino, conforme a tabela IBGE(Preencher com 9999999, se Exterior).
     * @param COD_MUN_DEST the COD_MUN_DEST to set
     */
    public void setCOD_MUN_DEST(String COD_MUN_DEST) {
        this.COD_MUN_DEST = COD_MUN_DEST;
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
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do documento fiscal.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do documento fiscal.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Numero do documento fiscal.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero do documento fiscal.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
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

    /**
     * Valor total do documento fiscal.
     * @return the VL_DOC
     */
    public double getVL_DOC() {
        return VL_DOC;
    }

    /**
     * Valor total do documento fiscal.
     * @param VL_DOC the VL_DOC to set
     */
    public void setVL_DOC(double VL_DOC) {
        this.VL_DOC = VL_DOC;
    }
    // </editor-fold>    
    
}