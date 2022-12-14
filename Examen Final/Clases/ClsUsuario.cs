using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen_Final.Clases
{
    public class ClsUsuario
    {
        public static string correo { get; set; }
        public static string clave { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }


        public static int Agregar(string Nomb, string Apelli, string Corr, string clave )
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("NewUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nomb));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", Apelli));
                    cmd.Parameters.Add(new SqlParameter("@User", Corr));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                 

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }
        public static int ModificarCliente(string Nombre, string Apellido, string Correo, string Clave)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nombre", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", Apellido));
                    cmd.Parameters.Add(new SqlParameter("@Clave", Clave));
                    cmd.Parameters.Add(new SqlParameter("@User", Correo));
                
                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        //public static int BuscarUsuario(string Correo)
        //{
        //    int retorno = 0;
        //    int tipo = 0;
        //    SqlConnection Conn = new SqlConnection();
        //    try
        //    {
        //        using (Conn = Dboconn.obtenerConexion())
        //        {
        //            SqlCommand cmd = new SqlCommand("ListarCliente", Conn)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            cmd.Parameters.Add(new SqlParameter("@nombre", Nombre));
        //            cmd.Parameters.Add(new SqlParameter("@correo", Correo));

        //            // retorno = cmd.ExecuteNonQuery();
        //            using (SqlDataReader rdr = cmd.ExecuteReader())
        //            {
        //                if (rdr.Read())
        //                {
        //                    ClsUsuario.Nombre = rdr["Nombre"].ToString();
        //                    ClsUsuario.Apellido = rdr["Apellido"].ToString();
        //                    ClsUsuario.Correo = rdr["Email"].ToString();
        //                    ClsUsuario.Telefono = rdr["Telefono"].ToString();
        //                    ClsUsuario.Tusuario = rdr["Tipo"].ToString();
        //                    ClsUsuario.provivia = rdr["CodProv"].ToString();
        //                    ClsUsuario.canton = rdr["CodCant"].ToString();
        //                    ClsUsuario.distrito = rdr["CodDis"].ToString();
        //                    ClsUsuario.señas = rdr["Señas"].ToString();
        //                    ClsUsuario.codigo = rdr["Codigo"].ToString();
        //                    retorno = 1;
        //                }

        //            }
        //        }
        //    }
        //    catch (System.Data.SqlClient.SqlException ex)
        //    {
        //        retorno = -1;
        //    }
        //    finally
        //    {
        //        Conn.Close();
        //        Conn.Dispose();
        //    }

        //    return retorno;
        //}
        public static int BorrarUser(string User)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = Dboconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("EliminarUser", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@User", User));
                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

    }
}