package jACBrFramework.sped.blocoC;

import jACBrFramework.sped.TipoOperacaoVeiculo;

/**
 * Operacoes com veiculos novos (codigo 01, 55)
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 15:35:23, revisao: $Id$
 */
public class RegistroC175 {

    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Indicador do tipo de operaCao com veiculo.
     */
    private TipoOperacaoVeiculo IND_VEIC_OPER;
    /**
     * CNPJ da Concessionaria.
     */
    private String CNPJ;
    /**
     * Sigla da unidade da federacao da Concessionaria.
     */
    private String UF;
    /**
     * Chassi do veiculo.
     */
    private String CHASSI_VEIC;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">      
    /**
     * Indicador do tipo de operaCao com veiculo.
     * @return the IND_VEIC_OPER
     */
    public TipoOperacaoVeiculo getIND_VEIC_OPER() {
        return IND_VEIC_OPER;
    }

    /**
     * Indicador do tipo de operaCao com veiculo.
     * @param IND_VEIC_OPER the IND_VEIC_OPER to set
     */
    public void setIND_VEIC_OPER(TipoOperacaoVeiculo IND_VEIC_OPER) {
        this.IND_VEIC_OPER = IND_VEIC_OPER;
    }

    /**
     * CNPJ da Concessionaria.
     * @return the CNPJ
     */
    public String getCNPJ() {
        return CNPJ;
    }

    /**
     * CNPJ da Concessionaria.
     * @param CNPJ the CNPJ to set
     */
    public void setCNPJ(String CNPJ) {
        this.CNPJ = CNPJ;
    }

    /**
     * Sigla da unidade da federacao da Concessionaria.
     * @return the UF
     */
    public String getUF() {
        return UF;
    }

    /**
     * Sigla da unidade da federacao da Concessionaria.
     * @param UF the UF to set
     */
    public void setUF(String UF) {
        this.UF = UF;
    }

    /**
     * Chassi do veiculo.
     * @return the CHASSI_VEIC
     */
    public String getCHASSI_VEIC() {
        return CHASSI_VEIC;
    }

    /**
     * Chassi do veiculo.
     * @param CHASSI_VEIC the CHASSI_VEIC to set
     */
    public void setCHASSI_VEIC(String CHASSI_VEIC) {
        this.CHASSI_VEIC = CHASSI_VEIC;
    }
    // </editor-fold>
    
}