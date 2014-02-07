package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.SituacaoDocto;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Cupom Fiscal eletronico - SAT (CF-e-SAT) (codigo 59).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 10:52:04, revisao: $Id$
 */
public class RegistroC800 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro analitico do CF-e-SAT (codigo 59).
     */
    private Collection<RegistroC850> registroC850 = new ArrayList<RegistroC850>();    
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     */
    private SituacaoDocto COD_SIT;
    /**
     * Numero do Cupom Fiscal Eletronico.
     */
    private String NUM_CFE;
    /**
     * Data da emissao do Cupom Fiscal Eletronico.
     */
    private Date DT_DOC;
    /**
     * Valor total do Cupom Fiscal Eletronico.
     */
    private double VL_CFE;
    /**
     * Valor total do PIS.
     */
    private double VL_PIS;
    /**
     * Valor total da COFINS.
     */
    private double VL_COFINS;
    /**
     * CNPJ ou CPF do destinatario.
     */
    private String CNPJ_CPF;
    /**
     * Numero de Serie do equipamento SAT.
     */
    private String NR_SAT;
    /**
     * Chave do Cupom Fiscal Eletronico.
     */
    private String CHV_CFE;
    /**
     * Valor total de descontos.
     */
    private double VL_DESC;
    /**
     * Valor total das mercadorias e servicos.
     */
    private double VL_MERC;
    /**
     * Valor total de outras despesas acessorias e acrescimos.
     */
    private double VL_OUT_DA;
    /**
     * Valor do ICMS.
     */
    private double VL_ICMS;
    /**
     * Valor total do PIS retido por subst. trib..
     */
    private double VL_PIS_ST;
    /**
     * Valor total da COFINS retido por subst. trib..
     */
    private double VL_COFINS_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Registro analitico do CF-e-SAT (codigo 59).
     * @return the registroC850
     */
    public Collection<RegistroC850> getRegistroC850() {
        return registroC850;
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
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @return the COD_SIT
     */
    public SituacaoDocto getCOD_SIT() {
        return COD_SIT;
    }

    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     * @param COD_SIT the COD_SIT to set
     */
    public void setCOD_SIT(SituacaoDocto COD_SIT) {
        this.COD_SIT = COD_SIT;
    }

    /**
     * Numero do Cupom Fiscal Eletronico.
     * @return the NUM_CFE
     */
    public String getNUM_CFE() {
        return NUM_CFE;
    }

    /**
     * Numero do Cupom Fiscal Eletronico.
     * @param NUM_CFE the NUM_CFE to set
     */
    public void setNUM_CFE(String NUM_CFE) {
        this.NUM_CFE = NUM_CFE;
    }

    /**
     * Data da emissao do Cupom Fiscal Eletronico.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao do Cupom Fiscal Eletronico.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Valor total do Cupom Fiscal Eletronico.
     * @return the VL_CFE
     */
    public double getVL_CFE() {
        return VL_CFE;
    }

    /**
     * Valor total do Cupom Fiscal Eletronico.
     * @param VL_CFE the VL_CFE to set
     */
    public void setVL_CFE(double VL_CFE) {
        this.VL_CFE = VL_CFE;
    }

    /**
     * Valor total do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor total do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor total da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor total da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * CNPJ ou CPF do destinatario.
     * @return the CNPJ_CPF
     */
    public String getCNPJ_CPF() {
        return CNPJ_CPF;
    }

    /**
     * CNPJ ou CPF do destinatario.
     * @param CNPJ_CPF the CNPJ_CPF to set
     */
    public void setCNPJ_CPF(String CNPJ_CPF) {
        this.CNPJ_CPF = CNPJ_CPF;
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
     * Chave do Cupom Fiscal Eletronico.
     * @return the CHV_CFE
     */
    public String getCHV_CFE() {
        return CHV_CFE;
    }

    /**
     * Chave do Cupom Fiscal Eletronico.
     * @param CHV_CFE the CHV_CFE to set
     */
    public void setCHV_CFE(String CHV_CFE) {
        this.CHV_CFE = CHV_CFE;
    }

    /**
     * Valor total de descontos.
     * @return the VL_DESC
     */
    public double getVL_DESC() {
        return VL_DESC;
    }

    /**
     * Valor total de descontos.
     * @param VL_DESC the VL_DESC to set
     */
    public void setVL_DESC(double VL_DESC) {
        this.VL_DESC = VL_DESC;
    }

    /**
     * Valor total das mercadorias e servicos.
     * @return the VL_MERC
     */
    public double getVL_MERC() {
        return VL_MERC;
    }

    /**
     * Valor total das mercadorias e servicos.
     * @param VL_MERC the VL_MERC to set
     */
    public void setVL_MERC(double VL_MERC) {
        this.VL_MERC = VL_MERC;
    }

    /**
     * Valor total de outras despesas acessorias e acrescimos.
     * @return the VL_OUT_DA
     */
    public double getVL_OUT_DA() {
        return VL_OUT_DA;
    }

    /**
     * Valor total de outras despesas acessorias e acrescimos.
     * @param VL_OUT_DA the VL_OUT_DA to set
     */
    public void setVL_OUT_DA(double VL_OUT_DA) {
        this.VL_OUT_DA = VL_OUT_DA;
    }

    /**
     * Valor do ICMS.
     * @return the VL_ICMS
     */
    public double getVL_ICMS() {
        return VL_ICMS;
    }

    /**
     * Valor do ICMS.
     * @param VL_ICMS the VL_ICMS to set
     */
    public void setVL_ICMS(double VL_ICMS) {
        this.VL_ICMS = VL_ICMS;
    }

    /**
     * Valor total do PIS retido por subst. trib..
     * @return the VL_PIS_ST
     */
    public double getVL_PIS_ST() {
        return VL_PIS_ST;
    }

    /**
     * Valor total do PIS retido por subst. trib..
     * @param VL_PIS_ST the VL_PIS_ST to set
     */
    public void setVL_PIS_ST(double VL_PIS_ST) {
        this.VL_PIS_ST = VL_PIS_ST;
    }

    /**
     * Valor total da COFINS retido por subst. trib..
     * @return the VL_COFINS_ST
     */
    public double getVL_COFINS_ST() {
        return VL_COFINS_ST;
    }

    /**
     * Valor total da COFINS retido por subst. trib..
     * @param VL_COFINS_ST the VL_COFINS_ST to set
     */
    public void setVL_COFINS_ST(double VL_COFINS_ST) {
        this.VL_COFINS_ST = VL_COFINS_ST;
    }
    // </editor-fold>
    
}