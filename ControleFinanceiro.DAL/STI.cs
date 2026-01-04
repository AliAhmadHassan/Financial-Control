using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class STI:Base<DTO.STI>
    {
        public virtual List<DTO.STI> SelectPeloRamal(int Id)
        {
            List<DTO.STI> LSTI = new List<DTO.STI>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSTIPeloRamal", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdRamal", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSTI.Add(Auxiliar.RetornaDadosEntidade<DTO.STI>(Dr));
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

            return LSTI;
        }
    }
}
