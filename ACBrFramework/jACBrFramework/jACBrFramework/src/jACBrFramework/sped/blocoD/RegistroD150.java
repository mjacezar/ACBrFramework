package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.TipoTarifa;

/**
 * Complemento do conhecimento aereo (codigo 10).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:33:28, revisao: $Id$
 */
public class RegistroD150 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do municipio de origem do serviço, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * Codigo do municipio de destino, conforme a tabela IBGE.
     */
    private String COD_MUN_DEST;
    /**
     * Identificacao da aeronave (DAC).
     */
    private String VEIC_ID;
    /**
     * Número do voo.
     */
    private String VIAGEM;
    /**
     * Indicador do tipo de tarifa aplicada.
     */
    private TipoTarifa IND_TFA;
    /**
     * Peso taxado.
     */
    private double VL_PESO_TX;
    /**
     * Valor da taxa terrestre.
     */
    private double VL_TX_TERR;
    /**
     * Valor da taxa de redespacho.
     */
    private double VL_TX_RED;
    /**
     * Outros valores.
     */
    private double VL_OUT;
    /**
     * Valor da taxa "ad valorem".
     */
    private double VL_TX_ADV;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do municipio de origem do serviço, conforme a tabela IBGE.
     * @return the COD_MUN_ORIG
     */
    public String getCOD_MUN_ORIG() {
        return COD_MUN_ORIG;
    }

    /**
     * Codigo do municipio de origem do serviço, conforme a tabela IBGE.
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
     * Identificacao da aeronave (DAC).
     * @return the VEIC_ID
     */
    public String getVEIC_ID() {
        return VEIC_ID;
    }

    /**
     * Identificacao da aeronave (DAC).
     * @param VEIC_ID the VEIC_ID to set
     */
    public void setVEIC_ID(String VEIC_ID) {
        this.VEIC_ID = VEIC_ID;
    }

    /**
     * Número do voo.
     * @return the VIAGEM
     */
    public String getVIAGEM() {
        return VIAGEM;
    }

    /**
     * Número do voo.
     * @param VIAGEM the VIAGEM to set
     */
    public void setVIAGEM(String VIAGEM) {
        this.VIAGEM = VIAGEM;
    }

    /**
     * Indicador do tipo de tarifa aplicada.
     * @return the IND_TFA
     */
    public TipoTarifa getIND_TFA() {
        return IND_TFA;
    }

    /**
     * Indicador do tipo de tarifa aplicada.
     * @param IND_TFA the IND_TFA to set
     */
    public void setIND_TFA(TipoTarifa IND_TFA) {
        this.IND_TFA = IND_TFA;
    }

    /**
     * Peso taxado.
     * @return the VL_PESO_TX
     */
    public double getVL_PESO_TX() {
        return VL_PESO_TX;
    }

    /**
     * Peso taxado.
     * @param VL_PESO_TX the VL_PESO_TX to set
     */
    public void setVL_PESO_TX(double VL_PESO_TX) {
        this.VL_PESO_TX = VL_PESO_TX;
    }

    /**
     * Valor da taxa terrestre.
     * @return the VL_TX_TERR
     */
    public double getVL_TX_TERR() {
        return VL_TX_TERR;
    }

    /**
     * Valor da taxa terrestre.
     * @param VL_TX_TERR the VL_TX_TERR to set
     */
    public void setVL_TX_TERR(double VL_TX_TERR) {
        this.VL_TX_TERR = VL_TX_TERR;
    }

    /**
     * Valor da taxa de redespacho.
     * @return the VL_TX_RED
     */
    public double getVL_TX_RED() {
        return VL_TX_RED;
    }

    /**
     * Valor da taxa de redespacho.
     * @param VL_TX_RED the VL_TX_RED to set
     */
    public void setVL_TX_RED(double VL_TX_RED) {
        this.VL_TX_RED = VL_TX_RED;
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
     * Valor da taxa "ad valorem".
     * @return the VL_TX_ADV
     */
    public double getVL_TX_ADV() {
        return VL_TX_ADV;
    }

    /**
     * Valor da taxa "ad valorem".
     * @param VL_TX_ADV the VL_TX_ADV to set
     */
    public void setVL_TX_ADV(double VL_TX_ADV) {
        this.VL_TX_ADV = VL_TX_ADV;
    }
    // </editor-fold>    
    
}