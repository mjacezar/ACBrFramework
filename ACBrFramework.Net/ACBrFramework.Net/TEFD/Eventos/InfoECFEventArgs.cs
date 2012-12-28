using System;

namespace ACBrFramework.TEFD
{
	public class InfoECFEventArgs : EventArgs
	{
		#region Constructor

		internal InfoECFEventArgs(InfoECF operacao)
		{
			this.Operacao = operacao;
		}

		#endregion Constructor

		#region Properties

		public InfoECF Operacao { get; private set; }

		public string Retorno { get; set; }

		public RetornoECF? RetornoECF
		{
			get
			{
				return GetAsRetornoECF();
			}
			set
			{
				SetAsRetornoECF(value);
			}
		}

		public decimal? Value
		{
			get
			{
				return GetAsDecimal();
			}
			set
			{
				SetAsDecimal(value);
			}
		}

		#endregion Properties

		#region Methods

		private RetornoECF? GetAsRetornoECF()
		{
			if (string.IsNullOrEmpty(Retorno)) return null;

			if (Retorno.Length == 1)
			{
				int value = (int)Retorno[0];
				if (Enum.IsDefined(typeof(RetornoECF), value))
				{
					return (RetornoECF)value;
				}
			}

			return null;
		}

		private void SetAsRetornoECF(RetornoECF? value)
		{
			if (value == null)
			{
				Retorno = null;
			}
			else
			{
				Retorno = ((char)value.Value).ToString();
			}
		}

		private decimal? GetAsDecimal()
		{
			decimal value;
			if (decimal.TryParse(Retorno, out value))
			{
				return value;
			}
			else
			{
				return null;
			}
		}

		private void SetAsDecimal(decimal? value)
		{
			if (value == null)
			{
				Retorno = null;
			}
			else
			{
				Retorno = string.Format("{0:n2}", value).Replace(".", string.Empty);
			}
		}

		#endregion Methods
	}
}