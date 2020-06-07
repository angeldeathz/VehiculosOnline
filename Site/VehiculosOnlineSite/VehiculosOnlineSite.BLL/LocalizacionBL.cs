using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class LocalizacionBL
    {
        private readonly LocalizacionService _localizacionService;

        public LocalizacionBL()
        {
            _localizacionService = new LocalizacionService();
        }

        public List<Pais> ObtenerPaises()
        {
            var paises = new List<Pais> { new Pais { Id = 0, Nombre = "Seleccione..." } };
            paises.AddRange(_localizacionService.ObtenerPaises());
            return paises;
        }

        public List<Region> ObtenerRegiones()
        {
            var regiones = new List<Region> { new Region { Id = 0, Nombre = "Seleccione..." } };
            regiones.AddRange(_localizacionService.ObtenerRegiones());
            return regiones;
        }

        public List<Ciudad> ObtenerCiudades(int idRegion)
        {
            var ciudades = new List<Ciudad> { new Ciudad { Id = 0, Nombre = "Seleccione..." } };
            ciudades.AddRange(_localizacionService.ObtenerCiudades(idRegion));
            return ciudades;
        }

        public List<Comuna> ObtenerComunas(int idCiudad)
        {
            var comunas = new List<Comuna> { new Comuna { Id = 0, Nombre = "Seleccione..." } };
            comunas.AddRange(_localizacionService.ObtenerComunas(idCiudad));
            return comunas;
        }
    }
}
