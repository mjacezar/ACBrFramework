package jACBrFramework.tefd.eventos;

import com.sun.jna.ptr.IntByReference;
import java.util.EventObject;

/**
 * Evento acionado para abertura do menu.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 12:52:04, revisao: $Id$
 */
public class TEFCliSiTefExibeMenuEventObject extends EventObject {
    
    // <editor-fold defaultstate="collapsed" desc="Constants">
    private static final long serialVersionUID = 3187880114413613657L;
    // </editor-fold>    
    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Tipo a ser exibido.
     */
    private String titulo;
    /**
     * Indica as opcoes.
     */
    private int opcoes;
    /**
     * Quantidade de opcoes.
     */
    private int opcoesCount;
    /**
     * Handle associado ao item selecionado.
     */
    private IntByReference itemSelecionado;
    /**
     * Handle associado ao voltar menu.
     */
    private IntByReference voltarMenu;
    // </editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public TEFCliSiTefExibeMenuEventObject(Object pSource, String pTitulo, int pOpcoes, int pOpcoesCount) {
        super(pSource);
        this.titulo = pTitulo;
        this.opcoes = pOpcoes;
        this.opcoesCount = pOpcoesCount;
        itemSelecionado = new IntByReference();
        voltarMenu = new IntByReference();
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Tipo a ser exibido.
     * @return the titulo
     */
    public String getTitulo() {
        return titulo;
    }

    /**
     * Indica as opcoes.
     * @return the opcoes
     */
    public int getOpcoes() {
        return opcoes;
    }

    /**
     * Quantidade de opcoes.
     * @return the opcoesCount
     */
    public int getOpcoesCount() {
        return opcoesCount;
    }

    /**
     * Handle associado ao item selecionado.
     * @return the itemSelecionado
     */
    public IntByReference getItemSelecionado() {
        return itemSelecionado;
    }

    /**
     * Handle associado ao item selecionado.
     * @param itemSelecionado the itemSelecionado to set
     */
    public void setItemSelecionado(IntByReference itemSelecionado) {
        this.itemSelecionado = itemSelecionado;
    }

    /**
     * Handle associado ao voltar menu.
     * @return the voltarMenu
     */
    public IntByReference getVoltarMenu() {
        return voltarMenu;
    }

    /**
     * Handle associado ao voltar menu.
     * @param voltarMenu the voltarMenu to set
     */
    public void setVoltarMenu(IntByReference voltarMenu) {
        this.voltarMenu = voltarMenu;
    }
    // </editor-fold>    

}