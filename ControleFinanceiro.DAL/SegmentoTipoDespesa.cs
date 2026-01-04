using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class SegmentoTipoDespesa
    {
        public virtual List<DTO.SegmentoTipoDespesa> Select()
        {
            List<DTO.SegmentoTipoDespesa> LSegmentoTipoDespesa = new List<DTO.SegmentoTipoDespesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSegmentoTipoDespesa", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmentoTipoDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.SegmentoTipoDespesa>(Dr));
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

            return LSegmentoTipoDespesa;
        }
    }
}
