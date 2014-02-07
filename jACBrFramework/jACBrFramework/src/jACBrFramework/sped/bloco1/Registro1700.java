package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.Dispositivo;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Documentos fiscais utilizados.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 09:14:40, revisao: $Id$
 */
public class Registro1700 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Documentos fiscais cancelados/inutilizados.
     */
    private Collection<Registro1710> registro1710 = new ArrayList<Registro1710>(); 
    /**
     * Codigo dispositivo autorizado.
     */
    private Dispositivo COD_DISP;
    /**
     * Codigo do modelo do dispositivo autorizado, conforme a Tabela 4.1.1. 
     */
    private String COD_MOD;
    /**
     * Serie do dispositivo autorizado.
     */
    private String SER;
    /**
     * Subserie do dispositivo autorizado.
     */
    private String SUB;
    /**
     * Numero inicial do dispositivo autorizado.
     */
    private String NUM_DOC_INI;
    /**
     * Numero final do dispositivo autorizado.
     */
    private String NUM_DOC_FIN;
    /**
     * Numero da autorizacao, conforme dispositivo autorizado. 
     */
    private String NUM_AUT;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Documentos fiscais cancelados/inutilizados.
     * @return the registro1710
     */
    public Collection<Registro1710> getRegistro1710() {
        return registro1710;
    }

    /**
     * Codigo dispositivo autorizado.
     * @return the COD_DISP
     */
    public Dispositivo getCOD_DISP() {
        return COD_DISP;
    }

    /**
     * Codigo dispositivo autorizado.
     * @param COD_DISP the COD_DISP to set
     */
    public void setCOD_DISP(Dispositivo COD_DISP) {
        this.COD_DISP = COD_DISP;
    }

    /**
     * Codigo do modelo do dispositivo autorizado, conforme a Tabela 4.1.1.
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do dispositivo autorizado, conforme a Tabela 4.1.1.
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie do dispositivo autorizado.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do dispositivo autorizado.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Subserie do dispositivo autorizado.
     * @return the SUB
     */
    public String getSUB() {
        return SUB;
    }

    /**
     * Subserie do dispositivo autorizado.
     * @param SUB the SUB to set
     */
    public void setSUB(String SUB) {
        this.SUB = SUB;
    }

    /**
     * Numero inicial do dispositivo autorizado.
     * @return the NUM_DOC_INI
     */
    public String getNUM_DOC_INI() {
        return NUM_DOC_INI;
    }

    /**
     * Numero inicial do dispositivo autorizado.
     * @param NUM_DOC_INI the NUM_DOC_INI to set
     */
    public void setNUM_DOC_INI(String NUM_DOC_INI) {
        this.NUM_DOC_INI = NUM_DOC_INI;
    }

    /**
     * Numero final do dispositivo autorizado.
     * @return the NUM_DOC_FIN
     */
    public String getNUM_DOC_FIN() {
        return NUM_DOC_FIN;
    }

    /**
     * Numero final do dispositivo autorizado.
     * @param NUM_DOC_FIN the NUM_DOC_FIN to set
     */
    public void setNUM_DOC_FIN(String NUM_DOC_FIN) {
        this.NUM_DOC_FIN = NUM_DOC_FIN;
    }

    /**
     * Numero da autorizacao, conforme dispositivo autorizado.
     * @return the NUM_AUT
     */
    public String getNUM_AUT() {
        return NUM_AUT;
    }

    /**
     * Numero da autorizacao, conforme dispositivo autorizado.
     * @param NUM_AUT the NUM_AUT to set
     */
    public void setNUM_AUT(String NUM_AUT) {
        this.NUM_AUT = NUM_AUT;
    }
    // </editor-fold>
    
}