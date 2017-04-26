using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRUD.Utils;
using System.Globalization;

namespace CRUD
{
    public partial class Edicao : System.Web.UI.Page
    {
        //Variavel global para pegar a data e hora do sistema.
        public DateTime data = DateTime.Now;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie == null || cookie.Value != "ok")
            {
                Response.Redirect("Default.aspx");
                return;
            }

            if (IsPostBack == false)
            {
                //O id vem pela QueryString.
                int id;
                if (int.TryParse(Request.QueryString["id"], out id) == false)
                {
                    lblMsg.Text = "Id inválido!";
                    return;
                }

                // Cria e abre a conexão com o banco de dados
                using (SqlConnection conn = Sql.OpenConnection())
                {

                    // Cria um comando para selecionar registros da tabela
                    using (SqlCommand cmd = new SqlCommand("SELECT TipoMercadoria , Nome, Quantidade, Preco, TipoNegocio FROM tbProduto WHERE Id = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Tenta obter o registro
                            if (reader.Read() == true)
                            {
                                txtMercadoria.Text = reader.GetString(0);
                                txtNome.Text = reader.GetString(1);
                                txtQuantidade.Text = reader.GetInt32(2).ToString();
                                txtPreco.Text = reader.GetDouble(3).ToString();
                                drop.Text = reader.GetString(4);

                                string.Format("{0:N}", txtPreco.Text);
                            }
                            else
                            {
                                lblMsg.Text = "Id não encontrado!";
                            }


                        }
                    }
                }

            }


        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(Request.QueryString["id"], out id) == false)
            {
                lblMsg.Text = "Id inválido!";
                return;
            }

            string mercadoria = txtMercadoria.Text.Trim();
            if (mercadoria.Length == 0)
            {
                lblMsg.Text = "Preencher a Mercadoria!";
                return;
            }

            string nome = txtNome.Text.Trim();
            if (nome.Length == 0)
            {
                lblMsg.Text = "Nome inválido!";
                return;
            }

            int quantidade;

            if (int.TryParse(txtQuantidade.Text, out quantidade) == false)
            {
                // Campo não contém um número inteiro!
                lblMsg.Text = "Quantidade inválida!";

                // O return encerra a execução por aqui
                return;
            }

            double preco;

            if (double.TryParse(txtPreco.Text, out preco) == false)
            {
                // Campo não contém um número inteiro!
                lblMsg.Text = "Preço inválido!";

                // O return encerra a execução por aqui
                return;
            }

            //Variavel para gravar o conteúdo da Lista.
            string negocio = drop.Text;

            //Instanciação do objeto item da Lista.
            ListItem item = new ListItem(negocio);

            drop.Items.Add(item);

            //Varaiável para atualizar o cadastro.
            //Formatando no Horario de Brasilia.
            DateTime atualizacao = DateTime.Now;
            CultureInfo brasil = new CultureInfo("pt-BR");
            atualizacao.ToString(brasil);
 

            // Cria e abre a conexão com o banco de dados
            using (SqlConnection conn = Sql.OpenConnection())
            {

                // Cria um comando para atualizar um registro da tabela
                using (SqlCommand cmd = new SqlCommand("UPDATE tbProduto SET TipoMercadoria = @mercadoria, Nome = @nome, Quantidade = @quantidade, Preco = @preco, TipoNegocio = @negocio, DataAtualizacao = @atualizacao WHERE Id = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@mercadoria", mercadoria);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@negocio", negocio);
                    cmd.Parameters.AddWithValue("@atualizacao", atualizacao);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();

                }
            }

            lblMsg.Text = "Produto alterado com sucesso!";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listagem.aspx");
        }



    }
}
