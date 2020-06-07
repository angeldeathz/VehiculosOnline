using System.Windows;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class DetalleVehiculo
    {
        private SolicitudDto soliObj;
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();

        public DetalleVehiculo()
        {
            InitializeComponent();
        }

        private void btnCotizar_Click(object sender, RoutedEventArgs e)
        {
            
            DatosContactoPersona datosContactoPersonaForm = new DatosContactoPersona();
            datosContactoPersonaForm.solicitudCotizada(soliObj);
            datosContactoPersonaForm.ShowDialog();
        }

        public void ObtenerVehiculoDetalle(SolicitudDto solicitud)
        {
            var vehiculoBdd = _vehiculoBl.ObtenerPorId(solicitud.IdVehiculo);
            soliObj = solicitud;
            if (vehiculoBdd != null)
            {
                lblMarca.Content = vehiculoBdd.Modelo.Marca.Nombre;
                lblModelo.Content = vehiculoBdd.Modelo.Nombre;
                lblPaisOrigen.Content = vehiculoBdd.PaisOrigen.Nombre;
                lblAño.Content = vehiculoBdd.Anio;
                lblColor.Content = vehiculoBdd.Color;
                lblPrecio.Content = vehiculoBdd.Precio;
                
            }
        }
    }
}
