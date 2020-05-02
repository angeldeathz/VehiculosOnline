namespace VehiculosOnline.Modelo.Clases
{
    public class Persona
    {
        public int Id { get; set; }

        public int IdDireccion { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime FecNacimiento { get; set; }

        public string Email { get; set; }

        public int Celular { get; set; }

        public int Telefono { get; set; }

    }
}
