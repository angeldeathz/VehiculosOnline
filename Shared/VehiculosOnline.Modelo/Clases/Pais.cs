using System.Text.Json.Serialization;

namespace VehiculosOnline.Model.Clases
{
    public class Pais : Base
    {
        public string Nombre { get; set; }
        [JsonIgnore]
        public bool Activo { get; set; }
    }
}
