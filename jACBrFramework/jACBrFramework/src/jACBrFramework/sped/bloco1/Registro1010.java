package jACBrFramework.sped.bloco1;

/**
 * Obrigatoriedade de registros do Bloco 1.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 11:46:07, revisao: $Id$
 */
public class Registro1010 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Reg. 1100 - Ocorreu averbacao (conclusao) de exportacao no periodo.
     */
    private String IND_EXP = "N";
    /**
     * Reg 1200 – Existem informacoes acerca de creditos de ICMS a serem controlados, definidos pela Sefaz.
     */
    private String IND_CCRF = "N";
    /**
     * Reg. 1300 – E comercio varejista de combustiveis com movimentacao e/ou estoque no periodo.
     */
    private String IND_COMB = "N";
    /**
     * Reg. 1390 – Usinas de acucar e/alcool – O estabelecimento e produtor de 
     * acucar e/ou alcool carburante com movimentacao e/ou estoque no periodo.
     */
    private String IND_USINA = "N";
    /**
     * Reg 1400 – Sendo o registro obrigatorio em sua Unidade de Federacao,
     * existem informacoes a serem prestadas neste registro.
     */
    private String IND_VA = "N";
    /**
     * Reg 1500 - A empresa e distribuidora de energia e ocorreu fornecimento de 
     * energia eletrica para consumidores de outra UF.
     */
    private String IND_EE = "N";
    /**
     * Reg 1600 - Realizou vendas com Cartao de Credito ou de debito.
     */
    private String IND_CART = "N";
    /**
     * Reg. 1700 – Foram emitidos documentos fiscais em papel no periodo  em unidade 
     * da federacao que exija o controle de utilizacao de documentos fiscais.
     */
    private String IND_FORM = "N";
    /**
     * Reg 1800 – A empresa prestou servicos de transporte aereo de cargas e de passageiros.
     */
    private String IND_AER = "N";
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Reg. 1100 - Ocorreu averbacao (conclusao) de exportacao no periodo.
     * @return the IND_EXP
     */
    public String getIND_EXP() {
        return IND_EXP;
    }

    /**
     * Reg. 1100 - Ocorreu averbacao (conclusao) de exportacao no periodo.
     * @param IND_EXP the IND_EXP to set
     */
    public void setIND_EXP(String IND_EXP) {
        this.IND_EXP = IND_EXP;
    }

    /**
     * Reg 1200 – Existem informacoes acerca de creditos de ICMS a serem controlados, definidos pela Sefaz.
     * @return the IND_CCRF
     */
    public String getIND_CCRF() {
        return IND_CCRF;
    }

    /**
     * Reg 1200 – Existem informacoes acerca de creditos de ICMS a serem controlados, definidos pela Sefaz.
     * @param IND_CCRF the IND_CCRF to set
     */
    public void setIND_CCRF(String IND_CCRF) {
        this.IND_CCRF = IND_CCRF;
    }

    /**
     * Reg. 1300 – E comercio varejista de combustiveis com movimentacao e/ou estoque no periodo.
     * @return the IND_COMB
     */
    public String getIND_COMB() {
        return IND_COMB;
    }

    /**
     * Reg. 1300 – E comercio varejista de combustiveis com movimentacao e/ou estoque no periodo.
     * @param IND_COMB the IND_COMB to set
     */
    public void setIND_COMB(String IND_COMB) {
        this.IND_COMB = IND_COMB;
    }

    /**
     * Reg. 1390 – Usinas de acucar e/alcool – O estabelecimento e produtor de
     * acucar e/ou alcool carburante com movimentacao e/ou estoque no periodo.
     * @return the IND_USINA
     */
    public String getIND_USINA() {
        return IND_USINA;
    }

    /**
     * Reg. 1390 – Usinas de acucar e/alcool – O estabelecimento e produtor de
     * acucar e/ou alcool carburante com movimentacao e/ou estoque no periodo.
     * @param IND_USINA the IND_USINA to set
     */
    public void setIND_USINA(String IND_USINA) {
        this.IND_USINA = IND_USINA;
    }

    /**
     * Reg 1400 – Sendo o registro obrigatorio em sua Unidade de Federacao,
     * existem informacoes a serem prestadas neste registro.
     * @return the IND_VA
     */
    public String getIND_VA() {
        return IND_VA;
    }

    /**
     * Reg 1400 – Sendo o registro obrigatorio em sua Unidade de Federacao,
     * existem informacoes a serem prestadas neste registro.
     * @param IND_VA the IND_VA to set
     */
    public void setIND_VA(String IND_VA) {
        this.IND_VA = IND_VA;
    }

    /**
     * Reg 1500 - A empresa e distribuidora de energia e ocorreu fornecimento de
     * energia eletrica para consumidores de outra UF.
     * @return the IND_EE
     */
    public String getIND_EE() {
        return IND_EE;
    }

    /**
     * Reg 1500 - A empresa e distribuidora de energia e ocorreu fornecimento de
     * energia eletrica para consumidores de outra UF.
     * @param IND_EE the IND_EE to set
     */
    public void setIND_EE(String IND_EE) {
        this.IND_EE = IND_EE;
    }

    /**
     * Reg 1600 - Realizou vendas com Cartao de Credito ou de debito.
     * @return the IND_CART
     */
    public String getIND_CART() {
        return IND_CART;
    }

    /**
     * Reg 1600 - Realizou vendas com Cartao de Credito ou de debito.
     * @param IND_CART the IND_CART to set
     */
    public void setIND_CART(String IND_CART) {
        this.IND_CART = IND_CART;
    }

    /**
     * Reg. 1700 – Foram emitidos documentos fiscais em papel no periodo  em unidade
     * da federacao que exija o controle de utilizacao de documentos fiscais.
     * @return the IND_FORM
     */
    public String getIND_FORM() {
        return IND_FORM;
    }

    /**
     * Reg. 1700 – Foram emitidos documentos fiscais em papel no periodo  em unidade
     * da federacao que exija o controle de utilizacao de documentos fiscais.
     * @param IND_FORM the IND_FORM to set
     */
    public void setIND_FORM(String IND_FORM) {
        this.IND_FORM = IND_FORM;
    }

    /**
     * Reg 1800 – A empresa prestou servicos de transporte aereo de cargas e de passageiros.
     * @return the IND_AER
     */
    public String getIND_AER() {
        return IND_AER;
    }

    /**
     * Reg 1800 – A empresa prestou servicos de transporte aereo de cargas e de passageiros.
     * @param IND_AER the IND_AER to set
     */
    public void setIND_AER(String IND_AER) {
        this.IND_AER = IND_AER;
    }
    // </editor-fold>
        
}