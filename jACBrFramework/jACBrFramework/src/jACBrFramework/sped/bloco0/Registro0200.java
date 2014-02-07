package jACBrFramework.sped.bloco0;

import jACBrFramework.sped.TipoItem;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Tabela de identificacao de itens, produtos e servicos.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 09:28:59, revisao: $Id$
 */
public class Registro0200 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Listagem de registro alterados.
     */
    private Collection<Registro0205> registro0205 = new ArrayList<Registro0205>();
    /**
     * Listagem de itens de combustivel.
     */
    private Collection<Registro0206> registro0206 = new ArrayList<Registro0206>();
    /**
     * Listagem de fatores de conversao.
     */
    private Collection<Registro0220> registro0220 = new ArrayList<Registro0220>();
    /**
     * Codigo do item.
     */
    private String COD_ITEM;
    /**
     * Descricao do item.
     */
    private String DESCR_ITEM;
    /**
     * Representacao alfanumerico do codigo de barra do produto, se houver.
     */
    private String COD_BARRA;
    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     */
    private String COD_ANT_ITEM;
    /**
     * Unidade de medida utilizada na quantificacao de estoques.
     */
    private String UNID_INV;
    /**
     * Tipo do item - Atividades Industriais, Comerciais e Servicos.
     */
    private TipoItem TIPO_ITEM;
    /**
     * Codigo da Nomenclatura Comum do Mercosul.
     */
    private String COD_NCM;
    /**
     * Codigo EX, conforme a TIPI.
     */
    private String EX_IPI;
    /**
     * Codigo do genero do item, conforme a Tabela 4.2.1.
     */
    private String COD_GEN;
    /**
     * Codigo do servico conforme lista do Anexo I da Lei Complementar Federal No. 116/03.
     */
    private String COD_LST;
    /**
     * Aliquota de ICMS aplicavel ao item nas operacoes internas.
     */
    private double ALIQ_ICMS;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Listagem de registro alterados.
     * @return the registro0205
     */
    public Collection<Registro0205> getRegistro0205() {
        return registro0205;
    }

    /**
     * Listagem de itens de combustivel.
     * @return the registro0206
     */
    public Collection<Registro0206> getRegistro0206() {
        return registro0206;
    }

    /**
     * Listagem de fatores de conversao.
     * @return the registro0220
     */
    public Collection<Registro0220> getRegistro0220() {
        return registro0220;
    }
    
    /**
     * Codigo do item.
     * @return the COD_ITEM
     */
    public String getCOD_ITEM() {
        return COD_ITEM;
    }

    /**
     * Codigo do item.
     * @param COD_ITEM the COD_ITEM to set
     */
    public void setCOD_ITEM(String COD_ITEM) {
        this.COD_ITEM = COD_ITEM;
    }

    /**
     * Descricao do item.
     * @return the DESCR_ITEM
     */
    public String getDESCR_ITEM() {
        return DESCR_ITEM;
    }

    /**
     * Descricao do item.
     * @param DESCR_ITEM the DESCR_ITEM to set
     */
    public void setDESCR_ITEM(String DESCR_ITEM) {
        this.DESCR_ITEM = DESCR_ITEM;
    }

    /**
     * Representacao alfanumerico do codigo de barra do produto, se houver.
     * @return the COD_BARRA
     */
    public String getCOD_BARRA() {
        return COD_BARRA;
    }

    /**
     * Representacao alfanumerico do codigo de barra do produto, se houver.
     * @param COD_BARRA the COD_BARRA to set
     */
    public void setCOD_BARRA(String COD_BARRA) {
        this.COD_BARRA = COD_BARRA;
    }

    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     * @return the COD_ANT_ITEM
     */
    public String getCOD_ANT_ITEM() {
        return COD_ANT_ITEM;
    }

    /**
     * Codigo anterior do item com relacao a ultima informacao apresentada.
     * @param COD_ANT_ITEM the COD_ANT_ITEM to set
     */
    public void setCOD_ANT_ITEM(String COD_ANT_ITEM) {
        this.COD_ANT_ITEM = COD_ANT_ITEM;
    }

    /**
     * Unidade de medida utilizada na quantificacao de estoques.
     * @return the UNID_INV
     */
    public String getUNID_INV() {
        return UNID_INV;
    }

    /**
     * Unidade de medida utilizada na quantificacao de estoques.
     * @param UNID_INV the UNID_INV to set
     */
    public void setUNID_INV(String UNID_INV) {
        this.UNID_INV = UNID_INV;
    }

    /**
     * Tipo do item - Atividades Industriais, Comerciais e Servicos.
     * @return the TIPO_ITEM
     */
    public TipoItem getTIPO_ITEM() {
        return TIPO_ITEM;
    }

    /**
     * Tipo do item - Atividades Industriais, Comerciais e Servicos.
     * @param TIPO_ITEM the TIPO_ITEM to set
     */
    public void setTIPO_ITEM(TipoItem TIPO_ITEM) {
        this.TIPO_ITEM = TIPO_ITEM;
    }

    /**
     * Codigo da Nomenclatura Comum do Mercosul.
     * @return the COD_NCM
     */
    public String getCOD_NCM() {
        return COD_NCM;
    }

    /**
     * Codigo da Nomenclatura Comum do Mercosul.
     * @param COD_NCM the COD_NCM to set
     */
    public void setCOD_NCM(String COD_NCM) {
        this.COD_NCM = COD_NCM;
    }

    /**
     * Codigo EX, conforme a TIPI.
     * @return the EX_IPI
     */
    public String getEX_IPI() {
        return EX_IPI;
    }

    /**
     * Codigo EX, conforme a TIPI.
     * @param EX_IPI the EX_IPI to set
     */
    public void setEX_IPI(String EX_IPI) {
        this.EX_IPI = EX_IPI;
    }

    /**
     * Codigo do genero do item, conforme a Tabela 4.2.1.
     * @return the COD_GEN
     */
    public String getCOD_GEN() {
        return COD_GEN;
    }

    /**
     * Codigo do genero do item, conforme a Tabela 4.2.1.
     * @param COD_GEN the COD_GEN to set
     */
    public void setCOD_GEN(String COD_GEN) {
        this.COD_GEN = COD_GEN;
    }

    /**
     * Codigo do servico conforme lista do Anexo I da Lei Complementar Federal No. 116/03.
     * @return the COD_LST
     */
    public String getCOD_LST() {
        return COD_LST;
    }

    /**
     * Codigo do servico conforme lista do Anexo I da Lei Complementar Federal No. 116/03.
     * @param COD_LST the COD_LST to set
     */
    public void setCOD_LST(String COD_LST) {
        this.COD_LST = COD_LST;
    }

    /**
     * Aliquota de ICMS aplicavel ao item nas operacoes internas.
     * @return the ALIQ_ICMS
     */
    public double getALIQ_ICMS() {
        return ALIQ_ICMS;
    }

    /**
     * Aliquota de ICMS aplicavel ao item nas operacoes internas.
     * @param ALIQ_ICMS the ALIQ_ICMS to set
     */
    public void setALIQ_ICMS(double ALIQ_ICMS) {
        this.ALIQ_ICMS = ALIQ_ICMS;
    }
    // </editor-fold>
    
}