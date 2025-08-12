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
    public partial class Tecnicos : System.Web.UI.Page
    {
        // Cadena de conexión, ajústala según tu entorno
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTecnicos();
            }
        }

        // Método para cargar todos los técnicos en el GridView
        private void CargarTecnicos()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Tecnicos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // Agregar nuevo técnico
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Tecnicos (TecnicoID, Nombre, Especialidad) VALUES (@TecnicoID, @Nombre, @Especialidad)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", tNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Especialidad", tEspecialidad.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarTecnicos();
        }

        // Eliminar técnico por ID
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Tecnicos WHERE TecnicoID = @TecnicoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarTecnicos();
        }

        // Modificar datos de técnico
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "UPDATE Tecnicos SET Nombre = @Nombre, Especialidad = @Especialidad WHERE TecnicoID = @TecnicoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", tNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Especialidad", tEspecialidad.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            LimpiarCampos();
            CargarTecnicos();
        }

        // Consultar técnico por ID y mostrar en los campos
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Tecnicos WHERE TecnicoID = @TecnicoID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TecnicoID", tTecnicoID.Text.Trim());

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tNombre.Text = dr["Nombre"].ToString();
                        tEspecialidad.Text = dr["Especialidad"].ToString();
                    }
                    else
                    {
                        // Opcional: Mostrar mensaje de no encontrado
                        tNombre.Text = "";
                        tEspecialidad.Text = "";
                    }
                }
            }
        }

        // Limpiar campos del formulario
        private void LimpiarCampos()
        {
            tTecnicoID.Text = "";
            tNombre.Text = "";
            tEspecialidad.Text = "";
        }
    }
}
