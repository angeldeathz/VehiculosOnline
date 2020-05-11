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
    /// Lógica de interacción para IngresoSolicitud.xaml
    /// </summary>
    public partial class IngresoSolicitud : Window
    {
        public IngresoSolicitud()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCotizar_Click(object sender, RoutedEventArgs e)
        {
            IngresoPersona ingresoPersonaForm = new IngresoPersona();
            ingresoPersonaForm.ShowDialog();
        }
    }
}
