using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsAsignaciones
    {
        public int AsignacionID { get; set; }
        public int ReparacionID { get; set; }
        public ClsReparaciones Reparacion { get; set; }
        public int TecnicoID { get; set; }
        public ClsTecnico Tecnico { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }
}