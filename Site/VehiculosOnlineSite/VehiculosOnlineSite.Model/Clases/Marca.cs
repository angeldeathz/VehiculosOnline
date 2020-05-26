using System.Collections.Generic;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Marca : Base
    {
        public string Nombre { get; set; }
        public List<Modelo> Modelos { get; set; }
    }
}
