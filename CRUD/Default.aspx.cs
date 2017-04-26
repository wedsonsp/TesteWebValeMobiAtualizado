using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD {
	public partial class Default : System.Web.UI.Page {
        //Variavel global para pegar a data e hora do sistema.
        public DateTime data = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e) {
			HttpCookie cookie = Request.Cookies["login"];
			if (cookie != null && cookie.Value == "ok") {
				Response.Redirect("Listagem.aspx");
			}
		}

		protected void btnLogin_Click(object sender, EventArgs e) {
			if (txtUser.Text == "user" && txtPass.Text == "1234") {
				HttpCookie cookie = new HttpCookie("login", "ok");
				cookie.Expires = DateTime.Now.AddYears(1);
				Response.Cookies.Add(cookie);
				Response.Redirect("Listagem.aspx");
			} else {
				lblMsg.Text = "Usuário ou senha inválidos!";
			}
		}
	}
}
