using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsPersona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }

        public virtual string ObtenerInfo()
        {
            return $"{Nombre} - {CorreoElectronico} - {Telefono}";
        }
    }
}