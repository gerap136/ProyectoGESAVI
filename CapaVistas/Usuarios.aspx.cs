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
    public partial class Usuarios : System.Web.UI.Page
    {
        private string conexion = "Data Source=.;Initial Catalog=ProyectoProgramacion;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        // 🔄 Cargar datos al GridView
        private void CargarUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuarios", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        // ✅ Agregar usuario
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "INSERT INTO Usuarios (UsuarioID, Nombre, Correoelectronico, Telefono) VALUES (@UsuarioID, @Nombre, @Correo, @Telefono)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", tNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", tcorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", ttelefono.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LimpiarCampos();
            CargarUsuarios();
        }

        // 🗑️ Eliminar usuario
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LimpiarCampos();
            CargarUsuarios();
        }

        // ✏️ Modificar usuario
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "UPDATE Usuarios SET Nombre = @Nombre, Correoelectronico = @Correo, Telefono = @Telefono WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nombre", tNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@Correo", tcorreo.Text.Trim());
                    cmd.Parameters.AddWithValue("@Telefono", ttelefono.Text.Trim());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LimpiarCampos();
            CargarUsuarios();
        }

        // 🔍 Consultar un usuario por ID
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                string query = "SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UsuarioID", tUsuarioID.Text.Trim());

                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tNombre.Text = dr["Nombre"].ToString();
                        tcorreo.Text = dr["Correoelectronico"].ToString();
                        ttelefono.Text = dr["Telefono"].ToString();
                    }
                }
            }
        }

        // 🔄 Limpiar campos del formulario
        private void LimpiarCampos()
        {
            tUsuarioID.Text = "";
            tNombre.Text = "";
            tcorreo.Text = "";
            ttelefono.Text = "";
        }
    }
}
