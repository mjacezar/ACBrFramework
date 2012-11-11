﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ACBrFramework.TEFD;

namespace ACBrFramework.TEFDTeste
{
    public partial class MenuForm : Form
    {
        private TEFCliSiTefExibeMenuEventArgs exibeMenuEventArgs;

        public MenuForm()
        {
            InitializeComponent();
        }

        public int SelectedItem
        {
            get
            {
                return this.optionsListBox.SelectedIndex;
            }
        }

		public void Initialize(TEFCliSiTefExibeMenuEventArgs exibeMenuEventArgs)
        {
            this.exibeMenuEventArgs = exibeMenuEventArgs;
            this.messageLabel.Text = exibeMenuEventArgs.Titulo;
            this.optionsListBox.DataSource = exibeMenuEventArgs.Opcoes;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show(this, "Selecione uma opção", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
