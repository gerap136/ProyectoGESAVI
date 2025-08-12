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
    public partial class Reparaciones : System.Web.UI.Page
    {
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarReparaciones();
                // Opcional: controlar edición de campos según rol
                ControlarCamposPorRol();
            }
        }

        private void CargarReparaciones()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Reparaciones";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"INSERT INTO Reparaciones (ReparacionID, EquipoID, FechaSolicitud, Estado)
                                 VALUES (@ReparacionID, @EquipoID, @FechaSolicitud, @Estado)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());
                    cmd.Parameters.AddWithValue("@EquipoID", EquipoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaSolicitud", tFechaSolicitud.Text.Trim());
                    cmd.Parameters.AddWithValue("@Estado", tEstado.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Reparaciones WHERE ReparacionID = @ReparacionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string rol = Session["Rol"]?.ToString();

            if (string.IsNullOrEmpty(rol))
            {
                lblMensaje.Text = "No tienes permisos para modificar.";
                return;
            }

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd;

                if (rol == "1") // Técnico: solo puede modificar Estado
                {
                    string query = "UPDATE Reparaciones SET Estado = @Estado WHERE ReparacionID = @ReparacionID";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Estado", tEstado.Text.Trim());
                    cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());
                }
                else if (rol == "2") // Administrador: puede modificar todo
                {
                    string query = @"UPDATE Reparaciones SET 
                                        EquipoID = @EquipoID, 
                                        FechaSolicitud = @FechaSolicitud, 
                                        Estado = @Estado 
                                     WHERE ReparacionID = @ReparacionID";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());
                    cmd.Parameters.AddWithValue("@EquipoID", EquipoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@FechaSolicitud", tFechaSolicitud.Text.Trim());
                    cmd.Parameters.AddWithValue("@Estado", tEstado.Text.Trim());
                }
                else
                {
                    lblMensaje.Text = "No tienes permisos para modificar.";
                    return;
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LimpiarCampos();
            CargarReparaciones();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Reparaciones WHERE ReparacionID = @ReparacionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        EquipoID.Text = dr["EquipoID"].ToString();
                        tFechaSolicitud.Text = Convert.ToDateTime(dr["FechaSolicitud"]).ToString("yyyy-MM-dd");
                        tEstado.Text = dr["Estado"].ToString();

                        // Controlar edición al consultar
                        ControlarCamposPorRol();
                    }
                    else
                    {
                        lblMensaje.Text = "Reparación no encontrada.";
                        LimpiarCampos();
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            tReparacionID.Text = "";
            EquipoID.Text = "";
            tFechaSolicitud.Text = "";
            tEstado.Text = "";
            lblMensaje.Text = "";
            ControlarCamposPorRol();
        }

        private void ControlarCamposPorRol()
        {
            string rol = Session["Rol"]?.ToString();

            if (rol == "1") // Técnico
            {
                EquipoID.Enabled = false;
                tFechaSolicitud.Enabled = false;
                tEstado.Enabled = true;
            }
            else if (rol == "2") // Administrador
            {
                EquipoID.Enabled = true;
                tFechaSolicitud.Enabled = true;
                tEstado.Enabled = true;
            }
            else
            {
                // Si no hay rol, deshabilitar todo (por seguridad)
                EquipoID.Enabled = false;
                tFechaSolicitud.Enabled = false;
                tEstado.Enabled = false;
            }
        }
    }
}


