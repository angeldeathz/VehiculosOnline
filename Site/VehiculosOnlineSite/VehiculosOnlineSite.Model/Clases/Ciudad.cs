using System.Collections.Generic;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Ciudad : Base
    {
        public string Nombre { get; set; }
        public int IdRegion { get; set; }
        public Region Region { get; set; }
        public List<Comuna> Comunas { get; set; }
    }
}
