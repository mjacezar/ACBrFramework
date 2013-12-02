package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Informacoes complementares de exportacoes.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:38:37, revisao: $Id$
 */
public class SintegraRegistro86 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Num. do registro de Exportacao.
     */
    private String registroExportacao;
    /**
     * Data do Registro de Exportacao.
     */
    private Date dataRegistro;
    /**
     * CNPJ do contribuinte Produtor/Industrial/Fabricante que promoveu a remessa com fim especifico.
     */
    private String cpfCnpj;
    /**
     * Inscricao Estadual do contribuinte Produtor/Industrial/ Fabricante que promoveu a remessa com fim especifico.
     */
    private String inscricao;
    /**
     * Unidade da Federacao do Produtor/Industrial/Fabricante que promoveu remessa com fim especifico.zNuNN
     */
    private String uf;
    /**
     * Num. da Nota Fiscal de remessa com fim especifico de exportacao recebida.
     */
    private String numeroNotaFiscal;
    /**
     * Data de emissao da Nota Fiscal da remessa com fim especifico.
     */
    private Date dataDocumento;
    /**
     * Codigo do modelo do documento fiscal.
     */
    private String modelo;
    /**
     * Serie da Nota Fiscal.
     */
    private String serie;
    /**
     * Codigo do produto adotado no registro tipo 75 quando do registro de entrada 
     * da Nota Fiscal de remessa com fim especifico.
     */
    private String codigo;
    /**
     * Quantidade, efetivamente exportada, do produto declarado na Nota Fiscal 
     * de remessa com fim especifico recebida.
     */
    private double quantidade;
    /**
     * Valor unitario do produto.
     */
    private double valorUnitario;
    /**
     * Valor total do produto (valor unitario multiplicado pela quantidade) – com 2 decimais.
     */
    private double valorTotalProduto;
    /**
     * Preencher conforme tabela de codigos de relacionamento entre Registro de 
     * Exportacao e Nota Fiscal de remessa com fim especifico.
     */
    private String relacionamento;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Num. do registro de Exportacao.
     * @return the registroExportacao
     */
    public String getRegistroExportacao() {
        return registroExportacao;
    }

    /**
     * Num. do registro de Exportacao.
     * @param registroExportacao the registroExportacao to set
     */
    public void setRegistroExportacao(String registroExportacao) {
        this.registroExportacao = registroExportacao;
    }

    /**
     * Data do Registro de Exportacao.
     * @return the dataRegistro
     */
    public Date getDataRegistro() {
        return dataRegistro;
    }

    /**
     * Data do Registro de Exportacao.
     * @param dataRegistro the dataRegistro to set
     */
    public void setDataRegistro(Date dataRegistro) {
        this.dataRegistro = dataRegistro;
    }

    /**
     * CNPJ do contribuinte Produtor/Industrial/Fabricante que promoveu a remessa com fim especifico.
     * @return the cpfCnpj
     */
    public String getCpfCnpj() {
        return cpfCnpj;
    }

    /**
     * CNPJ do contribuinte Produtor/Industrial/Fabricante que promoveu a remessa com fim especifico.
     * @param cpfCnpj the cpfCnpj to set
     */
    public void setCpfCnpj(String cpfCnpj) {
        this.cpfCnpj = cpfCnpj;
    }

    /**
     * Inscricao Estadual do contribuinte Produtor/Industrial/ Fabricante que promoveu a remessa com fim especifico.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao Estadual do contribuinte Produtor/Industrial/ Fabricante que promoveu a remessa com fim especifico.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Unidade da Federacao do Produtor/Industrial/Fabricante que promoveu remessa com fim especifico.zNuNN
     * @return the uf
     */
    public String getUf() {
        return uf;
    }

    /**
     * Unidade da Federacao do Produtor/Industrial/Fabricante que promoveu remessa com fim especifico.zNuNN
     * @param uf the uf to set
     */
    public void setUf(String uf) {
        this.uf = uf;
    }

    /**
     * Num. da Nota Fiscal de remessa com fim especifico de exportacao recebida.
     * @return the numeroNotaFiscal
     */
    public String getNumeroNotaFiscal() {
        return numeroNotaFiscal;
    }

    /**
     * Num. da Nota Fiscal de remessa com fim especifico de exportacao recebida.
     * @param numeroNotaFiscal the numeroNotaFiscal to set
     */
    public void setNumeroNotaFiscal(String numeroNotaFiscal) {
        this.numeroNotaFiscal = numeroNotaFiscal;
    }

    /**
     * Data de emissao da Nota Fiscal da remessa com fim especifico.
     * @return the dataDocumento
     */
    public Date getDataDocumento() {
        return dataDocumento;
    }

    /**
     * Data de emissao da Nota Fiscal da remessa com fim especifico.
     * @param dataDocumento the dataDocumento to set
     */
    public void setDataDocumento(Date dataDocumento) {
        this.dataDocumento = dataDocumento;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @return the modelo
     */
    public String getModelo() {
        return modelo;
    }

    /**
     * Codigo do modelo do documento fiscal.
     * @param modelo the modelo to set
     */
    public void setModelo(String modelo) {
        this.modelo = modelo;
    }

    /**
     * Serie da Nota Fiscal.
     * @return the serie
     */
    public String getSerie() {
        return serie;
    }

    /**
     * Serie da Nota Fiscal.
     * @param serie the serie to set
     */
    public void setSerie(String serie) {
        this.serie = serie;
    }

    /**
     * Codigo do produto adotado no registro tipo 75 quando do registro de entrada
     * da Nota Fiscal de remessa com fim especifico.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do produto adotado no registro tipo 75 quando do registro de entrada
     * da Nota Fiscal de remessa com fim especifico.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Quantidade, efetivamente exportada, do produto declarado na Nota Fiscal
     * de remessa com fim especifico recebida.
     * @return the quantidade
     */
    public double getQuantidade() {
        return quantidade;
    }

    /**
     * Quantidade, efetivamente exportada, do produto declarado na Nota Fiscal
     * de remessa com fim especifico recebida.
     * @param quantidade the quantidade to set
     */
    public void setQuantidade(double quantidade) {
        this.quantidade = quantidade;
    }

    /**
     * Valor unitario do produto.
     * @return the valorUnitario
     */
    public double getValorUnitario() {
        return valorUnitario;
    }

    /**
     * Valor unitario do produto.
     * @param valorUnitario the valorUnitario to set
     */
    public void setValorUnitario(double valorUnitario) {
        this.valorUnitario = valorUnitario;
    }

    /**
     * Valor total do produto (valor unitario multiplicado pela quantidade) – com 2 decimais.
     * @return the valorTotalProduto
     */
    public double getValorTotalProduto() {
        return valorTotalProduto;
    }

    /**
     * Valor total do produto (valor unitario multiplicado pela quantidade) – com 2 decimais.
     * @param valorTotalProduto the valorTotalProduto to set
     */
    public void setValorTotalProduto(double valorTotalProduto) {
        this.valorTotalProduto = valorTotalProduto;
    }

    /**
     * Preencher conforme tabela de codigos de relacionamento entre Registro de
     * Exportacao e Nota Fiscal de remessa com fim especifico.
     * @return the relacionamento
     */
    public String getRelacionamento() {
        return relacionamento;
    }

    /**
     * Preencher conforme tabela de codigos de relacionamento entre Registro de
     * Exportacao e Nota Fiscal de remessa com fim especifico.
     * @param relacionamento the relacionamento to set
     */
    public void setRelacionamento(String relacionamento) {
        this.relacionamento = relacionamento;
    }    
    // </editor-fold>        
    
}