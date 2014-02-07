package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.NaturezaFrete;

/**
 * Complemento do conhecimento multimodal de cargas (codigo 26).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:54:47, revisao: $Id$
 */
public class RegistroD170 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver.
     */
    private String COD_PART_CONSG;
    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachante, se houver.
     */
    private String COD_PART_RED;
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * Codigo do municipio de destino, conforme a tabela IBGE.
     */
    private String COD_MUN_DEST;
    /**
     * Registro do operador de transporte multimodal.
     */
    private String OTM;
    /**
     * Indicador da natureza do frete.
     */
    private NaturezaFrete IND_NAT_FRT;
    /**
     * Valor liquido do frete.
     */
    private double VL_LIQ_FRT;
    /**
     * Valor do gris (gerenciamento de risco).
     */
    private double VL_GRIS;
    /**
     * Somatorio dos valores de pedagio.
     */
    private double VL_PDG;
    /**
     * Outros valores.
     */
    private double VL_OUT;
    /**
     * Valor total do frete.
     */
    private double VL_FRT;
    /**
     * Placa de identificacao do veiculo.
     */
    private String VEIC_ID;
    /**
     * Sigla da UF da placa do veiculo.
     */
    private String UF_ID;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver.
     * @return the COD_PART_CONSG
     */
    public String getCOD_PART_CONSG() {
        return COD_PART_CONSG;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver.
     * @param COD_PART_CONSG the COD_PART_CONSG to set
     */
    public void setCOD_PART_CONSG(String COD_PART_CONSG) {
        this.COD_PART_CONSG = COD_PART_CONSG;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachante, se houver.
     * @return the COD_PART_RED
     */
    public String getCOD_PART_RED() {
        return COD_PART_RED;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachante, se houver.
     * @param COD_PART_RED the COD_PART_RED to set
     */
    public void setCOD_PART_RED(String COD_PART_RED) {
        this.COD_PART_RED = COD_PART_RED;
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
     * Codigo do municipio de destino, conforme a tabela IBGE.
     * @return the COD_MUN_DEST
     */
    public String getCOD_MUN_DEST() {
        return COD_MUN_DEST;
    }

    /**
     * Codigo do municipio de destino, conforme a tabela IBGE.
     * @param COD_MUN_DEST the COD_MUN_DEST to set
     */
    public void setCOD_MUN_DEST(String COD_MUN_DEST) {
        this.COD_MUN_DEST = COD_MUN_DEST;
    }

    /**
     * Registro do operador de transporte multimodal.
     * @return the OTM
     */
    public String getOTM() {
        return OTM;
    }

    /**
     * Registro do operador de transporte multimodal.
     * @param OTM the OTM to set
     */
    public void setOTM(String OTM) {
        this.OTM = OTM;
    }

    /**
     * Indicador da natureza do frete.
     * @return the IND_NAT_FRT
     */
    public NaturezaFrete getIND_NAT_FRT() {
        return IND_NAT_FRT;
    }

    /**
     * Indicador da natureza do frete.
     * @param IND_NAT_FRT the IND_NAT_FRT to set
     */
    public void setIND_NAT_FRT(NaturezaFrete IND_NAT_FRT) {
        this.IND_NAT_FRT = IND_NAT_FRT;
    }

    /**
     * Valor liquido do frete.
     * @return the VL_LIQ_FRT
     */
    public double getVL_LIQ_FRT() {
        return VL_LIQ_FRT;
    }

    /**
     * Valor liquido do frete.
     * @param VL_LIQ_FRT the VL_LIQ_FRT to set
     */
    public void setVL_LIQ_FRT(double VL_LIQ_FRT) {
        this.VL_LIQ_FRT = VL_LIQ_FRT;
    }

    /**
     * Valor do gris (gerenciamento de risco).
     * @return the VL_GRIS
     */
    public double getVL_GRIS() {
        return VL_GRIS;
    }

    /**
     * Valor do gris (gerenciamento de risco).
     * @param VL_GRIS the VL_GRIS to set
     */
    public void setVL_GRIS(double VL_GRIS) {
        this.VL_GRIS = VL_GRIS;
    }

    /**
     * Somatorio dos valores de pedagio.
     * @return the VL_PDG
     */
    public double getVL_PDG() {
        return VL_PDG;
    }

    /**
     * Somatorio dos valores de pedagio.
     * @param VL_PDG the VL_PDG to set
     */
    public void setVL_PDG(double VL_PDG) {
        this.VL_PDG = VL_PDG;
    }

    /**
     * Outros valores.
     * @return the VL_OUT
     */
    public double getVL_OUT() {
        return VL_OUT;
    }

    /**
     * Outros valores.
     * @param VL_OUT the VL_OUT to set
     */
    public void setVL_OUT(double VL_OUT) {
        this.VL_OUT = VL_OUT;
    }

    /**
     * Valor total do frete.
     * @return the VL_FRT
     */
    public double getVL_FRT() {
        return VL_FRT;
    }

    /**
     * Valor total do frete.
     * @param VL_FRT the VL_FRT to set
     */
    public void setVL_FRT(double VL_FRT) {
        this.VL_FRT = VL_FRT;
    }

    /**
     * Placa de identificacao do veiculo.
     * @return the VEIC_ID
     */
    public String getVEIC_ID() {
        return VEIC_ID;
    }

    /**
     * Placa de identificacao do veiculo.
     * @param VEIC_ID the VEIC_ID to set
     */
    public void setVEIC_ID(String VEIC_ID) {
        this.VEIC_ID = VEIC_ID;
    }

    /**
     * Sigla da UF da placa do veiculo.
     * @return the UF_ID
     */
    public String getUF_ID() {
        return UF_ID;
    }

    /**
     * Sigla da UF da placa do veiculo.
     * @param UF_ID the UF_ID to set
     */
    public void setUF_ID(String UF_ID) {
        this.UF_ID = UF_ID;
    }
    // </editor-fold>    
    
}