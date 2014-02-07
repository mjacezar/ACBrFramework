package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.ConhecEmbarque;
import jACBrFramework.sped.Exportacao;
import jACBrFramework.sped.TipoDocto;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Registro de informacoes sobre exportacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 14:52:52, revisao: $Id$
 */
public class Registro1100 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos fiscais de exportacao.
     */
    private Collection<Registro1105> registro1105 = new ArrayList<Registro1105>();
    /**
     * Informe o tipo de documento.
     */
    private TipoDocto IND_DOC;
    /**
     * Numero da declaracao.
     */
    private String NRO_DE;
    /**
     * Data da declaracao (DDMMAAAA).
     */
    private Date DT_DE;
    /**
     * Natureza da operacao.
     */
    private Exportacao NAT_EXP;
    /**
     * No. do registro de Exportacao.
     */
    private String NRO_RE;
    /**
     * Data do Registro de Exportacao (DDMMAAAA).
     */
    private Date DT_RE;
    /**
     * No. do conhecimento de embarque.
     */
    private String CHC_EMB;
    /**
     * Data do conhecimento de embarque (DDMMAAAA).
     */
    private Date DT_CHC;
    /**
     * Data da averbacao da Declaracao de exportacao (ddmmaaaa).
     */
    private Date DT_AVB;
    /**
     * Informacao do tipo de conhecimento de embarque.
     */
    private ConhecEmbarque TP_CHC;
    /**
     * Codigo do pais de destino da mercadoria (Preencher conforme tabela do SISCOMEX).
     */
    private String pais;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Documentos fiscais de exportacao.
     * @return the registro1105
     */
    public Collection<Registro1105> getRegistro1105() {
        return registro1105;
    }

    /**
     * Informe o tipo de documento.
     * @return the IND_DOC
     */
    public TipoDocto getIND_DOC() {
        return IND_DOC;
    }

    /**
     * Informe o tipo de documento.
     * @param IND_DOC the IND_DOC to set
     */
    public void setIND_DOC(TipoDocto IND_DOC) {
        this.IND_DOC = IND_DOC;
    }

    /**
     * Numero da declaracao.
     * @return the NRO_DE
     */
    public String getNRO_DE() {
        return NRO_DE;
    }

    /**
     * Numero da declaracao.
     * @param NRO_DE the NRO_DE to set
     */
    public void setNRO_DE(String NRO_DE) {
        this.NRO_DE = NRO_DE;
    }

    /**
     * Data da declaracao (DDMMAAAA).
     * @return the DT_DE
     */
    public Date getDT_DE() {
        return DT_DE;
    }

    /**
     * Data da declaracao (DDMMAAAA).
     * @param DT_DE the DT_DE to set
     */
    public void setDT_DE(Date DT_DE) {
        this.DT_DE = DT_DE;
    }

    /**
     * Natureza da operacao.
     * @return the NAT_EXP
     */
    public Exportacao getNAT_EXP() {
        return NAT_EXP;
    }

    /**
     * Natureza da operacao.
     * @param NAT_EXP the NAT_EXP to set
     */
    public void setNAT_EXP(Exportacao NAT_EXP) {
        this.NAT_EXP = NAT_EXP;
    }

    /**
     * No. do registro de Exportacao.
     * @return the NRO_RE
     */
    public String getNRO_RE() {
        return NRO_RE;
    }

    /**
     * No. do registro de Exportacao.
     * @param NRO_RE the NRO_RE to set
     */
    public void setNRO_RE(String NRO_RE) {
        this.NRO_RE = NRO_RE;
    }

    /**
     * Data do Registro de Exportacao (DDMMAAAA).
     * @return the DT_RE
     */
    public Date getDT_RE() {
        return DT_RE;
    }

    /**
     * Data do Registro de Exportacao (DDMMAAAA).
     * @param DT_RE the DT_RE to set
     */
    public void setDT_RE(Date DT_RE) {
        this.DT_RE = DT_RE;
    }

    /**
     * No. do conhecimento de embarque.
     * @return the CHC_EMB
     */
    public String getCHC_EMB() {
        return CHC_EMB;
    }

    /**
     * No. do conhecimento de embarque.
     * @param CHC_EMB the CHC_EMB to set
     */
    public void setCHC_EMB(String CHC_EMB) {
        this.CHC_EMB = CHC_EMB;
    }

    /**
     * Data do conhecimento de embarque (DDMMAAAA).
     * @return the DT_CHC
     */
    public Date getDT_CHC() {
        return DT_CHC;
    }

    /**
     * Data do conhecimento de embarque (DDMMAAAA).
     * @param DT_CHC the DT_CHC to set
     */
    public void setDT_CHC(Date DT_CHC) {
        this.DT_CHC = DT_CHC;
    }

    /**
     * Data da averbacao da Declaracao de exportacao (ddmmaaaa).
     * @return the DT_AVB
     */
    public Date getDT_AVB() {
        return DT_AVB;
    }

    /**
     * Data da averbacao da Declaracao de exportacao (ddmmaaaa).
     * @param DT_AVB the DT_AVB to set
     */
    public void setDT_AVB(Date DT_AVB) {
        this.DT_AVB = DT_AVB;
    }

    /**
     * Informacao do tipo de conhecimento de embarque.
     * @return the TP_CHC
     */
    public ConhecEmbarque getTP_CHC() {
        return TP_CHC;
    }

    /**
     * Informacao do tipo de conhecimento de embarque.
     * @param TP_CHC the TP_CHC to set
     */
    public void setTP_CHC(ConhecEmbarque TP_CHC) {
        this.TP_CHC = TP_CHC;
    }

    /**
     * Codigo do pais de destino da mercadoria (Preencher conforme tabela do SISCOMEX).
     * @return the pais
     */
    public String getPais() {
        return pais;
    }

    /**
     * Codigo do pais de destino da mercadoria (Preencher conforme tabela do SISCOMEX).
     * @param pais the pais to set
     */
    public void setPais(String pais) {
        this.pais = pais;
    }
    // </editor-fold>
    
}