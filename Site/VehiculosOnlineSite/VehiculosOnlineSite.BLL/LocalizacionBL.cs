using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
