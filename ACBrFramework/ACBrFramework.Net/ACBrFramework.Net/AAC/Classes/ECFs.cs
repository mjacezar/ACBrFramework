using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.AAC
{
	public sealed class ECFs : ACBrComposedComponent, IEnumerable<AACECF>
	{
		#region Constructor

		internal ECFs(IdenticacaoPaf identPaf)
			: base(identPaf.Parent)
		{
		}

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return GetInt32(ACBrAACInterop.AAC_IdentPaf_ECFsAutorizados_Count);
			}
		}

		[IndexerName("GetItem")]
		public AACECF this[int index]
		{
			get
			{
				return Get(index);
			}
		}

		#endregion Properties

		#region Methods

		public void New(AACECF aacECF)
		{
			ACBrAACInterop.TECFAutorizado item = new ACBrAACInterop.TECFAutorizado();
			item.ValorGT = Convert.ToDouble(aacECF.ValorGT);
			item.NumeroSerie = aacECF.NumeroSerie;
			item.CNI = aacECF.CNI;
			item.CRO = aacECF.CRO;

			int ret = ACBrAACInterop.AAC_IdentPaf_ECFsAutorizados_New(this.Handle, item);
			CheckResult(ret);
		}

		public void Clear()
		{
			int ret = ACBrAACInterop.AAC_IdentPaf_ECFsAutorizados_Clear(this.Handle);
			CheckResult(ret);
		}

		private AACECF Get(int index)
		{
			ACBrAACInterop.TECFAutorizado item = new ACBrAACInterop.TECFAutorizado();
			int ret = ACBrAACInterop.AAC_IdentPaf_ECFsAutorizados_Get(this.Handle, ref item, index);
			CheckResult(ret);

			AACECF aacECF = new AACECF();
			aacECF.ValorGT = Convert.ToDecimal(item.ValorGT);
			aacECF.NumeroSerie = item.NumeroSerie;
			aacECF.CNI = item.CNI;
			aacECF.CRO = item.CRO;
			aacECF.DtHrAtualizado = DateTime.FromOADate(item.DtHrAtualizado);

			return aacECF;
		}

		#endregion Methods

		#region IEnumerable<ACBrAACECF>

		public IEnumerator<AACECF> GetEnumerator()
		{
			int count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return Get(i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		#endregion IEnumerable<ACBrAACECF>
	}
}