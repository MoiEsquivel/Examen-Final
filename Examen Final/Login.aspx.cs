using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Examen_Final.Clases;

namespace Examen_Final
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Bingreso_Click(object sender, EventArgs e)
        {
           
            if (ClsUsuario.ValidarLogin(Tcorreo.Text, Tclave.Text) > 0)            {
               
                    Response.Redirect("Inicio.aspx");         
                               

            }
        }
    }
}