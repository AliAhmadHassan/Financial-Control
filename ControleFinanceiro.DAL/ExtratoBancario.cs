using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class ExtratoBancario
    {
        public virtual List<DTO.ExtratoBancario> Select(DateTime DataDe, DateTime DataAte, string IdDadosBancario, string Procedure, string Descricao)
        {
            List<DTO.ExtratoBancario> LExtratoBancario = new List<DTO.ExtratoBancario>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand(Procedure, Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DataDe", DataDe);
                        cmd.Parameters.AddWithValue("@DataAte", DataAte);
                        cmd.Parameters.AddWithValue("@IdDadosBancario", IdDadosBancario);
                        cmd.Parameters.AddWithValue("@Descricao", Descricao);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LExtratoBancario.Add(Auxiliar.RetornaDadosEntidade<DTO.ExtratoBancario>(Dr));
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
            return LExtratoBancario;
        }
    }
}
