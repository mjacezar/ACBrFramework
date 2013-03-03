package jACBrFramework.serial.ecf;

import java.util.EventObject;

public class AbreCupomEventObject extends EventObject
{
	//<editor-fold defaultstate="collapsed" desc="Fields">
	
	private String cpf_CNPJ;
	private String nome;
	private String endereco;
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Constructor">
	
	public AbreCupomEventObject(Object source, String cpf_CNPJ, String nome, String endereco)
	{
		super(source);
		this.cpf_CNPJ = cpf_CNPJ;
		this.nome = nome;
		this.endereco = endereco;
	}
	
	//</editor-fold>

	//<editor-fold defaultstate="collapsed" desc="Properties">
	
	public String getCPF_CNPJ()
	{
		return cpf_CNPJ;
	}
	
	public String getNome()
	{
		return nome;
	}
	
	public String getEndereco()
	{
		return endereco;
	}
	
	//</editor-fold>
}
