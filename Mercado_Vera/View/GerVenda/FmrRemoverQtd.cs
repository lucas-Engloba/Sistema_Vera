using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerVenda
{
    public partial class FmrRemoverQtd : Form
    {
        public string qtd;

        public void Getqtd(string qtd)
        {
            this.qtd = qtd;
        }

        public FmrRemoverQtd()
        {
            InitializeComponent();
        }

        private void FmrRemoverQtd_Load(object sender, EventArgs e)
        {
           
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(txtQtd.Text == "" || txtQtd.Text =="0")
            {
                MessageBox.Show("Coloque uma quantidade valida!");
            }
            else if(int.Parse(qtd) < int.Parse(txtQtd.Text))
            {
                MessageBox.Show("A quantidade é maior do que o número de produtos comprados");
            }
            else
            {
                FmrRemoverVenda.qtdRemover = txtQtd.Text;           
                this.Close();
            }

        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            //esse if é para aceitar, setas e apagar
            if (e.KeyChar == 8)
                return;
            //se for diferente de numeros aparece a menssagem
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
