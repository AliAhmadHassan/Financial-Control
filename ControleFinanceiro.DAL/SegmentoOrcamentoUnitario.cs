using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class SegmentoOrcamentoUnitario : Base<DTO.SegmentoOrcamentoUnitario>
    {
        public virtual List<DTO.SegmentoOrcamentoUnitario> SelectPeloSegmento(int Id)
        {
            List<DTO.SegmentoOrcamentoUnitario> LSegmentoOrcamentoUnitario = new List<DTO.SegmentoOrcamentoUnitario>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSegmentoOrcamentoUnitarioPeloIdSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdSegmento", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmentoOrcamentoUnitario.Add(Auxiliar.RetornaDadosEntidade<DTO.SegmentoOrcamentoUnitario>(Dr));
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

            return LSegmentoOrcamentoUnitario;
        }

    }
}
