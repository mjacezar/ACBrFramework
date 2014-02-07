package jACBrFramework.sped.bloco0;

import jACBrFramework.sped.NaturezaConta;
import jACBrFramework.sped.TipoConta;
import java.util.Date;

/**
 * Plano de contas contabeis.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:46:18, revisao: $Id$
 */
public class Registro0500 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Data da inclusao/alteracao.
     */
    private Date DT_ALT;
    /**
     * Codigo da natureza da conta/grupo de contas.
     */
    private NaturezaConta COD_NAT_CC;
    /**
     * Indicador do tipo de conta.
     */
    private TipoConta IND_CTA;
    /**
     * Nivel da conta analitica/grupo de contas. 
     */
    private String NIVEL;
    /**
     * Codigo da conta analitica/grupo de contas. 
     */
    private String COD_CTA;
    /**
     * Nome da conta analitica/grupo de contas. 
     */
    private String NOME_CTA;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Data da inclusao/alteracao.
     * @return the DT_ALT
     */
    public Date getDT_ALT() {
        return DT_ALT;
    }

    /**
     * Data da inclusao/alteracao.
     * @param DT_ALT the DT_ALT to set
     */
    public void setDT_ALT(Date DT_ALT) {
        this.DT_ALT = DT_ALT;
    }

    /**
     * Codigo da natureza da conta/grupo de contas.
     * @return the COD_NAT_CC
     */
    public NaturezaConta getCOD_NAT_CC() {
        return COD_NAT_CC;
    }

    /**
     * Codigo da natureza da conta/grupo de contas.
     * @param COD_NAT_CC the COD_NAT_CC to set
     */
    public void setCOD_NAT_CC(NaturezaConta COD_NAT_CC) {
        this.COD_NAT_CC = COD_NAT_CC;
    }

    /**
     * Indicador do tipo de conta.
     * @return the IND_CTA
     */
    public TipoConta getIND_CTA() {
        return IND_CTA;
    }

    /**
     * Indicador do tipo de conta.
     * @param IND_CTA the IND_CTA to set
     */
    public void setIND_CTA(TipoConta IND_CTA) {
        this.IND_CTA = IND_CTA;
    }

    /**
     * Nivel da conta analitica/grupo de contas.
     * @return the NIVEL
     */
    public String getNIVEL() {
        return NIVEL;
    }

    /**
     * Nivel da conta analitica/grupo de contas.
     * @param NIVEL the NIVEL to set
     */
    public void setNIVEL(String NIVEL) {
        this.NIVEL = NIVEL;
    }

    /**
     * Codigo da conta analitica/grupo de contas.
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analitica/grupo de contas.
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }

    /**
     * Nome da conta analitica/grupo de contas.
     * @return the NOME_CTA
     */
    public String getNOME_CTA() {
        return NOME_CTA;
    }

    /**
     * Nome da conta analitica/grupo de contas.
     * @param NOME_CTA the NOME_CTA to set
     */
    public void setNOME_CTA(String NOME_CTA) {
        this.NOME_CTA = NOME_CTA;
    }
    // </editor-fold>

}