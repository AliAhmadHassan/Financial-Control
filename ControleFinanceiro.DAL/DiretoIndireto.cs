using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class DiretoIndireto
    {
        public virtual List<DTO.DiretoIndireto> Select(DateTime De, DateTime Ate, int IdCarteira)
        {
            List<DTO.DiretoIndireto> LDiretoIndireto = new List<DTO.DiretoIndireto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDiretoIndireto", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@De", De);
                        cmd.Parameters.AddWithValue("@Ate", Ate);
                        cmd.Parameters.AddWithValue("@IdCarteira", IdCarteira);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LDiretoIndireto.Add(Auxiliar.RetornaDadosEntidade<DTO.DiretoIndireto>(Dr));
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
            return LDiretoIndireto;
        }
    }
}
