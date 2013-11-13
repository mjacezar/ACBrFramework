package jACBrFramework.serial.ecf;

public class ComprovanteNaoFiscal {
    //<editor-fold defaultstate="collapsed" desc="Fields">

    private String indice;
    private String descricao;
    private String formaPagamento;
    private int contador;
    private boolean permiteVinculado;
    private double total;

    //</editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public ComprovanteNaoFiscal(String indice, String descricao, String formaPagamento, int contador, boolean permiteVinculado, double total) {
        this.indice = indice;
        this.descricao = descricao;
        this.formaPagamento = formaPagamento;
        this.contador = contador;
        this.permiteVinculado = permiteVinculado;
        this.total = total;
    }

    //</editor-fold>    
    //<editor-fold defaultstate="collapsed" desc="Properties">
    public String getIndice() {
        return indice;
    }

    public String getDescricao() {
        return descricao;
    }

    public String getFormaPagamento() {
        return formaPagamento;
    }

    public int getContador() {
        return contador;
    }

    public boolean getPermiteVinculado() {
        return permiteVinculado;
    }

    public double getTotal() {
        return total;
    }
    //</editor-fold>
}
