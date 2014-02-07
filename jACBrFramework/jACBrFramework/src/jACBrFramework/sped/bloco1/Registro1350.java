package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.Medicao;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Bicos da bomba.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 17:18:36, revisao: $Id$
 */
public class Registro1350 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Lacres da bomba.
     */
    private Collection<Registro1360> registro1360 = new ArrayList<Registro1360>(); 
    /**
     * Lacres da bomba.
     */
    private Collection<Registro1370> registro1370 = new ArrayList<Registro1370>(); 
    /**
     * Numero deserie da Bomba.
     */
    private String SERIE;
    /**
     * Nome do fabricante da Bomba.
     */
    private String FABRICANTE;
    /**
     * Modelo da Bomba.
     */
    private String MODELO;
    /**
     * Identificador de medicao.
     */
    private Medicao TIPO_MEDICAO;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Lacres da bomba.
     * @return the registro1360
     */
    public Collection<Registro1360> getRegistro1360() {
        return registro1360;
    }

    /**
     * Lacres da bomba.
     * @return the registro1370
     */
    public Collection<Registro1370> getRegistro1370() {
        return registro1370;
    }

    /**
     * Numero deserie da Bomba.
     * @return the SERIE
     */
    public String getSERIE() {
        return SERIE;
    }

    /**
     * Numero deserie da Bomba.
     * @param SERIE the SERIE to set
     */
    public void setSERIE(String SERIE) {
        this.SERIE = SERIE;
    }

    /**
     * Nome do fabricante da Bomba.
     * @return the FABRICANTE
     */
    public String getFABRICANTE() {
        return FABRICANTE;
    }

    /**
     * Nome do fabricante da Bomba.
     * @param FABRICANTE the FABRICANTE to set
     */
    public void setFABRICANTE(String FABRICANTE) {
        this.FABRICANTE = FABRICANTE;
    }

    /**
     * Modelo da Bomba.
     * @return the MODELO
     */
    public String getMODELO() {
        return MODELO;
    }

    /**
     * Modelo da Bomba.
     * @param MODELO the MODELO to set
     */
    public void setMODELO(String MODELO) {
        this.MODELO = MODELO;
    }

    /**
     * Identificador de medicao.
     * @return the TIPO_MEDICAO
     */
    public Medicao getTIPO_MEDICAO() {
        return TIPO_MEDICAO;
    }

    /**
     * Identificador de medicao.
     * @param TIPO_MEDICAO the TIPO_MEDICAO to set
     */
    public void setTIPO_MEDICAO(Medicao TIPO_MEDICAO) {
        this.TIPO_MEDICAO = TIPO_MEDICAO;
    }
    // </editor-fold>
    
}