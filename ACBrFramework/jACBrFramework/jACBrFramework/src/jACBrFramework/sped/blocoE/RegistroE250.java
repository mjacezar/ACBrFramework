package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.OrigemProcesso;
import java.util.Date;

/**
 * Obrigacoes do ICMS recolhido ou a Recolhor - Substituicao Tributaria.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:33:29, revisao: $Id$
 */
public class RegistroE250 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da obrigacao a recolher, conforme a Tabela 5.4.
     */
    private String COD_OR;
    /**
     * Valor da obrigacao ICMS ST a recolher.
     */
    private double VL_OR;
    /**
     * Data de vencimento da obrigacao.
     */
    private Date DT_VCTO;
    /**
     * Codigo de receita referente a obrigacao, proprio da unidade da federacao 
     * do contribuinte substituido.
     */
    private String COD_REC;
    /**
     * Numero do processo ou auto de infracao ao qual a obrigacao esta vinculada, se houver.
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
     * Descricao complementar das obrigacoes a recolher.
     */
    private String TXT_COMPL;
    /**
     * Informe o mes de referencia no formato "mmaaaa". Versao 103
     */
    private String MES_REF; 
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo da obrigacao a recolher, conforme a Tabela 5.4.
     * @return the COD_OR
     */
    public String getCOD_OR() {
        return COD_OR;
    }

    /**
     * Codigo da obrigacao a recolher, conforme a Tabela 5.4.
     * @param COD_OR the COD_OR to set
     */
    public void setCOD_OR(String COD_OR) {
        this.COD_OR = COD_OR;
    }

    /**
     * Valor da obrigacao ICMS ST a recolher.
     * @return the VL_OR
     */
    public double getVL_OR() {
        return VL_OR;
    }

    /**
     * Valor da obrigacao ICMS ST a recolher.
     * @param VL_OR the VL_OR to set
     */
    public void setVL_OR(double VL_OR) {
        this.VL_OR = VL_OR;
    }

    /**
     * Data de vencimento da obrigacao.
     * @return the DT_VCTO
     */
    public Date getDT_VCTO() {
        return DT_VCTO;
    }

    /**
     * Data de vencimento da obrigacao.
     * @param DT_VCTO the DT_VCTO to set
     */
    public void setDT_VCTO(Date DT_VCTO) {
        this.DT_VCTO = DT_VCTO;
    }

    /**
     * Codigo de receita referente a obrigacao, proprio da unidade da federacao
     * do contribuinte substituido.
     * @return the COD_REC
     */
    public String getCOD_REC() {
        return COD_REC;
    }

    /**
     * Codigo de receita referente a obrigacao, proprio da unidade da federacao
     * do contribuinte substituido.
     * @param COD_REC the COD_REC to set
     */
    public void setCOD_REC(String COD_REC) {
        this.COD_REC = COD_REC;
    }

    /**
     * Numero do processo ou auto de infracao ao qual a obrigacao esta vinculada, se houver.
     * @return the NUM_PROC
     */
    public String getNUM_PROC() {
        return NUM_PROC;
    }

    /**
     * Numero do processo ou auto de infracao ao qual a obrigacao esta vinculada, se houver.
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
     * Descricao complementar das obrigacoes a recolher.
     * @return the TXT_COMPL
     */
    public String getTXT_COMPL() {
        return TXT_COMPL;
    }

    /**
     * Descricao complementar das obrigacoes a recolher.
     * @param TXT_COMPL the TXT_COMPL to set
     */
    public void setTXT_COMPL(String TXT_COMPL) {
        this.TXT_COMPL = TXT_COMPL;
    }

    /**
     * Informe o mes de referencia no formato "mmaaaa". Versao 103
     * @return the MES_REF
     */
    public String getMES_REF() {
        return MES_REF;
    }

    /**
     * Informe o mes de referencia no formato "mmaaaa". Versao 103
     * @param MES_REF the MES_REF to set
     */
    public void setMES_REF(String MES_REF) {
        this.MES_REF = MES_REF;
    }
    // </editor-fold>    
    
}