using System.Collections.Generic;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Region : Base
    {
        public string Nombre { get; set; }
        public List<Ciudad> Ciudades { get; set; }
    }
}
