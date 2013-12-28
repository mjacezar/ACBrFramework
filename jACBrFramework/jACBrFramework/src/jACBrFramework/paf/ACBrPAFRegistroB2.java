package jACBrFramework.paf;

import java.util.Date;

/**
 * Registros de Substituicao da Placa Eletronica de Gerenciamento de Bomba de Combustivel.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:10:56, revisao: $Id$
 */
public final class ACBrPAFRegistroB2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Numero da bomba que sofreu a substituicao da placa.
     */
    private String bomba;
    /**
     * Numero da bico da bomba que sofreu a substituicao da placa.
     */
    private String bico;
    /**
     * Data de realizacao da substituicao da placa.
     */
    private Date data;
    /**
     * Horario de realizaCao da substituicao da placa.
     */
    private Date hora;
    /**
     * Motivo da substituicao da placa.
     */
    private String motivo;
    /**
     * CNPJ da empresa que realizou a substituicao da placa.
     */
    private String cnpjEmpresa;
    /**
     * CPF do tecnico que realizou a substituicao da placa.
     */
    private String cpfTecnico;
    /**
     * Numero do (s) lacre (s) removido (s) da bomba para a realizacao da substituicao da placa.
     */
    private String numLacreAntes;
    /**
     * Numero do (s) lacre (s) aplicado (s) na bomba apos a realizacao da substituicao da placa.
     */
    private String numLacreApos;
    /**
     * Valor do encerrante imediatamente antes da substituicao da placa.
     */
    private double encerranteAntes;
    /**
     * Valor do encerrante imediatamente apos a substituicao da placa.
     */
    private double encerranteApos;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">        

    /**
     * Numero da bomba que sofreu a substituicao da placa.
     * @return the bomba
     */
    public String getBomba() {
        return bomba;
    }

    /**
     * Numero da bomba que sofreu a substituicao da placa.
     * @param bomba the bomba to set
     */
    public void setBomba(String bomba) {
        this.bomba = bomba;
    }

    /**
     * Numero da bico da bomba que sofreu a substituicao da placa.
     * @return the bico
     */
    public String getBico() {
        return bico;
    }

    /**
     * Numero da bico da bomba que sofreu a substituicao da placa.
     * @param bico the bico to set
     */
    public void setBico(String bico) {
        this.bico = bico;
    }

    /**
     * Data de realizacao da substituicao da placa.
     * @return the data
     */
    public Date getData() {
        return data;
    }

    /**
     * Data de realizacao da substituicao da placa.
     * @param data the data to set
     */
    public void setData(Date data) {
        this.data = data;
    }

    /**
     * Horario de realizaCao da substituicao da placa.
     * @return the hora
     */
    public Date getHora() {
        return hora;
    }

    /**
     * Horario de realizaCao da substituicao da placa.
     * @param hora the hora to set
     */
    public void setHora(Date hora) {
        this.hora = hora;
    }

    /**
     * Motivo da substituicao da placa.
     * @return the motivo
     */
    public String getMotivo() {
        return motivo;
    }

    /**
     * Motivo da substituicao da placa.
     * @param motivo the motivo to set
     */
    public void setMotivo(String motivo) {
        this.motivo = motivo;
    }

    /**
     * CNPJ da empresa que realizou a substituicao da placa.
     * @return the cnpjEmpresa
     */
    public String getCnpjEmpresa() {
        return cnpjEmpresa;
    }

    /**
     * CNPJ da empresa que realizou a substituicao da placa.
     * @param cnpjEmpresa the cnpjEmpresa to set
     */
    public void setCnpjEmpresa(String cnpjEmpresa) {
        this.cnpjEmpresa = cnpjEmpresa;
    }

    /**
     * CPF do tecnico que realizou a substituicao da placa.
     * @return the cpfTecnico
     */
    public String getCpfTecnico() {
        return cpfTecnico;
    }

    /**
     * CPF do tecnico que realizou a substituicao da placa.
     * @param cpfTecnico the cpfTecnico to set
     */
    public void setCpfTecnico(String cpfTecnico) {
        this.cpfTecnico = cpfTecnico;
    }

    /**
     * Numero do (s) lacre (s) removido (s) da bomba para a realizacao da substituicao da placa.
     * @return the numLacreAntes
     */
    public String getNumLacreAntes() {
        return numLacreAntes;
    }

    /**
     * Numero do (s) lacre (s) removido (s) da bomba para a realizacao da substituicao da placa.
     * @param numLacreAntes the numLacreAntes to set
     */
    public void setNumLacreAntes(String numLacreAntes) {
        this.numLacreAntes = numLacreAntes;
    }

    /**
     * Numero do (s) lacre (s) aplicado (s) na bomba apos a realizacao da substituicao da placa.
     * @return the numLacreApos
     */
    public String getNumLacreApos() {
        return numLacreApos;
    }

    /**
     * Numero do (s) lacre (s) aplicado (s) na bomba apos a realizacao da substituicao da placa.
     * @param numLacreApos the numLacreApos to set
     */
    public void setNumLacreApos(String numLacreApos) {
        this.numLacreApos = numLacreApos;
    }

    /**
     * Valor do encerrante imediatamente antes da substituicao da placa.
     * @return the encerranteAntes
     */
    public double getEncerranteAntes() {
        return encerranteAntes;
    }

    /**
     * Valor do encerrante imediatamente antes da substituicao da placa.
     * @param encerranteAntes the encerranteAntes to set
     */
    public void setEncerranteAntes(double encerranteAntes) {
        this.encerranteAntes = encerranteAntes;
    }

    /**
     * Valor do encerrante imediatamente apos a substituicao da placa.
     * @return the encerranteApos
     */
    public double getEncerranteApos() {
        return encerranteApos;
    }

    /**
     * Valor do encerrante imediatamente apos a substituicao da placa.
     * @param encerranteApos the encerranteApos to set
     */
    public void setEncerranteApos(double encerranteApos) {
        this.encerranteApos = encerranteApos;
    }

    /**
     * Se true o registro e valido.
     * @return the registroValido
     */
    public boolean isRegistroValido() {
        return registroValido;
    }

    /**
     * Se true o registro e valido.
     * @param registroValido the registroValido to set
     */
    public void setRegistroValido(boolean registroValido) {
        this.registroValido = registroValido;
    }
    // </editor-fold>
        
}