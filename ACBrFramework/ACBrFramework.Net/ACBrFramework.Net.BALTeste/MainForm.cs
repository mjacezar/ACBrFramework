using System;
using System.Windows.Forms;
using ACBrFramework.BAL;

namespace ACBrFramework.Net.BALTeste
{
	public partial class MainForm : Form
	{
		#region Constructor

		public MainForm()
		{
			InitializeComponent();
			Popular();
		}

		#endregion Constructor

		#region EventHandlers

		private void acbrBAL_OnLePeso(object sender, LePesoEventArgs e)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new EventHandler<LePesoEventArgs>(acbrBAL_OnLePeso), sender, e);
			}
			else
			{
				this.pesoValueLabel.Text = string.Format("{0:n3}", e.Peso);
			}
		}

		private void readButton_Click(object sender, EventArgs e)
		{
			decimal peso = acbrBAL.LePeso();
			this.pesoValueLabel.Text = string.Format("{0:n3}", peso);
		}

		private void ativarCheckButton_CheckedChanged(object sender, EventArgs e)
		{
			if (ativarCheckButton.Checked)
			{
				Ativar();
			}
			else
			{
				Desativar();
			}
		}

		private void monitorarCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			acbrBAL.MonitoraBalanca = monitorarCheckBox.Checked;
		}

		#endregion EventHandlers

		#region Methods

		private void Popular()
		{
			modeloComboBox.Items.Clear();
			foreach (var modelo in Enum.GetValues(typeof(ModeloBal))) modeloComboBox.Items.Add(modelo);
			modeloComboBox.SelectedIndex = 0;
			pesoValueLabel.Text = "Aguardando...";

			portaComboBox.Items.Clear();
			portaComboBox.Items.Add("COM1");
			portaComboBox.Items.Add("COM2");
			portaComboBox.Items.Add("COM3");
			portaComboBox.Items.Add("COM4");
			portaComboBox.Items.Add("COM5");
			portaComboBox.Items.Add("COM6");
			portaComboBox.Items.Add("COM7");
			portaComboBox.Items.Add("COM8");
			portaComboBox.Items.Add("COM9");
			portaComboBox.SelectedIndex = 0;

			velocidadeComboBox.Items.Add(1200);
			velocidadeComboBox.Items.Add(2400);
			velocidadeComboBox.Items.Add(4800);
			velocidadeComboBox.Items.Add(9600);
			velocidadeComboBox.Items.Add(19200);
			velocidadeComboBox.Items.Add(38400);
			velocidadeComboBox.Items.Add(57600);
			velocidadeComboBox.Items.Add(115200);
			velocidadeComboBox.SelectedItem = 9600;

			ativarCheckButton.Checked = false;
		}

		public void Ativar()
		{
			try
			{
				acbrBAL.Modelo = (ModeloBal)modeloComboBox.SelectedItem;
				acbrBAL.Porta = (string)portaComboBox.SelectedItem;
				acbrBAL.Device.Baud = (int)velocidadeComboBox.SelectedItem;
				acbrBAL.Ativar();

				ativarCheckButton.Checked = true;
				ativarCheckButton.Text = "Desativar";

				messageToolStripStatusLabel.Text = "Ativo";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				ativarCheckButton.Checked = false;

				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		public void Desativar()
		{
			try
			{
				acbrBAL.Desativar();
				ativarCheckButton.Checked = false;
				ativarCheckButton.Text = "Ativar";

				messageToolStripStatusLabel.Text = "OK";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (NullReferenceException)
			{
				messageToolStripStatusLabel.Text = "Não inicializado.";
				descriptionToolStripStatusLabel.Text = string.Empty;
			}
			catch (Exception exception)
			{
				messageToolStripStatusLabel.Text = "Exception";
				descriptionToolStripStatusLabel.Text = exception.Message;
			}
		}

		#endregion Methods
	}
}