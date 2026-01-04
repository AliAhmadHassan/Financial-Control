using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class CobNetBoletos
    {
        public virtual List<DTO.CobNetBoletos> Select(bool Fac, DateTime De, DateTime Ate)
        {
            List<DTO.CobNetBoletos> LBoletoCarteira = new List<DTO.CobNetBoletos>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("SPSControleFinanceiroBoletos", Conn))
                {
                    try
                    {
                        
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        SqlParameter param;

                        param = new SqlParameter("@Fac",System.Data.SqlDbType.Bit);
                        param.Value = Fac;
                        cmd.Parameters.Add(param);
                        
                        param = new SqlParameter("@De", System.Data.SqlDbType.Date);
                        param.Value = De;
                        cmd.Parameters.Add(param);
                        
                        param = new SqlParameter("@Ate", System.Data.SqlDbType.Date);
                        param.Value = Ate;
                        cmd.Parameters.Add(param);

                        cmd.CommandTimeout = 999;
                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoletoCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.CobNetBoletos>(Dr));
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
