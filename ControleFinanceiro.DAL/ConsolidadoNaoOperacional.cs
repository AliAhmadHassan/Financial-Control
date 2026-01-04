using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class ConsolidadoNaoOperacional
    {
        public virtual decimal Select(DateTime De, DateTime Ate, int IdCarteira, int Dedutivel, int Receita, int Despesas, string IdDadosBancario)
        {
            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSConsolidado", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@De", De);
                        cmd.Parameters.AddWithValue("@Ate", Ate);
                        cmd.Parameters.AddWithValue("@IdCarteira", IdCarteira);
                        cmd.Parameters.AddWithValue("@Dedutivel", Dedutivel);
                        cmd.Parameters.AddWithValue("@Receita", Receita);
                        cmd.Parameters.AddWithValue("@Despesas", Despesas);
                        cmd.Parameters.AddWithValue("@IdDadosBancario", IdDadosBancario);

                        Conn.Open();
                        return Convert.ToDecimal(cmd.ExecuteScalar());
                        
                    }
                    catch (Exception Erro)
                    {
                        throw new Exception("Erro ao consultar");
                    }
                    finally
                    {

                    }
                }
            }
            return 0;
        }
    }
}
