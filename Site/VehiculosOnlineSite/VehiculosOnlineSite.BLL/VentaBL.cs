using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class VentaBL
    {
        private readonly VentaService _ventaService;
        
        public VentaBL()
        {
            _ventaService = new VentaService();
        }

        public List<TipoPago> ObtenerTipoPago()
        {
            var tipopagos = new List<TipoPago> { new TipoPago { Id = 0, Nombre = "Seleccione..." } };
            tipopagos.AddRange(_ventaService.ObtenerTipoPago());
            return tipopagos;
        }

    }
}
