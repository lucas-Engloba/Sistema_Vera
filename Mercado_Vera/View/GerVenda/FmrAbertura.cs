using Mercado_Vera.Dao;
using Mercado_Vera.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mercado_Vera.View.GerVenda
{
    public partial class FmrAbertura : Form
    {
        DaoVenda daoVenda = new DaoVenda();

        private string id = "", nome = "", valor = "";

        public static string status = "Fechado";
        string data = DateTime.Now.ToString("yyyy-MM-dd");
        string hora = DateTime.Now.ToString("HH:mm:ss");


        public FmrAbertura()
        {
            InitializeComponent();
        }

        private void FmrAbertura_Load(object sender, EventArgs e)
        {
            txtCred.ReadOnly = true;
            txtCredia.ReadOnly = true;
            txtDeb.ReadOnly = true;
            txtDin.ReadOnly = true;
            txtTotal.ReadOnly = true;
            btnAbrirC.Focus();

            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = null;

            dataGridView1.DataSource = daoVenda.SelectVendaDia(data);

            DateTime date = DateTime.Parse(datePick.Text);
            ResumoPorData(date);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void datePick_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void datePick_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void datePick_ValueChanged(object sender, EventArgs e)
        {
            DateTime data = DateTime.Parse(datePick.Text);
            dataGridView1.DataSource = daoVenda.SelectVendaDia(data.ToString("yyyy-MM-dd"));

            ResumoPorData(data);

        }

        private void ResumoPorData(DateTime date)
        {


            SqlDataReader dt;
            dt = daoVenda.RetornaResumo(date.ToString("yyyy-MM-dd"));
            txtDin.Text = dt["DINHEIRO"].ToString();      
            txtCred.Text = dt["CREDITO"].ToString();           
            txtDeb.Text = dt["DEBITO"].ToString();
            txtCredia.Text = dt["CREDIARIO"].ToString();
            txtTotal.Text = dt["TOTAL"].ToString();
        }

        private void btnAbrirC_Click(object sender, EventArgs e)
        {
            //lblStatus.Text = status = "Aberto";
            //lblStatus.ForeColor = System.Drawing.Color.Green;
            //FmrCaixa caixa = new FmrCaixa();
            //caixa.GetStatusCaixa(status);
            this.Hide();
            FmrCaixa caixa = new FmrCaixa();
            caixa.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lblStatus.Text = status = "Fechado";
            //lblStatus.ForeColor = System.Drawing.Color.Red;
            //FmrCaixa caixa = new FmrCaixa();
            //caixa.GetStatusCaixa(status);
            FmrCaixa cx = new FmrCaixa();
            cx.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Fechamento fechamento = new Fechamento(txtDeb.Text, txtCred.Text, txtDin.Text, txtCredia.Text, txtTotal.Text, data, hora);
            DaoFechamento daoFechamento = new DaoFechamento();
            daoFechamento.Fechamento(fechamento);
            Documento.Print();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelResumo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Documento_PrintPage(object sender, PrintPageEventArgs e)
        {
            //chamando daoimprimir, puxando dados direto do banco.

            DaoImprimir daoImprimir = new DaoImprimir();

            SqlDataReader dr = daoImprimir.SelectLestFechamento();
            string dinheiro = "Dinheiro:  ......................     R$ " + dr["FECH_DINHEIRO"].ToString();
            string debito = "Débito:  .........................     R$ " + dr["FECH_DEBITO"].ToString();
            string credito = "Crédito:  ........................     R$ " + dr["FECH_CREDITO"].ToString();
            string crediario = "Crediário:  .....................     R$ " + dr["FECH_CREDIARIO"].ToString();
            string total = "Total:  ...........................      R$ " + dr["FECH_TOTAL"].ToString();
            string dataHora = "Data: " + dr["DATA"].ToString() + "  Hora: " + dr["HORA"].ToString();
            string nome = "LOJINHA DA VERA!";
            string fecha = "Fechamento de Caixa";
            string espaço = "------------------------------------------------------------";
            Font fonte = new Font("Arial", 10);

            //header
            e.Graphics.DrawString(nome, fonte, new SolidBrush(Color.Black), new Point(60, 10));
            e.Graphics.DrawString(espaço, fonte, new SolidBrush(Color.Black), new Point(0, 18));
            //header2
            e.Graphics.DrawString(fecha, fonte, new SolidBrush(Color.Black), new Point(60, 30));
            e.Graphics.DrawString(espaço, fonte, new SolidBrush(Color.Black), new Point(0, 45));
            //center itens
            e.Graphics.DrawString(dinheiro, fonte, new SolidBrush(Color.Black), new Point(10, 55));
            e.Graphics.DrawString(debito, fonte, new SolidBrush(Color.Black), new Point(10, 85));
            e.Graphics.DrawString(credito, fonte, new SolidBrush(Color.Black), new Point(10, 115));
            e.Graphics.DrawString(crediario, fonte, new SolidBrush(Color.Black), new Point(10, 145));
            //botom
            e.Graphics.DrawString(espaço, fonte, new SolidBrush(Color.Black), new Point(0, 158));
            e.Graphics.DrawString(total, fonte, new SolidBrush(Color.Black), new Point(10, 175));
            e.Graphics.DrawString(espaço, fonte, new SolidBrush(Color.Black), new Point(0, 195));
            //bottom2
            e.Graphics.DrawString(dataHora, fonte, new SolidBrush(Color.Black), new Point(10, 215));


        }

        private void btnExcluirVenda_Click(object sender, EventArgs e)
        {
            if (id != "" && nome != "" && valor != "")
            {
                try
                {
                    FmrRemoverVenda removerVenda = new FmrRemoverVenda();
                    removerVenda.GetVenda(id, nome, valor);
                    removerVenda.ShowDialog();

                    DateTime data = DateTime.Parse(datePick.Text);
                    dataGridView1.DataSource = daoVenda.SelectVendaDia(data.ToString("yyyy-MM-dd"));

                    DateTime date = DateTime.Parse(datePick.Text);
                    ResumoPorData(date);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error!!!," + ex.Message);
                }            
                finally
                {
                    id = "";
                    nome = "";
                    valor = "";
                }
            }
            else
            {
                MessageBox.Show("Selecione a venda primeiro!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id = Convert.ToString(this.dataGridView1.CurrentRow.Cells["IdVend"].Value);
                nome = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Cliente"].Value);
                valor = Convert.ToString(this.dataGridView1.CurrentRow.Cells["Valor"].Value);
            }
            catch (Exception)
            {

            }

        }
    }
}





