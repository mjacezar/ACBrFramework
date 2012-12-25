using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ACBrFramework.IBGE
{
	[ToolboxBitmap(typeof(ToolboxIcons), @"ACBrFramework.IBGE.ico.bmp")]
	public sealed class ACBrIBGE : ACBrComponent, IDisposable
	{
		#region Events

		public event EventHandler OnBuscaEfetuada
		{
			add
			{
				onBuscaEfetuada.Add(value);
			}
			remove
			{
				onBuscaEfetuada.Remove(value);
			}
		}

		#endregion Events

		#region Fields

		private readonly ACBrEventHandler<ACBrIBGEInterop.OnBuscaEfetuadaCallback> onBuscaEfetuada;
		private ACBrIBGECidade[] cidades;

		#endregion Fields

		#region Constructor

		public ACBrIBGE()
		{
			onBuscaEfetuada = new ACBrEventHandler<ACBrIBGEInterop.OnBuscaEfetuadaCallback>(this, OnBuscaEfetuadaCallback, ACBrIBGEInterop.IBGE_SetOnBuscaEfetuada);
		}

		#endregion Constructor

		#region Properties

		[Browsable(false)]
		public ACBrIBGECidade[] Cidades
		{
			get
			{
				if (cidades == null) CarregaCidades();
				return cidades;
			}
		}

		#endregion Properties

		#region Methods

		public void BuscarPorCodigo(int codigo)
		{
			cidades = null;
			int ret = ACBrIBGEInterop.IBGE_BuscarPorCodigo(this.Handle, codigo);
			CheckResult(ret);
		}

		public void BuscarPorNome(string nome)
		{
			cidades = null;
			int ret = ACBrIBGEInterop.IBGE_BuscarPorNome(this.Handle, ToUTF8(nome));
			CheckResult(ret);
		}

		private void CarregaCidades()
		{
			int count = ACBrIBGEInterop.IBGE_Cidades_GetCount(this.Handle);
			CheckResult(count);

			cidades = new ACBrIBGECidade[count];

			for (int i = 0; i < count; i++)
			{
				ACBrIBGEInterop.CidadeRec cidadeRec = new ACBrIBGEInterop.CidadeRec();
				int ret = ACBrIBGEInterop.IBGE_Cidades_GetItem(this.Handle, ref cidadeRec, i);
				CheckResult(ret);

				ACBrIBGECidade cidade = new ACBrIBGECidade();
				cidade.Municipio = FromUTF8(cidadeRec.Municipio);
				cidade.CodMunicio = cidadeRec.CodMunicio;
				cidade.UF = FromUTF8(cidadeRec.UF);
				cidade.CodUF = cidadeRec.CodUF;
				cidade.Area = cidadeRec.Area;

				cidades[i] = cidade;
			}
		}

		#region Callback EventHandlers

		[AllowReversePInvokeCalls]
		private void OnBuscaEfetuadaCallback()
		{
			if (onBuscaEfetuada.IsAssigned)
			{
				onBuscaEfetuada.Raise();
			}
		}

		#endregion Callback EventHandlers

		#region Override Methods

		protected internal override void OnInitializeComponent()
		{
			CallCreate(ACBrIBGEInterop.IBGE_Create);
		}

		protected internal override void CheckResult(int ret)
		{
			switch (ret)
			{
				case -1:

					const int BUFFER_LEN = 1024;
					string error = GetString(ACBrIBGEInterop.IBGE_GetUltimoErro, BUFFER_LEN);
					throw new ACBrException(error);

				case -2:

					throw new ACBrException("ACBr IBGE não inicializado.");
			}
		}

		protected override void OnDisposing()
		{
			if (this.Handle != IntPtr.Zero)
			{
				CallDestroy(ACBrIBGEInterop.IBGE_Destroy);
			}
		}

		#endregion Override Methods

		#endregion Methods
	}
}