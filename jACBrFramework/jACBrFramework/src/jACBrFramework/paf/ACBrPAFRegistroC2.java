package jACBrFramework.paf;

import java.util.Date;

/**
 * Controle de Abastecimentos e Encerrantes.
 * 
 * @author Jose Mauro
 * @version Criado em: 10/12/2013 16:25:10, revisao: $Id$
 */
public final class ACBrPAFRegistroC2 {

    // <editor-fold defaultstate="collapsed" desc="Attributes">
    /**
     * Identificador do abastecimento (chave).
     */
    private String idAbastecimento;
    /**
     * No. do Tanque onde estava armazenado o combustivel abastecido.
     */
    private String tanque;
    /**
     * No. da Bomba abastecida pelo Tanque informado no campo 03.
     */
    private String bomba;
    /**
     * No. do Bico de Abastecimento da Bomba informada no campo 04.
     */
    private String bico;
    /**
     * Tipo do Combustivel abastecido pela Bomba/Bico informados nos campos 04 e 05.
     */
    private String combustivel;
    /**
     * Data em que foi concluido ou capturado o abastecimento, obtida do equipamento 
     * concentrador, se possivel, ou do relógio do PC.
     */
    private Date dataAbastecimento;
    /**
     * Hora em que foi concluido ou capturado o abastecimento, obtida do equipamento 
     * concentrador, se possivel, ou do relogio do PC.
     */
    private Date horaAbastecimento;
    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05, 
     * ao iniciar o abastecimento.
     */
    private double encerranteInicial;
    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05, 
     * ao finalizar o abastecimento.
     */
    private double encerrantaFinal;
    /**
     * Status atribuido ao registro do abastecimento capturado da bomba conforme 
     * escrito na alínea "a" do item 1 do Requisito XXXV.
     */
    private String statusAbastecimento;
    /**
     * Numero de fabricacao do ECF que emitiu o Cupom Fiscal relativo ao respectivo abastecimento.
     */
    private String numSerieEcf;
    /**
     * Data do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     */
    private Date data;
    /**
     * Hora do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     */
    private Date hora;
    /**
     * COO (Contador de Ordem de Operacao) do Cupom Fiscal relativo ao respectivo abastecimento.
     */
    private int coo;
    /**
     * Numero da Nota Fiscal emitida manualmente ou por PED no caso previsto nas 
     * alineas "b" e "c" do item 1 do Requisito XVII, relativa ao respectivo abastecimento.
     */
    private int numNotaFiscal;
    /**
     * Volume de combustivel registrado no Cupom Fiscal ou Nota Fiscal relativos 
     * ao respectivo abastecimento, armazenado em Banco de Dados conforme descrito 
     * no item 2 do Requisito XXXII. 
     */
    private double volume;
    /**
     * Se true o registro e valido.
     */
    private boolean registroValido;
    // </editor-fold>
    // <editor-fold defaultstate="collapsed" desc="Getters - Setters">
    /**
     * Identificador do abastecimento (chave).
     * @return the idAbastecimento
     */
    public String getIdAbastecimento() {
        return idAbastecimento;
    }

    /**
     * Identificador do abastecimento (chave).
     * @param idAbastecimento the idAbastecimento to set
     */
    public void setIdAbastecimento(String idAbastecimento) {
        this.idAbastecimento = idAbastecimento;
    }

    /**
     * No. do Tanque onde estava armazenado o combustivel abastecido.
     * @return the tanque
     */
    public String getTanque() {
        return tanque;
    }

    /**
     * No. do Tanque onde estava armazenado o combustivel abastecido.
     * @param tanque the tanque to set
     */
    public void setTanque(String tanque) {
        this.tanque = tanque;
    }

    /**
     * No. da Bomba abastecida pelo Tanque informado no campo 03.
     * @return the bomba
     */
    public String getBomba() {
        return bomba;
    }

    /**
     * No. da Bomba abastecida pelo Tanque informado no campo 03.
     * @param bomba the bomba to set
     */
    public void setBomba(String bomba) {
        this.bomba = bomba;
    }

    /**
     * No. do Bico de Abastecimento da Bomba informada no campo 04.
     * @return the bico
     */
    public String getBico() {
        return bico;
    }

    /**
     * No. do Bico de Abastecimento da Bomba informada no campo 04.
     * @param bico the bico to set
     */
    public void setBico(String bico) {
        this.bico = bico;
    }

    /**
     * Tipo do Combustivel abastecido pela Bomba/Bico informados nos campos 04 e 05.
     * @return the combustivel
     */
    public String getCombustivel() {
        return combustivel;
    }

    /**
     * Tipo do Combustivel abastecido pela Bomba/Bico informados nos campos 04 e 05.
     * @param combustivel the combustivel to set
     */
    public void setCombustivel(String combustivel) {
        this.combustivel = combustivel;
    }

    /**
     * Data em que foi concluido ou capturado o abastecimento, obtida do equipamento
     * concentrador, se possivel, ou do relógio do PC.
     * @return the dataAbastecimento
     */
    public Date getDataAbastecimento() {
        return dataAbastecimento;
    }

    /**
     * Data em que foi concluido ou capturado o abastecimento, obtida do equipamento
     * concentrador, se possivel, ou do relógio do PC.
     * @param dataAbastecimento the dataAbastecimento to set
     */
    public void setDataAbastecimento(Date dataAbastecimento) {
        this.dataAbastecimento = dataAbastecimento;
    }

    /**
     * Hora em que foi concluido ou capturado o abastecimento, obtida do equipamento
     * concentrador, se possivel, ou do relogio do PC.
     * @return the horaAbastecimento
     */
    public Date getHoraAbastecimento() {
        return horaAbastecimento;
    }

    /**
     * Hora em que foi concluido ou capturado o abastecimento, obtida do equipamento
     * concentrador, se possivel, ou do relogio do PC.
     * @param horaAbastecimento the horaAbastecimento to set
     */
    public void setHoraAbastecimento(Date horaAbastecimento) {
        this.horaAbastecimento = horaAbastecimento;
    }

    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05,
     * ao iniciar o abastecimento.
     * @return the encerranteInicial
     */
    public double getEncerranteInicial() {
        return encerranteInicial;
    }

    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05,
     * ao iniciar o abastecimento.
     * @param encerranteInicial the encerranteInicial to set
     */
    public void setEncerranteInicial(double encerranteInicial) {
        this.encerranteInicial = encerranteInicial;
    }

    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05,
     * ao finalizar o abastecimento.
     * @return the encerrantaFinal
     */
    public double getEncerrantaFinal() {
        return encerrantaFinal;
    }

    /**
     * Valor do Encerrante capturado da bomba/bico informados nos campos 04 e 05,
     * ao finalizar o abastecimento.
     * @param encerrantaFinal the encerrantaFinal to set
     */
    public void setEncerrantaFinal(double encerrantaFinal) {
        this.encerrantaFinal = encerrantaFinal;
    }

    /**
     * Status atribuido ao registro do abastecimento capturado da bomba conforme
     * escrito na alínea "a" do item 1 do Requisito XXXV.
     * @return the statusAbastecimento
     */
    public String getStatusAbastecimento() {
        return statusAbastecimento;
    }

    /**
     * Status atribuido ao registro do abastecimento capturado da bomba conforme
     * escrito na alínea "a" do item 1 do Requisito XXXV.
     * @param statusAbastecimento the statusAbastecimento to set
     */
    public void setStatusAbastecimento(String statusAbastecimento) {
        this.statusAbastecimento = statusAbastecimento;
    }

    /**
     * Numero de fabricacao do ECF que emitiu o Cupom Fiscal relativo ao respectivo abastecimento.
     * @return the numSerieEcf
     */
    public String getNumSerieEcf() {
        return numSerieEcf;
    }

    /**
     * Numero de fabricacao do ECF que emitiu o Cupom Fiscal relativo ao respectivo abastecimento.
     * @param numSerieEcf the numSerieEcf to set
     */
    public void setNumSerieEcf(String numSerieEcf) {
        this.numSerieEcf = numSerieEcf;
    }

    /**
     * Data do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     * @return the data
     */
    public Date getData() {
        return data;
    }

    /**
     * Data do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     * @param data the data to set
     */
    public void setData(Date data) {
        this.data = data;
    }

    /**
     * Hora do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     * @return the hora
     */
    public Date getHora() {
        return hora;
    }

    /**
     * Hora do movimento impressa no cabecalho do Cupom Fiscal relativo ao respectivo abastecimento.
     * @param hora the hora to set
     */
    public void setHora(Date hora) {
        this.hora = hora;
    }

    /**
     * COO (Contador de Ordem de Operacao) do Cupom Fiscal relativo ao respectivo abastecimento.
     * @return the coo
     */
    public int getCoo() {
        return coo;
    }

    /**
     * COO (Contador de Ordem de Operacao) do Cupom Fiscal relativo ao respectivo abastecimento.
     * @param coo the coo to set
     */
    public void setCoo(int coo) {
        this.coo = coo;
    }

    /**
     * Numero da Nota Fiscal emitida manualmente ou por PED no caso previsto nas
     * alineas "b" e "c" do item 1 do Requisito XVII, relativa ao respectivo abastecimento.
     * @return the numNotaFiscal
     */
    public int getNumNotaFiscal() {
        return numNotaFiscal;
    }

    /**
     * Numero da Nota Fiscal emitida manualmente ou por PED no caso previsto nas
     * alineas "b" e "c" do item 1 do Requisito XVII, relativa ao respectivo abastecimento.
     * @param numNotaFiscal the numNotaFiscal to set
     */
    public void setNumNotaFiscal(int numNotaFiscal) {
        this.numNotaFiscal = numNotaFiscal;
    }

    /**
     * Volume de combustivel registrado no Cupom Fiscal ou Nota Fiscal relativos
     * ao respectivo abastecimento, armazenado em Banco de Dados conforme descrito
     * no item 2 do Requisito XXXII.
     * @return the volume
     */
    public double getVolume() {
        return volume;
    }

    /**
     * Volume de combustivel registrado no Cupom Fiscal ou Nota Fiscal relativos
     * ao respectivo abastecimento, armazenado em Banco de Dados conforme descrito
     * no item 2 do Requisito XXXII.
     * @param volume the volume to set
     */
    public void setVolume(double volume) {
        this.volume = volume;
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