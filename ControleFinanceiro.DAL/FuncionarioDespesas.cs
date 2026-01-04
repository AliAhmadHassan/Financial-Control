using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class FuncionarioDespesas : Base<DTO.FuncionarioDespesas>
    {
        public virtual DTO.FuncionarioDespesas SelectPelaIdControleAcesso(int Id)
        {
            DTO.FuncionarioDespesas funcionarioDespesas = new DTO.FuncionarioDespesas();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSFuncionarioDespesasPelaIdControleAcesso", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdControleAcesso", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            if (Dr.Read())
                                funcionarioDespesas = Auxiliar.RetornaDadosEntidade<DTO.FuncionarioDespesas>(Dr);
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

            return funcionarioDespesas;
        }

    }
}
