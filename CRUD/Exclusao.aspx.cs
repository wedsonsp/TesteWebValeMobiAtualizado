﻿using System;
using System.Data.SqlClient;
using System.Web;
using CRUD.Utils;
using CRUD.Models;

namespace CRUD {
	public partial class Exclusao : System.Web.UI.Page {
        //Variável para receber a Classe estatica HorarioDeBrasilia com o seu respectivo método.
        //Formatando no Horario de Brasilia.
        public DateTime cadastro = HorarioDeBrasilia.Agora;

        protected void Page_Load(object sender, EventArgs e) {
			HttpCookie cookie = Request.Cookies["login"];
			if (cookie == null || cookie.Value != "ok") {
				Response.Redirect("Default.aspx");
				return;
			}
            //Método que diz se é a primeira vez que a pagina.
			if (IsPostBack == false) {
				int id;
				if (int.TryParse(Request.QueryString["id"], out id) == false) {
					lblMsg.Text = "Id inválido!";
					btnSim.Visible = false;
					btnNao.Text = "Voltar";
					return;
				}

				// Cria e abre a conexão com o banco de dados
				using (SqlConnection conn = Sql.OpenConnection()) {

					// Cria um comando para selecionar registros da tabela
					using (SqlCommand cmd = new SqlCommand("SELECT Nome FROM tbProduto WHERE Id = @id", conn)) {
						cmd.Parameters.AddWithValue("@id", id);

                        //Leitor de registro
						using (SqlDataReader reader = cmd.ExecuteReader()) {
							// Tenta obter o registro sempre o próximo nunca o anterior. forwardOnly.
							if (reader.Read() == true) {
								lblMsg.Text = "Deseja mesmo excluir " + reader.GetString(0) + "?";
							} else {
								lblMsg.Text = "Id não encontrado!";
								btnSim.Visible = false;
								btnNao.Text = "Voltar";
							}
						}
					}
				}
			}
		}

		protected void btnSim_Click(object sender, EventArgs e) {
			int id;
			if (int.TryParse(Request.QueryString["id"], out id) == false) {
				lblMsg.Text = "Id inválido!";
				btnSim.Visible = false;
				btnNao.Text = "Voltar";
				return;
			}

			// Cria e abre a conexão com o banco de dados
			using (SqlConnection conn = Sql.OpenConnection()) {

				// Cria um comando para excluir o registro
				using (SqlCommand cmd = new SqlCommand("DELETE FROM tbProduto WHERE Id = @id", conn)) {
					cmd.Parameters.AddWithValue("@id", id);

					cmd.ExecuteNonQuery();
				}
			}

			lblMsg.Text = "Produto excluído com sucesso!";
			btnSim.Visible = false;
			btnNao.Text = "Voltar";
		}

		protected void btnNao_Click(object sender, EventArgs e) {
			Response.Redirect("Listagem.aspx");
		}
	}
}
