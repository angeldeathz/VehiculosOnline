using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosOnlineSite.Model.Clases
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
