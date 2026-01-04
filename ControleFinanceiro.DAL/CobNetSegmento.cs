using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class CobNetSegmento
    {
        public virtual List<DTO.CobNetSegmento> SelectPeloCredId(int Id)
        {
            List<DTO.CobNetSegmento> LSegmento = new List<DTO.CobNetSegmento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("Select Seg_ID as IdSegmento, Seg_Descricao as Descricao, Cred_Id as IdCredor from Tb_Segmento (Nolock) where Cred_Id = @Cred_Id order by Seg_Descricao", Conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("Cred_Id", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmento.Add(Auxiliar.RetornaDadosEntidade<DTO.CobNetSegmento>(Dr));
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
            return LSegmento;
        }

        public virtual DTO.CobNetSegmento SelectPelaPK(int Id)
        {
            DTO.CobNetSegmento segmento = new DTO.CobNetSegmento();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("Select Seg_ID as IdSegmento, Seg_Descricao as Descricao, Cred_Id as IdCredor from Tb_Segmento (Nolock) where Seg_Id = @Id order by Seg_Descricao", Conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("Id", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                segmento = Auxiliar.RetornaDadosEntidade<DTO.CobNetSegmento>(Dr);
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
            return segmento;
        }
    }
}
