using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class FuncionarioProvisoes : Base<DTO.FuncionarioProvisoes>
    {
        public virtual DTO.FuncionarioProvisoes SelectPelaIdControleAcesso(int Id)
        {
            DTO.FuncionarioProvisoes funcionarioProvisoes = new DTO.FuncionarioProvisoes();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSFuncionarioProvisoesPelaIdControleAcesso", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdControleAcesso", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            if(Dr.Read())
                            funcionarioProvisoes = Auxiliar.RetornaDadosEntidade<DTO.FuncionarioProvisoes>(Dr);
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

            return funcionarioProvisoes;
        }
    }
}
