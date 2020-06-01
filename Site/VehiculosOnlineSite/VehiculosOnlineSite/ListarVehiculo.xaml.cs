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

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para ListarVehiculo.xaml
    /// </summary>
    public partial class ListarVehiculo : Window
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();
        public ListarVehiculo()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerMarcas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ObtenerMarcas()
        {
            this.cboMarca.ItemsSource = _marcaBl.ObtenerMarcas();
            this.cboMarca.DisplayMemberPath = "Nombre";
            this.cboMarca.SelectedValuePath = "Id";
            this.cboMarca.SelectedIndex = 0;
        }

        private void ObtenerModelos(int idMarca)
        {
            this.cboMarca.ItemsSource = _marcaBl.ObtenerModelos(idMarca);
            this.cboMarca.DisplayMemberPath = "Nombre";
            this.cboMarca.SelectedValuePath = "Id";
            this.cboMarca.SelectedIndex = 0;
        }

        private void cboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idMarca = this.cboMarca.SelectedValue;
                if (idMarca != null)
                {
                    ObtenerModelos(int.Parse(idMarca.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }
    }
}
