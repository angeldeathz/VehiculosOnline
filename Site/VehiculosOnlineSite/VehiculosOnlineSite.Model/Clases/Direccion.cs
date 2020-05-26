namespace VehiculosOnlineSite.Model.Clases
{
    public class Direccion : Base
    {
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int IdComuna { get; set; }
        public Comuna Comuna { get; set; }
    }
}
