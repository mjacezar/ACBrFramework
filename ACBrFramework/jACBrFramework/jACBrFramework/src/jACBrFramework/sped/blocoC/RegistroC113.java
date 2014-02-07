package jACBrFramework.sped.blocoC;

import jACBrFramework.sintegra.TipoOperacao;
import jACBrFramework.sped.Emitente;
import java.util.Date;

/**
 * Documento fiscal referenciado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:56:55, revisao: $Id$
 */
public class RegistroC113 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de operacao.
     */
    private TipoOperacao IND_OPER;
    /**
     * Indicador do IND_EMIT do titulo.
     */
    private Emitente IND_EMIT;
    /**
     * Codigo do participante emitente (campo 02 do Registro 0150) do documento referenciado. 
     */
    private String COD_PART;
    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
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
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de operacao.
     * @return the IND_OPER
     */
    public TipoOperacao getIND_OPER() {
        return IND_OPER;
    }

    /**
     * Indicador do tipo de operacao.
     * @param IND_OPER the IND_OPER to set
     */
    public void setIND_OPER(TipoOperacao IND_OPER) {
        this.IND_OPER = IND_OPER;
    }

    /**
     * Indicador do IND_EMIT do titulo.
     * @return the IND_EMIT
     */
    public Emitente getIND_EMIT() {
        return IND_EMIT;
    }

    /**
     * Indicador do IND_EMIT do titulo.
     * @param IND_EMIT the IND_EMIT to set
     */
    public void setIND_EMIT(Emitente IND_EMIT) {
        this.IND_EMIT = IND_EMIT;
    }

    /**
     * Codigo do participante emitente (campo 02 do Registro 0150) do documento referenciado.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo do participante emitente (campo 02 do Registro 0150) do documento referenciado.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do documento fiscal, conforme a Tabela 4.1.1.
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
    // </editor-fold>
    
}