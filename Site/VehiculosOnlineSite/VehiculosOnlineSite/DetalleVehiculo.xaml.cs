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

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para DetalleVehiculo.xaml
    /// </summary>
    public partial class DetalleVehiculo : Window
    {
        public DetalleVehiculo()
        {
            InitializeComponent();
        }

        private void btnCotizar_Click(object sender, RoutedEventArgs e)
        {
            DatosContactoPersona datosContactoPersonaForm = new DatosContactoPersona();
            datosContactoPersonaForm.ShowDialog();
        }
    }
}
