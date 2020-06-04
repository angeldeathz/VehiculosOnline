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
        private readonly SolicitudBL _solicitudBl = new SolicitudBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();
        public VehiculoDataGrid Vehiculo { get; set; }

        public IngresoSolicitud()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerMarcas();
                BuscarVehiculo();
                OcultarDatosCliente();
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
                Vehiculo = (sender as Button)?.DataContext as VehiculoDataGrid;
                PedirDatosCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IngresarSolicitud();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void IngresarSolicitud()
        {
            if (EsPersonaValida())
            {
                var persona = new Persona
                {
                    Nombres = nombretxt.Text,
                    Apellidos = apellidotxt.Text,
                    Email = correoTxt.Text
                };
                persona.ValidaRut(ruttxt.Text);

                var solicitud = new SolicitudDto
                {
                    IdVehiculo = Vehiculo.Id,
                    Cliente = persona
                };

                // guardamos la solicitud
                var idSolicitud = _solicitudBl.IngresarSolicitud(solicitud);

                if (idSolicitud > 0)
                {
                    var detalleVehiculoForm = new DetalleVehiculo();
                    this.Hide();
                    detalleVehiculoForm.ShowDialog();
                }
            }
        }

        private bool EsPersonaValida()
        {
            var mensaje = string.Empty;
            var esValido = true;

            if (nombretxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje = "Debe ingresar su nombre." + "\r\n";
            }

            if (apellidotxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar sus apellidos." + "\r\n";
            }

            if (correoTxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar su correo electrónico." + "\r\n";
            }

            if (ruttxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar el rut." + "\r\n";
            }
            else
            {
                var persona = new Persona();
                if (!persona.ValidaRut(ruttxt.Text))
                {
                    esValido = false;
                    mensaje += "El rut ingresado es inválido." + "\r\n";
                }
            }

            if (!esValido) MessageBox.Show(mensaje, "Ha ocurrido un error");

            return esValido;
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

        private void OcultarDatosCliente()
        {
            gridDatosCliente.Visibility = Visibility.Hidden;
        }

        private void PedirDatosCliente()
        {
            gridDatosCliente.Visibility = Visibility.Visible;
        }
    }
}
