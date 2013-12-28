package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Demais documentos emitidos pelo ECF.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 18:30:36, revisao: $Id$
 */
public final class ACBrPAFRegistroR6 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro R7.
     */
    private Collection<ACBrPAFRegistroR7> registrosR7 = new ArrayList<ACBrPAFRegistroR7>();
    /**
     * Numero de ordem do usuario do ECF.
     */
    private int numeroUsuario;
    /**
     * Numero do COO relativo ao respectivo documento.
     */
    private int coo;
    /**
     * Numero do GNF relativo ao respectivo documento, quando houver.
     */
    private int gnf;
    /**
     * Numero do GRG relativo ao respectivo documento (vide item 7.6.1.2).
     */
    private int grg;
    /**
     * Numero do CDC relativo ao respectivo documento (vide item 7.6.1.3).
     */
    private int cdc;
    /**
     * Simbolo referente a denominacao do documento fiscal, conforme tabela.
     */
    private String denominacao;
    /**
     * Data final de emissao (impressa no rodape do documento).
     */
    private Date dataFinalEmissao;
    /**
     * Hora final de emissao (impressa no rodape do documento).
     */
    private Date horaFinalEmissao;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;            
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro R7.
     * @return the registrosR7
     */
    public Collection<ACBrPAFRegistroR7> getRegistrosR7() {
        return registrosR7;
    }

    /**
     * Numero de ordem do usuario do ECF.
     * @return the numeroUsuario
     */
    public int getNumeroUsuario() {
        return numeroUsuario;
    }

    /**
     * Numero de ordem do usuario do ECF.
     * @param numeroUsuario the numeroUsuario to set
     */
    public void setNumeroUsuario(int numeroUsuario) {
        this.numeroUsuario = numeroUsuario;
    }

    /**
     * Numero do COO relativo ao respectivo documento.
     * @return the coo
     */
    public int getCoo() {
        return coo;
    }

    /**
     * Numero do COO relativo ao respectivo documento.
     * @param coo the coo to set
     */
    public void setCoo(int coo) {
        this.coo = coo;
    }

    /**
     * Numero do GNF relativo ao respectivo documento, quando houver.
     * @return the gnf
     */
    public int getGnf() {
        return gnf;
    }

    /**
     * Numero do GNF relativo ao respectivo documento, quando houver.
     * @param gnf the gnf to set
     */
    public void setGnf(int gnf) {
        this.gnf = gnf;
    }

    /**
     * Numero do GRG relativo ao respectivo documento (vide item 7.6.1.2).
     * @return the grg
     */
    public int getGrg() {
        return grg;
    }

    /**
     * Numero do GRG relativo ao respectivo documento (vide item 7.6.1.2).
     * @param grg the grg to set
     */
    public void setGrg(int grg) {
        this.grg = grg;
    }

    /**
     * Numero do CDC relativo ao respectivo documento (vide item 7.6.1.3).
     * @return the cdc
     */
    public int getCdc() {
        return cdc;
    }

    /**
     * Numero do CDC relativo ao respectivo documento (vide item 7.6.1.3).
     * @param cdc the cdc to set
     */
    public void setCdc(int cdc) {
        this.cdc = cdc;
    }

    /**
     * Simbolo referente a denominacao do documento fiscal, conforme tabela.
     * @return the denominacao
     */
    public String getDenominacao() {
        return denominacao;
    }

    /**
     * Simbolo referente a denominacao do documento fiscal, conforme tabela.
     * @param denominacao the denominacao to set
     */
    public void setDenominacao(String denominacao) {
        this.denominacao = denominacao;
    }

    /**
     * Data final de emissao (impressa no rodape do documento).
     * @return the dataFinalEmissao
     */
    public Date getDataFinalEmissao() {
        return dataFinalEmissao;
    }

    /**
     * Data final de emissao (impressa no rodape do documento).
     * @param dataFinalEmissao the dataFinalEmissao to set
     */
    public void setDataFinalEmissao(Date dataFinalEmissao) {
        this.dataFinalEmissao = dataFinalEmissao;
    }

    /**
     * Hora final de emissao (impressa no rodape do documento).
     * @return the horaFinalEmissao
     */
    public Date getHoraFinalEmissao() {
        return horaFinalEmissao;
    }

    /**
     * Hora final de emissao (impressa no rodape do documento).
     * @param horaFinalEmissao the horaFinalEmissao to set
     */
    public void setHoraFinalEmissao(Date horaFinalEmissao) {
        this.horaFinalEmissao = horaFinalEmissao;
    }

    /**
     * Se true o registro e valido.
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Se true o registro e valido.
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }
    // </editor-fold>      
    
}