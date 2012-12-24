using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACBrFramework.SPED
{
    public sealed class ACBrSpedRegistro0150List : ICollection<ACBrSpedRegistro0150>
    {
        #region Fields

        private List<ACBrSpedRegistro0150> list;

        #endregion Fields

        #region Constructor

        internal ACBrSpedRegistro0150List()
        {
            this.list = new List<ACBrSpedRegistro0150>();
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
        public ACBrSpedRegistro0150 this[int index]
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

        public void Add(ACBrSpedRegistro0150 value)
        {
            list.Add(value);
        }

        public void AddRange(ACBrSpedRegistro0150[] values)
        {
            list.AddRange(values);
        }

        public bool Contains(ACBrSpedRegistro0150 value)
        {
            return list.Contains(value);
        }

        public void CopyTo(ACBrSpedRegistro0150[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ACBrSpedRegistro0150 item)
        {
            return list.Remove(item);
        }

		public bool LocalizaRegistro(string COD_PART)
		{
			bool retorno = false;
			int ret = -1;

			ret = list.FindIndex(p => p.COD_PART == COD_PART);
			if (ret > -1)
				retorno = true;

			return retorno;
		}

        public void Clear()
        {
            list.Clear();
        }

        #endregion Methods

        #region IEnumerable<ACBrSpedRegistro0150>

        public IEnumerator<ACBrSpedRegistro0150> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        #endregion IEnumerable<ACBrSpedRegistro0150>
    }
}