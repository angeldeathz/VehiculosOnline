using System;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Solicitud : Base
    {
        public int IdPersona { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FechaIngresoSolicitud { get; set; }
        public Persona Persona { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
