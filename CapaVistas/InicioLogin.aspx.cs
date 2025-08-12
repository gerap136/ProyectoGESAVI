using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoGESAVI.CapaVistas
{
    public partial class InicioLogin : System.Web.UI.Page
    {
        // Cambia la cadena si tu SQL Server es diferente
        string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            // No se necesita lógica en Page_Load para esta página
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            string usuarioID = TextBox1.Text.Trim();

            if (string.IsNullOrEmpty(usuarioID))
            {
                lblResultado.Text = "Por favor, ingrese un ID de usuario.";
                LimpiarLabels();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = @"
                        SELECT TOP 1 R.ReparacionID, R.EquipoID, R.FechaSolicitud, R.Estado
                        FROM Reparaciones R
                        INNER JOIN Equipos E ON R.EquipoID = E.EquipoID
                        WHERE E.UsuarioID = @UsuarioID
                        ORDER BY R.FechaSolicitud DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            lblReparacionID.Text = reader["ReparacionID"].ToString();
                            lblEquipoID.Text = reader["EquipoID"].ToString();
                            lblFechaSolicitud.Text = Convert.ToDateTime(reader["FechaSolicitud"]).ToString("yyyy-MM-dd");
                            lblEstado.Text = reader["Estado"].ToString();
                            lblResultado.Text = ""; // limpia mensaje anterior
                        }
                        else
                        {
                            lblResultado.Text = "No se encontraron reparaciones para este usuario.";
                            LimpiarLabels();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = "Error al consultar: " + ex.Message;
                LimpiarLabels();
            }
        }

        private void LimpiarLabels()
        {
            lblReparacionID.Text = "";
            lblEquipoID.Text = "";
            lblFechaSolicitud.Text = "";
            lblEstado.Text = "";
        }
    }
}