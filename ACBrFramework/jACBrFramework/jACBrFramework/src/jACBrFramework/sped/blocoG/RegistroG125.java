package jACBrFramework.sped.blocoG;

import jACBrFramework.sped.MovimentoBens;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Movimentacao de bem ou componente do ativo imobilizado.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 14:54:02, revisao: $Id$
 */
public class RegistroG125 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Outros creditos CIAP.
     */
    private Collection<RegistroG126> registroG126 = new ArrayList<RegistroG126>();     
    /**
     * Identificacao do documento fiscal.
     */
    private Collection<RegistroG130> registroG130 = new ArrayList<RegistroG130>(); 
    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial 
     * do estabelecimento informante.
     */
    private String COD_IND_BEM;
    /**
     * Data da movimentacao ou do saldo inicial.
     */
    private Date DT_MOV;
    /**
     * Tipo de movimentacao do bem ou componente.
     */
    private MovimentoBens TIPO_MOV;
    /**
     * Valor do ICMS da Operacao Propria na entrada do bem ou componente.
     */
    private double VL_IMOB_ICMS_OP;
    /**
     * Valor do ICMS da Oper. por Sub. Tributaria na entrada do bem ou componente.
     */
    private double VL_IMOB_ICMS_ST;
    /**
     * Valor do ICMS sobre Frete do Conhecimento de Transporte na entrada do bem ou componente.
     */
    private double VL_IMOB_ICMS_FRT;
    /**
     * Valor do ICMS - Diferencial de Aliquota, conforme Doc. de Arrecadacao, na 
     * entrada do bem ou componente.
     */
    private double VL_IMOB_ICMS_DIF;
    /**
     * Numero da parcela do ICMS.
     */
    private int NUM_PARC;
    /**
     * Valor da parcela de ICMS passivel de apropriacao (antes da aplicacao da 
     * participacao percentual do valor das saidas tributadas/exportacao sobre 
     * as saidas totais).
     */
    private double VL_PARC_PASS;
    /**
     * Valor da parcela apropriada de ICMS (Modelo D). Ate a versao 102.
     */
    private double VL_PARC_APROP;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Outros creditos CIAP.
     * @return the registroG126
     */
    public Collection<RegistroG126> getRegistroG126() {
        return registroG126;
    }

    /**
     * Identificacao do documento fiscal.
     * @return the registroG130
     */
    public Collection<RegistroG130> getRegistroG130() {
        return registroG130;
    }

    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial
     * do estabelecimento informante.
     * @return the COD_IND_BEM
     */
    public String getCOD_IND_BEM() {
        return COD_IND_BEM;
    }

    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial
     * do estabelecimento informante.
     * @param COD_IND_BEM the COD_IND_BEM to set
     */
    public void setCOD_IND_BEM(String COD_IND_BEM) {
        this.COD_IND_BEM = COD_IND_BEM;
    }

    /**
     * Data da movimentacao ou do saldo inicial.
     * @return the DT_MOV
     */
    public Date getDT_MOV() {
        return DT_MOV;
    }

    /**
     * Data da movimentacao ou do saldo inicial.
     * @param DT_MOV the DT_MOV to set
     */
    public void setDT_MOV(Date DT_MOV) {
        this.DT_MOV = DT_MOV;
    }

    /**
     * Tipo de movimentacao do bem ou componente.
     * @return the TIPO_MOV
     */
    public MovimentoBens getTIPO_MOV() {
        return TIPO_MOV;
    }

    /**
     * Tipo de movimentacao do bem ou componente.
     * @param TIPO_MOV the TIPO_MOV to set
     */
    public void setTIPO_MOV(MovimentoBens TIPO_MOV) {
        this.TIPO_MOV = TIPO_MOV;
    }

    /**
     * Valor do ICMS da Operacao Propria na entrada do bem ou componente.
     * @return the VL_IMOB_ICMS_OP
     */
    public double getVL_IMOB_ICMS_OP() {
        return VL_IMOB_ICMS_OP;
    }

    /**
     * Valor do ICMS da Operacao Propria na entrada do bem ou componente.
     * @param VL_IMOB_ICMS_OP the VL_IMOB_ICMS_OP to set
     */
    public void setVL_IMOB_ICMS_OP(double VL_IMOB_ICMS_OP) {
        this.VL_IMOB_ICMS_OP = VL_IMOB_ICMS_OP;
    }

    /**
     * Valor do ICMS da Oper. por Sub. Tributaria na entrada do bem ou componente.
     * @return the VL_IMOB_ICMS_ST
     */
    public double getVL_IMOB_ICMS_ST() {
        return VL_IMOB_ICMS_ST;
    }

    /**
     * Valor do ICMS da Oper. por Sub. Tributaria na entrada do bem ou componente.
     * @param VL_IMOB_ICMS_ST the VL_IMOB_ICMS_ST to set
     */
    public void setVL_IMOB_ICMS_ST(double VL_IMOB_ICMS_ST) {
        this.VL_IMOB_ICMS_ST = VL_IMOB_ICMS_ST;
    }

    /**
     * Valor do ICMS sobre Frete do Conhecimento de Transporte na entrada do bem ou componente.
     * @return the VL_IMOB_ICMS_FRT
     */
    public double getVL_IMOB_ICMS_FRT() {
        return VL_IMOB_ICMS_FRT;
    }

    /**
     * Valor do ICMS sobre Frete do Conhecimento de Transporte na entrada do bem ou componente.
     * @param VL_IMOB_ICMS_FRT the VL_IMOB_ICMS_FRT to set
     */
    public void setVL_IMOB_ICMS_FRT(double VL_IMOB_ICMS_FRT) {
        this.VL_IMOB_ICMS_FRT = VL_IMOB_ICMS_FRT;
    }

    /**
     * Valor do ICMS - Diferencial de Aliquota, conforme Doc. de Arrecadacao, na
     * entrada do bem ou componente.
     * @return the VL_IMOB_ICMS_DIF
     */
    public double getVL_IMOB_ICMS_DIF() {
        return VL_IMOB_ICMS_DIF;
    }

    /**
     * Valor do ICMS - Diferencial de Aliquota, conforme Doc. de Arrecadacao, na
     * entrada do bem ou componente.
     * @param VL_IMOB_ICMS_DIF the VL_IMOB_ICMS_DIF to set
     */
    public void setVL_IMOB_ICMS_DIF(double VL_IMOB_ICMS_DIF) {
        this.VL_IMOB_ICMS_DIF = VL_IMOB_ICMS_DIF;
    }

    /**
     * Numero da parcela do ICMS.
     * @return the NUM_PARC
     */
    public int getNUM_PARC() {
        return NUM_PARC;
    }

    /**
     * Numero da parcela do ICMS.
     * @param NUM_PARC the NUM_PARC to set
     */
    public void setNUM_PARC(int NUM_PARC) {
        this.NUM_PARC = NUM_PARC;
    }

    /**
     * Valor da parcela de ICMS passivel de apropriacao (antes da aplicacao da
     * participacao percentual do valor das saidas tributadas/exportacao sobre
     * as saidas totais).
     * @return the VL_PARC_PASS
     */
    public double getVL_PARC_PASS() {
        return VL_PARC_PASS;
    }

    /**
     * Valor da parcela de ICMS passivel de apropriacao (antes da aplicacao da
     * participacao percentual do valor das saidas tributadas/exportacao sobre
     * as saidas totais).
     * @param VL_PARC_PASS the VL_PARC_PASS to set
     */
    public void setVL_PARC_PASS(double VL_PARC_PASS) {
        this.VL_PARC_PASS = VL_PARC_PASS;
    }

    /**
     * Valor da parcela apropriada de ICMS (Modelo D). Ate a versao 102.
     * @return the VL_PARC_APROP
     */
    public double getVL_PARC_APROP() {
        return VL_PARC_APROP;
    }

    /**
     * Valor da parcela apropriada de ICMS (Modelo D). Ate a versao 102.
     * @param VL_PARC_APROP the VL_PARC_APROP to set
     */
    public void setVL_PARC_APROP(double VL_PARC_APROP) {
        this.VL_PARC_APROP = VL_PARC_APROP;
    }
    // </editor-fold>    
    
}