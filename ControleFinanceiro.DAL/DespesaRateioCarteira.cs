using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class DespesaRateioCarteira: Base<DTO.DespesaRateioCarteira>
    {
        //
        public virtual List<DTO.DespesaRateioCarteira> SelectPeloDespesasRatio(int Id)
        {
            List<DTO.DespesaRateioCarteira> LReceitaDespesa = new List<DTO.DespesaRateioCarteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSDespesasRateioCarteiraPeloDespesasRateio", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdDespesasRateio", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.DespesaRateioCarteira>(Dr));
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

        public virtual void Remover(int IdDespesasRateio)
        {

            //IdDespesasRateio

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPDDespesasRateioCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdDespesasRateio", IdDespesasRateio);
                        Conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception("Erro ao deletar o registro");
                    }
                    finally
                    {
                    }
                }
            }
        }
    }
}
