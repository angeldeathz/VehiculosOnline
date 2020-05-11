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
    /// Lógica de interacción para DatosContactoPersona.xaml
    /// </summary>
    public partial class DatosContactoPersona : Window
    {
        public DatosContactoPersona()
        {
            InitializeComponent();
        }

        private void btnConfirmarCotizacion_Click(object sender, RoutedEventArgs e)
        {
            IngresoVenta ingresoVentaForm = new IngresoVenta();
            ingresoVentaForm.ShowDialog();
        }
    }
}
