package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 *
 * @author Jose Mauro
 * @version Criado em: 11/12/2013 09:16:43, revisao: $Id$
 */
public final class ACBrPAF_TITP {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Mercadorias.
     */
    private Collection<ACBrPAFRegistroMercadoria> mercadorias = new ArrayList<ACBrPAFRegistroMercadoria>();
    /**
     * Data.
     */
    private Date data;
    /**
     * Titulo.
     */
    private String titulo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">
    /**
     * Realiza a limpeza dos registros associado ao bloco.
     */
    public void limparRegistros() {
        getMercadorias().clear();
    } 
    /**
     * Contabiliza os registros de insumo.
     * 
     * @return numero de registros.
     */
    public int countInsumos() {
        int lCount = 0;
        
        for (ACBrPAFRegistroMercadoria lRegistro : getMercadorias()) {
            lCount += lRegistro.getInsumos().size();
        }
        return lCount;
    }      
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Mercadorias.
     * @return the mercadorias
     */
    public Collection<ACBrPAFRegistroMercadoria> getMercadorias() {
        return mercadorias;
    }

    /**
     * Data.
     * @return the data
     */
    public Date getData() {
        return data;
    }

    /**
     * Data.
     * @param data the data to set
     */
    public void setData(Date data) {
        this.data = data;
    }

    /**
     * Titulo.
     * @return the titulo
     */
    public String getTitulo() {
        return titulo;
    }

    /**
     * Titulo.
     * @param titulo the titulo to set
     */
    public void setTitulo(String titulo) {
        this.titulo = titulo;
    }
    // </editor-fold>       
    
}