using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGESAVI.CapaDatos
{
    public class ClsUsuario : ClsPersona
    {
        public override string ObtenerInfo()
        {
            return $"Usuario: {Nombre} | Email: {CorreoElectronico} | Tel: {Telefono}";
        }
    }
}