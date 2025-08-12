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
    public partial class Asignaciones : System.Web.UI.Page
    {
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CargarAsignaciones();
                    VerificarPermisos();
                }
            }

            private void CargarAsignaciones()
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = "SELECT * FROM Asignaciones";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

            private void VerificarPermisos()
            {
                // Solo permite botones si el rol es 2 (Administrador)
                object rolObj = Session["Rol"];
                string rol = rolObj != null ? rolObj.ToString() : "";

                bool esAdmin = rol == "2";

                btnGuardar.Enabled = esAdmin;
                btnModificar.Enabled = esAdmin;
                btnEliminar.Enabled = esAdmin;
            }

            protected void btnGuardar_Click(object sender, EventArgs e)
            {
                if (!EsAdministrador()) return;

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = @"INSERT INTO Asignaciones (AsignacionID, ReparacionID, TecnicoID, FechaAsignacion)
                                 VALUES (@AsignacionID, @ReparacionID, @TecnicoID, @FechaAsignacion)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AsignacionID", tAsignacionID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());
                        cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaAsignacion", tFechaAsignacion.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LimpiarCampos();
                CargarAsignaciones();
            }

            protected void btnEliminar_Click(object sender, EventArgs e)
            {
                if (!EsAdministrador()) return;

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = "DELETE FROM Asignaciones WHERE AsignacionID = @AsignacionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AsignacionID", tAsignacionID.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LimpiarCampos();
                CargarAsignaciones();
            }

            protected void btnModificar_Click(object sender, EventArgs e)
            {
                if (!EsAdministrador()) return;

                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = @"UPDATE Asignaciones SET 
                                    ReparacionID = @ReparacionID, 
                                    TecnicoID = @TecnicoID, 
                                    FechaAsignacion = @FechaAsignacion 
                                 WHERE AsignacionID = @AsignacionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AsignacionID", tAsignacionID.Text.Trim());
                        cmd.Parameters.AddWithValue("@ReparacionID", tReparacionID.Text.Trim());
                        cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaAsignacion", tFechaAsignacion.Text.Trim());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                LimpiarCampos();
                CargarAsignaciones();
            }

            protected void btnConsultar_Click(object sender, EventArgs e)
            {
                using (SqlConnection conn = new SqlConnection(conexion))
                {
                    string query = "SELECT * FROM Asignaciones WHERE AsignacionID = @AsignacionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AsignacionID", tAsignacionID.Text.Trim());

                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            tReparacionID.Text = dr["ReparacionID"].ToString();
                            tTecnicoID.Text = dr["TecnicoID"].ToString();
                            DateTime fecha;
                            if (DateTime.TryParse(dr["FechaAsignacion"].ToString(), out fecha))
                                tFechaAsignacion.Text = fecha.ToString("yyyy-MM-dd");
                            else
                                tFechaAsignacion.Text = "";
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
                tAsignacionID.Text = "";
                tReparacionID.Text = "";
                tTecnicoID.Text = "";
                tFechaAsignacion.Text = "";
            }

            private bool EsAdministrador()
            {
                object rolObj = Session["Rol"];
                if (rolObj == null || rolObj.ToString() != "2")
                {
                    // Opcional: mostrar mensaje de error o alertar usuario
                    // Ejemplo: lblMensaje.Text = "No tienes permisos para esta acción.";
                    return false;
                }
                return true;
            }
        }
    }
