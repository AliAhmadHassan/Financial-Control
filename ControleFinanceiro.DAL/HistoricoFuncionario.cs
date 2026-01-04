using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class HistoricoFuncionario : Base<DTO.HistoricoFuncionario>
    {
        public List<DTO.HistoricoFuncionario> SelectByDataCadastro(DateTime DataCadastro)
        {
            List<DTO.HistoricoFuncionario> LConsolidado = new List<DTO.HistoricoFuncionario>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSHistoricoFuncionarioPeloDataCadastro", Conn))
                {
                    cmd.CommandTimeout = 9999;
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DataCadastro", DataCadastro);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LConsolidado.Add(Auxiliar.RetornaDadosEntidade<DTO.HistoricoFuncionario>(Dr));
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
