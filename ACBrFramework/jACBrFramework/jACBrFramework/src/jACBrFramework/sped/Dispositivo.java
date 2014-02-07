package jACBrFramework.sped;

/**
 * Codigo dispositivo autorizado.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/01/2014 09:15:29, revisao: $Id$
 */
public enum Dispositivo {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    FormSeguranca(0, "00 - Formulário de Segurança"),
    FSDA(1, "01 - FS-DA – Formulário de Segurança para Impressão de DANFE"),
    NFe(2, "02 – Formulário de segurança - NF-e"),
    FormContinuo(3, "03 - Formulário Contínuo"),
    Blocos(4, "04 – Blocos"),
    JogosSoltos(5, "05 - Jogos Soltos");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao do dispositivo.
     */
    private String descricao;
    /**
     * Codigo do dispositivo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    Dispositivo(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao do dispositivo.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo do dispositivo.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    // </editor-fold>     
}