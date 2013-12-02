package jACBrFramework.sintegra;

import java.util.Date;

/**
 * Codigo de produtos ou servicos.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:38:00, revisao: $Id$
 */
public class SintegraRegistro75 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">        
    /**
     * Codigo do produto ou serviço utilizado pelo contribuinte.
     */
    private String codigo;
    /**
     * Descricao do produto ou servico.
     */
    private String descricao;
    /**
     * % de reducao na base de calculo do ICMS, nas operacoes internas (com 2 decimais).
     */
    private double reducao;
    /**
     * Base de calculo do ICMS de substituicao tributaria (com 2 decimais).
     */
    private double baseST;
    /**
     * Aliquota do IPI do produto (com 2 decimais).
     */
    private double aliquotaIpi;
    /**
     * Codificacao da Nomenclatura Comum do Mercosul.
     */
    private String ncm;
    /**
     * Unidade de medida de comercializacao do produto (un, kg, m, m3, sc, frd, kWh, etc..).
     */
    private String unidade;
    /**
     * Aliquota do ICMS aplicavel a mercadoria ou serviço nas operacoes ou 
     * prestacoes internas ou naquelas que se tiverem iniciado no exterior (com 2 decimais).
     */
    private double aliquotaICMS;
    /**
     * Data final do periodo de validade das informacoes.
     */
    private Date dataFinal;
    /**
     * Data inicial do periodo de validade das informacoes.
     */
    private Date dataInicial;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">                  
    /**
     * Codigo do produto ou serviço utilizado pelo contribuinte.
     * @return the codigo
     */
    public String getCodigo() {
        return codigo;
    }

    /**
     * Codigo do produto ou serviço utilizado pelo contribuinte.
     * @param codigo the codigo to set
     */
    public void setCodigo(String codigo) {
        this.codigo = codigo;
    }

    /**
     * Descricao do produto ou servico.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Descricao do produto ou servico.
     * @param descricao the descricao to set
     */
    public void setDescricao(String descricao) {
        this.descricao = descricao;
    }

    /**
     * % de reducao na base de calculo do ICMS, nas operacoes internas (com 2 decimais).
     * @return the reducao
     */
    public double getReducao() {
        return reducao;
    }

    /**
     * % de reducao na base de calculo do ICMS, nas operacoes internas (com 2 decimais).
     * @param reducao the reducao to set
     */
    public void setReducao(double reducao) {
        this.reducao = reducao;
    }

    /**
     * Base de calculo do ICMS de substituicao tributaria (com 2 decimais).
     * @return the baseST
     */
    public double getBaseST() {
        return baseST;
    }

    /**
     * Base de calculo do ICMS de substituicao tributaria (com 2 decimais).
     * @param baseST the baseST to set
     */
    public void setBaseST(double baseST) {
        this.baseST = baseST;
    }

    /**
     * Aliquota do IPI do produto (com 2 decimais).
     * @return the aliquotaIpi
     */
    public double getAliquotaIpi() {
        return aliquotaIpi;
    }

    /**
     * Aliquota do IPI do produto (com 2 decimais).
     * @param aliquotaIpi the aliquotaIpi to set
     */
    public void setAliquotaIpi(double aliquotaIpi) {
        this.aliquotaIpi = aliquotaIpi;
    }

    /**
     * Codificacao da Nomenclatura Comum do Mercosul.
     * @return the ncm
     */
    public String getNcm() {
        return ncm;
    }

    /**
     * Codificacao da Nomenclatura Comum do Mercosul.
     * @param ncm the ncm to set
     */
    public void setNcm(String ncm) {
        this.ncm = ncm;
    }

    /**
     * Unidade de medida de comercializacao do produto (un, kg, m, m3, sc, frd, kWh, etc..).
     * @return the unidade
     */
    public String getUnidade() {
        return unidade;
    }

    /**
     * Unidade de medida de comercializacao do produto (un, kg, m, m3, sc, frd, kWh, etc..).
     * @param unidade the unidade to set
     */
    public void setUnidade(String unidade) {
        this.unidade = unidade;
    }

    /**
     * Aliquota do ICMS aplicavel a mercadoria ou serviço nas operacoes ou
     * prestacoes internas ou naquelas que se tiverem iniciado no exterior (com 2 decimais).
     * @return the aliquotaICMS
     */
    public double getAliquotaICMS() {
        return aliquotaICMS;
    }

    /**
     * Aliquota do ICMS aplicavel a mercadoria ou serviço nas operacoes ou
     * prestacoes internas ou naquelas que se tiverem iniciado no exterior (com 2 decimais).
     * @param aliquotaICMS the aliquotaICMS to set
     */
    public void setAliquotaICMS(double aliquotaICMS) {
        this.aliquotaICMS = aliquotaICMS;
    }

    /**
     * Data final do periodo de validade das informacoes.
     * @return the dataFinal
     */
    public Date getDataFinal() {
        return dataFinal;
    }

    /**
     * Data final do periodo de validade das informacoes.
     * @param dataFinal the dataFinal to set
     */
    public void setDataFinal(Date dataFinal) {
        this.dataFinal = dataFinal;
    }

    /**
     * Data inicial do periodo de validade das informacoes.
     * @return the dataInicial
     */
    public Date getDataInicial() {
        return dataInicial;
    }

    /**
     * Data inicial do periodo de validade das informacoes.
     * @param dataInicial the dataInicial to set
     */
    public void setDataInicial(Date dataInicial) {
        this.dataInicial = dataInicial;
    }
    // </editor-fold>       
    
}