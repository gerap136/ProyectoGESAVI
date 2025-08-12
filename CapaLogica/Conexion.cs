using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ProyectoGESAVI.CapaLogica
{
    public static class Conexion
    {
        public static SqlConnection ObtenerConexion()
        {
            string cadena = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            return new SqlConnection(cadena);
        }

        public static void MostrarAlerta(Page page, string mensaje)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", $"alert('{mensaje}');", true);
        }
    }
}
