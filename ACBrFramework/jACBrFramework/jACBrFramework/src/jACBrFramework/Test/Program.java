package jACBrFramework.Test;

import jACBrFramework.ACBrEventListener;
import java.io.BufferedReader;
import java.io.InputStreamReader;

import jACBrFramework.serial.ecf.ACBrECF;
import jACBrFramework.serial.ecf.AbreCupomEventObject;
import jACBrFramework.serial.ecf.DAV;
import jACBrFramework.serial.ecf.FormaPagamento;
import jACBrFramework.serial.ecf.VendeItemEventObject;
import java.util.Date;
import java.util.EventObject;

public class Program
{

	/**
	 * @param args
	 */
	public static void main(String[] args) throws Throwable
	{
		ACBrECF ecf = null;

		try {
			BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

			System.out.println("jACBrFramework\n\n");

			System.out.println("SELECIONE O MODELO DE ECF:\n");
			System.out.println("  1. NaoFiscal");
			System.out.println("  2. Bematech");
			System.out.println("  3. Sweda");
			System.out.println("  4. Daruma");
			System.out.println("  5. Schalter");
			System.out.println("  6. Mecaf");
			System.out.println("  7. Yanco");
			System.out.println("  8. DataRegis");
			System.out.println("  9. Urano");
			System.out.println(" 10. ICash");
			System.out.println(" 11. Quattro");
			System.out.println(" 12. FiscNET");
			System.out.println(" 13. Epson");
			System.out.println(" 14. NCR");
			System.out.println(" 15. SwedaSTX");

			System.out.println("\nEntre com o ECF: ");

			int modelo = new Integer(reader.readLine()).intValue();

			System.out.println("\nEntre com a porta: ");
			String porta = reader.readLine();

			System.out.println("\nCriando componente ...\n");
			ecf = new ACBrECF();

			
			System.out.println("\nExemplo de eventos do ECF ...\n");
			ecf.addOnAntesAbreCupom(new ACBrEventListener<AbreCupomEventObject>() {

				@Override
				public void notification(AbreCupomEventObject e)
				{
					System.out.println(">> Evento OnAntesAbreCupom <<");
				}
			} );
			
			ecf.addOnDepoisVendeItem(new ACBrEventListener<VendeItemEventObject>() {

				@Override
				public void notification(VendeItemEventObject e)
				{
					System.out.println(">> Evento OnDepoisVendeItem <<");
					System.out.println(e.getCodigo() + " " + e.getDescricao());
				}
			});

			ecf.addOnMsgPoucoPapel(new ACBrEventListener<EventObject>() {

				@Override
				public void notification(EventObject e)
				{
					System.out.println(">> Evento OnMsgPoucoPapel <<");
				}
			});
			

			System.out.println("SetModelo\n");
			ecf.setModelo(modelo);


			System.out.print("GetModeloStr");
			System.out.println(": " + ecf.getModeloStr() + "\n");

			System.out.println("SetPorta\n");
			ecf.getDevice().setPorta(porta);

			System.out.print("GetPorta");
			System.out.println(": " + ecf.getDevice().getPorta() + "\n");

			System.out.print("GetAtivo");
			System.out.println(": " + ecf.getAtivo());
			
			
			System.out.println("Ativar\n");
			ecf.ativar();

			System.out.print("GetAtivo");
			System.out.println(": " + ecf.getAtivo());

			
			System.out.print("GetDataHora");
			System.out.println(": " + ecf.getDataHora().toString());


        DAV[] lDavs = new DAV[3];
        for (int i = 0; i < lDavs.length; i++) {
            lDavs[i] = new DAV();
            lDavs[i].setCooCupom(i);
            lDavs[i].setCooDAV(i + 1);
            lDavs[i].setDtEmissao(new Date());
            lDavs[i].setNumero(String.valueOf(i));
            lDavs[i].setTitulo("Pedido" + i);
            lDavs[i].setValor(i + 100);
        }            
        
        ecf.pafMF_RelDAVEmitidos(lDavs, "DAVs", 0);
			System.out.println("\nLeituraX\n");
			ecf.corrigeEstadoErro(true);
			ecf.leituraX();

			System.out.println("\nCarrega Formas de Pagamento\n");
			ecf.carregaFormasPagamento();

			System.out.println("Formas de pagamento\n");

			for (int i = 0; i < ecf.getFormasPagamento().length; i++) 
			{
				FormaPagamento formaPagto = ecf.getFormasPagamento()[i];
				System.out.println(" - " + formaPagto.getIndice() + " " + formaPagto.getDescricao());
			}

            System.out.println("\nImprimindo relatório com as formas de pagamento");
            FormaPagamento[] lForma = {
                new FormaPagamento("Dinheiro", 100, new Date(), "Cupom Fiscal"),
                new FormaPagamento("Cheque", 150, new Date(), "Cupom Fiscal"),
                new FormaPagamento("Dinheiro", 3000, new Date(), "Nota Fiscal"),
            };
            ecf.pafMF_RelMeiosPagamento(lForma, "MEIOS DE PAGAMENTO", 0);
			System.out.println("\nTesta cupom fiscal\n");
			ecf.abreCupom();


			for (int i = 0; i < 10; i++) {
				System.out.println("Vende item " + i + "\n");
				ecf.vendeItem("0001", "PRODUTO", "I", 3, 0.8, 10, "UN", "%", "D", 0);
			}

			System.out.println("Subtotaliza\n");
			ecf.subtotalizaCupom(0, "Mensagem subtotaliza");

			System.out.println("Efetua Pagamento\n");
			FormaPagamento formaPagto = ecf.getFormasPagamento()[0];
			ecf.efetuaPagamento(formaPagto.getIndice(), 50, "MENSAGEM FORMA DE PAGTO", false);
			//ecf.efetuaPagamento("01", 50, "MENSAGEM FORMA DE PAGTO", false);

			System.out.println("Fecha cupom\n");
			ecf.fechaCupom("MENSAGEM FECHAMENTO");


			System.out.println("Finalizado\n");
			ecf.desativar();
			ecf = null;

			reader.readLine();

		}
		/*
		catch (Throwable t) {
			System.out.println(t.getMessage());
		}*/
		finally {
			if (ecf != null) {
				ecf.desativar();
			}
		}


		System.in.read();
	}
}
