using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class CobNetBoletoCarteira
    {
        public virtual List<DTO.CobNetBoletoCarteira> Select(string Credores, string Segmentos, string Produtos)
        {
            List<DTO.CobNetBoletoCarteira> LBoletoCarteira = new List<DTO.CobNetBoletoCarteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("SPSControleFinanceiroBoletoCampanha", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Segmentos", Segmentos);
                        cmd.Parameters.AddWithValue("Produtos", Produtos);
                        cmd.Parameters.AddWithValue("Credores", Credores);
                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoletoCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.CobNetBoletoCarteira>(Dr));
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

            return LBoletoCarteira;
        }
    }
}
