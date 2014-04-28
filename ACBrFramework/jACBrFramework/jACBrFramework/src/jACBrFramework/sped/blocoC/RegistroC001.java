package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.IndicadorMovimento;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Abertura do bloco C.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 10:32:09, revisao: $Id$
 */
public class RegistroC001 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Nota fiscal (codigo 01), nota fiscal avulsa (codigo 1B), nota fiscal de produto 
     * (codigo 04), NF-e (codigo 55) e NFC-e (codigo 65).
     */
    private Collection<RegistroC100> registroC100 = new ArrayList<RegistroC100>();     
    /**
     * Resumo diario das notas fiscais de venda a consumidor (codigo 02).
     */
    private Collection<RegistroC300> registroC300 = new ArrayList<RegistroC300>();     
    /**
     * Nota fiscal de venda a consumidor (codigo 02).
     */
    private Collection<RegistroC350> registroC350 = new ArrayList<RegistroC350>();     
    /**
     * Equipamento ECF (codigo 02, 2D e 60).
     */
    private Collection<RegistroC400> registroC400 = new ArrayList<RegistroC400>();     
    /**
     * Resumo mensal de itens do Ecf por estabelecimento (codigo 02, 2D).
     */
    private Collection<RegistroC495> registroC495 = new ArrayList<RegistroC495>();     
    /**
     * Nota fiscal/conta de energia eletrica (codigo 06), nota fiscal/conta de 
     * fornecimento de agua canalizada (codigo 29) e nota fiscal de consumo 
     * fornecimento de gas (codigo 28).
     */
    private Collection<RegistroC500> registroC500 = new ArrayList<RegistroC500>();     
    /**
     * Consolidacao diaria de notas fiscais/contas de energia eletrica (codigo 06),
     * nota fiscal/conta de fornecimento de agua canalizada (codigo 29) e nota fiscal/conta
     * de fornecimento de gas (codigo 28) (empresas nao obrigadas ao convenio ICMS 115/03)
     */
    private Collection<RegistroC600> registroC600 = new ArrayList<RegistroC600>();     
    /**
     * Consolidacao dos Documentos Nota Fiscal/Conta Energia Eletrica (codigo 06) 
     * emitidas em via unica - (Empresas obrigadas a entrega do arquivo previsto no 
     * Convenio ICMS 115/03) e Nota Fiscal/Conta de Fornecimento de Gas Canalizado (Código 28).
     */
    private Collection<RegistroC700> registroC700 = new ArrayList<RegistroC700>();     
    /**
     * Cupom Fiscal eletronico - SAT (CF-e-SAT) (codigo 59).
     */
    private Collection<RegistroC800> registroC800 = new ArrayList<RegistroC800>();     
    /**
     * Identificacao do equipamento SAT-CF-e.
     */
    private Collection<RegistroC860> registroC860 = new ArrayList<RegistroC860>();     
    /**
     * Indicador de movimento.
     */
    private IndicadorMovimento IND_MOV = IndicadorMovimento.SemDados;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Nota fiscal (codigo 01), nota fiscal avulsa (codigo 1B), nota fiscal de produto
     * (codigo 04), NF-e (codigo 55) e NFC-e (codigo 65).
     * @return the registroC100
     */
    public Collection<RegistroC100> getRegistroC100() {
        return registroC100;
    }

    /**
     * Resumo diario das notas fiscais de venda a consumidor (codigo 02).
     * @return the registroC300
     */
    public Collection<RegistroC300> getRegistroC300() {
        return registroC300;
    }

    /**
     * Nota fiscal de venda a consumidor (codigo 02).
     * @return the registroC350
     */
    public Collection<RegistroC350> getRegistroC350() {
        return registroC350;
    }

    /**
     * Equipamento ECF (codigo 02, 2D e 60).
     * @return the registroC400
     */
    public Collection<RegistroC400> getRegistroC400() {
        return registroC400;
    }

    /**
     * Resumo mensal de itens do Ecf por estabelecimento (codigo 02, 2D).
     * @return the registroC495
     */
    public Collection<RegistroC495> getRegistroC495() {
        return registroC495;
    }

    /**
     * Nota fiscal/conta de energia eletrica (codigo 06), nota fiscal/conta de
     * fornecimento de agua canalizada (codigo 29) e nota fiscal de consumo
     * fornecimento de gas (codigo 28).
     * @return the registroC500
     */
    public Collection<RegistroC500> getRegistroC500() {
        return registroC500;
    }

    /**
     * Consolidacao diaria de notas fiscais/contas de energia eletrica (codigo 06),
     * nota fiscal/conta de fornecimento de agua canalizada (codigo 29) e nota fiscal/conta
     * de fornecimento de gas (codigo 28) (empresas nao obrigadas ao convenio ICMS 115/03)
     * @return the registroC600
     */
    public Collection<RegistroC600> getRegistroC600() {
        return registroC600;
    }

    /**
     * Consolidacao dos Documentos Nota Fiscal/Conta Energia Eletrica (codigo 06)
     * emitidas em via unica - (Empresas obrigadas a entrega do arquivo previsto no
     * Convenio ICMS 115/03) e Nota Fiscal/Conta de Fornecimento de Gas Canalizado (Código 28).
     * @return the registroC700
     */
    public Collection<RegistroC700> getRegistroC700() {
        return registroC700;
    }

    /**
     * Cupom Fiscal eletronico - SAT (CF-e-SAT) (codigo 59).
     * @return the registroC800
     */
    public Collection<RegistroC800> getRegistroC800() {
        return registroC800;
    }

    /**
     * Identificacao do equipamento SAT-CF-e.
     * @return the registroC860
     */
    public Collection<RegistroC860> getRegistroC860() {
        return registroC860;
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