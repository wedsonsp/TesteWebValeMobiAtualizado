using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD {
	public partial class Logout : System.Web.UI.Page {
        //Variavel global para pegar a data e hora do sistema.
        public DateTime data = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e) {
			HttpCookie cookie = new HttpCookie("login");
			cookie.Expires = DateTime.Now.AddYears(-1);
			Response.Cookies.Add(cookie);
			Response.Redirect("Default.aspx");
		}
	}
}
