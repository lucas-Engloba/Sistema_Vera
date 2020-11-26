using dllDao;
using Mercado_Vera.Entity;
using Mercado_Vera.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercado_Vera.Dao
{
    class DaoPagamento
    {
        Conexao conexao = new Conexao();

        public void InsertPagCrediario(Venda venda)
        {
            string data = venda.Date.ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(conexao.StrConexao());
            SqlCommand cmd1 = con.CreateCommand();

            cmd1.CommandText = "INSERT INTO TBL_VENDA(CLI_ID, VEN_PAGAMENTO, VEN_PARCELA, VEN_BANDEIRA, VEN_QTD, VEN_TOTAL, VEN_DATE) VALUES(@CLIID, @PAGAMENTO, @PARCELA, @BANDEIRA, @QTD, @TOTAL, @DATE)";

            cmd1.Parameters.Add(new SqlParameter("@CLIID", venda.CliId));
            cmd1.Parameters.Add(new SqlParameter("@PAGAMENTO","Pagamento " + venda.TipoPagamento));

            if (venda.Parcelas != 0)
                cmd1.Parameters.Add(new SqlParameter("@PARCELA", venda.Parcelas));
            else
                cmd1.Parameters.Add(new SqlParameter("@PARCELA", DBNull.Value));

            if (venda.Bandeira != null)
                cmd1.Parameters.Add(new SqlParameter("@BANDEIRA", venda.Bandeira));
            else
                cmd1.Parameters.Add(new SqlParameter("@BANDEIRA", DBNull.Value));

            cmd1.Parameters.Add(new SqlParameter("@QTD", venda.Qtd));
            cmd1.Parameters.Add(new SqlParameter("@TOTAL", venda.ValorTotal));
            cmd1.Parameters.Add(new SqlParameter("@DATE", data));

            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                cmd1.Transaction = tran;
                cmd1.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new DomainExceptions("Erro!!! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertPagamento(Pagamento pagamento, string tipo)
        {
            Conexao conexao = new Conexao();
            string idVenda = "0";

            if (tipo == "venda")
            {
                string query = "SELECT MAX(VEN_ID) FROM TBL_VENDA";
                idVenda = conexao.SelecioneId(query);
            }

            SqlConnection con = new SqlConnection(conexao.StrConexao());
            SqlCommand cmd1 = con.CreateCommand();
 
            cmd1.CommandText = "INSERT INTO TBL_PAGAMENTO(PAG_DINHEIRO,PAG_DEBITO,PAG_CREDITO,PAG_CREDIARIO,VENDA_ID)" +
            "VALUES(@DINHEIRO,@DEBITO,@CREDITO,@CREDIARIO,@ID)";

            cmd1.Parameters.Add(new SqlParameter("@DINHEIRO", pagamento.Dinheiro));
            cmd1.Parameters.Add(new SqlParameter("@DEBITO", pagamento.Debito));
            cmd1.Parameters.Add(new SqlParameter("@CREDITO", pagamento.Credito));
            cmd1.Parameters.Add(new SqlParameter("@CREDIARIO", pagamento.Crediario));


            if (tipo == "venda")
            {
                cmd1.Parameters.Add(new SqlParameter("@ID", idVenda));
            }
            else
            {
                cmd1.Parameters.Add(new SqlParameter("@ID", DBNull.Value));
            }
            con.Open();
            SqlTransaction tran = con.BeginTransaction();

            try
            {
                cmd1.Transaction = tran;
                cmd1.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new DomainExceptions("Erro!!! " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
