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
    public partial class Equipos : System.Web.UI.Page
    {
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipos();
                VerificarPermisos();
            }
        }

        private void CargarEquipos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Equipos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void VerificarPermisos()
        {
            object rolObj = Session["Rol"];
            string rol = rolObj != null ? rolObj.ToString() : "";

            bool esAdmin = rol == "2";

            btnGuardar.Enabled = esAdmin;
            btnEliminar.Enabled = esAdmin;
            btnModificar.Enabled = esAdmin;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador()) return;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"INSERT INTO Equipos (EquipoID, TipodeEquipo, Modelo, UsuarioID) 
                                 VALUES (@EquipoID, @TipodeEquipo, @Modelo, @UsuarioID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", tEquipoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@TipodeEquipo", tTipoEquipo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Modelo", tmodelo.Text.Trim());
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarEquipos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador()) return;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Equipos WHERE EquipoID = @EquipoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", tEquipoID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarEquipos();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador()) return;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"UPDATE Equipos SET 
                                    TipodeEquipo = @TipodeEquipo, 
                                    Modelo = @Modelo, 
                                    UsuarioID = @UsuarioID 
                                 WHERE EquipoID = @EquipoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", tEquipoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@TipodeEquipo", tTipoEquipo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Modelo", tmodelo.Text.Trim());
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarEquipos();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Equipos WHERE EquipoID = @EquipoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipoID", tEquipoID.Text.Trim());

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tTipoEquipo.Text = dr["TipodeEquipo"].ToString();
                        tmodelo.Text = dr["Modelo"].ToString();
                        tUsuarioID.Text = dr["UsuarioID"].ToString();
                    }
                    else
                    {
                        LimpiarCampos();
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            tEquipoID.Text = "";
            tTipoEquipo.Text = "";
            tmodelo.Text = "";
            tUsuarioID.Text = "";
        }

        private bool EsAdministrador()
        {
            object rolObj = Session["Rol"];
            if (rolObj == null || rolObj.ToString() != "2")
            {
                // Opcional: mostrar mensaje de error, por ejemplo con un Label o alerta
                // lblMensaje.Text = "No tienes permiso para realizar esta acción.";
                return false;
            }
            return true;
        }
    }
}