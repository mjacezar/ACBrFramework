using System;

namespace ACBrFramework.Validador
{
	public sealed class Modulo : ACBrComposedComponent
	{
		#region Constructor

		internal Modulo(ACBrValidador acbrValidador)
			: base(acbrValidador)
		{

		}

		#endregion Constructor

		#region Properties

		public string Documento
		{
			get
			{
				return GetString(ACBrValidadorInterop.VAL_Modulo_GetDocumento);
			}
			set
			{
				SetString(ACBrValidadorInterop.VAL_Modulo_SetDocumento, value);
			}
		}

		public int MultiplicadorInicial
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetMultiplicadorInicial);
			}
			set
			{
				SetInt32(ACBrValidadorInterop.VAL_Modulo_SetMultiplicadorInicial, value);
			}
		}

		public int MultiplicadorFinal
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetMultiplicadorFinal);
			}
			set
			{
				SetInt32(ACBrValidadorInterop.VAL_Modulo_SetMultiplicadorFinal, value);
			}
		}

		public int MultiplicadorAtual
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetMultiplicadorAtual);
			}
			set
			{
				SetInt32(ACBrValidadorInterop.VAL_Modulo_SetMultiplicadorAtual, value);
			}
		}

		public int DigitoFinal
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetDigitoFinal);
			}
		}

		public int ModuloFinal
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetModuloFinal);
			}
		}

		public int SomaDigitos
		{
			get
			{
				return GetInt32(ACBrValidadorInterop.VAL_Modulo_GetSomaDigitos);
			}
		}

		public CalcDigFormula FormulaDigito
		{
			get
			{
				return (CalcDigFormula)GetInt32(ACBrValidadorInterop.VAL_Modulo_GetFormulaDigito);
			}
			set
			{
				SetInt32(ACBrValidadorInterop.VAL_Modulo_SetFormulaDigito, (int)value);
			}
		}

		#endregion Properties		

		#region Methods

		public void Calcular()
		{
			int ret = ACBrValidadorInterop.VAL_Modulo_Calcular(this.Handle);
			CheckResult(ret);
		}

		public void CalculoPadrao()
		{
			int ret = ACBrValidadorInterop.VAL_Modulo_CalculoPadrao(this.Handle);
			CheckResult(ret);
		}

		#endregion Methods
	}
}
