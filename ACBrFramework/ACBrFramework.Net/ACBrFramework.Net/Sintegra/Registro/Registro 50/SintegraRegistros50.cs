using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ACBrFramework.Sintegra
{
    #region COM_INTEROP

#if COM_INTEROP

    [ComVisible(true)]
    [Guid("298A41E0-0FF5-465D-A6DC-55A62A8A7AD5")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

	public sealed class SintegraRegistros50 : ICollection<SintegraRegistro50>
	{
		#region Fields

		private List<SintegraRegistro50> list;

		#endregion Fields

		#region Constructor

		internal SintegraRegistros50()
		{
			this.list = new List<SintegraRegistro50>();
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
		public SintegraRegistro50 this[int index]
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

		public void Add(SintegraRegistro50 item)
		{
			list.Add(item);
		}

		public void AddRange(SintegraRegistro50[] item)
		{
			list.AddRange(item);
		}

		public bool Contains(SintegraRegistro50 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(SintegraRegistro50[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(SintegraRegistro50 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

        #region IEnumerable<SintegraRegistro50>

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

        IEnumerator<SintegraRegistro50> IEnumerable<SintegraRegistro50>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<SintegraRegistro50>
	}
}