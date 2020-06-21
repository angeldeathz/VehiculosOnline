using System;

namespace VehiculosOnline.Solicitudes.DAL.ClassJoin
{
    public class SolicitudJoin
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public DateTime FechaSolicitud { get; set; }

    }


}
