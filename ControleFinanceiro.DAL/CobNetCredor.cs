using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class CobNetCredor
    {
        public virtual List<DTO.CobNetCredor> Select()
        {
            List<DTO.CobNetCredor> LCredor = new List<DTO.CobNetCredor>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("Select Cred_Id as IdCredor, Cred_Fantasia as Descricao from tb_credor (Nolock) order by Cred_Fantasia", Conn))
                {
                    try
                    {
                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCredor.Add(Auxiliar.RetornaDadosEntidade<DTO.CobNetCredor>(Dr));
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

            return LCredor;
        }
    }
}
