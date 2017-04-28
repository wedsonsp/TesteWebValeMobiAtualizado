using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Models;
using CRUD.Utils;

namespace CRUD
{

    public partial class Listagem : System.Web.UI.Page
    {

        //Variável global para fazer o Calculo da quantidade total de Produtos a serem mostrados na Listagem.
        public decimal somaQuantidade;
        public decimal somaValorproduto;
        public decimal somaValorprodutoUnidade;
        public decimal somaValorProduto;

        //Variavel global para pegar a data e hora do sistema.
        public DateTime data = DateTime.Now;

        //Criando um objeto para a lista de Produtos.
        public List<Produto> produtos = new List<Produto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie == null || cookie.Value != "ok")
            {
                Response.Redirect("Default.aspx");
                return;
            }

            // Cria e abre a conexão com o banco de dados
            using (SqlConnection conn = Sql.OpenConnection())
            {

                // Cria um comando para selecionar registros da tabela
                using (SqlCommand cmd = new SqlCommand("SELECT Id, TipoMercadoria, Nome, Quantidade, Preco, TipoNegocio, DataCadastro, DataAtualizacao FROM tbProduto ORDER BY id ASC", conn))
                {
                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        // Obtém os registros, um por vez
                        while (reader.Read() == true)
                        {
                            Produto p = new Produto();
                            p.Id = reader.GetInt32(0);
                            p.TipoMercadoria = reader.GetString(1);
                            p.Nome = reader.GetString(2);
                            p.Quantidade = reader.GetInt32(3);
                            p.Preco = reader.GetDecimal(4);
                            p.TipoNegocio = reader.GetString(5);
                            p.DataCadastro = reader.GetDateTime(6);
                            p.DataAtualizacao = reader.GetDateTime(7);

                            //Variaveis para Calculos.
                            somaQuantidade += p.Quantidade;
                            somaValorproduto += p.Preco;
                            somaValorprodutoUnidade += p.Quantidade * p.Preco;
                            somaValorProduto = p.Quantidade * p.Preco;


                            produtos.Add(p);

                            //Configurando texto para ser Visualizado na Lista.
                            if (p.TipoNegocio == "V")
                            {
                                p.TipoNegocio = "Venda";
                            }
                            else
                            {
                                p.TipoNegocio = "Compra";
                            }

                     

                        }
                    }
                }
            }
        }
    }
}
