namespace ACBrFramework.ECF
{
	public sealed class ConfigBarras : ACBrComposedComponent
	{
		#region Constructor

		internal ConfigBarras(ACBrECF acbrECF)
			: base(acbrECF)
		{

		}

		#endregion Constructor

		#region Properties

		public int Altura
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_ConfigBarras_GetAltura);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_ConfigBarras_SetAltura, value);
			}
		}

		public int LarguraLinha
		{
			get
			{
				return GetInt32(ACBrECFInterop.ECF_ConfigBarras_GetLarguraLinha);
			}
			set
			{
				SetInt32(ACBrECFInterop.ECF_ConfigBarras_SetLarguraLinha, value);
			}
		}

		public bool MostrarCodigo
		{
			get
			{
				return GetBool(ACBrECFInterop.ECF_ConfigBarras_GetMostrarCodigo);
			}
			set
			{
				SetBool(ACBrECFInterop.ECF_ConfigBarras_SetMostrarCodigo, value);
			}
		}

		#endregion Properties
	}
}
