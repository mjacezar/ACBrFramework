package jACBrFramework.sped.blocoD;

/**
 * Complemento da nota fiscal de servicos de transporte (codigo 07).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:35:14, revisao: $Id$
 */
public class RegistroD120 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
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
     * Sigla da UF da placa do veiculo.
     */
    private String UF_ID;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
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