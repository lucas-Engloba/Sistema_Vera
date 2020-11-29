using Mercado_Vera.Dao;
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
    public partial class FmrRemoverVenda : Form
    {
        string valor ="", idProd="", nomeProd="", qtdProduto="";
        public static string qtdRemover;

        DaoVenda daoVenda = new DaoVenda();

        public void GetVenda(string id, string nome, string valor)
        {
            lblId.Text = id;
            lblCliente.Text = nome;
        }

        public FmrRemoverVenda()
        {
            InitializeComponent();
        }

        private void FmrRemoverVenda_Load(object sender, EventArgs e)
        {
            try
            {
                AtualizarDg();
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!!, " + ex.Message);
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir a venda permanentemente?", "Excluir produto", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            if (confirm.ToString().ToUpper() == "YES")
            {
                try
                {
                    daoVenda.DeleteVenda(lblValor.Text, lblCliente.Text, int.Parse(lblId.Text));
                    MessageBox.Show("Venda excluida com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!!!," + ex.Message);
                }

                this.Close();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProd == "")
                {
                    MessageBox.Show("Selecione o produto para remover!");
                }
                else
                {
                    FmrRemoverQtd removerQtd = new FmrRemoverQtd();
                    removerQtd.Getqtd(qtdProduto);
                    removerQtd.ShowDialog();

                    //qtdRemover = removerQtd.qtd;

                    daoVenda.DeleteItemVenda(valor, lblCliente.Text, int.Parse(idProd), int.Parse(lblId.Text), int.Parse(qtdRemover), int.Parse(qtdProduto), decimal.Parse(lblValor.Text));
                    AtualizarDg();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!!!," + ex);
            }
            finally
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = null;

                idProd = "";
                nomeProd = "";
                valor = "";
                qtdProduto = "";
                qtdRemover = "";
                qtdProduto = "";
            }   
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idProd = Convert.ToString(this.dataGridView1.CurrentRow.Cells["PROD_ID"].Value);
            nomeProd = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Clmn_Produto"].Value);
            valor = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Colmn_Valor"].Value);
            qtdProduto = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Colmn_Qtd"].Value);
        }

        public void AtualizarDg()
        {
            dataGridView1.DataSource = daoVenda.SelectVendaPorId(int.Parse(lblId.Text));
            lblValor.Text = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(i => Convert.ToDecimal(i.Cells[Colmn_Valor.Name].Value ?? 0)).ToString("##0.00");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
