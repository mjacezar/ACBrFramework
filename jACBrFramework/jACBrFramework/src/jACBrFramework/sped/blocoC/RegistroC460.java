package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.SituacaoDocto;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Documento fiscal emitido por ECF (codigo 02, 2D e 60).
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 18:17:13, revisao: $Id$
 */
public class RegistroC460 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento fiscal emitido por ECF (codigo 02 e 2D).
     */
    private Collection<RegistroC470> registroC470 = new ArrayList<RegistroC470>();     
    /**
     * Complemento do cupom fiscal eletronico emitido por ECF - ECF-e-ECF (codigo 60).
     */
    //TODO Ver este novo registro.
    private Collection<RegistroC465> registroC465 = new ArrayList<RegistroC465>();     
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Codigo da situacao do documento fiscal, conforme a Tabela 4.1.2.
     */
    private SituacaoDocto COD_SIT;
    /**
     * Número do documento fiscal (COO).
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
    /**
     * Valor do PIS.
     */
    private double VL_PIS;
    /**
     * Valor da COFINS.
     */
    private double VL_COFINS;
    /**
     * CPF ou CNPJ do adquirente.
     */
    private String CPF_CNPJ;
    /**
     * Nome do adquirente.
     */
    private String NOM_ADQ;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Itens do documento fiscal emitido por ECF (codigo 02 e 2D).
     * @return the registroC470
     */
    public Collection<RegistroC470> getRegistroC470() {
        return registroC470;
    }

    /**
     * Complemento do cupom fiscal eletronico emitido por ECF - ECF-e-ECF (codigo 60).
     * @return the registroC465
     */
    public Collection<RegistroC465> getRegistroC465() {
        return registroC465;
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
     * Número do documento fiscal (COO).
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Número do documento fiscal (COO).
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

    /**
     * Valor do PIS.
     * @return the VL_PIS
     */
    public double getVL_PIS() {
        return VL_PIS;
    }

    /**
     * Valor do PIS.
     * @param VL_PIS the VL_PIS to set
     */
    public void setVL_PIS(double VL_PIS) {
        this.VL_PIS = VL_PIS;
    }

    /**
     * Valor da COFINS.
     * @return the VL_COFINS
     */
    public double getVL_COFINS() {
        return VL_COFINS;
    }

    /**
     * Valor da COFINS.
     * @param VL_COFINS the VL_COFINS to set
     */
    public void setVL_COFINS(double VL_COFINS) {
        this.VL_COFINS = VL_COFINS;
    }

    /**
     * CPF ou CNPJ do adquirente.
     * @return the CPF_CNPJ
     */
    public String getCPF_CNPJ() {
        return CPF_CNPJ;
    }

    /**
     * CPF ou CNPJ do adquirente.
     * @param CPF_CNPJ the CPF_CNPJ to set
     */
    public void setCPF_CNPJ(String CPF_CNPJ) {
        this.CPF_CNPJ = CPF_CNPJ;
    }

    /**
     * Nome do adquirente.
     * @return the NOM_ADQ
     */
    public String getNOM_ADQ() {
        return NOM_ADQ;
    }

    /**
     * Nome do adquirente.
     * @param NOM_ADQ the NOM_ADQ to set
     */
    public void setNOM_ADQ(String NOM_ADQ) {
        this.NOM_ADQ = NOM_ADQ;
    }
    // </editor-fold>
    
}