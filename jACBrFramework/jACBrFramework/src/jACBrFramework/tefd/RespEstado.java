package jACBrFramework.tefd;

/**
 * Resposta da requisicao.
 * 
 * @author Jose Mauro
 * @version Criado em: 28/02/2014 09:23:06, revisao: $Id$
 */
public enum RespEstado {

    // <editor-fold defaultstate="collapsed" desc="Enums">    
    Nenhum(0, "0 - Nennhuma Resposta em andamento"),
    AguardandoResposta(1, "1 - Requisição Escrita, Aguardando Resposta"),
    Processando(2, "2 - Processando a Resposta"),
    Concluida(3, "3 - Concluida");
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da resposta da requisicao.
     */
    private String descricao;
    /**
     * Codigo da resposta da requisicao.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    RespEstado(int pCodigo, String pDescricao) {
        codigo = pCodigo;
        descricao = pDescricao;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da resposta da requisicao.
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da resposta da requisicao.
     * @return the codigo
     */
    public int getCodigo() {
        return codigo;
    }
    
    /**
     * Recupera o enum pelo codigo correspondente.
     * 
     * @param pCodigo codigo a ser recuperado.
     * @return 
     */
    public static RespEstado valueOf(int pCodigo) {
        for (RespEstado lRespEstado : values()) {
            if (lRespEstado.getCodigo() == pCodigo) return lRespEstado;
        }
        return null;
    }    
    // </editor-fold>      

}