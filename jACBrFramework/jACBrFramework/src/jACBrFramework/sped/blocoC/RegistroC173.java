package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.TipoBaseMedicamento;
import jACBrFramework.sped.TipoProduto;
import java.util.Date;

/**
 * Operacoes com medicamentos (codigo 01, 55)
 *  
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:21:26, revisao: $Id$
 */
public class RegistroC173 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero do lote de fabricacao do medicamento.
     */
    private String LOTE_MED;
    /**
     * Quantidade de item por lote.
     */
    private double QTD_ITEM;
    /**
     * Data de fabricacao do medicamento.
     */
    private Date DT_FAB;
    /**
     * Data de expiracao da validade do medicamento.
     */
    private Date DT_VAL;
    /**
     * Indicador de tipo de referencia da base de calculo do ICMS (ST) do produto farmaceutico.
     */
    private TipoBaseMedicamento IND_MED;
    /**
     * Tipo de produto
     */
    private TipoProduto TP_PROD;
    /**
     * Valor do preco tabelado ou valor do preco maximo.
     */
    private double VL_TAB_MAX;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Numero do lote de fabricacao do medicamento.
     * @return the LOTE_MED
     */
    public String getLOTE_MED() {
        return LOTE_MED;
    }

    /**
     * Numero do lote de fabricacao do medicamento.
     * @param LOTE_MED the LOTE_MED to set
     */
    public void setLOTE_MED(String LOTE_MED) {
        this.LOTE_MED = LOTE_MED;
    }

    /**
     * Quantidade de item por lote.
     * @return the QTD_ITEM
     */
    public double getQTD_ITEM() {
        return QTD_ITEM;
    }

    /**
     * Quantidade de item por lote.
     * @param QTD_ITEM the QTD_ITEM to set
     */
    public void setQTD_ITEM(double QTD_ITEM) {
        this.QTD_ITEM = QTD_ITEM;
    }

    /**
     * Data de fabricacao do medicamento.
     * @return the DT_FAB
     */
    public Date getDT_FAB() {
        return DT_FAB;
    }

    /**
     * Data de fabricacao do medicamento.
     * @param DT_FAB the DT_FAB to set
     */
    public void setDT_FAB(Date DT_FAB) {
        this.DT_FAB = DT_FAB;
    }

    /**
     * Data de expiracao da validade do medicamento.
     * @return the DT_VAL
     */
    public Date getDT_VAL() {
        return DT_VAL;
    }

    /**
     * Data de expiracao da validade do medicamento.
     * @param DT_VAL the DT_VAL to set
     */
    public void setDT_VAL(Date DT_VAL) {
        this.DT_VAL = DT_VAL;
    }

    /**
     * Indicador de tipo de referencia da base de calculo do ICMS (ST) do produto farmaceutico.
     * @return the IND_MED
     */
    public TipoBaseMedicamento getIND_MED() {
        return IND_MED;
    }

    /**
     * Indicador de tipo de referencia da base de calculo do ICMS (ST) do produto farmaceutico.
     * @param IND_MED the IND_MED to set
     */
    public void setIND_MED(TipoBaseMedicamento IND_MED) {
        this.IND_MED = IND_MED;
    }

    /**
     * Tipo de produto
     * @return the TP_PROD
     */
    public TipoProduto getTP_PROD() {
        return TP_PROD;
    }

    /**
     * Tipo de produto
     * @param TP_PROD the TP_PROD to set
     */
    public void setTP_PROD(TipoProduto TP_PROD) {
        this.TP_PROD = TP_PROD;
    }

    /**
     * Valor do preco tabelado ou valor do preco maximo.
     * @return the VL_TAB_MAX
     */
    public double getVL_TAB_MAX() {
        return VL_TAB_MAX;
    }

    /**
     * Valor do preco tabelado ou valor do preco maximo.
     * @param VL_TAB_MAX the VL_TAB_MAX to set
     */
    public void setVL_TAB_MAX(double VL_TAB_MAX) {
        this.VL_TAB_MAX = VL_TAB_MAX;
    }
    // </editor-fold>
    
}