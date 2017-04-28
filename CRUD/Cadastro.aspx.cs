using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
using CRUD.Utils;
using CRUD.Models;

namespace CRUD
{
    public partial class Criacao : System.Web.UI.Page
    {
        //Variável para receber a Classe estatica HorarioDeBrasilia com o seu respectivo método.
        //Formatando no Horario de Brasilia.
        public DateTime cadastro = HorarioDeBrasilia.Agora;
        public DateTime dataAtualizacao = HorarioDeBrasilia.Agora;

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["login"];
            if (cookie == null || cookie.Value != "ok")
            {
                Response.Redirect("Default.aspx");
                return;
            }


        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
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

            decimal preco;

            if (decimal.TryParse(txtPreco.Text, out preco) == false)
            {
                // Campo não contém um número float!
                lblMsg.Text = "Preço inválido!";

                // O return encerra a execução por aqui
                return;
            }

            //Variavel para gravar o conteúdo da Lista.
            string negocio = drop.Text;

            //Instanciação do objeto item da Lista.
            ListItem item = new ListItem(negocio);

            drop.Items.Add(item);

            // Cria e abre a conexão com o banco de dados
            using (SqlConnection conn = Sql.OpenConnection())
            {

                // Cria um comando para inserir um novo registro à tabela
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbProduto (TipoMercadoria, Nome , Quantidade , Preco , TipoNegocio, DataCadastro, DataAtualizacao) VALUES (@mercadoria, @nome, @quantidade, @preco, @negocio, @cadastro, @dataAtualizacao)", conn))
                {

                    cmd.Parameters.AddWithValue("@mercadoria", mercadoria);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@negocio", negocio);

                    if (negocio == "V")
                    {
                        drop.Text = "Venda";
                        
                    }
                    else
                    {
                        drop.Text = "Compra";
                        
                    }

                    cmd.Parameters.AddWithValue("@cadastro", cadastro);
                    cmd.Parameters.AddWithValue("@dataAtualizacao", dataAtualizacao);

                    cmd.ExecuteNonQuery();


                }
            }

            //Limpa todos os campos ao final
            txtMercadoria.Text = "";
            txtNome.Text = "";
            txtQuantidade.Text = "";
            txtPreco.Text = "";

            lblMsg.Text = "Produto cadastrado com sucesso!";
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listagem.aspx");
        }


    }
}