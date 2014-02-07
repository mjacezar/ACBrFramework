package jACBrFramework.sped.bloco0;

import jACBrFramework.sped.CodFinalidade;
import jACBrFramework.sped.Perfil;
import jACBrFramework.sped.TipoAtividade;
import jACBrFramework.sped.VersaoLeiaute;
import java.util.Date;

/**
 * Abertura do arquivo digital e identificacao da entidade.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 08:20:09, revisao: $Id$
 */
public class Registro0000 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Codigo da versao do leiaute conforme a tabela indicada no Ato Cotepe.
     */
    private VersaoLeiaute COD_VER;
    /**
     * Codigo da finalidade do arquivo.
     */
    private CodFinalidade COD_FIN;
    /**
     * Data inicial das informacoes contidas no arquivo.
     */
    private Date DT_INI;
    /**
     * Data final das informacoes contidas no arquivo.
     */
    private Date DT_FIN;
    /**
     * NOME empresarial da entidade.
     */
    private String NOME;
    /**
     * Numero de inscricao da entidade no CNPJ.
     */
    private String CNPJ;
    /**
     * Numero de inscricao da entidade no CPF.
     */
    private String CPF;
    /**
     * Sigla da unidade da federacao da entidade.
     */
    private String UF;
    /**
     * Inscricao Estadual da entidade.
     */
    private String IE;
    /**
     * Codigo do municipio do domicílio fiscal da entidade, conforme a tabela IBGE.
     */
    private int COD_MUN;
    /**
     * Inscricao Municipal da entidade.
     */
    private String IM;
    /**
     * Inscricao da entidade na SUFRAMA.
     */
    private String SUFRAMA;
    /**
     * Perfil de apresentacao do arquivo fiscal.
     */
    private Perfil IND_PERFIL;
    /**
     * Indicador de tipo de atividade.
     */
    private TipoAtividade IND_ATIV;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        
    /**
     * Codigo da versao do leiaute conforme a tabela indicada no Ato Cotepe.
     * @return the COD_VER
     */
    public VersaoLeiaute getCOD_VER() {
        return COD_VER;
    }

    /**
     * Codigo da versao do leiaute conforme a tabela indicada no Ato Cotepe.
     * @param COD_VER the COD_VER to set
     */
    public void setCOD_VER(VersaoLeiaute COD_VER) {
        this.COD_VER = COD_VER;
    }

    /**
     * Codigo da finalidade do arquivo.
     * @return the COD_FIN
     */
    public CodFinalidade getCOD_FIN() {
        return COD_FIN;
    }

    /**
     * Codigo da finalidade do arquivo.
     * @param COD_FIN the COD_FIN to set
     */
    public void setCOD_FIN(CodFinalidade COD_FIN) {
        this.COD_FIN = COD_FIN;
    }

    /**
     * Data inicial das informacoes contidas no arquivo.
     * @return the DT_INI
     */
    public Date getDT_INI() {
        return DT_INI;
    }

    /**
     * Data inicial das informacoes contidas no arquivo.
     * @param DT_INI the DT_INI to set
     */
    public void setDT_INI(Date DT_INI) {
        this.DT_INI = DT_INI;
    }

    /**
     * Data final das informacoes contidas no arquivo.
     * @return the DT_FIN
     */
    public Date getDT_FIN() {
        return DT_FIN;
    }

    /**
     * Data final das informacoes contidas no arquivo.
     * @param DT_FIN the DT_FIN to set
     */
    public void setDT_FIN(Date DT_FIN) {
        this.DT_FIN = DT_FIN;
    }

    /**
     * NOME empresarial da entidade.
     * @return the NOME
     */
    public String getNOME() {
        return NOME;
    }

    /**
     * NOME empresarial da entidade.
     * @param NOME the NOME to set
     */
    public void setNOME(String NOME) {
        this.NOME = NOME;
    }

    /**
     * Numero de inscricao da entidade no CNPJ.
     * @return the CNPJ
     */
    public String getCNPJ() {
        return CNPJ;
    }

    /**
     * Numero de inscricao da entidade no CNPJ.
     * @param CNPJ the CNPJ to set
     */
    public void setCNPJ(String CNPJ) {
        this.CNPJ = CNPJ;
    }

    /**
     * Numero de inscricao da entidade no CPF.
     * @return the CPF
     */
    public String getCPF() {
        return CPF;
    }

    /**
     * Numero de inscricao da entidade no CPF.
     * @param CPF the CPF to set
     */
    public void setCPF(String CPF) {
        this.CPF = CPF;
    }

    /**
     * Sigla da unidade da federacao da entidade.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da unidade da federacao da entidade.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
    }

    /**
     * Inscricao Estadual da entidade.
     * @return the IE
     */
    public String getIE() {
        return IE;
    }

    /**
     * Inscricao Estadual da entidade.
     * @param IE the IE to set
     */
    public void setIE(String IE) {
        this.IE = IE;
    }

    /**
     * Codigo do municipio do domicílio fiscal da entidade, conforme a tabela IBGE.
     * @return the COD_MUN
     */
    public int getCOD_MUN() {
        return COD_MUN;
    }

    /**
     * Codigo do municipio do domicílio fiscal da entidade, conforme a tabela IBGE.
     * @param COD_MUN the COD_MUN to set
     */
    public void setCOD_MUN(int COD_MUN) {
        this.COD_MUN = COD_MUN;
    }

    /**
     * Inscricao Municipal da entidade.
     * @return the IM
     */
    public String getIM() {
        return IM;
    }

    /**
     * Inscricao Municipal da entidade.
     * @param IM the IM to set
     */
    public void setIM(String IM) {
        this.IM = IM;
    }

    /**
     * Inscricao da entidade na SUFrama.
     * @return the SUFRAMA
     */
    public String getSUFRAMA() {
        return SUFRAMA;
    }

    /**
     * Inscricao da entidade na SUFrama.
     * @param SUFRAMA the SUFRAMA to set
     */
    public void setSUFRAMA(String SUFRAMA) {
        this.SUFRAMA = SUFRAMA;
    }

    /**
     * Perfil de apresentacao do arquivo fiscal.
     * @return the IND_PERFIL
     */
    public Perfil getIND_PERFIL() {
        return IND_PERFIL;
    }

    /**
     * Perfil de apresentacao do arquivo fiscal.
     * @param IND_PERFIL the IND_PERFIL to set
     */
    public void setIND_PERFIL(Perfil IND_PERFIL) {
        this.IND_PERFIL = IND_PERFIL;
    }

    /**
     * Indicador de tipo de atividade.
     * @return the IND_ATIV
     */
    public TipoAtividade getIND_ATIV() {
        return IND_ATIV;
    }

    /**
     * Indicador de tipo de atividade.
     * @param IND_ATIV the IND_ATIV to set
     */
    public void setIND_ATIV(TipoAtividade IND_ATIV) {
        this.IND_ATIV = IND_ATIV;
    }
    // </editor-fold>
    
}