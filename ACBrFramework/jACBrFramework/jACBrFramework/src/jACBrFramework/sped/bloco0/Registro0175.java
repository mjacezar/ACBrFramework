package jACBrFramework.sped.bloco0;

import java.util.Date;

/**
 * Alteracao da Tabela de Cadastro de Participante.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:03:58, revisao: $Id$
 */
public class Registro0175 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Data de alteracao do cadastro.
     */
    private Date DT_ALT;
    /**
     * Numero do campo alterado (campos 03 a 13, exceto 07).
     */
    private String NR_CAMPO;
    /**
     * Conteudo anterior do campo.
     */
    private String CONT_ANT;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        
    /**
     * Data de alteracao do cadastro.
     * @return the DT_ALT
     */
    public Date getDT_ALT() {
        return DT_ALT;
    }

    /**
     * Data de alteracao do cadastro.
     * @param DT_ALT the DT_ALT to set
     */
    public void setDT_ALT(Date DT_ALT) {
        this.DT_ALT = DT_ALT;
    }

    /**
     * Numero do campo alterado (campos 03 a 13, exceto 07).
     * @return the NR_CAMPO
     */
    public String getNR_CAMPO() {
        return NR_CAMPO;
    }

    /**
     * Numero do campo alterado (campos 03 a 13, exceto 07).
     * @param NR_CAMPO the NR_CAMPO to set
     */
    public void setNR_CAMPO(String NR_CAMPO) {
        this.NR_CAMPO = NR_CAMPO;
    }

    /**
     * Conteudo anterior do campo.
     * @return the CONT_ANT
     */
    public String getCONT_ANT() {
        return CONT_ANT;
    }

    /**
     * Conteudo anterior do campo.
     * @param CONT_ANT the CONT_ANT to set
     */
    public void setCONT_ANT(String CONT_ANT) {
        this.CONT_ANT = CONT_ANT;
    }
    // </editor-fold>

}