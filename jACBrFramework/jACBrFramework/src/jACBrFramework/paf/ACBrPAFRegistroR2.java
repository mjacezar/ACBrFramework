package jACBrFramework.paf;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;

/**
 * Relacao de Reducoes Z.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 18:02:22, revisao: $Id$
 */
public final class ACBrPAFRegistroR2 {
    
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Registro R3.
     */
    private Collection<ACBrPAFRegistroR3> registrosR3 = new ArrayList<ACBrPAFRegistroR3>();    
    /**
     * No. de ordem do usuario do ECF.
     */
    private int numeroUsuario;
    /**
     * No. do Contador de Reducao Z relativo a respectiva reducao.
     */
    private int crz;
    /**
     * No. do Contador de Ordem de Operacao relativo a respectiva Reducao Z.
     */
    private int coo;
    /**
     * No. do contador de reinicio de Operacao relativo a respectiva Reducao Z.
     */
    private int cro;
    /**
     * Data das operacoes relativas a respectiva Reducao Z.
     */
    private Date dataMovimento;
    /**
     * Data de emissao da Reducao Z.
     */
    private Date dataEmissao;
    /**
     * Hora de emissao da Reducao Z.
     */
    private Date horaEmissao;
    /**
     * Valor acumulado neste totalizador relativo a respectiva Reducao Z.
     */
    private double vendaBrutaDiaria;
    /**
     * Parametro do ECF para incidencia de desconto sobre itens sujeitos ao ISSQN conforme item 7.2.1.4.
     */
    private String parametroEcf;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;    
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">    
    /**
     * Registro R3.
     * @return the registrosR3
     */
    public Collection<ACBrPAFRegistroR3> getRegistrosR3() {
        return registrosR3;
    }

    /**
     * No. de ordem do usuario do ECF.
     * @return the numeroUsuario
     */
    public int getNumeroUsuario() {
        return numeroUsuario;
    }

    /**
     * No. de ordem do usuario do ECF.
     * @param numeroUsuario the numeroUsuario to set
     */
    public void setNumeroUsuario(int numeroUsuario) {
        this.numeroUsuario = numeroUsuario;
    }

    /**
     * No. do Contador de Reducao Z relativo a respectiva reducao.
     * @return the crz
     */
    public int getCrz() {
        return crz;
    }

    /**
     * No. do Contador de Reducao Z relativo a respectiva reducao.
     * @param crz the crz to set
     */
    public void setCrz(int crz) {
        this.crz = crz;
    }

    /**
     * No. do Contador de Ordem de Operacao relativo a respectiva Reducao Z.
     * @return the coo
     */
    public int getCoo() {
        return coo;
    }

    /**
     * No. do Contador de Ordem de Operacao relativo a respectiva Reducao Z.
     * @param coo the coo to set
     */
    public void setCoo(int coo) {
        this.coo = coo;
    }

    /**
     * No. do contador de reinicio de Operacao relativo a respectiva Reducao Z.
     * @return the cro
     */
    public int getCro() {
        return cro;
    }

    /**
     * No. do contador de reinicio de Operacao relativo a respectiva Reducao Z.
     * @param cro the cro to set
     */
    public void setCro(int cro) {
        this.cro = cro;
    }

    /**
     * Data das operacoes relativas a respectiva Reducao Z.
     * @return the dataMovimento
     */
    public Date getDataMovimento() {
        return dataMovimento;
    }

    /**
     * Data das operacoes relativas a respectiva Reducao Z.
     * @param dataMovimento the dataMovimento to set
     */
    public void setDataMovimento(Date dataMovimento) {
        this.dataMovimento = dataMovimento;
    }

    /**
     * Data de emissao da Reducao Z.
     * @return the dataEmissao
     */
    public Date getDataEmissao() {
        return dataEmissao;
    }

    /**
     * Data de emissao da Reducao Z.
     * @param dataEmissao the dataEmissao to set
     */
    public void setDataEmissao(Date dataEmissao) {
        this.dataEmissao = dataEmissao;
    }

    /**
     * Hora de emissao da Reducao Z.
     * @return the horaEmissao
     */
    public Date getHoraEmissao() {
        return horaEmissao;
    }

    /**
     * Hora de emissao da Reducao Z.
     * @param horaEmissao the horaEmissao to set
     */
    public void setHoraEmissao(Date horaEmissao) {
        this.horaEmissao = horaEmissao;
    }

    /**
     * Valor acumulado neste totalizador relativo a respectiva Reducao Z.
     * @return the vendaBrutaDiaria
     */
    public double getVendaBrutaDiaria() {
        return vendaBrutaDiaria;
    }

    /**
     * Valor acumulado neste totalizador relativo a respectiva Reducao Z.
     * @param vendaBrutaDiaria the vendaBrutaDiaria to set
     */
    public void setVendaBrutaDiaria(double vendaBrutaDiaria) {
        this.vendaBrutaDiaria = vendaBrutaDiaria;
    }

    /**
     * Parametro do ECF para incidencia de desconto sobre itens sujeitos ao ISSQN conforme item 7.2.1.4.
     * @return the parametroEcf
     */
    public String getParametroEcf() {
        return parametroEcf;
    }

    /**
     * Parametro do ECF para incidencia de desconto sobre itens sujeitos ao ISSQN conforme item 7.2.1.4.
     * @param parametroEcf the parametroEcf to set
     */
    public void setParametroEcf(String parametroEcf) {
        this.parametroEcf = parametroEcf;
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