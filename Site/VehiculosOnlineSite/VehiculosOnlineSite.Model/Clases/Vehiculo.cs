namespace VehiculosOnlineSite.Model.Clases
{
    public class Vehiculo : Base
    {
        public int IdModelo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdTipoCombustible { get; set; }
        public int IdPaisOrigen { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int Precio { get; set; }
        public Modelo Modelo { get; set; }
        public TipoVehiculo TipoVehiculo { get; set; }
        public TipoCombustible TipoCombustible { get; set; }
        public Pais PaisOrigen { get; set; }
    }
}
