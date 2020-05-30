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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void btnIngresarVenta_Click(object sender, RoutedEventArgs e)
        {
            IngresoSolicitud ingresoSolicitudForm = new IngresoSolicitud();
            ingresoSolicitudForm.ShowDialog();
        }

        private void btnIngresoSolicitud_Click(object sender, RoutedEventArgs e)
        {
            IngresoSolicitud ingresoSolicitudForm = new IngresoSolicitud();
            ingresoSolicitudForm.ShowDialog();
        }

        private void btnFlujoEjecutivo_Click(object sender, RoutedEventArgs e)
        {
            MantenedorVehiculo mantenedorVehiculoForm = new MantenedorVehiculo();
            mantenedorVehiculoForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }
    }
}
