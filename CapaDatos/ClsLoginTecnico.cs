using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsLoginTecnico
    {
        public int LoginID { get; set; }
        public int TecnicoID { get; set; }
        public string UsuarioLogin { get; set; }
        public string ContraseñaHash { get; set; }
        public int RolID { get; set; }
        public string NombreRol { get; set; }
    }
}