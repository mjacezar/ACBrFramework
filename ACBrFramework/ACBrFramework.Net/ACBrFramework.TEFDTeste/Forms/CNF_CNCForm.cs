using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ACBrFramework.TEFDTeste
{
    public partial class CNF_CNCForm : Form
    {
        #region Fields

        public bool IsNCN { get; set; }
        public string Rede { get; set; }
        public string NSU { get; set; }
        public string Finalizacao { get; set; }
        public decimal Valor { get; set; }

        #endregion Fields

        #region Constructor

        public CNF_CNCForm()
        {
            InitializeComponent();           
        }

        #endregion Constructor

        #region Methods

        private void Inicializa()
        {
            txtValor.Enabled = IsNCN;

            if (IsNCN)
            {
                this.Text = "NCN";
                btnOK.Text = "NCN";
            }
            else
            {
                this.Text = "CNF";
                btnOK.Text = "CNF";
            }
        }

        private void Finalizar()
        {
            decimal valor = 0;

            if (IsNCN && !decimal.TryParse(txtValor.Text, out valor))
                return;

            Rede = (string)cmbRede.SelectedItem;
            NSU = txtNSU.Text;
            Finalizacao = txtFinalizacao.Text;
            DialogResult = DialogResult.OK;
            Close();            
        }

        #endregion Methods       

        #region EventHandlers

        private void CNF_CNCForm_Load(object sender, EventArgs e)
        {
            Inicializa();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Finalizar();
        }

        #endregion EventHandlers        
    }
}
