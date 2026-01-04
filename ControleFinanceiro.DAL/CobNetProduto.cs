using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class CobNetProduto
    {
        public virtual List<DTO.CobNetProduto> SelectPeloSegId(int Id)
        {
            List<DTO.CobNetProduto> LProduto = new List<DTO.CobNetProduto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("Select Prod_Id as IdProduto, Prod_Descricao as Descricao, Seg_Id as IdCredor from Tb_Produto (Nolock) where Seg_Id = @Seg_Id order by Prod_Descricao", Conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("Seg_Id", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LProduto.Add(Auxiliar.RetornaDadosEntidade<DTO.CobNetProduto>(Dr));
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
            return LProduto;
        }

        public virtual DTO.CobNetProduto SelectPelaPK(int Id)
        {
            DTO.CobNetProduto produto = new DTO.CobNetProduto();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnCobNet))
            {
                using (SqlCommand cmd = new SqlCommand("Select Prod_Id as IdProduto, Prod_Descricao as Descricao, Seg_Id as IdCredor from Tb_Produto (Nolock) where Prod_Id = @Id order by Prod_Descricao", Conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("Id", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            if (Dr.Read())
                                produto = Auxiliar.RetornaDadosEntidade<DTO.CobNetProduto>(Dr);
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
            return produto;
        }
    }
}
