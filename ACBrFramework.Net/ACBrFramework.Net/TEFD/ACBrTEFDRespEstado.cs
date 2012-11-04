namespace ACBrFramework.TEFD
{
	public enum ACBrTEFDRespEstado
	{
		#region Documentation

		/// <summary>
		///  Nennhuma Resposta em andamento
		/// </summary>

		#endregion Documentation

		Nenhum,

		#region Documentation

		/// <summary>
		/// Requisição Escrita, Aguardando Resposta
		/// </summary>

		#endregion Documentation

		AguardandoResposta,

		#region Documentation

		/// <summary>
		/// Processando a Resposta
		/// </summary>

		#endregion Documentation

		Processando,

		#region Documentation

		/// <summary>
		/// Concluida
		/// </summary>

		#endregion Documentation

		Concluida
	}
}