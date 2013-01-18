using System;
using System.ComponentModel;

namespace ACBrFramework.NFE
{
	public sealed class NFEConfiguracoes : ACBrComposedComponent
	{
		#region Constructor

		public NFEConfiguracoes(ACBrNFE parent)
			: base(parent)
		{
			this.Geral = new NFECFGGeral(parent);
			this.Arquivos = new NFECFGArquivos(parent);
			this.Certificados = new NFECFGCertificados(parent);
			this.WebServices = new NFECFGWebServices(parent);
		}

		#endregion Constructor

		#region Properties

		[Browsable(true)]
		public NFECFGGeral Geral { get; private set; }

		[Browsable(true)]
		public NFECFGArquivos Arquivos { get; private set; }

		[Browsable(true)]
		public NFECFGCertificados Certificados { get; private set; }

		[Browsable(true)]
		public NFECFGWebServices WebServices { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods

	}
}