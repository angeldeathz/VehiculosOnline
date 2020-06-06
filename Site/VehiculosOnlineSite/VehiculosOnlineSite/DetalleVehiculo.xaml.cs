using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para DetalleVehiculo.xaml
    /// </summary>
    public partial class DetalleVehiculo : Window
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
