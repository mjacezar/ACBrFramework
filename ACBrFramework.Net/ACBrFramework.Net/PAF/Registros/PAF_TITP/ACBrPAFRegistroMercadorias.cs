using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("7AFC0F6D-CA64-4F43-BC4F-077D1D26B1EB")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class ACBrPAFRegistroMercadorias : ICollection<ACBrPAFRegistroMercadoria>
	{
		#region Fields

		private List<ACBrPAFRegistroMercadoria> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistroMercadorias()
		{
			this.list = new List<ACBrPAFRegistroMercadoria>();
		}

		#endregion Constructor

		#region Properties

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		[IndexerName("GetItem")]
		public ACBrPAFRegistroMercadoria this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		#endregion Properties

		#region Methods

		public void Add(ACBrPAFRegistroMercadoria mercadoria)
		{
			list.Add(mercadoria);
		}

		public void AddRange(ACBrPAFRegistroMercadoria[] mercadorias)
		{
			list.AddRange(mercadorias);
		}

		public bool Contains(ACBrPAFRegistroMercadoria item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroMercadoria[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroMercadoria item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrPAFRegistroMercadoria>

#if COM_INTEROP
        [DispId(-4)]
        public IDictionaryEnumerator GetEnumerator()
#else
		public IEnumerator GetEnumerator()
#endif
        {
#if COM_INTEROP
            return (IDictionaryEnumerator)(list.GetEnumerator() as IEnumerator);
#else
		    return list.GetEnumerator();
#endif
        }

        IEnumerator<ACBrPAFRegistroMercadoria> IEnumerable<ACBrPAFRegistroMercadoria>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroMercadoria>
	}
}