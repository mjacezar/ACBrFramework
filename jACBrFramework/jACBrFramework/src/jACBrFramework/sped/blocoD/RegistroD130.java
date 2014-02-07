package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.TipoFreteRedespacho;

/**
 * Complemento do conhecimento rodoviario de cargas (codigo 08) e conhecimento de
 * transportes de carga avulso (codigo 8B).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:38:48, revisao: $Id$
 */
public class RegistroD130 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver
     */
    private String COD_PART_CONSG;
    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachado, se houver
     */
    private String COD_PART_RED;
    /**
     * Indicador do tipo do frete da operacao de redespacho.
     */
    private TipoFreteRedespacho IND_FRT_RED;
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * Codigo do municipio de destino, conforme a tabela IBGE.
     */
    private String COD_MUN_DEST;
    /**
     * Placa de identificacao do veiculo.
     */
    private String VEIC_ID;
    /**
     * Valor liquido do frete.
     */
    private double VL_LIQ_FRT;
    /**
     * Soma de valores de Sec/Cat (servicos de coleta/custo adicional de transporte).
     */
    private double VL_SEC_CAT;
    /**
     * Soma de valores de despacho.
     */
    private double VL_DESP;
    /**
     * Soma dos valores de pedagio.
     */
    private double VL_PEDG;
    /**
     * Outros valores.
     */
    private double VL_OUT;
    /**
     * Valor total do frete.
     */
    private double VL_FRT;
    /**
     * Sigla da UF da placa do veiculo.
     */
    private String UF_ID;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver
     * @return the COD_PART_CONSG
     */
    public String getCOD_PART_CONSG() {
        return COD_PART_CONSG;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver
     * @param COD_PART_CONSG the COD_PART_CONSG to set
     */
    public void setCOD_PART_CONSG(String COD_PART_CONSG) {
        this.COD_PART_CONSG = COD_PART_CONSG;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachado, se houver
     * @return the COD_PART_RED
     */
    public String getCOD_PART_RED() {
        return COD_PART_RED;
    }

    /**
     * Codigo do participante (campo 02 do Registro 0150): - redespachado, se houver
     * @param COD_PART_RED the COD_PART_RED to set
     */
    public void setCOD_PART_RED(String COD_PART_RED) {
        this.COD_PART_RED = COD_PART_RED;
    }

    /**
     * Indicador do tipo do frete da operacao de redespacho.
     * @return the IND_FRT_RED
     */
    public TipoFreteRedespacho getIND_FRT_RED() {
        return IND_FRT_RED;
    }

    /**
     * Indicador do tipo do frete da operacao de redespacho.
     * @param IND_FRT_RED the IND_FRT_RED to set
     */
    public void setIND_FRT_RED(TipoFreteRedespacho IND_FRT_RED) {
        this.IND_FRT_RED = IND_FRT_RED;
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
     * Soma de valores de Sec/Cat (servicos de coleta/custo adicional de transporte).
     * @return the VL_SEC_CAT
     */
    public double getVL_SEC_CAT() {
        return VL_SEC_CAT;
    }

    /**
     * Soma de valores de Sec/Cat (servicos de coleta/custo adicional de transporte).
     * @param VL_SEC_CAT the VL_SEC_CAT to set
     */
    public void setVL_SEC_CAT(double VL_SEC_CAT) {
        this.VL_SEC_CAT = VL_SEC_CAT;
    }

    /**
     * Soma de valores de despacho.
     * @return the VL_DESP
     */
    public double getVL_DESP() {
        return VL_DESP;
    }

    /**
     * Soma de valores de despacho.
     * @param VL_DESP the VL_DESP to set
     */
    public void setVL_DESP(double VL_DESP) {
        this.VL_DESP = VL_DESP;
    }

    /**
     * Soma dos valores de pedagio.
     * @return the VL_PEDG
     */
    public double getVL_PEDG() {
        return VL_PEDG;
    }

    /**
     * Soma dos valores de pedagio.
     * @param VL_PEDG the VL_PEDG to set
     */
    public void setVL_PEDG(double VL_PEDG) {
        this.VL_PEDG = VL_PEDG;
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