package jACBrFramework.sintegra;

import java.util.Date;

/**
 *  Mestre : Identificador do equipamento.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:37:00, revisao: $Id$
 */
public class SintegraRegistro60M {

    // <editor-fold defaultstate="collapsed" desc="Attributes">          
    /**
     * Valor acumulado no Contador de Reinicio de Operacao (CRO).
     */
    private int cro;
    /**
     * Numero atribuido pelo estabelecimento ao equipamento.
     */
    private int numOrdem;
    /**
     * Valor acumulado no totalizador de venda bruta.
     */
    private double vendaBruta;
    /**
     * Codigo do modelo do documento fiscal.
     */
    private String modeloDoc;
    /**
     * Valor acumulado no totalizador geral.
     */
    private double valorGT;
    /**
     * Numero do Contador de Reducao Z (CRZ).
     */
    private int crz;
    /**
     * Numero do primeiro documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     */
    private int cooFinal;
    /**
     * Numero do ultimo documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     */
    private int cooInicial;
    /**
     * Numero de serie de fabricacao do equipamento.
     */
    private String numSerie;
    /**
     * Data de emissao dos documentos fiscais.
     */
    private Date emissao;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Valor acumulado no Contador de Reinicio de Operacao (CRO).
     * @return the cro
     */
    public int getCro() {
        return cro;
    }

    /**
     * Valor acumulado no Contador de Reinicio de Operacao (CRO).
     * @param cro the cro to set
     */
    public void setCro(int cro) {
        this.cro = cro;
    }

    /**
     * Numero atribuido pelo estabelecimento ao equipamento.
     * @return the numOrdem
     */
    public int getNumOrdem() {
        return numOrdem;
    }

    /**
     * Numero atribuido pelo estabelecimento ao equipamento.
     * @param numOrdem the numOrdem to set
     */
    public void setNumOrdem(int numOrdem) {
        this.numOrdem = numOrdem;
    }

    /**
     * Valor acumulado no totalizador de venda bruta.
     * @return the vendaBruta
     */
    public double getVendaBruta() {
        return vendaBruta;
    }

    /**
     * Valor acumulado no totalizador de venda bruta.
     * @param vendaBruta the vendaBruta to set
     */
    public void setVendaBruta(double vendaBruta) {
        this.vendaBruta = vendaBruta;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @return the modeloDoc
     */
    public String getModeloDoc() {
        return modeloDoc;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @param modeloDoc the modeloDoc to set
     */
    public void setModeloDoc(String modeloDoc) {
        this.modeloDoc = modeloDoc;
    }

    /**
     * Valor acumulado no totalizador geral.
     * @return the valorGT
     */
    public double getValorGT() {
        return valorGT;
    }

    /**
     * Valor acumulado no totalizador geral.
     * @param valorGT the valorGT to set
     */
    public void setValorGT(double valorGT) {
        this.valorGT = valorGT;
    }

    /**
     * Numero do Contador de Reducao Z (CRZ).
     * @return the crz
     */
    public int getCrz() {
        return crz;
    }

    /**
     * Numero do Contador de Reducao Z (CRZ).
     * @param crz the crz to set
     */
    public void setCrz(int crz) {
        this.crz = crz;
    }

    /**
     * Numero do primeiro documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     * @return the cooFinal
     */
    public int getCooFinal() {
        return cooFinal;
    }

    /**
     * Numero do primeiro documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     * @param cooFinal the cooFinal to set
     */
    public void setCooFinal(int cooFinal) {
        this.cooFinal = cooFinal;
    }

    /**
     * Numero do ultimo documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     * @return the cooInicial
     */
    public int getCooInicial() {
        return cooInicial;
    }

    /**
     * Numero do ultimo documento fiscal emitido no dia (numero do Contador de ordem de Operacao - COO).
     * @param cooInicial the cooInicial to set
     */
    public void setCooInicial(int cooInicial) {
        this.cooInicial = cooInicial;
    }

    /**
     * Numero de serie de fabricacao do equipamento.
     * @return the numSerie
     */
    public String getNumSerie() {
        return numSerie;
    }

    /**
     * Numero de serie de fabricacao do equipamento.
     * @param numSerie the numSerie to set
     */
    public void setNumSerie(String numSerie) {
        this.numSerie = numSerie;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @return the emissao
     */
    public Date getEmissao() {
        return emissao;
    }

    /**
     * Data de emissao dos documentos fiscais.
     * @param emissao the emissao to set
     */
    public void setEmissao(Date emissao) {
        this.emissao = emissao;
    }
    // </editor-fold>
    
}