namespace VehiculosOnline.Model.Clases
{
    public class Direccion : Base
    {
        public string Calle { get; set; }
        public string Numero { get; set; }
        public int IdComuna { get; set; }
        public Comuna Comuna { get; set; }
    }
}
