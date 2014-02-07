package jACBrFramework.sped.bloco1;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco 1.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 11:45:55, revisao: $Id$
 */
public class Registro1001 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Obrigatoriedade de registros do Bloco 1.
     */
    private Collection<Registro1010> registro1010 = new ArrayList<Registro1010>();     
    /**
     * Registro de informacoes sobre exportacao.
     */
    private Collection<Registro1100> registro1100 = new ArrayList<Registro1100>();     
    /**
     * Controle de creditos fiscais - ICMS.
     */
    private Collection<Registro1200> registro1200 = new ArrayList<Registro1200>();     
    /**
     * Movimentacao diaria de combustiveis.
     */
    private Collection<Registro1300> registro1300 = new ArrayList<Registro1300>();     
    /**
     * Bicos da bomba.
     */
    private Collection<Registro1350> registro1350 = new ArrayList<Registro1350>();     
    /**
     * Controle de producao de usina.
     */
    private Collection<Registro1390> registro1390 = new ArrayList<Registro1390>();     
    /**
     * Informacao sobre valores agregados.
     */
    private Collection<Registro1400> registro1400 = new ArrayList<Registro1400>();     
    /**
     * Nota fsical/conta de energia eletrica (codigo 06) - operacoes interestaduais.
     */
    private Collection<Registro1500> registro1500 = new ArrayList<Registro1500>();     
    /**
     * Total das operacoes com cartao de credito e/ou debito.
     */
    private Collection<Registro1600> registro1600 = new ArrayList<Registro1600>();     
    /**
     * Documentos fiscais utilizados.
     */
    private Collection<Registro1700> registro1700 = new ArrayList<Registro1700>();     
    /**
     * DCTA - Demonstrativo de credito do ICMS sobre transporte aereo.
     */
    private Collection<Registro1800> registro1800 = new ArrayList<Registro1800>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters"> 
    /**
     * Obrigatoriedade de registros do Bloco 1.
     * @return the registro1010
     */
    public Collection<Registro1010> getRegistro1010() {
        return registro1010;
    }

    /**
     * Registro de informacoes sobre exportacao.
     * @return the registro1100
     */
    public Collection<Registro1100> getRegistro1100() {
        return registro1100;
    }

    /**
     * Controle de creditos fiscais - ICMS.
     * @return the registro1200
     */
    public Collection<Registro1200> getRegistro1200() {
        return registro1200;
    }

    /**
     * Movimentacao diaria de combustiveis.
     * @return the registro1300
     */
    public Collection<Registro1300> getRegistro1300() {
        return registro1300;
    }

    /**
     * Bicos da bomba.
     * @return the registro1350
     */
    public Collection<Registro1350> getRegistro1350() {
        return registro1350;
    }

    /**
     * Controle de producao de usina.
     * @return the registro1390
     */
    public Collection<Registro1390> getRegistro1390() {
        return registro1390;
    }

    /**
     * Informacao sobre valores agregados.
     * @return the registro1400
     */
    public Collection<Registro1400> getRegistro1400() {
        return registro1400;
    }

    /**
     * Nota fsical/conta de energia eletrica (codigo 06) - operacoes interestaduais.
     * @return the registro1500
     */
    public Collection<Registro1500> getRegistro1500() {
        return registro1500;
    }

    /**
     * Total das operacoes com cartao de credito e/ou debito.
     * @return the registro1600
     */
    public Collection<Registro1600> getRegistro1600() {
        return registro1600;
    }

    /**
     * Documentos fiscais utilizados.
     * @return the registro1700
     */
    public Collection<Registro1700> getRegistro1700() {
        return registro1700;
    }

    /**
     * DCTA - Demonstrativo de credito do ICMS sobre transporte aereo.
     * @return the registro1800
     */
    public Collection<Registro1800> getRegistro1800() {
        return registro1800;
    }

    /**
     * Indicador de movimento.
     * @return the IND_MOV
     */
    public IndicadorMovimento getIND_MOV() {
        return IND_MOV;
    }

    /**
     * Indicador de movimento.
     * @param IND_MOV the IND_MOV to set
     */
    public void setIND_MOV(IndicadorMovimento IND_MOV) {
        this.IND_MOV = IND_MOV;
    }
    // </editor-fold>
    
}