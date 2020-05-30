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
            var marcas = new List<Marca> { new Marca { Id = 0, Nombre = "Seleccione..." } };
            marcas.AddRange(_marcaService.ObtenerMarcas());
            return marcas;
        }

        public List<Modelo> ObtenerModelos(int idMarca)
        {
            var modelos = new List<Modelo> { new Modelo { Id = 0, Nombre = "Seleccione..." } };
            modelos.AddRange(_marcaService.ObtenerModelos(idMarca));
            return modelos;
        }
    }
}
