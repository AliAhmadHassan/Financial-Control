using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Despesa:Base<DTO.Despesa>
    {
        public virtual List<DTO.Despesa> SelectPeloSegmento(int Id)
        {
            List<DTO.Despesa> LReceitaDespesa = new List<DTO.Despesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDespesasPeloSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdSegmento", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.Despesa>(Dr));
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

            return LReceitaDespesa;
        }

        public virtual List<DTO.Despesa> SelectPelaCarteira(int Id)
        {
            List<DTO.Despesa> LReceitaDespesa = new List<DTO.Despesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDespesasPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.Despesa>(Dr));
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

            return LReceitaDespesa;
        }

    }
}
