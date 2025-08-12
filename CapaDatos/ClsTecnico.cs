using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsTecnico : ClsPersona
    {
        public string Especialidad { get; set; }

        public override string ObtenerInfo()
        {
            return $"Técnico: {Nombre} | Especialidad: {Especialidad}";
        }
    }
}