using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Datos.Clases.DO;

namespace Datos.Clases.DAL
{
    public interface IPlaneacionRepository
    {
        Task<Guid> ObtenerIdPlaneacionPorOrdenServicio(int numeroOrdenServicio);
        Task ActualizarEstadoPlaneacion(Guid idPlaneacion, int idEstadoPlaneacion);
    }

    public class PlaneacionRepository : IPlaneacionRepository
    {
        private readonly AppDbContext _context;

        public PlaneacionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> ObtenerIdPlaneacionPorOrdenServicio(int numeroOrdenServicio)
        {
            var idPlaneacion = await _context.DetallePlaneacion
                .Join(_context.OrdenServicio,
                    dp => dp.IdOrdenServicio,
                    os => os.IdOrdenServicio,
                    (dp, os) => new { dp, os })
                .Where(x => x.os.NumeroOrdenServicio == numeroOrdenServicio)
                .Select(x => x.dp.IdPlaneacion)
                .FirstOrDefaultAsync();

            return idPlaneacion;
        }

        public async Task ActualizarEstadoPlaneacion(Guid idPlaneacion, int idEstadoPlaneacion)
        {
            var planeacion = await _context.Planeacion.FindAsync(idPlaneacion);
            if (planeacion != null)
            {
                planeacion.IdEstadoPlaneacion = idEstadoPlaneacion;
                _context.Planeacion.Update(planeacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
