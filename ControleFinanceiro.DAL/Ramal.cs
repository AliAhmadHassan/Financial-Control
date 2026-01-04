using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Ramal:Base<DTO.Ramal>
    {
        public virtual List<DTO.Ramal> SelectPeloControleAcesso(int Id)
        {
            List<DTO.Ramal> LRamal = new List<DTO.Ramal>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSRamalPeloControleAcesso", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdControleAcesso", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LRamal.Add(Auxiliar.RetornaDadosEntidade<DTO.Ramal>(Dr));
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

            return LRamal;
        }
    }
}
