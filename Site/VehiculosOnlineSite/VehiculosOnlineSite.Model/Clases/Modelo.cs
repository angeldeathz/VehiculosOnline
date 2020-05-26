namespace VehiculosOnlineSite.Model.Clases
{
    public class Modelo : Base
    {
        public string Nombre { get; set; }
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
    }
}
