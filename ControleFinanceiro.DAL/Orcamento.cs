using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL
{
    public class Orcamento:Base<DTO.Orcamento>
    {
        public virtual List<DTO.Orcamento> SelectPeloSegmento(int Id)
        {
            List<DTO.Orcamento> LOrcamento = new List<DTO.Orcamento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSOrcamentoPelaIdSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdSegmento", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LOrcamento.Add(Auxiliar.RetornaDadosEntidade<DTO.Orcamento>(Dr));
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

            return LOrcamento;
        }

        public virtual List<DTO.Orcamento> SelectPelaCarteira(int Id)
        {
            List<DTO.Orcamento> LOrcamento = new List<DTO.Orcamento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSOrcamentoPelaIdCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LOrcamento.Add(Auxiliar.RetornaDadosEntidade<DTO.Orcamento>(Dr));
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

            return LOrcamento;
        }
    }
}
