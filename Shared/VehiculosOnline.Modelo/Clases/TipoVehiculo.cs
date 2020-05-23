using System.Text.Json.Serialization;

namespace VehiculosOnline.Model.Clases
{
    public class TipoVehiculo : Base
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public bool Activo { get; set; }
    }
}
