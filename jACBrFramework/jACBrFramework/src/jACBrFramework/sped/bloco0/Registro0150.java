package jACBrFramework.sped.bloco0;

import java.util.ArrayList;
import java.util.Collection;

/**
 * Tabela de cadastro do participante.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:03:26, revisao: $Id$
 */
public class Registro0150 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Listagem de registro alterados.
     */
    private Collection<Registro0175> registro0175 = new ArrayList<Registro0175>();
    /**
     * Codigo de identificacao do participante no arquivo.
     */
    private String COD_PART;
    /**
     * Nome pessoal ou empresarial do participante.
     */
    private String NOME;
    /**
     * Codigo do pais do participante, conforme a tabela indicada no item 3.2.1.
     */
    private String COD_PAIS;
    /**
     * CNPJ do participante.
     */
    private String CNPJ;
    /**
     * CPF do participante.
     */
    private String CPF;
    /**
     * Inscricao Estadual do participante.
     */
    private String IE;
    /**
     * Codigo do municipio, conforme a tabela IBGE.
     */
    private int COD_MUN;
    /**
     * Numero de inscricao do participante na Suframa.
     */
    private String SUFRAMA;
    /**
     * Logradouro e ENDERECO do imovel.
     */
    private String ENDERECO;
    /**
     * Numero do imovel.
     */
    private String NUM;
    /**
     * Dados complementares do ENDERECO.
     */
    private String COMPL;
    /**
     * Bairro em que o imovel esta situado.
     */
    private String BAIRRO;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">       
    /**
     * Listagem de registro alterados.
     * @return the registro0175
     */
    public Collection<Registro0175> getRegistro0175() {
        return registro0175;
    }

    /**
     * Codigo de identificacao do participante no arquivo.
     * @return the COD_PART
     */
    public String getCOD_PART() {
        return COD_PART;
    }

    /**
     * Codigo de identificacao do participante no arquivo.
     * @param COD_PART the COD_PART to set
     */
    public void setCOD_PART(String COD_PART) {
        this.COD_PART = COD_PART;
    }

    /**
     * Nome pessoal ou empresarial do participante.
     * @return the NOME
     */
    public String getNOME() {
        return NOME;
    }

    /**
     * Nome pessoal ou empresarial do participante.
     * @param NOME the NOME to set
     */
    public void setNOME(String NOME) {
        this.NOME = NOME;
    }

    /**
     * Codigo do pais do participante, conforme a tabela indicada no item 3.2.1.
     * @return the COD_PAIS
     */
    public String getCOD_PAIS() {
        return COD_PAIS;
    }

    /**
     * Codigo do pais do participante, conforme a tabela indicada no item 3.2.1.
     * @param COD_PAIS the COD_PAIS to set
     */
    public void setCOD_PAIS(String COD_PAIS) {
        this.COD_PAIS = COD_PAIS;
    }

    /**
     * CNPJ do participante.
     * @return the CNPJ
     */
    public String getCNPJ() {
        return CNPJ;
    }

    /**
     * CNPJ do participante.
     * @param CNPJ the CNPJ to set
     */
    public void setCNPJ(String CNPJ) {
        this.CNPJ = CNPJ;
    }

    /**
     * CPF do participante.
     * @return the CPF
     */
    public String getCPF() {
        return CPF;
    }

    /**
     * CPF do participante.
     * @param CPF the CPF to set
     */
    public void setCPF(String CPF) {
        this.CPF = CPF;
    }

    /**
     * Inscricao Estadual do participante.
     * @return the IE
     */
    public String getIE() {
        return IE;
    }

    /**
     * Inscricao Estadual do participante.
     * @param IE the IE to set
     */
    public void setIE(String IE) {
        this.IE = IE;
    }

    /**
     * Codigo do municipio, conforme a tabela IBGE.
     * @return the COD_MUN
     */
    public int getCOD_MUN() {
        return COD_MUN;
    }

    /**
     * Codigo do municipio, conforme a tabela IBGE.
     * @param COD_MUN the COD_MUN to set
     */
    public void setCOD_MUN(int COD_MUN) {
        this.COD_MUN = COD_MUN;
    }

    /**
     * Numero de inscricao do participante na Suframa.
     * @return the SUFRAMA
     */
    public String getSUFRAMA() {
        return SUFRAMA;
    }

    /**
     * Numero de inscricao do participante na Suframa.
     * @param SUFRAMA the SUFRAMA to set
     */
    public void setSUFRAMA(String SUFRAMA) {
        this.SUFRAMA = SUFRAMA;
    }

    /**
     * Logradouro e ENDERECO do imovel.
     * @return the ENDERECO
     */
    public String getENDERECO() {
        return ENDERECO;
    }

    /**
     * Logradouro e ENDERECO do imovel.
     * @param ENDERECO the ENDERECO to set
     */
    public void setENDERECO(String ENDERECO) {
        this.ENDERECO = ENDERECO;
    }

    /**
     * Numero do imovel.
     * @return the NUM
     */
    public String getNUM() {
        return NUM;
    }

    /**
     * Numero do imovel.
     * @param numero the NUM to set
     */
    public void setNUM(String NUM) {
        this.NUM = NUM;
    }

    /**
     * Dados complementares do ENDERECO.
     * @return the COMPL
     */
    public String getCOMPL() {
        return COMPL;
    }

    /**
     * Dados complementares do ENDERECO.
     * @param COMPL the COMPL to set
     */
    public void setCOMPL(String COMPL) {
        this.COMPL = COMPL;
    }

    /**
     * Bairro em que o imovel esta situado.
     * @return the BAIRRO
     */
    public String getBAIRRO() {
        return BAIRRO;
    }

    /**
     * Bairro em que o imovel esta situado.
     * @param BAIRRO the BAIRRO to set
     */
    public void setBAIRRO(String BAIRRO) {
        this.BAIRRO = BAIRRO;
    }
    // </editor-fold>
    
}