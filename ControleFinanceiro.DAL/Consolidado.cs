using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Consolidado
    {
        public virtual List<DTO.Consolidado> Select(DateTime De, DateTime Ate, int IdCarteira, int Dedutivel, int Receita, int Despesas, string IdDadosBancario)
        {
            List<DTO.Consolidado> LConsolidado = new List<DTO.Consolidado>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSConsolidado", Conn))
                {
                    cmd.CommandTimeout = 9999;
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
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LConsolidado.Add(Auxiliar.RetornaDadosEntidade<DTO.Consolidado>(Dr));
                        }
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
            return LConsolidado;
        }
    }
}
