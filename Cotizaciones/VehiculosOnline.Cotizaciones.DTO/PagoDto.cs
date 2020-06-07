using System.Collections.Generic;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.DTO
{
    public class PagoDto
    {
        public int PrecioSinIVA { get; set; }
        public int PrecioVehiuclo { get; set; }
        public int Cuota { get; set; }
        public int ValorCuota { get; set; }
        public int CostoTotalCredito { get; set; }
    }
}
