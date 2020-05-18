using System;

namespace VehiculosOnline.Model.Clases
{
    public class Usuario : Base
    {
        public Usuario()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }

        public int IdPersona { get; set; }
        public string Clave { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public Persona Persona { get; set; }
    }
}
