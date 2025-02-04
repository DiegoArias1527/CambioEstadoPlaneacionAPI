using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases.DO
{
    public class Planeacion
    {
        [Key]
        public Guid IdPlaneacion { get; set; }
        public int IdEstadoPlaneacion { get; set; }
    }
    public class OrdenServicio
    {
        [Key]
        public Guid IdOrdenServicio { get; set; }
        public int NumeroOrdenServicio { get; set; }
    }

    public class DetallePlaneacion
    {
        [Key]
        public Guid IdDetallePlaneacion { get; set; } // Clave primaria
        public Guid IdPlaneacion { get; set; }
        public Guid IdOrdenServicio { get; set; }
    }

    public class EstadoPlaneacion
    {
        [Key]
        public int IdEstadoPlaneacion { get; set; }
        public string EstadPlaneacion { get; set; }
    }
}
