using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class MarcaBL
    {
        private readonly MarcaService _marcaService;

        public MarcaBL()
        {
            _marcaService = new MarcaService();
        }

        public List<Marca> ObtenerMarcas()
        {
            return _marcaService.ObtenerMarcas();
        }

        public List<Modelo> ObtenerModelos(int idMarca)
        {
            return _marcaService.ObtenerModelos(idMarca);
        }
    }
}
