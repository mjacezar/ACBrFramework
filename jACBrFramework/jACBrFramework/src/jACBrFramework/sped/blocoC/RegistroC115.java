package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.TipoTransporte;

/**
 * Local de coleta e/ou entrega (codigos 01, 1B e 04)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 11:13:20, revisao: $Id$
 */
public class RegistroC115 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de transporte.
     */
    private TipoTransporte IND_CARGA;
    /**
     * Numero do CNPJ do contribuinte do local de coleta.
     */
    private String CNPJ_COL;
    /**
     * Inscricao Estadual do contribuinte do local de coleta.
     */
    private String IE_COL;
    /**
     * CPF do contribuinte do local de coleta das mercadorias. 
     */
    private String CPF_COL;
    /**
     * Codigo do Municipio do local de coleta.
     */
    private String COD_MUN_COL;
    /**
     * Numero do CNPJ do contribuinte do local de entrega.
     */
    private String CNPJ_ENTG;
    /**
     * Inscricao Estadual do contribuinte do local de entrega.
     */
    private String IE_ENTG;
    /**
     * Cpf do contribuinte do local de entrega.
     */
    private String CPF_ENTG;
    /**
     * Codigo do Municipio do local de entrega.
     */
    private String COD_MUN_ENTG;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de transporte.
     * @return the IND_CARGA
     */
    public TipoTransporte getIND_CARGA() {
        return IND_CARGA;
    }

    /**
     * Indicador do tipo de transporte.
     * @param IND_CARGA the IND_CARGA to set
     */
    public void setIND_CARGA(TipoTransporte IND_CARGA) {
        this.IND_CARGA = IND_CARGA;
    }

    /**
     * Numero do CNPJ do contribuinte do local de coleta.
     * @return the CNPJ_COL
     */
    public String getCNPJ_COL() {
        return CNPJ_COL;
    }

    /**
     * Numero do CNPJ do contribuinte do local de coleta.
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
     * CPF do contribuinte do local de coleta das mercadorias.
     * @return the CPF_COL
     */
    public String getCPF_COL() {
        return CPF_COL;
    }

    /**
     * CPF do contribuinte do local de coleta das mercadorias.
     * @param CPF_COL the CPF_COL to set
     */
    public void setCPF_COL(String CPF_COL) {
        this.CPF_COL = CPF_COL;
    }

    /**
     * Codigo do Municipio do local de coleta.
     * @return the COD_MUN_COL
     */
    public String getCOD_MUN_COL() {
        return COD_MUN_COL;
    }

    /**
     * Codigo do Municipio do local de coleta.
     * @param COD_MUN_COL the COD_MUN_COL to set
     */
    public void setCOD_MUN_COL(String COD_MUN_COL) {
        this.COD_MUN_COL = COD_MUN_COL;
    }

    /**
     * Numero do CNPJ do contribuinte do local de entrega.
     * @return the CNPJ_ENTG
     */
    public String getCNPJ_ENTG() {
        return CNPJ_ENTG;
    }

    /**
     * Numero do CNPJ do contribuinte do local de entrega.
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
     * Cpf do contribuinte do local de entrega.
     * @return the CPF_ENTG
     */
    public String getCPF_ENTG() {
        return CPF_ENTG;
    }

    /**
     * Cpf do contribuinte do local de entrega.
     * @param CPF_ENTG the CPF_ENTG to set
     */
    public void setCPF_ENTG(String CPF_ENTG) {
        this.CPF_ENTG = CPF_ENTG;
    }

    /**
     * Codigo do Municipio do local de entrega.
     * @return the COD_MUN_ENTG
     */
    public String getCOD_MUN_ENTG() {
        return COD_MUN_ENTG;
    }

    /**
     * Codigo do Municipio do local de entrega.
     * @param COD_MUN_ENTG the COD_MUN_ENTG to set
     */
    public void setCOD_MUN_ENTG(String COD_MUN_ENTG) {
        this.COD_MUN_ENTG = COD_MUN_ENTG;
    }
    // </editor-fold>
    
}