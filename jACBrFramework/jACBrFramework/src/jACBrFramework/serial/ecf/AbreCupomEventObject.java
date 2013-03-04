package jACBrFramework.serial.ecf;

import java.util.EventObject;

public final class AbreCupomEventObject extends EventObject
{

	//<editor-fold defaultstate="collapsed" desc="Fields">
	private String cPF_CNPJ;
	private String nome;
	private String endereco;

//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Constructor">
	public AbreCupomEventObject(Object source, String cPF_CNPJ, String nome, String endereco)
	{
		super(source);
		this.cPF_CNPJ = cPF_CNPJ;
		this.nome = nome;
		this.endereco = endereco;
	}

//</editor-fold>
	
	//<editor-fold defaultstate="collapsed" desc="Properties">
	public String getCPF_CNPJ()
	{
		return this.cPF_CNPJ;
	}

	public String getNome()
	{
		return this.nome;
	}

	public String getEndereco()
	{
		return this.endereco;
	}
//</editor-fold>

}
