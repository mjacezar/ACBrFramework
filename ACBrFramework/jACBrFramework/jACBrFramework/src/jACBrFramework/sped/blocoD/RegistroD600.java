package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Consolidacao da prestacao de servicos - notas de servico de comunicacao (codigo 21)
 * e de servico de telecomunicacao (codigo 22).
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 10:24:51, revisao: $Id$
 */
public class RegistroD600 {
    
    //TODO Ver este bloco. 
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Itens do documento consolidado (codigo 21 e 22).
     */
    private Collection<RegistroD610> registroD610 = new ArrayList<RegistroD610>(); 
    /**
     * Registro analitico dos documentos (codigos 21 e 22).
     */
    private Collection<RegistroD690> registroD690 = new ArrayList<RegistroD690>();     
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Itens do documento consolidado (codigo 21 e 22).
     * @return the registroD610
     */
    public Collection<RegistroD610> getRegistroD610() {
        return registroD610;
    }

    /**
     * Registro analitico dos documentos (codigos 21 e 22).
     * @return the registroD690
     */
    public Collection<RegistroD690> getRegistroD690() {
        return registroD690;
    }
    // </editor-fold>    
    
}