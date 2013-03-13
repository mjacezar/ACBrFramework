using System;
using System.Collections.Generic;

namespace ACBrFramework.NFE
{
	public sealed class NFE : ACBrComposedComponent
	{
		#region Fields
		#endregion Fields

		#region Constructor

		internal NFE(ACBrNFE parent, IntPtr composedHandle)
			: base(parent, composedHandle)
		{
			this.Emit = new Emit(parent, composedHandle);
			this.InfNFE = new InfNFe(parent, composedHandle);
			this.Avulsa = new Avulsa(parent, composedHandle);
			this.Retirada = new Retirada(parent, composedHandle);
			this.Entrega = new Entrega(parent, composedHandle);
			this.Det = new DetCollection(parent, composedHandle);
		}

		#endregion Constructor

		#region Properties

		private new ACBrNFE Parent
		{
			get
			{
				return (ACBrNFE)base.Parent;
			}
		}

		public Schema Schema
		{
			get
			{
				return (Schema)GetInt32(ACBrNFEInterop.NFE_NFe_Getschema);
			}
			set
			{
				SetInt32(ACBrNFEInterop.NFE_NFe_Setschema, (int)value);
			}
		}

		public InfNFe InfNFE { get; private set; }
		public Emit Emit { get; private set; }
		public Avulsa Avulsa { get; private set; }
		public Retirada Retirada { get; private set; }
		public Entrega Entrega { get; private set; }
		public DetCollection Det { get; private set; }

		#endregion Properties

		#region Methods
		#endregion Methods
	}
}
