package jACBrFramework.serial.ecf;

import java.util.Date;

public class FormaPagamento {
    //<editor-fold defaultstate="collapsed" desc="Fields">
    private String indice;
    private String descricao;
    private boolean permiteVinculado;
    private double total;
    private Date data;
    private String tipoDoc;
    //</editor-fold>	
    //<editor-fold defaultstate="collapsed" desc="Constructor">
    public FormaPagamento(String indice, String descricao, boolean permiteVinculado, double total) {
        this.indice = indice;
        this.descricao = descricao;
        this.permiteVinculado = permiteVinculado;
        this.total = total;
    }
    public FormaPagamento(String descricao, double total, Date data, String tipoDoc) {
        this(null, descricao, false, total);
        this.data = data;
        this.tipoDoc = tipoDoc;
    }    
    //</editor-fold>
    //<editor-fold defaultstate="collapsed" desc="Properties">
    public String getIndice() {
        return indice;
    }
    public String getDescricao() {
        return descricao;
    }
    public boolean getPermiteVinculado() {
        return permiteVinculado;
    }
    public double getTotal() {
        return total;
    }
    public Date getData() {
        return data;
    }    
    public String getTipoDoc() {
        return tipoDoc;
    }    
    //</editor-fold>
}