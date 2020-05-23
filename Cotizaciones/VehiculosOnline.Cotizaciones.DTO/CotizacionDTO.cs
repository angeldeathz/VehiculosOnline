using System.Collections.Generic;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.DTO
{
    public class CotizacionDTO
    {
        public int IdSolicitud { get; set; }
        public Persona Cliente { get; set; }
        public List<int> IdSeguros { get; set; }
        public int IdTipoPago { get; set; }
        public bool EsPagoDiferido { get; set; }
        public int CantidadMesesDiferido { get; set; }
        public int CantidadCuotas { get; set; }
    }
}
