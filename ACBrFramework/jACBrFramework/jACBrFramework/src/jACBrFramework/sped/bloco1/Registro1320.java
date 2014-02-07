package jACBrFramework.sped.bloco1;

/**
 * Volume de vendas.
 * 
 * @author Jose Mauro
 * @version Criado em: 27/01/2014 16:59:54, revisao: $Id$
 */
public class Registro1320 {
    
    //<editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Bico Ligado a Bomba.
     */
    private String NUM_BICO;
    /**
     * Numero da intervencao.
     */
    private String NR_INTERV;
    /**
     * Motivo da Intervencao.
     */
    private String MOT_INTERV;
    /**
     * Nome do Interventor.
     */
    private String NOM_INTERV;
    /**
     * CNPJ da empresa responsavel pela intervencao.
     */
    private String CNPJ_INTERV;
    /**
     * CPF do tecnico responsavel pela intervencao.
     */
    private String CPF_INTERV;
    /**
     * Valor da leitura final do contador, no fechamento do bico.
     */
    private double VAL_FECHA;
    /**
     * Valor da leitura inicial do contador, na abertura do bico.
     */
    private double VAL_ABERT;
    /**
     * Afericoes da Bomba, em litros.
     */
    private double VOL_AFERI;
    /**
     * Vendas (08 - 09 - 10 ) do bico, em litros.
     */
    private double VOL_VENDAS;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">     
    /**
     * Bico Ligado a Bomba.
     * @return the NUM_BICO
     */
    public String getNUM_BICO() {
        return NUM_BICO;
    }

    /**
     * Bico Ligado a Bomba.
     * @param NUM_BICO the NUM_BICO to set
     */
    public void setNUM_BICO(String NUM_BICO) {
        this.NUM_BICO = NUM_BICO;
    }

    /**
     * Numero da intervencao.
     * @return the NR_INTERV
     */
    public String getNR_INTERV() {
        return NR_INTERV;
    }

    /**
     * Numero da intervencao.
     * @param NR_INTERV the NR_INTERV to set
     */
    public void setNR_INTERV(String NR_INTERV) {
        this.NR_INTERV = NR_INTERV;
    }

    /**
     * Motivo da Intervencao.
     * @return the MOT_INTERV
     */
    public String getMOT_INTERV() {
        return MOT_INTERV;
    }

    /**
     * Motivo da Intervencao.
     * @param MOT_INTERV the MOT_INTERV to set
     */
    public void setMOT_INTERV(String MOT_INTERV) {
        this.MOT_INTERV = MOT_INTERV;
    }

    /**
     * Nome do Interventor.
     * @return the NOM_INTERV
     */
    public String getNOM_INTERV() {
        return NOM_INTERV;
    }

    /**
     * Nome do Interventor.
     * @param NOM_INTERV the NOM_INTERV to set
     */
    public void setNOM_INTERV(String NOM_INTERV) {
        this.NOM_INTERV = NOM_INTERV;
    }

    /**
     * CNPJ da empresa responsavel pela intervencao.
     * @return the CNPJ_INTERV
     */
    public String getCNPJ_INTERV() {
        return CNPJ_INTERV;
    }

    /**
     * CNPJ da empresa responsavel pela intervencao.
     * @param CNPJ_INTERV the CNPJ_INTERV to set
     */
    public void setCNPJ_INTERV(String CNPJ_INTERV) {
        this.CNPJ_INTERV = CNPJ_INTERV;
    }

    /**
     * CPF do tecnico responsavel pela intervencao.
     * @return the CPF_INTERV
     */
    public String getCPF_INTERV() {
        return CPF_INTERV;
    }

    /**
     * CPF do tecnico responsavel pela intervencao.
     * @param CPF_INTERV the CPF_INTERV to set
     */
    public void setCPF_INTERV(String CPF_INTERV) {
        this.CPF_INTERV = CPF_INTERV;
    }

    /**
     * Valor da leitura final do contador, no fechamento do bico.
     * @return the VAL_FECHA
     */
    public double getVAL_FECHA() {
        return VAL_FECHA;
    }

    /**
     * Valor da leitura final do contador, no fechamento do bico.
     * @param VAL_FECHA the VAL_FECHA to set
     */
    public void setVAL_FECHA(double VAL_FECHA) {
        this.VAL_FECHA = VAL_FECHA;
    }

    /**
     * Valor da leitura inicial do contador, na abertura do bico.
     * @return the VAL_ABERT
     */
    public double getVAL_ABERT() {
        return VAL_ABERT;
    }

    /**
     * Valor da leitura inicial do contador, na abertura do bico.
     * @param VAL_ABERT the VAL_ABERT to set
     */
    public void setVAL_ABERT(double VAL_ABERT) {
        this.VAL_ABERT = VAL_ABERT;
    }

    /**
     * Afericoes da Bomba, em litros.
     * @return the VOL_AFERI
     */
    public double getVOL_AFERI() {
        return VOL_AFERI;
    }

    /**
     * Afericoes da Bomba, em litros.
     * @param VOL_AFERI the VOL_AFERI to set
     */
    public void setVOL_AFERI(double VOL_AFERI) {
        this.VOL_AFERI = VOL_AFERI;
    }

    /**
     * Vendas (08 - 09 - 10 ) do bico, em litros.
     * @return the VOL_VENDAS
     */
    public double getVOL_VENDAS() {
        return VOL_VENDAS;
    }

    /**
     * Vendas (08 - 09 - 10 ) do bico, em litros.
     * @param VOL_VENDAS the VOL_VENDAS to set
     */
    public void setVOL_VENDAS(double VOL_VENDAS) {
        this.VOL_VENDAS = VOL_VENDAS;
    }
    // </editor-fold>

}