package jACBrFramework.sped.blocoD;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco D.
 * 
 * @author Jose Mauro
 * @version Criado em: 29/01/2014 13:26:29, revisao: $Id$
 */
public class RegistroD001 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Nota fiscal de servico de transporte (codigo 07) e conhecimentos de transporte
     * rodoviario de cargas (codigo 08), conhecimento de transporte de cargas avulso 
     * (codigo 8B), aquaviario de cargas (codigo 09), aereo (codigo 10), ferroviario 
     * de cargas (codigo 11), multimodal de cargas (codigo 26), nota fiscal de transporte 
     * ferroviario de carga (codigo 27) e conhecimento de transporte eletronico - CT-e (codigo 57). 
     */
    private Collection<RegistroD100> registroD100 = new ArrayList<RegistroD100>(); 
    /**
     * Registro analitico dos bilhetes consolidados de passagem rodoviario (codigo 13),
     * de passagem aquaviario (codigo 14), de passagem e nota de bagagem (codigo 15) 
     * de de passagem ferroviario (codigo 16). 
     */
    private Collection<RegistroD300> registroD300 = new ArrayList<RegistroD300>();     
    /**
     * Equipamento ECF (codigos 2E, 13, 14, 15 e 16).
     */
    private Collection<RegistroD350> registroD350 = new ArrayList<RegistroD350>();     
    /**
     * Resumo de movimento diario (codigo 18).
     */
    private Collection<RegistroD400> registroD400 = new ArrayList<RegistroD400>();     
    /**
     * Nota fiscal de servico de comunicacao (codigo 21) e nota fiscal de servico de
     * telecomunicacao (codigo 22).
     */
    private Collection<RegistroD500> registroD500 = new ArrayList<RegistroD500>();     
    /**
     * Consolidacao da prestacao de servicos - notas de servico de comunicacao (codigo 21)
     * e de servico de telecomunicacao (codigo 22).
     */
    private Collection<RegistroD600> registroD600 = new ArrayList<RegistroD600>();     
    /**
     * Consolidacao da Prestacao de Servicos - Notas de Serviço de Comunicacao (codigo 21) 
     * e de Servico de Telecomunicacao (codigo 22) (Empresas obrigadas a entrega dos 
     * arquivos previstos no Convenio ICMS No. 115/03).
     */
    private Collection<RegistroD695> registroD695 = new ArrayList<RegistroD695>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Nota fiscal de servico de transporte (codigo 07) e conhecimentos de transporte
     * rodoviario de cargas (codigo 08), conhecimento de transporte de cargas avulso
     * (codigo 8B), aquaviario de cargas (codigo 09), aereo (codigo 10), ferroviario
     * de cargas (codigo 11), multimodal de cargas (codigo 26), nota fiscal de transporte
     * ferroviario de carga (codigo 27) e conhecimento de transporte eletronico - CT-e (codigo 57).
     * @return the registroD100
     */
    public Collection<RegistroD100> getRegistroD100() {
        return registroD100;
    }

    /**
     * Registro analitico dos bilhetes consolidados de passagem rodoviario (codigo 13),
     * de passagem aquaviario (codigo 14), de passagem e nota de bagagem (codigo 15)
     * de de passagem ferroviario (codigo 16).
     * @return the registroD300
     */
    public Collection<RegistroD300> getRegistroD300() {
        return registroD300;
    }

    /**
     * Equipamento ECF (codigos 2E, 13, 14, 15 e 16).
     * @return the registroD350
     */
    public Collection<RegistroD350> getRegistroD350() {
        return registroD350;
    }

    /**
     * Resumo de movimento diario (codigo 18).
     * @return the registroD400
     */
    public Collection<RegistroD400> getRegistroD400() {
        return registroD400;
    }

    /**
     * Nota fiscal de servico de comunicacao (codigo 21) e nota fiscal de servico de
     * telecomunicacao (codigo 22).
     * @return the registroD500
     */
    public Collection<RegistroD500> getRegistroD500() {
        return registroD500;
    }

    /**
     * Consolidacao da prestacao de servicos - notas de servico de comunicacao (codigo 21)
     * e de servico de telecomunicacao (codigo 22).
     * @return the registroD600
     */
    public Collection<RegistroD600> getRegistroD600() {
        return registroD600;
    }

    /**
     * Consolidacao da Prestacao de Servicos - Notas de Serviço de Comunicacao (codigo 21)
     * e de Servico de Telecomunicacao (codigo 22) (Empresas obrigadas a entrega dos
     * arquivos previstos no Convenio ICMS No. 115/03).
     * @return the registroD695
     */
    public Collection<RegistroD695> getRegistroD695() {
        return registroD695;
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