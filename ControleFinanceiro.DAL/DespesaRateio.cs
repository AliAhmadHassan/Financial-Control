using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class DespesaRateio:Base<DTO.DespesaRateio>
    {
        public virtual List<DTO.DespesaRateio> SelectPeloSegmento(int Id)
        {
            List<DTO.DespesaRateio> LReceitaDespesa = new List<DTO.DespesaRateio>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDespesasRateioPeloSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdSegmento", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.DespesaRateio>(Dr));
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

        public virtual List<DTO.DespesaRateio> SelectPelaCarteira(int Id)
        {
            List<DTO.DespesaRateio> LReceitaDespesa = new List<DTO.DespesaRateio>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDespesasRateioPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.DespesaRateio>(Dr));
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
