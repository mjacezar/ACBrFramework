package jACBrFramework.sped.bloco1;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Documentos fiscais de exportacao.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 14:53:46, revisao: $Id$
 */
public class Registro1105 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registros de exportacao indireta.
     */
    private Collection<Registro1110> registro1110 = new ArrayList<Registro1110>();
    /**
     * Codigo do modelo da NF, conforme tabela 4.1.1.
     */
    private String COD_MOD;
    /**
     * Serie da Nota Fiscal.
     */
    private String SERIE;
    /**
     * Numero de Nota Fiscal de Exportacao emitida pelo Exportador.
     */
    private String NUM_DOC;
    /**
     * Chave da Nota Fiscal Eletronica.
     */
    private String CHV_NFE;
    /**
     * Data da emissao da NF de exportacao.
     */
    private Date DT_DOC;
    /**
     * Codigo do item (campo 02 do Registro 0200).
     */
    private String COD_ITEM;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Registros de exportacao indireta.
     * @return the registro1110
     */
    public Collection<Registro1110> getRegistro1110() {
        return registro1110;
    }

    /**
     * Registros de exportacao indireta.
     * @param registro1110 the registro1110 to set
     */
    public void setRegistro1110(Collection<Registro1110> registro1110) {
        this.registro1110 = registro1110;
    }

    /**
     * Codigo do modelo da NF, conforme tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo da NF, conforme tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie da Nota Fiscal.
     * @return the SERIE
     */
    public String getSERIE() {
        return SERIE;
    }

    /**
     * Serie da Nota Fiscal.
     * @param SERIE the SERIE to set
     */
    public void setSERIE(String SERIE) {
        this.SERIE = SERIE;
    }

    /**
     * Numero de Nota Fiscal de Exportacao emitida pelo Exportador.
     * @return the NUM_DOC
     */
    public String getNUM_DOC() {
        return NUM_DOC;
    }

    /**
     * Numero de Nota Fiscal de Exportacao emitida pelo Exportador.
     * @param NUM_DOC the NUM_DOC to set
     */
    public void setNUM_DOC(String NUM_DOC) {
        this.NUM_DOC = NUM_DOC;
    }

    /**
     * Chave da Nota Fiscal Eletronica.
     * @return the CHV_NFE
     */
    public String getCHV_NFE() {
        return CHV_NFE;
    }

    /**
     * Chave da Nota Fiscal Eletronica.
     * @param CHV_NFE the CHV_NFE to set
     */
    public void setCHV_NFE(String CHV_NFE) {
        this.CHV_NFE = CHV_NFE;
    }

    /**
     * Data da emissao da NF de exportacao.
     * @return the DT_DOC
     */
    public Date getDT_DOC() {
        return DT_DOC;
    }

    /**
     * Data da emissao da NF de exportacao.
     * @param DT_DOC the DT_DOC to set
     */
    public void setDT_DOC(Date DT_DOC) {
        this.DT_DOC = DT_DOC;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item (campo 02 do Registro 0200).
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }
    // </editor-fold>

}