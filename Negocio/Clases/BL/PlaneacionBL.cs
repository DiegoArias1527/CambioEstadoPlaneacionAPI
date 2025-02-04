using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Clases.DAL;
using InterfacesComunes.DTO;

namespace Negocio.Clases.BL
{
    public interface IPlaneacionService
    {
        Task CambiarEstadoPlaneacion(CambioEstadoDTO request);
    }

    public class PlaneacionService : IPlaneacionService
    {
        private readonly IPlaneacionRepository _repository;

        public PlaneacionService(IPlaneacionRepository repository)
        {
            _repository = repository;
        }

        public async Task CambiarEstadoPlaneacion(CambioEstadoDTO request)
        {
            var idPlaneacion = await _repository.ObtenerIdPlaneacionPorOrdenServicio(request.NumeroOrdenServicio);
            if (idPlaneacion == Guid.Empty)
            {
                throw new Exception("No se encontró la planeación para la orden de servicio especificada.");
            }

            await _repository.ActualizarEstadoPlaneacion(idPlaneacion, request.IdEstadoPlaneacion);
        }
    }
}
