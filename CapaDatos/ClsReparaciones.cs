using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsReparaciones
    {

        public int ReparacionID { get; set; }
        public int EquipoID { get; set; }
        public ClsEquipos Equipo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; }
    }
}