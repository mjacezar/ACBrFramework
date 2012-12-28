using ACBrFramework.ECF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ACBrFramework
{
	[DesignTimeVisible(true)]
	[DesignerCategory("ACBrFramework")]
	[ProvideProperty("MemoBobinaControl", typeof(ACBrECF))]
	[ProvideProperty("MemoBobinaPropertyName", typeof(ACBrECF))]
	public class ACBrECFBobina : Component, IExtenderProvider
	{
		#region InnerTypes

		private class ECFInfo
		{
			#region Fields

			private StringBuilder memo;
			private IBindableComponent control;
			private bool resetMemo;

			#endregion Fields

			#region Properties

			public ACBrECF ECF { get; set; }

			public IBindableComponent Control
			{
				get
				{
					return control;
				}
				set
				{
					if (control != null && control != value)
					{
						RemoveHandler();
					}

					control = value;
					AddHandler();
				}
			}

			public string PropertyName { get; set; }

			public string Memo
			{
				get
				{
					if (ECF == null || memo == null) return string.Empty;
					return string.Format("<html>{0}</html>", memo);
				}
			}

			#endregion Properties

			#region Methods

			private void AddHandler()
			{
				if (control != null)
				{
					this.memo = new StringBuilder();
					this.ECF.OnBobinaAdicionaLinhas += ECF_OnBobinaAdicionaLinhas;
				}
			}

			private void RemoveHandler()
			{
				this.memo = null;
				this.ECF.OnBobinaAdicionaLinhas -= ECF_OnBobinaAdicionaLinhas;
			}

			private void OnMemoChanged()
			{
				Type type = control.GetType();
				PropertyInfo property = type.GetProperty(PropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

				if (property != null)
				{
					property.SetValue(control, Memo, null);
				}
			}

			private void ECF_OnBobinaAdicionaLinhas(object sender, BobinaEventArgs e)
			{
				switch (e.Operacao)
				{
					case "leiturax":
					case "reducaoz":
					case "abrecupom":
					case "abrenaofiscal":
					case "abrerelatoriogerencial":

						if (resetMemo)
						{
							memo.Length = 0;
							resetMemo = false;
						}

						break;

					default:

						resetMemo = true;
						break;
				}

				memo.Append(e.Linhas);

				OnMemoChanged();
			}

			#endregion Methods
		}

		#endregion InnerTypes

		#region Fields

		private Dictionary<IntPtr, ECFInfo> infos = new Dictionary<IntPtr, ECFInfo>();

		#endregion Fields

		#region Methods

		[DefaultValue(null)]
		[Category("Bobina")]
		public IBindableComponent GetMemoBobinaControl(ACBrECF ecf)
		{
			ECFInfo info;

			if (this.infos.TryGetValue(ecf.Handle, out info))
			{
				return info.Control;
			}
			else
			{
				return null;
			}
		}

		public void SetMemoBobinaControl(ACBrECF ecf, IBindableComponent control)
		{
			ECFInfo info;

			if (!this.infos.TryGetValue(ecf.Handle, out info))
			{
				info = new ECFInfo();
				info.ECF = ecf;
				infos.Add(ecf.Handle, info);
			}

			info.Control = control;
		}

		[DefaultValue("Text")]
		[Category("Bobina")]
		public string GetMemoBobinaPropertyName(ACBrECF ecf)
		{
			ECFInfo info;

			if (this.infos.TryGetValue(ecf.Handle, out info))
			{
				return info.PropertyName;
			}
			else
			{
				return null;
			}
		}

		public void SetMemoBobinaPropertyName(ACBrECF ecf, string propertyName)
		{
			ECFInfo info;

			if (!this.infos.TryGetValue(ecf.Handle, out info))
			{
				info = new ECFInfo();
				info.ECF = ecf;
				infos.Add(ecf.Handle, info);
			}

			info.PropertyName = propertyName;
		}

		#endregion Methods

		#region IExtenderProvider

		bool IExtenderProvider.CanExtend(object extendee)
		{
			return extendee is ACBrECF;
		}

		#endregion IExtenderProvider
	}
}