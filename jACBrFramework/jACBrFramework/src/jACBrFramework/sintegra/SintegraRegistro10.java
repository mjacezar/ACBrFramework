package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Registro mestre do Sintegra, destinado a identificacao do estabelecimento do informante. 
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:34:37, revisao: $Id$
 */
public class SintegraRegistro10 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * CNPJ do estabelecimento informante
     */
    private String cnpj;
    /**
     * Inscricao estadual do estabelecimento informante.
     */
    private String inscricao;
    /**
     * Nome comercial (raza social/ denominacao) do contribuinte.
     */
    private String razaoSocial;
    /**
     * Municipio onde esta domiciliado o estabelecimento informante.
     */
    private String cidade;
    /**
     * Unidade da Federacao referente ao Municipio.
     */
    private String estado;
    /**
     * Numero do fax do estabelecimento informante.
     */
    private String telefone;
    /**
     * A data do inicio do periodo referente as informacoes prestadas.
     */
    private Date dataInicial;
    /**
     * A data do fim do periodo referente as informacoes prestadas.
     */
    private Date dataFinal;
    /**
     * Codigo da identificacao da estruturado arquivo magnetico entregue.
     */
    private Convenio convenio;
    /**
     * Codigo da identificacao da natureza das operacoes informadas.
     */
    private NaturezaInformacao naturezaInformacao;
    /**
     * Codigo do finalidade utilizado no arquivo magnetico.
     */
    private FinalidadeArquivo finalidadeArquivo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * CNPJ do estabelecimento informante
     * @return the cnpj
     */
    public String getCnpj() {
        return cnpj;
    }

    /**
     * CNPJ do estabelecimento informante
     * @param cnpj the cnpj to set
     */
    public void setCnpj(String cnpj) {
        this.cnpj = cnpj;
    }

    /**
     * Inscricao estadual do estabelecimento informante.
     * @return the inscricao
     */
    public String getInscricao() {
        return inscricao;
    }

    /**
     * Inscricao estadual do estabelecimento informante.
     * @param inscricao the inscricao to set
     */
    public void setInscricao(String inscricao) {
        this.inscricao = inscricao;
    }

    /**
     * Nome comercial (raza social/ denominacao) do contribuinte.
     * @return the razaoSocial
     */
    public String getRazaoSocial() {
        return razaoSocial;
    }

    /**
     * Nome comercial (raza social/ denominacao) do contribuinte.
     * @param razaoSocial the razaoSocial to set
     */
    public void setRazaoSocial(String razaoSocial) {
        this.razaoSocial = razaoSocial;
    }

    /**
     * Municipio onde esta domiciliado o estabelecimento informante.
     * @return the cidade
     */
    public String getCidade() {
        return cidade;
    }

    /**
     * Municipio onde esta domiciliado o estabelecimento informante.
     * @param cidade the cidade to set
     */
    public void setCidade(String cidade) {
        this.cidade = cidade;
    }

    /**
     * Unidade da Federacao referente ao Municipio.
     * @return the estado
     */
    public String getEstado() {
        return estado;
    }

    /**
     * Unidade da Federacao referente ao Municipio.
     * @param estado the estado to set
     */
    public void setEstado(String estado) {
        this.estado = estado;
    }

    /**
     * Numero do fax do estabelecimento informante.
     * @return the telefone
     */
    public String getTelefone() {
        return telefone;
    }

    /**
     * Numero do fax do estabelecimento informante.
     * @param telefone the telefone to set
     */
    public void setTelefone(String telefone) {
        this.telefone = telefone;
    }

    /**
     * A data do inicio do periodo referente as informacoes prestadas.
     * @return the dataInicial
     */
    public Date getDataInicial() {
        return dataInicial;
    }

    /**
     * A data do inicio do periodo referente as informacoes prestadas.
     * @param dataInicial the dataInicial to set
     */
    public void setDataInicial(Date dataInicial) {
        this.dataInicial = dataInicial;
    }

    /**
     * A data do fim do periodo referente as informacoes prestadas.
     * @return the dataFinal
     */
    public Date getDataFinal() {
        return dataFinal;
    }

    /**
     * A data do fim do periodo referente as informacoes prestadas.
     * @param dataFinal the dataFinal to set
     */
    public void setDataFinal(Date dataFinal) {
        this.dataFinal = dataFinal;
    }

    /**
     * Codigo da identificacao da estruturado arquivo magnetico entregue.
     * @return the convenio
     */
    public Convenio getConvenio() {
        return convenio;
    }

    /**
     * Codigo da identificacao da estruturado arquivo magnetico entregue.
     * @param convenio the convenio to set
     */
    public void setConvenio(Convenio convenio) {
        this.convenio = convenio;
    }

    /**
     * Codigo da identificacao da natureza das operacoes informadas.
     * @return the naturezaInformacao
     */
    public NaturezaInformacao getNaturezaInformacao() {
        return naturezaInformacao;
    }

    /**
     * Codigo da identificacao da natureza das operacoes informadas.
     * @param naturezaInformacao the naturezaInformacao to set
     */
    public void setNaturezaInformacao(NaturezaInformacao naturezaInformacao) {
        this.naturezaInformacao = naturezaInformacao;
    }

    /**
     * Codigo do finalidade utilizado no arquivo magnetico.
     * @return the finalidadeArquivo
     */
    public FinalidadeArquivo getFinalidadeArquivo() {
        return finalidadeArquivo;
    }

    /**
     * Codigo do finalidade utilizado no arquivo magnetico.
     * @param finalidadeArquivo the finalidadeArquivo to set
     */
    public void setFinalidadeArquivo(FinalidadeArquivo finalidadeArquivo) {
        this.finalidadeArquivo = finalidadeArquivo;
    }
    // </editor-fold>

}