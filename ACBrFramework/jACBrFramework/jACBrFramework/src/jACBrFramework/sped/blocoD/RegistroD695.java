package jACBrFramework.sped.blocoD;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Consolidacao da Prestacao de Servicos - Notas de Serviço de Comunicacao (codigo 21) 
 * e de Servico de Telecomunicacao (codigo 22) (Empresas obrigadas a entrega dos 
 * arquivos previstos no Convenio ICMS No. 115/03).
 * 
 * @author Jose Mauro
 * @version Criado em: 30/01/2014 10:34:30, revisao: $Id$
 */
public class RegistroD695 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Registro analitico dos documentos (codigo 21 e 22).
     */
    private Collection<RegistroD696> registroD696 = new ArrayList<RegistroD696>(); 
    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     */
    private String COD_MOD;
    /**
     * Serie do documento fiscal.
     */
    private String SER;
    /**
     * Numero de ordem inicial.
     */
    private int NRO_ORD_INI;
    /**
     * Numero de ordem final.
     */
    private int NRO_ORD_FIN;
    /**
     * Data de emissao inicial dos documentos / Data inicial de vencimento da fatura.
     */
    private Date DT_DOC_INI;
    /**
     * Data de emissao final dos documentos / Data final do vencimento da fatura.
     */
    private Date DT_DOC_FIN;
    /**
     * Nome do arquivo Mestre de Documento Fiscal.
     */
    private String NOM_MEST;
    /**
     * Chave de codificacao digital do arquivo Mestre de Documento Fiscal.
     */
    private String CHV_COD_DIG;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Registro analitico dos documentos (codigo 21 e 22).
     * @return the registroD696
     */
    public Collection<RegistroD696> getRegistroD696() {
        return registroD696;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     * @return the COD_MOD
     */
    public String getCOD_MOD() {
        return COD_MOD;
    }

    /**
     * Codigo do modelo do documento fiscal, conforme a Tabela 4.1.1 .
     * @param COD_MOD the COD_MOD to set
     */
    public void setCOD_MOD(String COD_MOD) {
        this.COD_MOD = COD_MOD;
    }

    /**
     * Serie do documento fiscal.
     * @return the SER
     */
    public String getSER() {
        return SER;
    }

    /**
     * Serie do documento fiscal.
     * @param SER the SER to set
     */
    public void setSER(String SER) {
        this.SER = SER;
    }

    /**
     * Numero de ordem inicial.
     * @return the NRO_ORD_INI
     */
    public int getNRO_ORD_INI() {
        return NRO_ORD_INI;
    }

    /**
     * Numero de ordem inicial.
     * @param NRO_ORD_INI the NRO_ORD_INI to set
     */
    public void setNRO_ORD_INI(int NRO_ORD_INI) {
        this.NRO_ORD_INI = NRO_ORD_INI;
    }

    /**
     * Numero de ordem final.
     * @return the NRO_ORD_FIN
     */
    public int getNRO_ORD_FIN() {
        return NRO_ORD_FIN;
    }

    /**
     * Numero de ordem final.
     * @param NRO_ORD_FIN the NRO_ORD_FIN to set
     */
    public void setNRO_ORD_FIN(int NRO_ORD_FIN) {
        this.NRO_ORD_FIN = NRO_ORD_FIN;
    }

    /**
     * Data de emissao inicial dos documentos / Data inicial de vencimento da fatura.
     * @return the DT_DOC_INI
     */
    public Date getDT_DOC_INI() {
        return DT_DOC_INI;
    }

    /**
     * Data de emissao inicial dos documentos / Data inicial de vencimento da fatura.
     * @param DT_DOC_INI the DT_DOC_INI to set
     */
    public void setDT_DOC_INI(Date DT_DOC_INI) {
        this.DT_DOC_INI = DT_DOC_INI;
    }

    /**
     * Data de emissao final dos documentos / Data final do vencimento da fatura.
     * @return the DT_DOC_FIN
     */
    public Date getDT_DOC_FIN() {
        return DT_DOC_FIN;
    }

    /**
     * Data de emissao final dos documentos / Data final do vencimento da fatura.
     * @param DT_DOC_FIN the DT_DOC_FIN to set
     */
    public void setDT_DOC_FIN(Date DT_DOC_FIN) {
        this.DT_DOC_FIN = DT_DOC_FIN;
    }

    /**
     * Nome do arquivo Mestre de Documento Fiscal.
     * @return the NOM_MEST
     */
    public String getNOM_MEST() {
        return NOM_MEST;
    }

    /**
     * Nome do arquivo Mestre de Documento Fiscal.
     * @param NOM_MEST the NOM_MEST to set
     */
    public void setNOM_MEST(String NOM_MEST) {
        this.NOM_MEST = NOM_MEST;
    }

    /**
     * Chave de codificacao digital do arquivo Mestre de Documento Fiscal.
     * @return the CHV_COD_DIG
     */
    public String getCHV_COD_DIG() {
        return CHV_COD_DIG;
    }

    /**
     * Chave de codificacao digital do arquivo Mestre de Documento Fiscal.
     * @param CHV_COD_DIG the CHV_COD_DIG to set
     */
    public void setCHV_COD_DIG(String CHV_COD_DIG) {
        this.CHV_COD_DIG = CHV_COD_DIG;
    }
    // </editor-fold>    
    
}