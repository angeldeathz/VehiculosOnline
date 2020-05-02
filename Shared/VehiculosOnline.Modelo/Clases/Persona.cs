using System;

namespace VehiculosOnline.Model.Clases
{
    public class Persona : Base
    {
        public int IdDireccion { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public int Telefono { get; set; }
        public Direccion Direccion { get; set; }
    }
}
