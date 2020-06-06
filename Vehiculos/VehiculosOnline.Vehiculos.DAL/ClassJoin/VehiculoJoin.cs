namespace VehiculosOnline.Vehiculos.DAL.ClassJoin
{
    public class VehiculoJoin
    {
        public int Id { get; set; }
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string NombreTipoVehiculo { get; set; }
        public int IdTipoCombustible { get; set; }
        public string NombreTipoCombustible { get; set; }
        public int IdPaisOrigen { get; set; }
        public string NombrePaisOrigen { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
    }
}
