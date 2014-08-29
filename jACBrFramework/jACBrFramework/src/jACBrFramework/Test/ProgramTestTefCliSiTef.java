package jACBrFramework.Test;

import com.sun.jna.ptr.IntByReference;
import jACBrFramework.ACBrEventListener;
import jACBrFramework.ACBrException;
import jACBrFramework.serial.ecf.ACBrECF;
import jACBrFramework.serial.ecf.EstadoECF;
import jACBrFramework.serial.ecf.FormaPagamento;
import jACBrFramework.tefd.ACBrTEFD;
import jACBrFramework.tefd.InfoECF;
import jACBrFramework.tefd.ModalResult;
import jACBrFramework.tefd.OperacaoMensagem;
import jACBrFramework.tefd.RetornoECF;
import jACBrFramework.tefd.TefTipo;
import jACBrFramework.tefd.eventos.AguardaRespEventObject;
import jACBrFramework.tefd.eventos.ComandaECFAbreVinculadoEventObject;
import jACBrFramework.tefd.eventos.ComandaECFEventObject;
import jACBrFramework.tefd.eventos.ComandaECFImprimeViaEventObject;
import jACBrFramework.tefd.eventos.ComandaECFPagamentoEventObject;
import jACBrFramework.tefd.eventos.ExibeMsgEventObject;
import jACBrFramework.tefd.eventos.InfoECFEventObject;
import jACBrFramework.tefd.eventos.TEFCliSiTefExibeMenuEventObject;
import jACBrFramework.tefd.eventos.TEFCliSiTefObtemCampoEventObject;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author MarceloNepomuceno
 * @version revisao: $Id$
 */
public class ProgramTestTefCliSiTef {

    /**
     * @param args
     */
    public static ACBrECF acBrECF1 = null;
    public static ACBrTEFD acBrTEFD1 = null;
    public static BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
    private static final String CLISITEF_COD_LOJA = "00000000";
    private static final String CLISITEF_ENDERECO_IP = "192.168.1.102";
    private static final String CLISITEF_NUMERO_TERMINAL = "PV000001";
    private static final String TEFD_ARQ_LOG = "F:\\logs\\log.txt";
    private static final String TEFD_PATH_BACKUP = "C:\\CliSiTef\\";
    private static final String INDICE_CARTAO_DEBITO = "02";
    private static final String INDICE_CARTAO_CREDITO = "03";

    public static void main(String[] args) throws Throwable {
        try {
            System.out.println("===============================");
            System.out.println("Teste ACBrECF");
            instanciarEcf();
            ativarEcf();
            System.out.println("===============================");

            System.out.println("===============================");
            System.out.println("Teste ACBrTEF");

            acBrTEFD1 = new ACBrTEFD();
            acBrTEFD1.setArqLOG(TEFD_ARQ_LOG);
            acBrTEFD1.setExibirMsgAutenticacao(false);
            
            acBrTEFD1.getTefCliSiTef().setCodigoLoja(CLISITEF_COD_LOJA);
            acBrTEFD1.getTefCliSiTef().setEnderecoIP(CLISITEF_ENDERECO_IP);
            acBrTEFD1.getTefCliSiTef().setNumeroTerminal(CLISITEF_NUMERO_TERMINAL);

            acBrTEFD1.getTefCliSiTef().setOperacaoADM(110);
            acBrTEFD1.getTefCliSiTef().setOperacaoATV(111);
            acBrTEFD1.getTefCliSiTef().setOperacaoCHQ(1);
            acBrTEFD1.getTefCliSiTef().setOperacaoCNC(200);
            acBrTEFD1.getTefCliSiTef().setOperacaoCRT(0);
            acBrTEFD1.getTefCliSiTef().setOperacaoReImpressao(112);

            acBrTEFD1.setAutoAtivar(true);
            acBrTEFD1.setAutoEfetuarPagamento(true);
            acBrTEFD1.setAutoFinalizarCupom(true);

            acBrTEFD1.setEsperaSTS(7);
            acBrTEFD1.setGPAtual(TefTipo.CliSiTef);

            acBrTEFD1.setPathBackup(TEFD_PATH_BACKUP);

            acBrTEFD1.addOnAguardaResp(new ACBrEventListener<AguardaRespEventObject>() {
                @Override
                public void notification(AguardaRespEventObject e) {
                    try {
                        System.out.println(String.format("Aguardando: %s - %d}", e.getArquivo(), e.getTimeoutEmSegundos()));
                    } catch (Exception ex) {
                        System.out.println(String.format("Exception - Evento: addOnAguardaResp() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnExibeMensagem(new ACBrEventListener<ExibeMsgEventObject>() {
                @Override
                public void notification(ExibeMsgEventObject e) {
                    try {
                        if (e.getOperacao() == OperacaoMensagem.OK) {
                            String ret = "";
                            while (!ret.matches("o|O")) {
                                System.out.println(e.getMensagem());
                                System.out.println("o - Ok");
                                ret = reader.readLine();
                            }
                            e.setaModalResult(new IntByReference(ModalResult.OK.getCodigo()));
                        } else if (e.getOperacao() == OperacaoMensagem.YesNo) {
                            String ret = "";
                            while (!ret.matches("y|Y|n|N")) {
                                System.out.println(e.getMensagem());
                                System.out.println("y - Sim");
                                System.out.println("n - Não");
                                ret = reader.readLine();
                            }
                            if (ret.matches("y|Y")) {
                                e.setaModalResult(new IntByReference(ModalResult.Yes.getCodigo()));
                            } else if (ret.matches("n|N")) {
                                e.setaModalResult(new IntByReference(ModalResult.No.getCodigo()));
                            }
                        }
                    } catch (IOException ex) {
                        System.out.println(String.format("Exception - Evento: addOnExibeMensagem() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnComandaECFPagamento(new ACBrEventListener<ComandaECFPagamentoEventObject>() {
                @Override
                public void notification(ComandaECFPagamentoEventObject e) {
                    try {
                        System.out.println(String.format("ECF - Pagamento, IndiceECF: %s Valor: %.2f", e.getIndiceEcf(), e.getValor()));
                        if (acBrECF1.getEstado() == EstadoECF.NAO_FISCAL) {
                            acBrECF1.efetuaPagamentoNaoFiscal(e.getIndiceEcf(), e.getValor(), "MENSAGEM FORMA DE PAGTO", true);
                        } else {
                            acBrECF1.carregaFormasPagamento();
                            acBrECF1.efetuaPagamento(e.getIndiceEcf(), e.getValor(), "MENSAGEM FORMA DE PAGTO", true);
                        }
                        e.setRetornoEcf(new IntByReference(1));
                    } catch (Exception ex) {
                        e.setRetornoEcf(new IntByReference(0));
                        System.out.println(String.format("Exception - Evento: addOnComandaECFPagamento() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnComandaECF(new ACBrEventListener<ComandaECFEventObject>() {
                @Override
                public void notification(ComandaECFEventObject e) {
                    try {
                        System.out.println("ComandaECF: " + e.getOperacao());
                        switch (e.getOperacao()) {
                            case SubTotalizaCupom:
                                acBrECF1.subtotalizaCupom(0, null);
                                break;
                            case AbreGerencial:
                                acBrECF1.abreRelatorioGerencial(0);
                                break;
                            case PulaLinhas:
                                acBrECF1.pulaLinhas(acBrECF1.getLinhasEntreCupons());
                                acBrECF1.cortaPapel(true);
                                try {
                                    Thread.sleep(200);
                                } catch (InterruptedException ex) {
                                    Logger.getLogger(ProgramTestTefCliSiTef.class.getName()).log(Level.SEVERE, null, ex);
                                }
                                break;
                            case ImprimePagamentos:
                                //if (acBrECF1.getEstado() == EstadoECF.NAO_FISCAL) {
                                //    acBrECF1.efetuaPagamentoNaoFiscal("1", 0, "", true);
                                //} else {
                                //    acBrECF1.efetuaPagamento("1", 0, "", true);
                                //}
                                break;
                            case FechaVinculado:
                            case FechaGerencial:
                                acBrECF1.fechaRelatorio();
                                break;
                            case CancelaCupom:
                                if (acBrECF1.getEstado() == EstadoECF.NAO_FISCAL) {
                                    acBrECF1.cancelaNaoFiscal();
                                } else {
                                    acBrECF1.cancelaCupom();
                                }
                                break;

                            case FechaCupom:
                                if (acBrECF1.getEstado() == EstadoECF.NAO_FISCAL) {
                                    acBrECF1.fechaNaoFiscal("Projeto ACBrFramework|http://acbrframework.sf.net", 0);
                                } else {
                                    acBrECF1.fechaCupom("Projeto ACBrFramework|http://acbrframework.sf.net");
                                }
                                break;
                        }
                        e.setRetornoEcf(new IntByReference(1));
                    } catch (ACBrException ex) {
                        e.setRetornoEcf(new IntByReference(0));
                        System.out.println(String.format("Exception - Evento: addOnComandaECF() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnComandaECFAbreVinculado(new ACBrEventListener<ComandaECFAbreVinculadoEventObject>() {
                @Override
                public void notification(ComandaECFAbreVinculadoEventObject e) {
                    try {
                        System.out.println(String.format("ECF - AbreVinculado, COO: %s IndiceECF: %s Valor: %.2f", e.getCoo(), e.getIndiceEcf(), e.getValor()));
                        acBrECF1.abreCupomVinculado(e.getCoo(), e.getIndiceEcf(), e.getValor());
                        e.setRetornoEcf(new IntByReference(1)); // 1 = true
                    } catch (Exception ex) {
                        e.setRetornoEcf(new IntByReference(0)); // 0 = false
                        System.out.println(String.format("Exception - Evento: addOnComandaECFAbreVinculado() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnComandaECFImprimeVia(new ACBrEventListener<ComandaECFImprimeViaEventObject>() {
                @Override
                public void notification(ComandaECFImprimeViaEventObject e) {
                    try {
                        System.out.println(String.format("ComandaECFImprimeVia, Tipo: %s Via: %d", e.getTipoRelatorio().getDescricao(), e.getVia()));
                        System.out.println(e.getImagemComprovante());
                        /**
                         * * Se estiver usando ACBrECF... Lembre-se de
                         * configurar *** ACBrECF1.MaxLinhasBuffer := 3; // Os
                         * homologadores permitem no máximo Impressao de 3 em 3
                         * linhas ACBrECF1.LinhasEntreCupons := 7; // (ajuste
                         * conforme o seu ECF)
                         *
                         * NOTA: ACBrECF nao possui comando para imprimir a 2a
                         * via do CCD
                         */
                        switch (e.getTipoRelatorio()) {
                            case Gerencial:
                                acBrECF1.linhaRelatorioGerencial(e.getImagemComprovante(), 0);
                                break;
                            case Vinculado:
                                acBrECF1.linhaCupomVinculado(e.getImagemComprovante());
                                break;
                        }
                        e.setRetornoEcf(new IntByReference(1));
                    } catch (Exception ex) {
                        e.setRetornoEcf(new IntByReference(0));
                        System.out.println(String.format("Exception - Evento: addOnComandaECFImprimeVia() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.addOnInfoECF(new ACBrEventListener<InfoECFEventObject>() {
                @Override
                public void notification(InfoECFEventObject e) {
                    try {
                        if (e.getOperacao() == InfoECF.EstadoECF) {
                            switch (acBrECF1.getEstado()) {
                                case EstadoECF.LIVRE:
                                    e.setRetornoEcf(RetornoECF.Livre);
                                    break;

                                case EstadoECF.VENDA:
                                    e.setRetornoEcf(RetornoECF.VendaDeItens);
                                    break;

                                case EstadoECF.PAGAMENTO:
                                    e.setRetornoEcf(RetornoECF.PagamentoOuSubTotal);
                                    break;

                                case EstadoECF.RELATORIO:
                                    e.setRetornoEcf(RetornoECF.RelatorioGerencial);
                                    break;

                                case EstadoECF.NAO_FISCAL:
                                    e.setRetornoEcf(RetornoECF.RecebimentoNaoFiscal);
                                    break;
                                default:
                                    e.setRetornoEcf(RetornoECF.Outro);
                                    break;
                            }
                        } else if (e.getOperacao() == InfoECF.SubTotal) {
                            double valor = acBrECF1.getSubTotal();
                            valor -= acBrECF1.getTotalPago() + 0;
                            e.setRetornoEcf(valor);
                        } else if (e.getOperacao() == InfoECF.TotalAPagar) {
                            double valor = 0;
                            e.setRetornoEcf(valor);
                        }

                    } catch (ACBrException ex) {
                        System.out.println(String.format("Exception - Evento: addOnInfoECF() Mensagem: %s", ex.getMessage()));
                    }
                }
            });

            acBrTEFD1.getTefCliSiTef().addOnExibeMenu(new ACBrEventListener<TEFCliSiTefExibeMenuEventObject>() {
                @Override
                public void notification(TEFCliSiTefExibeMenuEventObject e) {
                    int ret = exibeMenu(e.getTitulo(), e.getOpcoes());
                    if ((ret >= 0 && ret <= e.getOpcoesCount())) {
                        e.setItemSelecionado(ret);
                    } else {
                        e.setVoltarMenu(true);
                    }
                }
            });

            acBrTEFD1.getTefCliSiTef().addOnObtemCampo(new ACBrEventListener<TEFCliSiTefObtemCampoEventObject>() {
                @Override
                public void notification(TEFCliSiTefObtemCampoEventObject e) {
                    try {
                        System.out.println(e.getTitulo());
                        String ret = reader.readLine();
                        e.setResposta(ret);
                        e.setDigitado(new IntByReference(1));
                    } catch (IOException ex) {
                        e.setDigitado(new IntByReference(0));
                        System.out.println(String.format("Exception - Evento: addOnObtemCampo() Mensagem: %s", ex.getMessage()));
                    }
                }
            });
            
            teste();
            
            //Iniciar CliSiTef
            iniciarGP();

            //Ativar CliSiTef
            atv();
            
            teste1();

            //Carregar formas de pagamento da ECF
            //carregarFormasPagamento();

            //Teste 01
            //testePagamentoIntegralCartaoDebito();

            //Teste 02
            //testePagamentoParcialCartaoDebitoDinheiro();

            //Teste 03
            //testePagamentoIntegralCartaoDeCredito();

            //Teste 04
            //testePagamentoParcialCartaoDeCreditoDinheiro();

        } finally {
            if (acBrECF1 != null) {
                acBrECF1.desativar();
            }
        }
    }

    private static void teste() {
        //Abre Vende Subtotaliza
        abrirCupom();
        vendeItem(100);
        subTotaliza();
    }
    
    private static void teste1() {
        //Realizar Pagamento em cartao
        crt(100, INDICE_CARTAO_DEBITO);
    }
    
    private static void testePagamentoIntegralCartaoDebito() {
        //Abre Vende Subtotaliza
        abrirCupom();
        vendeItem(100);
        subTotaliza();

        //Realizar Pagamento em cartao
        crt(100, INDICE_CARTAO_DEBITO);
    }

    private static void testePagamentoIntegralCartaoDeCredito() {
        //Abre Vende Subtotaliza
        abrirCupom();
        vendeItem(100);
        subTotaliza();

        //Realizar Pagamento em cartao
        crt(100, INDICE_CARTAO_CREDITO);
    }

    private static void testePagamentoParcialCartaoDebitoDinheiro() {
        abrirCupom();
        vendeItem(100);
        subTotaliza();

        //Realizar Pagamento em cartao
        crt(80, INDICE_CARTAO_DEBITO);

        //Realiza pagamento em dinheiro
        realizaPagamento(20);

        //Fecha o cupom
        fechaCupom();

        //Imprime o comprovante do cartao
        imprimirTransacoesPendentes();
    }

    private static void testePagamentoParcialCartaoDeCreditoDinheiro() {
        abrirCupom();
        vendeItem(100);
        subTotaliza();

        //Realizar Pagamento em cartao
        crt(80, INDICE_CARTAO_CREDITO);

        //Realiza pagamento em dinheiro
        realizaPagamento(20);

        //Fecha o cupom
        fechaCupom();

        //Imprime o comprovante do cartao
        imprimirTransacoesPendentes();
    }

    private static int exibeMenu(String titulo, String[] opcoes) {
        int opcaoSelecionada = -1;
        StringBuilder opcoesPossiveis = new StringBuilder();

        try {
            System.out.println("\n======================================");
            System.out.println(titulo);
            for (int i = 0; i < opcoes.length; i++) {
                System.out.println(opcoes[i]);
                opcoesPossiveis.append(String.format("%d|", i));
            }
            opcoesPossiveis.append(String.format("%d", 99));
            System.out.println("99:Sair");

            String ret = "";
            while (!ret.matches(opcoesPossiveis.toString())) {
                ret = reader.readLine();
            }

            //SiTef espera a possição e não o numero
            opcaoSelecionada = Integer.parseInt(ret) - 1;

            System.out.println("\n======================================");
        } catch (IOException | NumberFormatException ex) {
            System.out.println(String.format("Exception - Evento: exibeMenu() Mensagem: %s", ex.getMessage()));
        }
        return opcaoSelecionada;
    }

    private static void cancelarCupom() {
        try {
            acBrECF1.cancelaCupom();
            System.out.println("ECF - Cancela Cupom");
            acBrTEFD1.cancelarTransacoesPendentes();
            System.out.println("TEF - Cancela Transações");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: cancelarCupom() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void abrirCupom() {
        try {
            if (acBrECF1.getEstado() == EstadoECF.VENDA || acBrECF1.getEstado() == EstadoECF.PAGAMENTO) {
                cancelarCupom();
            }
            System.out.println("ECF - abreCupom");
            acBrECF1.abreCupom();
            System.out.println("ECF - Cumpom Aberto");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: abrirCupom() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void vendeItem(double valor) {
        try {
            System.out.println("ECF - vendeItem");
            acBrECF1.vendeItem("0001", "PRODUTO TESTE", "I", 1, valor, 0, "UN", "%", "", 0);
            System.out.println("ECF - Vende Item");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: vendeItem() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void subTotaliza() {
        try {
            System.out.println("ECF - subtotalizaCupom");
            acBrECF1.subtotalizaCupom(0, "Mensagem Subtotaliza");
            System.out.println("ECF - SubTotaliza Cupom");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: subTotaliza() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void realizaPagamento(double valor) {
        try {
            System.out.println("Efetua Pagamento\n");
            acBrECF1.efetuaPagamento("01", valor, "MENSAGEM FORMA DE PAGTO", false);
        } catch (Throwable ex) {
            System.out.println(String.format("Exception - Evento: realizaPagamento() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void fechaCupom() {
        try {
            System.out.println("ECF - fechaCupom");
            acBrECF1.fechaCupom("MENSAGEM FECHAMENTO");
            System.out.println("ECF - FechaCupom");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: fechaCupom() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void crt(double valor, String indice) {
        try {
            acBrTEFD1.crt(valor, indice);
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: crt() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void imprimirTransacoesPendentes() {
        try {
            acBrTEFD1.imprimirTransacoesPendentes();
            System.out.println("TEF - Imprimindo Transações Pendentes");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: imprimirTransacoesPendentes() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void instanciarEcf() throws Throwable {
        System.out.println("jACBrFramework\n");
        System.out.println("Teste TefCliSiTef\n\n");

        System.out.println("Modelo selecionado  2. Bematech");
        int modelo = 2;

        System.out.println("Porta: COM1 ");
        String porta = "COM1";

        System.out.println("Criando componente ...");
        acBrECF1 = new ACBrECF();

        acBrECF1.setModelo(modelo);
        System.out.println("GetModeloStr: " + acBrECF1.getModeloStr() + "\n");

        acBrECF1.getDevice().setPorta(porta);
        System.out.println("GetPorta: " + acBrECF1.getDevice().getPorta() + "\n");
    }

    private static void ativarEcf() {
        try {
            System.out.print("GetAtivo");
            System.out.println(": " + acBrECF1.getAtivo());

            System.out.println("Ativar\n");
            acBrECF1.ativar();

            System.out.print("GetAtivo");
            System.out.println(": " + acBrECF1.getAtivo());

            System.out.print("GetDataHora");
            System.out.println(": " + acBrECF1.getDataHora().toString());

            //System.out.print("Leitura X");
            //ecf.leituraX();
        } catch (Throwable ex) {
            System.out.println(String.format("Exception - Evento: ativarEcf() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void carregarFormasPagamento() throws ACBrException {
        System.out.println("Carregando formas de pagamento...");
        acBrECF1.carregaFormasPagamento();
        for (int i = 0; i < acBrECF1.getFormasPagamento().length; i++) {
            FormaPagamento formaPagto = acBrECF1.getFormasPagamento()[i];
            System.out.println(" - " + formaPagto.getIndice() + " " + formaPagto.getDescricao());
        }
    }

    private static void vendaTeste() throws Throwable {
        try {
            System.out.println("\nCarrega Formas de Pagamento\n");
            acBrECF1.carregaFormasPagamento();

            System.out.println("Formas de pagamento\n");

            for (int i = 0; i < acBrECF1.getFormasPagamento().length; i++) {
                FormaPagamento formaPagto = acBrECF1.getFormasPagamento()[i];
                System.out.println(" - " + formaPagto.getIndice() + " " + formaPagto.getDescricao());
            }

            System.out.println("\nTesta cupom fiscal\n");
            acBrECF1.abreCupom();


            for (int i = 0; i < 10; i++) {
                System.out.println("Vende item " + i + "\n");
                acBrECF1.vendeItem("0001", "PRODUTO", "I", 3, 0.8, 10, "UN", "%", "D", 0);
            }

            System.out.println("Subtotaliza\n");
            acBrECF1.subtotalizaCupom(0, "Mensagem subtotaliza");

            System.out.println("Efetua Pagamento\n");
            FormaPagamento formaPagto = acBrECF1.getFormasPagamento()[0];
            acBrECF1.efetuaPagamento(formaPagto.getIndice(), 50, "MENSAGEM FORMA DE PAGTO", false);
            //ecf.efetuaPagamento("01", 50, "MENSAGEM FORMA DE PAGTO", false);

            System.out.println("Fecha cupom\n");
            acBrECF1.fechaCupom("MENSAGEM FECHAMENTO");

        } catch (Throwable ex) {
            System.out.println(String.format("Exception - Evento: vendaTeste() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void VerificarECFATV() {
        try {
            if (!acBrECF1.getAtivo()) {
                System.out.println("ATENÇÃO !! O ECF AINDA NÃO FOI ATIVADO");
            }
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: VerificarECFATV() Mensagem: %s", ex.getMessage()));
        }
    }

    private static void iniciarGP() {
        try {
            acBrTEFD1.setEsperaSleep(250);
            acBrTEFD1.inicializar(TefTipo.CliSiTef);
            System.out.println("Tef: CliSiTef - Iniciado");
            analisaTEF();
        } catch (Exception ex) {
            System.out.println("Exception " + ex.getMessage());
        }
    }

    private static void analisaTEF() throws ACBrException {
        int esperaSTS = 7;

        if (acBrTEFD1.getTefDial().isHabilitado()) {
            acBrTEFD1.getTefDial().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefDial) Habilitado");
        } else {
            acBrTEFD1.getTefDial().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefDial) Desabilitado");
        }

        if (acBrTEFD1.getTefDisc().isHabilitado()) {
            acBrTEFD1.getTefDisc().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefDisc) Habilitado");
        } else {
            acBrTEFD1.getTefDisc().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefDisc) Desabilitado");
        }

        if (acBrTEFD1.getTefHiper().isHabilitado()) {
            acBrTEFD1.getTefHiper().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefHiper) Habilitado");
        } else {
            acBrTEFD1.getTefHiper().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefHiper) Desabilitado");
        }

        if (acBrTEFD1.getTefCrediShop().isHabilitado()) {
            acBrTEFD1.getTefCrediShop().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefCrediShop) Habilitado");
        } else {
            acBrTEFD1.getTefCrediShop().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefCrediShop) Desabilitado");
        }

        if (acBrTEFD1.getTefAuttar().isHabilitado()) {
            acBrTEFD1.getTefAuttar().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefAuttar) Habilitado");
        } else {
            acBrTEFD1.getTefAuttar().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefAuttar) Desabilitado");
        }

        if (acBrTEFD1.getTefGPU().isHabilitado()) {
            acBrTEFD1.getTefGPU().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefGPU) Habilitado");
        } else {
            acBrTEFD1.getTefGPU().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefGPU) Desabilitado");
        }

        if (acBrTEFD1.getTefGood().isHabilitado()) {
            acBrTEFD1.getTefGood().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefGood) Habilitado");
        } else {
            acBrTEFD1.getTefGood().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefGood) Desabilitado");
        }

        if (acBrTEFD1.getTefFoxWin().isHabilitado()) {
            acBrTEFD1.getTefFoxWin().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefFoxWin) Habilitado");
        } else {
            acBrTEFD1.getTefFoxWin().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefFoxWin) Desabilitado");
        }

        if (acBrTEFD1.getTefPetrocard().isHabilitado()) {
            acBrTEFD1.getTefPetrocard().setEsperaSTS(esperaSTS);
            System.out.println("Tef: CliSiTef (TefPetrocard) Habilitado");
        } else {
            acBrTEFD1.getTefPetrocard().setEsperaSTS(7);
            System.out.println("Tef: CliSiTef (TefPetrocard) Desabilitado");
        }

    }

    private static void atv() {
        try {
            acBrTEFD1.atv(TefTipo.CliSiTef);
            System.out.println("ATV executado com sucesso");
        } catch (Exception ex) {
            System.out.println(String.format("Exception - Evento: ATV() Mensagem: %s", ex.getMessage()));
        }
    }
}
