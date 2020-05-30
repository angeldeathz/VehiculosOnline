using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiculosOnlineSite.Model.Clases
{
    public class SolicitudDto
    {
        public Persona Cliente { get; set; }
        public int IdVehiculo { get; set; }
    }
}
