using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class ControleAcesso:Base<DTO.ControleAcesso>
    {
        public virtual List<DTO.ControleAcesso> SelectPelaCarteira(int Id)
        {
            List<DTO.ControleAcesso> LControleAcesso = new List<DTO.ControleAcesso>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSControleAcessoPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LControleAcesso.Add(Auxiliar.RetornaDadosEntidade<DTO.ControleAcesso>(Dr));
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

            return LControleAcesso;
        }

        
    }
}
