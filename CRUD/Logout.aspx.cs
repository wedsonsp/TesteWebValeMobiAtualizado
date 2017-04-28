using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD {
	public partial class Logout : System.Web.UI.Page {
        //Variável para receber a Classe estatica HorarioDeBrasilia com o seu respectivo método.
        //Formatando no Horario de Brasilia.
        public DateTime cadastro = HorarioDeBrasilia.Agora;

        protected void Page_Load(object sender, EventArgs e) {
			HttpCookie cookie = new HttpCookie("login");
			cookie.Expires = DateTime.Now.AddYears(-1);
			Response.Cookies.Add(cookie);
			Response.Redirect("Default.aspx");
		}
	}
}
