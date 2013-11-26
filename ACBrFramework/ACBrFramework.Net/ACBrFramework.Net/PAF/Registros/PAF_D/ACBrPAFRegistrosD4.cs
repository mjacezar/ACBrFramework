using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.PAF
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("95a1cc87-c985-49ff-bf02-a9980e96883a")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistrosD4 : ICollection<ACBrPAFRegistroD4>
	{
		#region Fields

		private List<ACBrPAFRegistroD4> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosD4()
		{
			this.list = new List<ACBrPAFRegistroD4>();
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
		public ACBrPAFRegistroD4 this[int index]
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

		public void Add(ACBrPAFRegistroD4 registrod3)
		{
			list.Add(registrod3);
		}

		public void AddRange(ACBrPAFRegistroD4[] registrosd3)
		{
			list.AddRange(registrosd3);
		}

		public bool Contains(ACBrPAFRegistroD4 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroD4[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroD4 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<ACBrPAFRegistroD4>

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

        IEnumerator<ACBrPAFRegistroD4> IEnumerable<ACBrPAFRegistroD4>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroD4>
	}
}