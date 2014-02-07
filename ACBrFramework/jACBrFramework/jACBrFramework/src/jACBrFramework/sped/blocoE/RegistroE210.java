package jACBrFramework.sped.blocoE;

import jACBrFramework.sped.MovimentoST;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Apuracao do ICMS - Substituicao Tributaria.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 13:21:48, revisao: $Id$
 */
public class RegistroE210 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Ajuste/Beneficio/Incentivo da apuracao do ICMS Substituicao Tributaria.
     */
    private Collection<RegistroE220> registroE220 = new ArrayList<RegistroE220>(); 
    /**
     * Obrigacoes do ICMS recolhido ou a Recolhor - Substituicao Tributaria.
     */
    private Collection<RegistroE250> registroE250 = new ArrayList<RegistroE250>();     
    /**
     * Indicador de movimento.
     */
    private MovimentoST IND_MOV_ST;
    /**
     * Valor do "Saldo credor de periodo anterior - Substituicao Tributaria".
     */
    private double VL_SLD_CRED_ANT_ST;
    /**
     * Valor total do ICMS ST de devolucao de mercadorias.
     */
    private double VL_DEVOL_ST;
    /**
     * Valor total do ICMS ST de ressarcimentos.
     */
    private double VL_RESSARC_ST;
    /**
     * Valor total de Ajustes "Outros creditos ST" e "Estorno de debitos ST".
     */
    private double VL_OUT_CRED_ST;
    /**
     * Valor total dos ajustes a credito de ICMS ST, provenientes de ajustes do documento fiscal.
     */
    private double VL_AJ_CREDITOS_ST;
    /**
     * Valor Total do ICMS retido por Substituicao Tributaria.
     */
    private double VL_RETENCAO_ST;
    /**
     * Valor Total dos ajustes "Outros debitos ST" e "Estorno de creditos ST".
     */
    private double VL_OUT_DEB_ST;
    /**
     * Valor total dos ajustes a debito de ICMS ST, provenientes de ajustes do documento fiscal.
     */
    private double VL_AJ_DEBITOS_ST;
    /**
     * Valor total de Saldo devedor antes das deducoes.
     */
    private double VL_SLD_DEV_ANT_ST;
    /**
     * Valor total dos ajustes "Deducoes ST".
     */
    private double VL_DEDUCOES_ST;
    /**
     * Imposto a recolher ST (11-12).
     */
    private double VL_ICMS_RECOL_ST;
    /**
     * Saldo credor de ST a transportar para o periodo seguinte [(03+04+05+06+07)- (08+09+10)].
     */
    private double VL_SLD_CRED_ST_TRANSPORTAR;
    /**
     *  Valores recolhidos ou a recolher, extra-apuracao.
     */
    private double DEB_ESP_ST;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Ajuste/Beneficio/Incentivo da apuracao do ICMS Substituicao Tributaria.
     * @return the registroE220
     */
    public Collection<RegistroE220> getRegistroE220() {
        return registroE220;
    }

    /**
     * Obrigacoes do ICMS recolhido ou a Recolhor - Substituicao Tributaria.
     * @return the registroE250
     */
    public Collection<RegistroE250> getRegistroE250() {
        return registroE250;
    }

    /**
     * Indicador de movimento.
     * @return the IND_MOV_ST
     */
    public MovimentoST getIND_MOV_ST() {
        return IND_MOV_ST;
    }

    /**
     * Indicador de movimento.
     * @param IND_MOV_ST the IND_MOV_ST to set
     */
    public void setIND_MOV_ST(MovimentoST IND_MOV_ST) {
        this.IND_MOV_ST = IND_MOV_ST;
    }

    /**
     * Valor do "Saldo credor de periodo anterior - Substituicao Tributaria".
     * @return the VL_SLD_CRED_ANT_ST
     */
    public double getVL_SLD_CRED_ANT_ST() {
        return VL_SLD_CRED_ANT_ST;
    }

    /**
     * Valor do "Saldo credor de periodo anterior - Substituicao Tributaria".
     * @param VL_SLD_CRED_ANT_ST the VL_SLD_CRED_ANT_ST to set
     */
    public void setVL_SLD_CRED_ANT_ST(double VL_SLD_CRED_ANT_ST) {
        this.VL_SLD_CRED_ANT_ST = VL_SLD_CRED_ANT_ST;
    }

    /**
     * Valor total do ICMS ST de devolucao de mercadorias.
     * @return the VL_DEVOL_ST
     */
    public double getVL_DEVOL_ST() {
        return VL_DEVOL_ST;
    }

    /**
     * Valor total do ICMS ST de devolucao de mercadorias.
     * @param VL_DEVOL_ST the VL_DEVOL_ST to set
     */
    public void setVL_DEVOL_ST(double VL_DEVOL_ST) {
        this.VL_DEVOL_ST = VL_DEVOL_ST;
    }

    /**
     * Valor total do ICMS ST de ressarcimentos.
     * @return the VL_RESSARC_ST
     */
    public double getVL_RESSARC_ST() {
        return VL_RESSARC_ST;
    }

    /**
     * Valor total do ICMS ST de ressarcimentos.
     * @param VL_RESSARC_ST the VL_RESSARC_ST to set
     */
    public void setVL_RESSARC_ST(double VL_RESSARC_ST) {
        this.VL_RESSARC_ST = VL_RESSARC_ST;
    }

    /**
     * Valor total de Ajustes "Outros creditos ST" e "Estorno de debitos ST".
     * @return the VL_OUT_CRED_ST
     */
    public double getVL_OUT_CRED_ST() {
        return VL_OUT_CRED_ST;
    }

    /**
     * Valor total de Ajustes "Outros creditos ST" e "Estorno de debitos ST".
     * @param VL_OUT_CRED_ST the VL_OUT_CRED_ST to set
     */
    public void setVL_OUT_CRED_ST(double VL_OUT_CRED_ST) {
        this.VL_OUT_CRED_ST = VL_OUT_CRED_ST;
    }

    /**
     * Valor total dos ajustes a credito de ICMS ST, provenientes de ajustes do documento fiscal.
     * @return the VL_AJ_CREDITOS_ST
     */
    public double getVL_AJ_CREDITOS_ST() {
        return VL_AJ_CREDITOS_ST;
    }

    /**
     * Valor total dos ajustes a credito de ICMS ST, provenientes de ajustes do documento fiscal.
     * @param VL_AJ_CREDITOS_ST the VL_AJ_CREDITOS_ST to set
     */
    public void setVL_AJ_CREDITOS_ST(double VL_AJ_CREDITOS_ST) {
        this.VL_AJ_CREDITOS_ST = VL_AJ_CREDITOS_ST;
    }

    /**
     * Valor Total do ICMS retido por Substituicao Tributaria.
     * @return the VL_RETENCAO_ST
     */
    public double getVL_RETENCAO_ST() {
        return VL_RETENCAO_ST;
    }

    /**
     * Valor Total do ICMS retido por Substituicao Tributaria.
     * @param VL_RETENCAO_ST the VL_RETENCAO_ST to set
     */
    public void setVL_RETENCAO_ST(double VL_RETENCAO_ST) {
        this.VL_RETENCAO_ST = VL_RETENCAO_ST;
    }

    /**
     * Valor Total dos ajustes "Outros debitos ST" e "Estorno de creditos ST".
     * @return the VL_OUT_DEB_ST
     */
    public double getVL_OUT_DEB_ST() {
        return VL_OUT_DEB_ST;
    }

    /**
     * Valor Total dos ajustes "Outros debitos ST" e "Estorno de creditos ST".
     * @param VL_OUT_DEB_ST the VL_OUT_DEB_ST to set
     */
    public void setVL_OUT_DEB_ST(double VL_OUT_DEB_ST) {
        this.VL_OUT_DEB_ST = VL_OUT_DEB_ST;
    }

    /**
     * Valor total dos ajustes a debito de ICMS ST, provenientes de ajustes do documento fiscal.
     * @return the VL_AJ_DEBITOS_ST
     */
    public double getVL_AJ_DEBITOS_ST() {
        return VL_AJ_DEBITOS_ST;
    }

    /**
     * Valor total dos ajustes a debito de ICMS ST, provenientes de ajustes do documento fiscal.
     * @param VL_AJ_DEBITOS_ST the VL_AJ_DEBITOS_ST to set
     */
    public void setVL_AJ_DEBITOS_ST(double VL_AJ_DEBITOS_ST) {
        this.VL_AJ_DEBITOS_ST = VL_AJ_DEBITOS_ST;
    }

    /**
     * Valor total de Saldo devedor antes das deducoes.
     * @return the VL_SLD_DEV_ANT_ST
     */
    public double getVL_SLD_DEV_ANT_ST() {
        return VL_SLD_DEV_ANT_ST;
    }

    /**
     * Valor total de Saldo devedor antes das deducoes.
     * @param VL_SLD_DEV_ANT_ST the VL_SLD_DEV_ANT_ST to set
     */
    public void setVL_SLD_DEV_ANT_ST(double VL_SLD_DEV_ANT_ST) {
        this.VL_SLD_DEV_ANT_ST = VL_SLD_DEV_ANT_ST;
    }

    /**
     * Valor total dos ajustes "Deducoes ST".
     * @return the VL_DEDUCOES_ST
     */
    public double getVL_DEDUCOES_ST() {
        return VL_DEDUCOES_ST;
    }

    /**
     * Valor total dos ajustes "Deducoes ST".
     * @param VL_DEDUCOES_ST the VL_DEDUCOES_ST to set
     */
    public void setVL_DEDUCOES_ST(double VL_DEDUCOES_ST) {
        this.VL_DEDUCOES_ST = VL_DEDUCOES_ST;
    }

    /**
     * Imposto a recolher ST (11-12).
     * @return the VL_ICMS_RECOL_ST
     */
    public double getVL_ICMS_RECOL_ST() {
        return VL_ICMS_RECOL_ST;
    }

    /**
     * Imposto a recolher ST (11-12).
     * @param VL_ICMS_RECOL_ST the VL_ICMS_RECOL_ST to set
     */
    public void setVL_ICMS_RECOL_ST(double VL_ICMS_RECOL_ST) {
        this.VL_ICMS_RECOL_ST = VL_ICMS_RECOL_ST;
    }

    /**
     * Saldo credor de ST a transportar para o periodo seguinte [(03+04+05+06+07)- (08+09+10)].
     * @return the VL_SLD_CRED_ST_TRANSPORTAR
     */
    public double getVL_SLD_CRED_ST_TRANSPORTAR() {
        return VL_SLD_CRED_ST_TRANSPORTAR;
    }

    /**
     * Saldo credor de ST a transportar para o periodo seguinte [(03+04+05+06+07)- (08+09+10)].
     * @param VL_SLD_CRED_ST_TRANSPORTAR the VL_SLD_CRED_ST_TRANSPORTAR to set
     */
    public void setVL_SLD_CRED_ST_TRANSPORTAR(double VL_SLD_CRED_ST_TRANSPORTAR) {
        this.VL_SLD_CRED_ST_TRANSPORTAR = VL_SLD_CRED_ST_TRANSPORTAR;
    }

    /**
     * Valores recolhidos ou a recolher, extra-apuracao.
     * @return the DEB_ESP_ST
     */
    public double getDEB_ESP_ST() {
        return DEB_ESP_ST;
    }

    /**
     * Valores recolhidos ou a recolher, extra-apuracao.
     * @param DEB_ESP_ST the DEB_ESP_ST to set
     */
    public void setDEB_ESP_ST(double DEB_ESP_ST) {
        this.DEB_ESP_ST = DEB_ESP_ST;
    }
    // </editor-fold>    
    
}