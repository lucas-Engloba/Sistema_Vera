using dllDao;
using Mercado_Vera.Dao;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Mercado_Vera.View.GerVenda
{
    public partial class Financeiro : Form
    {

        DaoVenda daoVenda = new DaoVenda();
        SqlConnection Conn = new SqlConnection(@"Data Source=DESKTOP-LUCAS\SQLEXPRESS;Initial Catalog=MERCADO_01;Integrated Security=True");
        //SqlConnection Conn = new SqlConnection(@"Data Source=JEAN-PC\SQLEXPRESS;Initial Catalog=MERCADO_01;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        DaoFechamento daoFechamento = new DaoFechamento();


        public Financeiro()
        {
            InitializeComponent();
        }

        private void Financeiro_Load(object sender, EventArgs e)
        {
            Graf_Pior_Vendas();
            Graf_Melhor_Vendidos();
            Graf_Vendas_dia();
            Graf_Vendas_mes();
            Graf_Qtd_Dia();
            Graf_Qtd_Mes();
            divida();
            valor();
            Fat_Month();
            Fat_Day();
            btnGraf.Enabled = true;
            btnHome.Enabled = false;
            ResumoPagamento();

            //string date = dateTimePicker1.Text;
            //SqlDataReader dr = daoFechamento.GetMensal(date);

            //lblValorMensal.Text = dr["valor"].ToString();

        }

        public void ResumoPagamento()
        {
            DateTime date = DateTime.Now;
            SqlDataReader dt;
            dt = daoVenda.RetornaResumo(date.ToString("yyyy-MM-dd"));

            button7.Text = dt["DINHEIRO"].ToString();
            button6.Text  = dt["CREDITO"].ToString();
            button8.Text = dt["DEBITO"].ToString();
            button9.Text = dt["CREDIARIO"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        //CRIO OS ARRAYS QUE RECEBEM OS DAODS PARA PASSAEM PARA OS GRAFICOS
        ArrayList PRODUTO = new ArrayList();
        ArrayList SAIDAS = new ArrayList();

        // CRIO UM METHOD QUE RECEBE OS DADOS DO BANDO PASSANDO UMA STORED PROCEDURE RETORNANDO OS DADOS ESPECIFICADOS
        private void Graf_Melhor_Vendidos()
        {
            cmd = new SqlCommand("PROD_MAIS_COMPRADOS", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {   //AQUI FAZ OS TESTES E RETORNA A COLUNA EM QUE ESTA O DADO
                PRODUTO.Add(dr.GetString(0));
                SAIDAS.Add(dr.GetInt32(1));

            }
            // AQUI PASSO O NOME DO GRAFICO QUE RECEBE OS DADOS E CONVERTO PARA QUE ENTRE NOS EIXOS X E Y
            chart2.Series[0].Points.DataBindXY(PRODUTO, SAIDAS);
            dr.Close();
            Conn.Close();
        }
        ArrayList PROD = new ArrayList();
        ArrayList SAID = new ArrayList();

        public object painelContenedor { get; private set; }

        private void Graf_Pior_Vendas()
        {

            cmd = new SqlCommand("PROD_MENOS_VENDIDOS", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                PROD.Add(dr.GetString(0));
                SAID.Add(dr.GetInt32(1));

            }
            chart1.Series[0].Points.DataBindXY(PROD, SAID);
            dr.Close();
            Conn.Close();

        }

        private void divida()
        {   // REPITO O MESMO PROCESSO ACIMA
            SqlCommand cmd = new SqlCommand("SELECT SUM(CLI_DIVIDA) AS VALOR FROM TBL_CLIENTE WHERE CLI_ID > 1", Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();

            string seuValor = cmd.ExecuteScalar().ToString();

            button2.Text = "R$  " + seuValor;
            Conn.Close();
        }
        private void valor()
        { // AQUI CRIO UM CHAMADO CMD PARA QUE COM O SQLCOMMAND ELE RETORNE OS DADOS DO BANCO EM UMA LABEL
            SqlCommand cmd = new SqlCommand("SELECT -1* CLI_DIVIDA AS TOTAL FROM TBL_CLIENTE WHERE CLI_ID <= 1", Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();

            string seuValor = cmd.ExecuteScalar().ToString();

            button1.Text = "R$  " + seuValor;
            Conn.Close();
        }



        private void Fat_Month()
        {   // REPITO O MESMO PROCESSO ACIMA
            SqlCommand cmd = new SqlCommand("SELECT TOP (1) SUM(VEN_TOTAL) AS VALOR, MONTH(VEN_DATE) AS DATA FROM TBL_VENDA GROUP BY MONTH(VEN_DATE) ORDER BY MONTH(VEN_DATE) DESC", Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();

            string ValorAtual = cmd.ExecuteScalar().ToString();

            button3.Text = "R$  " + ValorAtual;
            Conn.Close();
        }
        private void Fat_Day()
        {   // REPITO O MESMO PROCESSO ACIMA
            SqlCommand cmd = new SqlCommand("SELECT TOP(1) SUM(VEN_TOTAL) AS VALOR, DAY(VEN_DATE) FROM TBL_VENDA GROUP BY VEN_DATE ORDER BY VEN_DATE DESC", Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();

            string ValorAtual = cmd.ExecuteScalar().ToString();

            button5.Text = "R$  " + ValorAtual;
            Conn.Close();
        }
        //private void Fat_Dinheiro()
        //{   // REPITO O MESMO PROCESSO ACIMA
        //    SqlCommand cmd = new SqlCommand("SELECT TOP (1) SUM(VEN_TOTAL), VEN_DATE FROM TBL_VENDA WHERE VEN_PAGAMENTO = 'DINHEIRO' GROUP BY VEN_DATE ORDER BY VEN_DATE DESC", Conn);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    Conn.Open();

        //    string ValorAtual = cmd.ExecuteScalar().ToString();

        //    button7.Text = "R$  " + ValorAtual;
        //    Conn.Close();
        //}
        //private void Fat_Deb()
        //{   // REPITO O MESMO PROCESSO ACIMA
        //    SqlCommand cmd = new SqlCommand("SELECT TOP (1)  SUM(VEN_TOTAL), VEN_DATE FROM TBL_VENDA WHERE VEN_PAGAMENTO = 'DÉBITO' GROUP BY VEN_DATE ORDER BY VEN_DATE DESC", Conn);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    Conn.Open();

        //    string ValorAtual = cmd.ExecuteScalar().ToString();

        //    button8.Text = "R$  " + ValorAtual;
        //    Conn.Close();
        //}
        //private void Fat_Cre()
        //{   // REPITO O MESMO PROCESSO ACIMA
        //    SqlCommand cmd = new SqlCommand("SELECT TOP (1)  SUM(VEN_TOTAL), VEN_DATE FROM TBL_VENDA WHERE VEN_PAGAMENTO = 'CRÉDITO' GROUP BY VEN_DATE ORDER BY VEN_DATE DESC", Conn);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    Conn.Open();

        //    string ValorAtual = cmd.ExecuteScalar().ToString();

        //    button6.Text = "R$  " + ValorAtual;
        //    Conn.Close();
        //}

        private void Fat_Crediario()
        {   // REPITO O MESMO PROCESSO ACIMA
            SqlCommand cmd = new SqlCommand("SELECT TOP (1) SUM(VEN_TOTAL), VEN_DATE FROM TBL_VENDA WHERE VEN_PAGAMENTO = 'CREDIÁRIO' GROUP BY VEN_DATE ORDER BY VEN_DATE DESC", Conn);
            //cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();

            string ValorAtual = cmd.ExecuteScalar().ToString();

            button9.Text = "R$  " + "-" + ValorAtual;
            Conn.Close();
        }


        ArrayList DATA = new ArrayList();
        ArrayList VALOR1 = new ArrayList();
        private void Graf_Vendas_dia()
        {

            cmd = new SqlCommand("VENDAS_DIA", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DATA.Add(dr.GetInt32(0));
                VALOR1.Add(dr.GetDecimal(1));

            }
            chartDia.Series[0].Points.DataBindXY(DATA, VALOR1);
            dr.Close();
            Conn.Close();

        }
        ArrayList MES = new ArrayList();
        ArrayList VALOR2 = new ArrayList();

        private void Graf_Vendas_mes()
        {

            cmd = new SqlCommand("VENDAS_MES", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                MES.Add(dr.GetInt32(0));
                VALOR2.Add(dr.GetDecimal(1));

            }
            chartMes.Series[0].Points.DataBindXY(MES, VALOR2);
            dr.Close();
            Conn.Close();

        }

        ArrayList DIA = new ArrayList();
        ArrayList VALOR3 = new ArrayList();

        private void Graf_Qtd_Dia()
        {

            cmd = new SqlCommand("QTD_DIA", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DIA.Add(dr.GetInt32(0));
                VALOR3.Add(dr.GetInt32(1));

            }
            chartQtd.Series[0].Points.DataBindXY(DIA, VALOR3);
            dr.Close();
            Conn.Close();

        }
        ArrayList Mes = new ArrayList();
        ArrayList VALOR4 = new ArrayList();

        private void Graf_Qtd_Mes()
        {

            cmd = new SqlCommand("QTD_MES", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Conn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Mes.Add(dr.GetInt32(0));
                VALOR4.Add(dr.GetInt32(1));

            }
            chartQtdMes.Series[0].Points.DataBindXY(Mes, VALOR4);
            dr.Close();
            Conn.Close();

        }
        

        private void Cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (Gb1.Width == 182 && Gb1.Height == 260)
            {
                Gb1.Width = 0;
                Gb1.Height = 0;
            }
            else
            {
                Gb1.Width = 182;
                Gb1.Height = 260;
            }
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            if (Gb2.Width == 147 && Gb2.Height == 120)
            {
                Gb2.Width = 0;
                Gb2.Height = 0;
            }
            else
            {
                Gb2.Width = 147;
                Gb2.Height = 120;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (pnGrafs.Width == 985 && pnGrafs.Height == 603)
            {
                Gb2.Width = 0;
                Gb2.Height = 0;
                pnGrafs.Width = 0;
                pnGrafs.Height = 0;
                btnGraf.Enabled = true;
                btnHome.Enabled = false;






            }
            else
            {

                Gb2.Width = 0;
                Gb2.Height = 0;
                pnGrafs.Width = 985;
                pnGrafs.Height = 603;
                btnGraf.Enabled = false;




            }
        }

        private void btnGraf_Click(object sender, EventArgs e)
        {
            if (pnGrafs.Width == 985 && pnGrafs.Height == 603)
            {

                pnGrafs.Width = 0;
                pnGrafs.Height = 0;
                btnGraf.Enabled = true;
                btnHome.Enabled = false;




            }
            else
            {

                Gb2.Width = 0;
                Gb2.Height = 0;
                pnGrafs.Width = 985;
                pnGrafs.Height = 603;
                btnGraf.Enabled = false;
                btnHome.Enabled = true;

            }
        }

        private void QtdDia_CheckedChanged(object sender, EventArgs e)
        {
            if (pnMes.Width == 440 && pnMes.Height == 234)
            {
                pnMes.Width = 0;
                pnMes.Height = 0;
                if (QtdMes.Checked)
                {
                    QtdMes.Checked = false;

                }
            }
        }

        private void QtdMes_CheckedChanged(object sender, EventArgs e)
        {
            if (pnMes.Width == 0 && pnMes.Height == 0)
            {
                pnMes.Width = 440;
                pnMes.Height = 234;
                if (QtdDia.Checked)
                {

                    QtdDia.Checked = false;

                }
            }
        }
    }
}
