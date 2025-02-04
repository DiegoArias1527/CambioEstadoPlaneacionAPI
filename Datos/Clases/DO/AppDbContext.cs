using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Clases.DO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<OrdenServicio> OrdenServicio { get; set; }
        public DbSet<DetallePlaneacion> DetallePlaneacion { get; set; }
        public DbSet<Planeacion> Planeacion { get; set; }
        public DbSet<EstadoPlaneacion> Estado { get; set; }
    }

}
