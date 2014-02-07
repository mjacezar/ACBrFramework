package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.TipoTransporte;

/**
 * Local da coleta e entrega (codigo 08, 8B, 09, 10, 11, 26 e 27).
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 14:40:38, revisao: $Id$
 */
public class RegistroD161 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de transporte da carga coletada.
     */
    private TipoTransporte IND_CARGA;
    /**
     * Numero do CNPJ ou CPF do local da coleta.
     */
    private String CNPJ_COL;
    /**
     * Inscricao Estadual do contribuinte do local de coleta.
     */
    private String IE_COL;
    /**
     * Codigo do Municipio do local de coleta, conforme tabela IBGE.
     */
    private String COD_MUN_COL;
    /**
     * Numero do CNPJ ou CPF do local da entrega.
     */
    private String CNPJ_ENTG;
    /**
     * Inscricao Estadual do contribuinte do local de entrega.
     */
    private String IE_ENTG;
    /**
     * Codigo do Municipio do local de entrega, conforme tabela IBGE.
     */
    private String COD_MUN_ENTG;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de transporte da carga coletada.
     * @return the IND_CARGA
     */
    public TipoTransporte getIND_CARGA() {
        return IND_CARGA;
    }

    /**
     * Indicador do tipo de transporte da carga coletada.
     * @param IND_CARGA the IND_CARGA to set
     */
    public void setIND_CARGA(TipoTransporte IND_CARGA) {
        this.IND_CARGA = IND_CARGA;
    }

    /**
     * Numero do CNPJ ou CPF do local da coleta.
     * @return the CNPJ_COL
     */
    public String getCNPJ_COL() {
        return CNPJ_COL;
    }

    /**
     * Numero do CNPJ ou CPF do local da coleta.
     * @param CNPJ_COL the CNPJ_COL to set
     */
    public void setCNPJ_COL(String CNPJ_COL) {
        this.CNPJ_COL = CNPJ_COL;
    }

    /**
     * Inscricao Estadual do contribuinte do local de coleta.
     * @return the IE_COL
     */
    public String getIE_COL() {
        return IE_COL;
    }

    /**
     * Inscricao Estadual do contribuinte do local de coleta.
     * @param IE_COL the IE_COL to set
     */
    public void setIE_COL(String IE_COL) {
        this.IE_COL = IE_COL;
    }

    /**
     * Codigo do Municipio do local de coleta, conforme tabela IBGE.
     * @return the COD_MUN_COL
     */
    public String getCOD_MUN_COL() {
        return COD_MUN_COL;
    }

    /**
     * Codigo do Municipio do local de coleta, conforme tabela IBGE.
     * @param COD_MUN_COL the COD_MUN_COL to set
     */
    public void setCOD_MUN_COL(String COD_MUN_COL) {
        this.COD_MUN_COL = COD_MUN_COL;
    }

    /**
     * Numero do CNPJ ou CPF do local da entrega.
     * @return the CNPJ_ENTG
     */
    public String getCNPJ_ENTG() {
        return CNPJ_ENTG;
    }

    /**
     * Numero do CNPJ ou CPF do local da entrega.
     * @param CNPJ_ENTG the CNPJ_ENTG to set
     */
    public void setCNPJ_ENTG(String CNPJ_ENTG) {
        this.CNPJ_ENTG = CNPJ_ENTG;
    }

    /**
     * Inscricao Estadual do contribuinte do local de entrega.
     * @return the IE_ENTG
     */
    public String getIE_ENTG() {
        return IE_ENTG;
    }

    /**
     * Inscricao Estadual do contribuinte do local de entrega.
     * @param IE_ENTG the IE_ENTG to set
     */
    public void setIE_ENTG(String IE_ENTG) {
        this.IE_ENTG = IE_ENTG;
    }

    /**
     * Codigo do Municipio do local de entrega, conforme tabela IBGE.
     * @return the COD_MUN_ENTG
     */
    public String getCOD_MUN_ENTG() {
        return COD_MUN_ENTG;
    }

    /**
     * Codigo do Municipio do local de entrega, conforme tabela IBGE.
     * @param COD_MUN_ENTG the COD_MUN_ENTG to set
     */
    public void setCOD_MUN_ENTG(String COD_MUN_ENTG) {
        this.COD_MUN_ENTG = COD_MUN_ENTG;
    }
    // </editor-fold>    
    
}