package jACBrFramework.sped.blocoE;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Apuracao do ICMS - operacoes proprias.
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 11:10:26, revisao: $Id$
 */
public class RegistroE110 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Ajuste/Beneficio/Incentivo da apuracao do ICMS.
     */
    private Collection<RegistroE111> registroE111 = new ArrayList<RegistroE111>();     
    /**
     * Informacoes adicionais da apuracao - valores declaratorios.
     */
    private Collection<RegistroE115> registroE115 = new ArrayList<RegistroE115>();     
    /**
     * Obrigacoes do ICMS recolhido ou a recolhor - operacoes proprias.
     */
    private Collection<RegistroE116> registroE116 = new ArrayList<RegistroE116>();     
    /**
     * Valor total dos debitos por "Saidas e prestacoes com debito do imposto".
     */
    private double VL_TOT_DEBITOS;
    /**
     * Valor total dos ajustes a debito decorrentes do documento fiscal.
     */
    private double VL_AJ_DEBITOS;
    /**
     * Valor total de "Ajustes a debito".
     */
    private double VL_TOT_AJ_DEBITOS;
    /**
     * Valor total de Ajustes "Estornos de creditos".
     */
    private double VL_ESTORNOS_CRED;
    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     */
    private double VL_TOT_CREDITOS;
    /**
     * Valor total dos ajustes a credito decorrentes do documento fiscal.
     */
    private double VL_AJ_CREDITOS;
    /**
     * Valor total de "Ajustes a credito".
     */
    private double VL_TOT_AJ_CREDITOS;
    /**
     * Valor total de Ajustes "Estornos de Debitos".
     */
    private double VL_ESTORNOS_DEB;
    /**
     * Valor total de "Saldo credor do periodo anterior".
     */
    private double VL_SLD_CREDOR_ANT;
    /**
     * Valor do saldo devedor apurado.
     */
    private double VL_SLD_APURADO;
    /**
     * Valor total de "Deducoes".
     */
    private double VL_TOT_DED;
    /**
     * Valor total de "ICMS a recolher (11-12)".
     */
    private double VL_ICMS_RECOLHER;
    /**
     * Valor total de "Saldo credor a transportar para o periodo seguinte".
     */
    private double VL_SLD_CREDOR_TRANSPORTAR;
    /**
     * Valores recolhidos ou a recolher, extra-apuracao.
     */
    private double DEB_ESP;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Ajuste/Beneficio/Incentivo da apuracao do ICMS.
     * @return the registroE111
     */
    public Collection<RegistroE111> getRegistroE111() {
        return registroE111;
    }

    /**
     * Informacoes adicionais da apuracao - valores declaratorios.
     * @return the registroE115
     */
    public Collection<RegistroE115> getRegistroE115() {
        return registroE115;
    }

    /**
     * Obrigacoes do ICMS recolhido ou a recolhor - operacoes proprias.
     * @return the registroE116
     */
    public Collection<RegistroE116> getRegistroE116() {
        return registroE116;
    }

    /**
     * Valor total dos debitos por "Saidas e prestacoes com debito do imposto".
     * @return the VL_TOT_DEBITOS
     */
    public double getVL_TOT_DEBITOS() {
        return VL_TOT_DEBITOS;
    }

    /**
     * Valor total dos debitos por "Saidas e prestacoes com debito do imposto".
     * @param VL_TOT_DEBITOS the VL_TOT_DEBITOS to set
     */
    public void setVL_TOT_DEBITOS(double VL_TOT_DEBITOS) {
        this.VL_TOT_DEBITOS = VL_TOT_DEBITOS;
    }

    /**
     * Valor total dos ajustes a debito decorrentes do documento fiscal.
     * @return the VL_AJ_DEBITOS
     */
    public double getVL_AJ_DEBITOS() {
        return VL_AJ_DEBITOS;
    }

    /**
     * Valor total dos ajustes a debito decorrentes do documento fiscal.
     * @param VL_AJ_DEBITOS the VL_AJ_DEBITOS to set
     */
    public void setVL_AJ_DEBITOS(double VL_AJ_DEBITOS) {
        this.VL_AJ_DEBITOS = VL_AJ_DEBITOS;
    }

    /**
     * Valor total de "Ajustes a debito".
     * @return the VL_TOT_AJ_DEBITOS
     */
    public double getVL_TOT_AJ_DEBITOS() {
        return VL_TOT_AJ_DEBITOS;
    }

    /**
     * Valor total de "Ajustes a debito".
     * @param VL_TOT_AJ_DEBITOS the VL_TOT_AJ_DEBITOS to set
     */
    public void setVL_TOT_AJ_DEBITOS(double VL_TOT_AJ_DEBITOS) {
        this.VL_TOT_AJ_DEBITOS = VL_TOT_AJ_DEBITOS;
    }

    /**
     * Valor total de Ajustes "Estornos de creditos".
     * @return the VL_ESTORNOS_CRED
     */
    public double getVL_ESTORNOS_CRED() {
        return VL_ESTORNOS_CRED;
    }

    /**
     * Valor total de Ajustes "Estornos de creditos".
     * @param VL_ESTORNOS_CRED the VL_ESTORNOS_CRED to set
     */
    public void setVL_ESTORNOS_CRED(double VL_ESTORNOS_CRED) {
        this.VL_ESTORNOS_CRED = VL_ESTORNOS_CRED;
    }

    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     * @return the VL_TOT_CREDITOS
     */
    public double getVL_TOT_CREDITOS() {
        return VL_TOT_CREDITOS;
    }

    /**
     * Valor total dos creditos por "Entradas e aquisicoes com credito do imposto".
     * @param VL_TOT_CREDITOS the VL_TOT_CREDITOS to set
     */
    public void setVL_TOT_CREDITOS(double VL_TOT_CREDITOS) {
        this.VL_TOT_CREDITOS = VL_TOT_CREDITOS;
    }

    /**
     * Valor total dos ajustes a credito decorrentes do documento fiscal.
     * @return the VL_AJ_CREDITOS
     */
    public double getVL_AJ_CREDITOS() {
        return VL_AJ_CREDITOS;
    }

    /**
     * Valor total dos ajustes a credito decorrentes do documento fiscal.
     * @param VL_AJ_CREDITOS the VL_AJ_CREDITOS to set
     */
    public void setVL_AJ_CREDITOS(double VL_AJ_CREDITOS) {
        this.VL_AJ_CREDITOS = VL_AJ_CREDITOS;
    }

    /**
     * Valor total de "Ajustes a credito".
     * @return the VL_TOT_AJ_CREDITOS
     */
    public double getVL_TOT_AJ_CREDITOS() {
        return VL_TOT_AJ_CREDITOS;
    }

    /**
     * Valor total de "Ajustes a credito".
     * @param VL_TOT_AJ_CREDITOS the VL_TOT_AJ_CREDITOS to set
     */
    public void setVL_TOT_AJ_CREDITOS(double VL_TOT_AJ_CREDITOS) {
        this.VL_TOT_AJ_CREDITOS = VL_TOT_AJ_CREDITOS;
    }

    /**
     * Valor total de Ajustes "Estornos de Debitos".
     * @return the VL_ESTORNOS_DEB
     */
    public double getVL_ESTORNOS_DEB() {
        return VL_ESTORNOS_DEB;
    }

    /**
     * Valor total de Ajustes "Estornos de Debitos".
     * @param VL_ESTORNOS_DEB the VL_ESTORNOS_DEB to set
     */
    public void setVL_ESTORNOS_DEB(double VL_ESTORNOS_DEB) {
        this.VL_ESTORNOS_DEB = VL_ESTORNOS_DEB;
    }

    /**
     * Valor total de "Saldo credor do periodo anterior".
     * @return the VL_SLD_CREDOR_ANT
     */
    public double getVL_SLD_CREDOR_ANT() {
        return VL_SLD_CREDOR_ANT;
    }

    /**
     * Valor total de "Saldo credor do periodo anterior".
     * @param VL_SLD_CREDOR_ANT the VL_SLD_CREDOR_ANT to set
     */
    public void setVL_SLD_CREDOR_ANT(double VL_SLD_CREDOR_ANT) {
        this.VL_SLD_CREDOR_ANT = VL_SLD_CREDOR_ANT;
    }

    /**
     * Valor do saldo devedor apurado.
     * @return the VL_SLD_APURADO
     */
    public double getVL_SLD_APURADO() {
        return VL_SLD_APURADO;
    }

    /**
     * Valor do saldo devedor apurado.
     * @param VL_SLD_APURADO the VL_SLD_APURADO to set
     */
    public void setVL_SLD_APURADO(double VL_SLD_APURADO) {
        this.VL_SLD_APURADO = VL_SLD_APURADO;
    }

    /**
     * Valor total de "Deducoes".
     * @return the VL_TOT_DED
     */
    public double getVL_TOT_DED() {
        return VL_TOT_DED;
    }

    /**
     * Valor total de "Deducoes".
     * @param VL_TOT_DED the VL_TOT_DED to set
     */
    public void setVL_TOT_DED(double VL_TOT_DED) {
        this.VL_TOT_DED = VL_TOT_DED;
    }

    /**
     * Valor total de "ICMS a recolher (11-12)".
     * @return the VL_ICMS_RECOLHER
     */
    public double getVL_ICMS_RECOLHER() {
        return VL_ICMS_RECOLHER;
    }

    /**
     * Valor total de "ICMS a recolher (11-12)".
     * @param VL_ICMS_RECOLHER the VL_ICMS_RECOLHER to set
     */
    public void setVL_ICMS_RECOLHER(double VL_ICMS_RECOLHER) {
        this.VL_ICMS_RECOLHER = VL_ICMS_RECOLHER;
    }

    /**
     * Valor total de "Saldo credor a transportar para o periodo seguinte".
     * @return the VL_SLD_CREDOR_TRANSPORTAR
     */
    public double getVL_SLD_CREDOR_TRANSPORTAR() {
        return VL_SLD_CREDOR_TRANSPORTAR;
    }

    /**
     * Valor total de "Saldo credor a transportar para o periodo seguinte".
     * @param VL_SLD_CREDOR_TRANSPORTAR the VL_SLD_CREDOR_TRANSPORTAR to set
     */
    public void setVL_SLD_CREDOR_TRANSPORTAR(double VL_SLD_CREDOR_TRANSPORTAR) {
        this.VL_SLD_CREDOR_TRANSPORTAR = VL_SLD_CREDOR_TRANSPORTAR;
    }

    /**
     * Valores recolhidos ou a recolher, extra-apuracao.
     * @return the DEB_ESP
     */
    public double getDEB_ESP() {
        return DEB_ESP;
    }

    /**
     * Valores recolhidos ou a recolher, extra-apuracao.
     * @param DEB_ESP the DEB_ESP to set
     */
    public void setDEB_ESP(double DEB_ESP) {
        this.DEB_ESP = DEB_ESP;
    }
    // </editor-fold>    
    
}