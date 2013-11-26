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
    [Guid("2452CB98-A2FA-4C58-B9B4-8154777CB469")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
#endif

    #endregion COM_INTEROP

    public sealed class ACBrPAFRegistrosA2 : ICollection<ACBrPAFRegistroA2>
    {
        #region Fields

        private List<ACBrPAFRegistroA2> list;

        #endregion Fields

        #region Constructor

        internal ACBrPAFRegistrosA2()
        {
            this.list = new List<ACBrPAFRegistroA2>();
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
        public ACBrPAFRegistroA2 this[int index]
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

        public void Add(ACBrPAFRegistroA2 registrob2)
        {
            list.Add(registrob2);
        }

        public void AddRange(ACBrPAFRegistroA2[] registrosb2)
        {
            list.AddRange(registrosb2);
        }

        public bool Contains(ACBrPAFRegistroA2 item)
        {
            return list.Contains(item);
        }

        public void CopyTo(ACBrPAFRegistroA2[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrPAFRegistroA2 item)
        {
            return list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ACBrPAFRegistroA2>

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

        IEnumerator<ACBrPAFRegistroA2> IEnumerable<ACBrPAFRegistroA2>.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrPAFRegistroA2>
    }
}