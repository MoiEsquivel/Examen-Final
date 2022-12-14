using Examen_Final.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Examen_Final
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void Bagregar_Click(object sender, EventArgs e)
        {
            ClsUsuario.Agregar(Tnombre.Text, Tapellido.Text, Tuser.Text, Tclave.Text);
            Response.Redirect("Usuarios.aspx");
        }

       

        protected void Bbuscar_Click(object sender, EventArgs e)
        {
            ClsUsuario.BuscarUsuario(Tbuscar.Text);
            Tnombre.Text = ClsUsuario.nombre;
            Tapellido.Text = ClsUsuario.apellido;
            Tclave.Text = ClsUsuario.clave;
            Tuser.Text = ClsUsuario.correo;
        }

        protected void Bmodificar_Click(object sender, EventArgs e)
        {
            ClsUsuario.ModificarCliente(Tnombre.Text, Tapellido.Text, Tuser.Text, Tclave.Text);
            Response.Redirect("Usuarios.aspx");
        }
        
        protected void Beliminar_Click(object sender, EventArgs e)
        {
            ClsUsuario.BorrarUser(Tbuscar.Text);
            Response.Redirect("Usuarios.aspx");
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["VehiculosConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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
    }
}