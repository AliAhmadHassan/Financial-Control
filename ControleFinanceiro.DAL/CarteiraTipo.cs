using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class CarteiraTipo
    {
        public virtual List<DTO.CarteiraTipo> Select()
        {
            List<DTO.CarteiraTipo> LCarteirasTipos = new List<DTO.CarteiraTipo>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSCarteiraTipo", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCarteirasTipos.Add(Auxiliar.RetornaDadosEntidade<DTO.CarteiraTipo>(Dr));
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

            return LCarteirasTipos;
        }
    }
}
