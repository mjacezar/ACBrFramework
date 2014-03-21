package jACBrFramework.sintegra;

/**
 * Codigos de finalidade utilizado no arquivo magnetico.
 * 
 * @author Jose Mauro
 * @version Criado em: 26/11/2013 14:50:14, revisao: $Id$
 */
public enum FinalidadeArquivo {
    // <editor-fold defaultstate="collapsed" desc="Enums">    
    NORMAL("Normal", 1),
    RETIFICACAO_TOTAL("Retificação total de arquivo: substituição total de informações prestadas pelo contribuinte referentes a este período", 2),
    RETIFICACAO_ADITIVA("Retificação aditiva de arquivo: acréscimo de informação não incluída em arquivos já apresentados", 3),
    DESFAZIMENTO("Desfazimento: arquivo de informação referente a operações/prestações não efetivadas . Neste caso, o arquivo deverá conter, além dos registros tipo 10 e tipo 90, apenas os registros referentes as operações/prestações não efetivadas", 5);
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Attributes">    
    /**
     * Descricao da finalidade do arquivo.
     */
    private String descricao;
    /**
     * Codigo da finalidade do arquivo.
     */
    private int codigo;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Constructors">  
    FinalidadeArquivo(String pDescricao, int pCodigo) {
        descricao = pDescricao;
        codigo = pCodigo;
    }
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Methods">    
    /**
     * Descricao da finalidade do arquivo.
     * 
     * @return the descricao
     */
    public String getDescricao() {
        return descricao;
    }

    /**
     * Codigo da finalidade do arquivo.
     * 
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
    public static FinalidadeArquivo valueOf(int pCodigo) {
        for (FinalidadeArquivo lFinalidadeArquivo : values()) {
            if (lFinalidadeArquivo.getCodigo() == pCodigo) return lFinalidadeArquivo;
        }
        return null;
    }        
    // </editor-fold>
}