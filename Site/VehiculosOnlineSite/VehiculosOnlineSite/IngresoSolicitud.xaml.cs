using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class IngresoSolicitud
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();

        public IngresoSolicitud()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerMarcas();
                BuscarVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void Marcacbo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idMarca = this.marcacbo.SelectedValue;
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

        private void BtnCotizar_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var vehiculo = (sender as Button)?.DataContext as VehiculoDataGrid;
                EscogerVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void ObtenerMarcas()
        {
            this.marcacbo.ItemsSource = _marcaBl.ObtenerMarcas();
            this.marcacbo.DisplayMemberPath = "Nombre";
            this.marcacbo.SelectedValuePath = "Id";
            this.marcacbo.SelectedIndex = 0;
        }

        private void ObtenerModelos(int idMarca)
        {
            this.modelocbo.ItemsSource = _marcaBl.ObtenerModelos(idMarca);
            this.modelocbo.DisplayMemberPath = "Nombre";
            this.modelocbo.SelectedValuePath = "Id";
            this.modelocbo.SelectedIndex = 0;
        }

        private void BuscarVehiculo()
        {
            int.TryParse(this.marcacbo.SelectedValue.ToString(), out int idMarca);
            int.TryParse(this.modelocbo.SelectedValue.ToString(), out int idModelo);

            var vehiculos = _vehiculoBl.ObtenerPorIdMarcaModelo(idMarca, idModelo);
            this.gridVehiculos.ItemsSource = vehiculos;
            this.gridVehiculos.IsReadOnly = true;

            if (!vehiculos.Any())
            {
                MessageBox.Show("No se han encontrado resultados", "Atención");
            }
        }

        private void EscogerVehiculo(VehiculoDataGrid vehiculo)
        {
            var ingresoPersona = new IngresoPersona();
            ingresoPersona.Vehiculo = vehiculo;
            ingresoPersona.ShowDialog();
        }
    }
}
