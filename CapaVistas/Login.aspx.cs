using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoGESAVI.CapaVistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string tecnicoUsuario = txtTecnicoUsuario.Text.Trim();
            string tecnicoContraseña = txtTecnicoContraseña.Text.Trim();

            if (string.IsNullOrEmpty(tecnicoUsuario) || string.IsNullOrEmpty(tecnicoContraseña))
            {
                lblMensaje.Text = "Debe ingresar usuario y contraseña.";
                return;
            }

            // Aquí podrías aplicar un hash real a la contraseña
            string hash = tecnicoContraseña; // Temporal sin hash

            string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ValidarLoginTecnico", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioLogin", tecnicoUsuario);
                    cmd.Parameters.AddWithValue("@ContraseñaHash", hash);

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        // Guardar datos en sesión
                        Session["LoginID"] = dr["LoginID"].ToString();
                        Session["NombreTecnico"] = dr["NombreTecnico"].ToString();
                        Session["Rol"] = dr["NombreRol"].ToString();

                        // Redirigir a inicio
                        Response.Redirect("Inicio.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o contraseña inválidos.";
                    }
                }
            }
        }
    }
}