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
    public partial class Placa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void Bbuscar_Click(object sender, EventArgs e)
        {

        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["VehiculosConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Placa"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsUsuario.BorrarPlaca(Tplaca.Text);
            Response.Redirect("Placa.aspx");
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsUsuario.ModificarPlaca(Tplaca.Text,Tbuscar.Text,int.Parse(Tid.Text),float.Parse(Tmonto.Text));
            Response.Redirect("Placa.aspx");
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            ClsUsuario.AgregarPlaca(Tplaca.Text, int.Parse(Tid.Text), float.Parse(Tmonto.Text));
            Response.Redirect("Placa.aspx");
        }
    }
}