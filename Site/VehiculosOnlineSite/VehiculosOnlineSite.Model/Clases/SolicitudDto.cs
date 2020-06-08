namespace VehiculosOnlineSite.Model.Clases
{
    public class SolicitudDto
    {
        public int Id { get; set; }
        public int IdVehiculo { get; set; }
        public Persona Cliente { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
