using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class BoletoCarteira : Base<DTO.BoletoCarteira>
    {
        public virtual List<DTO.BoletoCarteira> SelectPelaIdCarteira(int Id)
        {
            List<DTO.BoletoCarteira> LBoletoCarteira = new List<DTO.BoletoCarteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSBoletoCarteiraPelaIdCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoletoCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.BoletoCarteira>(Dr));
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

        public virtual void RemovePelaIdCarteira(int Id)
        {

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPDBoletoCarteiraPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCarteira", Id);

                        Conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception Erro)
                    {
                        throw new Exception("Erro ao Deletar");
                    }
                    finally
                    {

                    }
                }
            }
        }

    }
}
