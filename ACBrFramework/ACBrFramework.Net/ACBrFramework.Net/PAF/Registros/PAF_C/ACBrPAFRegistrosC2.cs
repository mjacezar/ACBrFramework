using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
#region COM_INTEROP
#if COM_INTEROP

using System.Runtime.InteropServices;

#endif
#endregion COM_INTEROP

namespace ACBrFramework.PAF
{
	#region COM_INTEROP

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("8D1504E1-FFA6-4E96-AAE1-8A260987A141")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
#endif

	#endregion COM_INTEROP

	public sealed class ACBrPAFRegistrosC2 : ICollection<ACBrPAFRegistroC2>
	{
		#region Fields

		private List<ACBrPAFRegistroC2> list;

		#endregion Fields

		#region Constructor

		internal ACBrPAFRegistrosC2()
		{
			this.list = new List<ACBrPAFRegistroC2>();
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
		public ACBrPAFRegistroC2 this[int index]
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

		public void Add(ACBrPAFRegistroC2 registroc2)
		{
			list.Add(registroc2);
		}

		public void AddRange(ACBrPAFRegistroC2[] registrosc2)
		{
			list.AddRange(registrosc2);
		}

		public bool Contains(ACBrPAFRegistroC2 item)
		{
			return list.Contains(item);
		}

		public void CopyTo(ACBrPAFRegistroC2[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public bool Remove(ACBrPAFRegistroC2 item)
		{
			return list.Remove(item);
		}

		public void Clear()
		{
			list.Clear();
		}

		#endregion Methods

		#region IEnumerable<ACBrPAFRegistroC2>

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

		IEnumerator<ACBrPAFRegistroC2> IEnumerable<ACBrPAFRegistroC2>.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		#endregion IEnumerable<ACBrPAFRegistroC2>
	}
}