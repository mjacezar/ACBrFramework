package jACBrFramework.sped.bloco0;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco 0.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:47:20, revisao: $Id$
 */
public class Registro0001 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Dados complementares da entidade.
     */
    private Registro0005 registro0005 = new Registro0005();
    /**
     * Listagem dos dados do contribuinte substituto.
     */
    private Collection<Registro0015> registro0015 = new ArrayList<Registro0015>();  
    /**
     * Dados do contabilista.
     */
    private Registro0100 registro0100 = new Registro0100(); 
    /**
     * Tabela de cadastro do participante.
     */
    private Collection<Registro0150> registro0150 = new ArrayList<Registro0150>(); 
    /**
     * Unidades de medida.
     */
    private Collection<Registro0190> registro0190 = new ArrayList<Registro0190>(); 
    /**
     * Identificacao de itens, produtos e servicos.
     */
    private Collection<Registro0200> registro0200 = new ArrayList<Registro0200>(); 
    /**
     * Cadastro de bens ou componentes do ativo imobilizado.
     */
    private Collection<Registro0300> registro0300 = new ArrayList<Registro0300>(); 
    /**
     * Tabela de natureza da operacao/prestacao.
     */
    private Collection<Registro0400> registro0400 = new ArrayList<Registro0400>(); 
    /**
     * Tabela de informacao complementar do documento fiscal.
     */
    private Collection<Registro0450> registro0450 = new ArrayList<Registro0450>(); 
    /**
     * Tabela de observacoes do lancamento fiscal.
     */
    private Collection<Registro0460> registro0460 = new ArrayList<Registro0460>(); 
    /**
     * Plano de contas contabeis.
     */
    private Collection<Registro0500> registro0500 = new ArrayList<Registro0500>(); 
    /**
     * Centro de custos.
     */
    private Collection<Registro0600> registro0600 = new ArrayList<Registro0600>(); 
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV = IndicadorMovimento.ComDados;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        
    /**
     * Dados complementares da entidade.
     * @return the registro0005
     */
    public Registro0005 getRegistro0005() {
        return registro0005;
    }

    /**
     * Listagem dos dados do contribuinte substituto.
     * @return the registro0015
     */
    public Collection<Registro0015> getRegistro0015() {
        return registro0015;
    }

    /**
     * Dados do contabilista.
     * @return the registro0100
     */
    public Registro0100 getRegistro0100() {
        return registro0100;
    }

    /**
     * Tabela de cadastro do participante.
     * @return the registro0150
     */
    public Collection<Registro0150> getRegistro0150() {
        return registro0150;
    }

    /**
     * Unidades de medida.
     * @return the registro0190
     */
    public Collection<Registro0190> getRegistro0190() {
        return registro0190;
    }

    /**
     * Identificacao de itens, produtos e servicos.
     * @return the registro0200
     */
    public Collection<Registro0200> getRegistro0200() {
        return registro0200;
    }

    /**
     * Cadastro de bens ou componentes do ativo imobilizado.
     * @return the registro0300
     */
    public Collection<Registro0300> getRegistro0300() {
        return registro0300;
    }

    /**
     * Tabela de natureza da operacao/prestacao.
     * @return the registro0400
     */
    public Collection<Registro0400> getRegistro0400() {
        return registro0400;
    }

    /**
     * Tabela de informacao complementar do documento fiscal.
     * @return the registro0450
     */
    public Collection<Registro0450> getRegistro0450() {
        return registro0450;
    }

    /**
     * Tabela de observacoes do lancamento fiscal.
     * @return the registro0460
     */
    public Collection<Registro0460> getRegistro0460() {
        return registro0460;
    }

    /**
     * Plano de contas contabeis.
     * @return the registro0500
     */
    public Collection<Registro0500> getRegistro0500() {
        return registro0500;
    }

    /**
     * Centro de custos.
     * @return the registro0600
     */
    public Collection<Registro0600> getRegistro0600() {
        return registro0600;
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