package jACBrFramework.sped.bloco0;

import jACBrFramework.sped.TipoMercadoria;
import java.util.ArrayList;
import java.util.Collection;

/**
 * Cadastro de bens ou componentes do ativo imobilizado.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 10:03:28, revisao: $Id$
 */
public class Registro0300 {

    // <editor-fold defaultstate="collapsed" desc="Attributes"> 
    /**
     * Listagem sobre a informacao dos bens.
     */
    private Collection<Registro0305> registro0305 = new ArrayList<Registro0305>();
    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial do estabelecimento informante.
     */
    private String COD_IND_BEM;
    /**
     * Identificacao do tipo de mercadoria.
     */
    private TipoMercadoria IDENT_MERC;
    /**
     * Descricao do bem ou componente (modelo, marca e outras caracteristicas necessarias a sua individualizacao).
     */
    private String DESCR_ITEM;
    /**
     * Codigo de cadastro do bem principal nos casos em que o bem ou componente ( campo 02) esteja vinculado a um bem principal.
     */
    private String COD_PRNC;
    /**
     * Codigo da conta analitica de contabilizacao do bem ou componente (campo 06 do Registro 0500).
     */
    private String COD_CTA;
    /**
     * Numero total de parcelas a serem apropriadas, segundo a legislacao de cada unidade federada.
     */
    private double NR_PARC;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Listagem sobre a informacao dos bens.
     * @return the registro0305
     */
    public Collection<Registro0305> getRegistro0305() {
        return registro0305;
    }

    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial do estabelecimento informante.
     * @return the COD_IND_BEM
     */
    public String getCOD_IND_BEM() {
        return COD_IND_BEM;
    }

    /**
     * Codigo individualizado do bem ou componente adotado no controle patrimonial do estabelecimento informante.
     * @param COD_IND_BEM the COD_IND_BEM to set
     */
    public void setCOD_IND_BEM(String COD_IND_BEM) {
        this.COD_IND_BEM = COD_IND_BEM;
    }

    /**
     * Identificacao do tipo de mercadoria.
     * @return the IDENT_MERC
     */
    public TipoMercadoria getIDENT_MERC() {
        return IDENT_MERC;
    }

    /**
     * Identificacao do tipo de mercadoria.
     * @param IDENT_MERC the IDENT_MERC to set
     */
    public void setIDENT_MERC(TipoMercadoria IDENT_MERC) {
        this.IDENT_MERC = IDENT_MERC;
    }

    /**
     * Descricao do bem ou componente (modelo, marca e outras caracteristicas necessarias a sua individualizacao).
     * @return the DESCR_ITEM
     */
    public String getDESCR_ITEM() {
        return DESCR_ITEM;
    }

    /**
     * Descricao do bem ou componente (modelo, marca e outras caracteristicas necessarias a sua individualizacao).
     * @param DESCR_ITEM the DESCR_ITEM to set
     */
    public void setDESCR_ITEM(String DESCR_ITEM) {
        this.DESCR_ITEM = DESCR_ITEM;
    }

    /**
     * Codigo de cadastro do bem principal nos casos em que o bem ou componente ( campo 02) esteja vinculado a um bem principal.
     * @return the COD_PRNC
     */
    public String getCOD_PRNC() {
        return COD_PRNC;
    }

    /**
     * Codigo de cadastro do bem principal nos casos em que o bem ou componente ( campo 02) esteja vinculado a um bem principal.
     * @param COD_PRNC the COD_PRNC to set
     */
    public void setCOD_PRNC(String COD_PRNC) {
        this.COD_PRNC = COD_PRNC;
    }

    /**
     * Codigo da conta analitica de contabilizacao do bem ou componente (campo 06 do Registro 0500).
     * @return the COD_CTA
     */
    public String getCOD_CTA() {
        return COD_CTA;
    }

    /**
     * Codigo da conta analitica de contabilizacao do bem ou componente (campo 06 do Registro 0500).
     * @param COD_CTA the COD_CTA to set
     */
    public void setCOD_CTA(String COD_CTA) {
        this.COD_CTA = COD_CTA;
    }

    /**
     * Numero total de parcelas a serem apropriadas, segundo a legislacao de cada unidade federada.
     * @return the NR_PARC
     */
    public double getNR_PARC() {
        return NR_PARC;
    }

    /**
     * Numero total de parcelas a serem apropriadas, segundo a legislacao de cada unidade federada.
     * @param NR_PARC the NR_PARC to set
     */
    public void setNR_PARC(double NR_PARC) {
        this.NR_PARC = NR_PARC;
    }
    // </editor-fold>
    
}