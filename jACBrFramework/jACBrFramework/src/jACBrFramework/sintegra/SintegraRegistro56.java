package jACBrFramework.sintegra;

/**
 * Operacoes com veiculos automotores novos.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:36:12, revisao: $Id$
 */
public class SintegraRegistro56 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">      
    /**
     * CNPJ ou CPF do adquirente.
     */
    private String cnpj;
    /**
     * Codigo do modelo da nota fiscal.
     */
    private String modelo;
    /**
     * Serie da nota fiscal.
     */
    private String serie;
    /**
     * Numero da nota fiscal.
     */
    private String numero;
    /**
     * Codigo Fiscal de Operacao e Prestacao.
     */
    private String cfop;
    /**
     * Codigo da situacao tributaria.
     */
    private String cst;
    /**
     * Numero de ordem do item na nota fiscal.
     */
    private int numeroItem;
    /**
     * Codigo do produto ou serviço do informante.
     */
    private String codigo;
    /**
     * Tipo de operacao associada ao registro.
     */
    private TipoOperacao tipoOperacao;
    /**
     * CNPJ da concessionaria.
     */
    private String cnpjConcessionaria;
    /**
     * Aliquota do IPI (com 2 decimais).
     */
    private double ipi;
    /**
     * Codigo do chassi do veiculo.
     */
    private String chassi;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">          
    /**
     * CNPJ ou CPF do adquirente.
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ ou CPF do adquirente.
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Codigo do modelo da nota fiscal.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo da nota fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Serie da nota fiscal.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie da nota fiscal.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Numero da nota fiscal.
     * @return the numero
     */
    public String getNumero() {
        return numero;
    }

    /**
     * Numero da nota fiscal.
     * @param numero the numero to set
     */
    public void setNumero(String numero) {
        this.numero = numero;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @return the cfop
     */
    public String getCfop() {
        return cfop;
    }

    /**
     * Codigo Fiscal de Operacao e Prestacao.
     * @param cfop the cfop to set
     */
    public void setCfop(String cfop) {
        this.cfop = cfop;
    }

    /**
     * Codigo da situacao tributaria.
     * @return the cst
     */
    public String getCst() {
        return cst;
    }

    /**
     * Codigo da situacao tributaria.
     * @param cst the cst to set
     */
    public void setCst(String cst) {
        this.cst = cst;
    }

    /**
     * Numero de ordem do item na nota fiscal.
     * @return the numeroItem
     */
    public int getNumeroItem() {
        return numeroItem;
    }

    /**
     * Numero de ordem do item na nota fiscal.
     * @param numeroItem the numeroItem to set
     */
    public void setNumeroItem(int numeroItem) {
        this.numeroItem = numeroItem;
    }

    /**
     * Codigo do produto ou serviço do informante.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do produto ou serviço do informante.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Tipo de operacao associada ao registro.
     * @return the tipoOperacao
     */
    public TipoOperacao getTipoOperacao() {
        return tipoOperacao;
    }

    /**
     * Tipo de operacao associada ao registro.
     * @param tipoOperacao the tipoOperacao to set
     */
    public void setTipoOperacao(TipoOperacao tipoOperacao) {
        this.tipoOperacao = tipoOperacao;
    }

    /**
     * CNPJ da concessionaria.
     * @return the cnpjConcessionaria
     */
    public String getCnpjConcessionaria() {
        return cnpjConcessionaria;
    }

    /**
     * CNPJ da concessionaria.
     * @param cnpjConcessionaria the cnpjConcessionaria to set
     */
    public void setCnpjConcessionaria(String cnpjConcessionaria) {
        this.cnpjConcessionaria = cnpjConcessionaria;
    }

    /**
     * Aliquota do IPI (com 2 decimais).
     * @return the ipi
     */
    public double getIpi() {
        return ipi;
    }

    /**
     * Aliquota do IPI (com 2 decimais).
     * @param ipi the ipi to set
     */
    public void setIpi(double ipi) {
        this.ipi = ipi;
    }

    /**
     * Codigo do chassi do veiculo.
     * @return the chassi
     */
    public String getChassi() {
        return chassi;
    }

    /**
     * Codigo do chassi do veiculo.
     * @param chassi the chassi to set
     */
    public void setChassi(String chassi) {
        this.chassi = chassi;
    }
    // </editor-fold>
    
}