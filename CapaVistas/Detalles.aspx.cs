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
    public partial class Detalles : System.Web.UI.Page
    {
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetalles();
                VerificarPermisos();
            }
        }

        private void CargarDetalles()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM DetallesReparacion";
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
                string query = @"INSERT INTO DetallesReparacion 
                                 (DetalleID, ReparacionID, Descripcion, FechaInicio, FechaFin, Estado) 
                                 VALUES (@DetalleID, @ReparacionID, @Descripcion, @FechaInicio, @FechaFin, @Estado)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetalleID", DetalleID.Text.Trim());
                    cmd.Parameters.AddWithValue("@ReparacionID", tRepacionID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Descripcion", tDescripcion.Text.Trim());

                    DateTime fechaInicio, fechaFin;
                    DateTime.TryParse(tFechaInicio.Text.Trim(), out fechaInicio);
                    DateTime.TryParse(tFechaFin.Text.Trim(), out fechaFin);

                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio != DateTime.MinValue ? (object)fechaInicio : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin != DateTime.MinValue ? (object)fechaFin : DBNull.Value);

                    cmd.Parameters.AddWithValue("@Estado", tEstado.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarDetalles();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador()) return;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "DELETE FROM DetallesReparacion WHERE DetalleID = @DetalleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetalleID", DetalleID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarDetalles();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!EsAdministrador()) return;

            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = @"UPDATE DetallesReparacion SET 
                                    ReparacionID = @ReparacionID,
                                    Descripcion = @Descripcion,
                                    FechaInicio = @FechaInicio,
                                    FechaFin = @FechaFin,
                                    Estado = @Estado
                                 WHERE DetalleID = @DetalleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetalleID", DetalleID.Text.Trim());
                    cmd.Parameters.AddWithValue("@ReparacionID", tRepacionID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Descripcion", tDescripcion.Text.Trim());

                    DateTime fechaInicio, fechaFin;
                    DateTime.TryParse(tFechaInicio.Text.Trim(), out fechaInicio);
                    DateTime.TryParse(tFechaFin.Text.Trim(), out fechaFin);

                    cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio != DateTime.MinValue ? (object)fechaInicio : DBNull.Value);
                    cmd.Parameters.AddWithValue("@FechaFin", fechaFin != DateTime.MinValue ? (object)fechaFin : DBNull.Value);

                    cmd.Parameters.AddWithValue("@Estado", tEstado.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarDetalles();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM DetallesReparacion WHERE DetalleID = @DetalleID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DetalleID", DetalleID.Text.Trim());

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tRepacionID.Text = dr["ReparacionID"].ToString();
                        tDescripcion.Text = dr["Descripcion"].ToString();

                        DateTime fechaInicio, fechaFin;
                        if (DateTime.TryParse(dr["FechaInicio"].ToString(), out fechaInicio))
                            tFechaInicio.Text = fechaInicio.ToString("yyyy-MM-dd");
                        else
                            tFechaInicio.Text = "";

                        if (DateTime.TryParse(dr["FechaFin"].ToString(), out fechaFin))
                            tFechaFin.Text = fechaFin.ToString("yyyy-MM-dd");
                        else
                            tFechaFin.Text = "";

                        tEstado.Text = dr["Estado"].ToString();
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
            DetalleID.Text = "";
            tRepacionID.Text = "";
            tDescripcion.Text = "";
            tFechaInicio.Text = "";
            tFechaFin.Text = "";
            tEstado.Text = "";
        }

        private bool EsAdministrador()
        {
            object rolObj = Session["Rol"];
            if (rolObj == null || rolObj.ToString() != "2")
            {
                // Opcional: Mostrar mensaje o alerta que no tiene permisos
                // Ejemplo: lblMensaje.Text = "No tienes permiso para esta acción.";
                return false;
            }
            return true;
        }
    }
}