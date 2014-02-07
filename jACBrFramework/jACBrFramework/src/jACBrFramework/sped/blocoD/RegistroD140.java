package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.TipoNavegacao;
import jACBrFramework.sped.TipoVeiculo;

/**
 * Complemento do conhecimento aquaviario de cargas (codigo 09).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:47:58, revisao: $Id$
 */
public class RegistroD140 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo do participante (campo 02 do Registro 0150): - consignatario, se houver
     */
    private String COD_PART_CONSG;
    /**
     * Codigo do municipio de origem do servico, conforme a tabela IBGE.
     */
    private String COD_MUN_ORIG;
    /**
     * Codigo do municipio de destino, conforme a tabela IBGE.
     */
    private String COD_MUN_DEST;
    /**
     * Indicador do tipo do veiculo transportador.
     */
    private TipoVeiculo IND_VEIC;
    /**
     * Identificacao da embarcacao (IRIM ou Registro CPP).
     */
    private String VEIC_ID;
    /**
     * Indicador do tipo da navegacao.
     */
    private TipoNavegacao IND_NAV;
    /**
     * Numero da VIAGEM.
     */
    private String VIAGEM;
    /**
     * Valor liquido do frete.
     */
    private double VL_FRT_LIQ;
    /**
     * Valor das despesas portuarias.
     */
    private double VL_DESP_PORT;
    /**
     * Valor das despesas com carga e descarga.
     */
    private double VL_DESP_CAR_DESC;
    /**
     * Outros valores.
     */
    private double VL_OUT;
    /**
     * Valor bruto do frete.
     */
    private double VL_FRT_BRT;
    /**
     * Valor adicional do frete para renovacao da Marinha Mercante.
     */
    private double VL_FRT_MM;    
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
     * Indicador do tipo do veiculo transportador.
     * @return the IND_VEIC
     */
    public TipoVeiculo getIND_VEIC() {
        return IND_VEIC;
    }

    /**
     * Indicador do tipo do veiculo transportador.
     * @param IND_VEIC the IND_VEIC to set
     */
    public void setIND_VEIC(TipoVeiculo IND_VEIC) {
        this.IND_VEIC = IND_VEIC;
    }

    /**
     * Identificacao da embarcacao (IRIM ou Registro CPP).
     * @return the VEIC_ID
     */
    public String getVEIC_ID() {
        return VEIC_ID;
    }

    /**
     * Identificacao da embarcacao (IRIM ou Registro CPP).
     * @param VEIC_ID the VEIC_ID to set
     */
    public void setVEIC_ID(String VEIC_ID) {
        this.VEIC_ID = VEIC_ID;
    }

    /**
     * Indicador do tipo da navegacao.
     * @return the IND_NAV
     */
    public TipoNavegacao getIND_NAV() {
        return IND_NAV;
    }

    /**
     * Indicador do tipo da navegacao.
     * @param IND_NAV the IND_NAV to set
     */
    public void setIND_NAV(TipoNavegacao IND_NAV) {
        this.IND_NAV = IND_NAV;
    }

    /**
     * Numero da VIAGEM.
     * @return the VIAGEM
     */
    public String getVIAGEM() {
        return VIAGEM;
    }

    /**
     * Numero da VIAGEM.
     * @param VIAGEM the VIAGEM to set
     */
    public void setVIAGEM(String VIAGEM) {
        this.VIAGEM = VIAGEM;
    }

    /**
     * Valor liquido do frete.
     * @return the VL_FRT_LIQ
     */
    public double getVL_FRT_LIQ() {
        return VL_FRT_LIQ;
    }

    /**
     * Valor liquido do frete.
     * @param VL_FRT_LIQ the VL_FRT_LIQ to set
     */
    public void setVL_FRT_LIQ(double VL_FRT_LIQ) {
        this.VL_FRT_LIQ = VL_FRT_LIQ;
    }

    /**
     * Valor das despesas portuarias.
     * @return the VL_DESP_PORT
     */
    public double getVL_DESP_PORT() {
        return VL_DESP_PORT;
    }

    /**
     * Valor das despesas portuarias.
     * @param VL_DESP_PORT the VL_DESP_PORT to set
     */
    public void setVL_DESP_PORT(double VL_DESP_PORT) {
        this.VL_DESP_PORT = VL_DESP_PORT;
    }

    /**
     * Valor das despesas com carga e descarga.
     * @return the VL_DESP_CAR_DESC
     */
    public double getVL_DESP_CAR_DESC() {
        return VL_DESP_CAR_DESC;
    }

    /**
     * Valor das despesas com carga e descarga.
     * @param VL_DESP_CAR_DESC the VL_DESP_CAR_DESC to set
     */
    public void setVL_DESP_CAR_DESC(double VL_DESP_CAR_DESC) {
        this.VL_DESP_CAR_DESC = VL_DESP_CAR_DESC;
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
     * Valor bruto do frete.
     * @return the VL_FRT_BRT
     */
    public double getVL_FRT_BRT() {
        return VL_FRT_BRT;
    }

    /**
     * Valor bruto do frete.
     * @param VL_FRT_BRT the VL_FRT_BRT to set
     */
    public void setVL_FRT_BRT(double VL_FRT_BRT) {
        this.VL_FRT_BRT = VL_FRT_BRT;
    }

    /**
     * Valor adicional do frete para renovacao da Marinha Mercante.
     * @return the VL_FRT_MM
     */
    public double getVL_FRT_MM() {
        return VL_FRT_MM;
    }

    /**
     * Valor adicional do frete para renovacao da Marinha Mercante.
     * @param VL_FRT_MM the VL_FRT_MM to set
     */
    public void setVL_FRT_MM(double VL_FRT_MM) {
        this.VL_FRT_MM = VL_FRT_MM;
    }
    // </editor-fold>    
    
}