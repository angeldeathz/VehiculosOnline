using System;
using System.Collections.Generic;
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
                ObtenerAnios();
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
                    var crearCotizacion = new CrearCotizacion();
                    solicitud.Id = idSolicitud;

                    crearCotizacion.CargarDatosVehiculo(solicitud);
                    this.Hide();
                    crearCotizacion.ShowDialog();
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
            int.TryParse(this.cboAnio.SelectedValue.ToString(), out int anio);

            var vehiculos = _vehiculoBl.ObtenerPorIdMarcaModelo(idMarca, idModelo, anio);
            // Se listaran al cliente solo los que tienen stock
            vehiculos = vehiculos.Where(x => x.Stock > 0).ToList();

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

        private void ObtenerAnios()
        {
            var anios = new List<Item>
            {
                new Item
                {
                    Value = 0,
                    Text = "Selecione..."
                },
                new Item
                {
                    Value = 2020,
                    Text = "2020"
                },
                new Item
                {
                    Value = 2019,
                    Text = "2019"
                },
                new Item
                {
                    Value = 2018,
                    Text = "2018"
                },
                new Item
                {
                    Value = 2017,
                    Text = "2017"
                },
                new Item
                {
                    Value = 2016,
                    Text = "2016"
                },
                new Item
                {
                    Value = 2015,
                    Text = "2015"
                },
                new Item
                {
                    Value = 2014,
                    Text = "2014"
                },
                new Item
                {
                    Value = 2013,
                    Text = "2013"
                },
                new Item
                {
                    Value = 2012,
                    Text = "2012"
                },
                new Item
                {
                    Value = 2011,
                    Text = "2011"
                },
                new Item
                {
                    Value = 2010,
                    Text = "2010"
                },
                new Item
                {
                    Value = 2009,
                    Text = "2009"
                },
                new Item
                {
                    Value = 2008,
                    Text = "2008"
                },
                new Item
                {
                    Value = 2007,
                    Text = "2007"
                },
                new Item
                {
                    Value = 2006,
                    Text = "2006"
                },
                new Item
                {
                    Value = 2005,
                    Text = "2005"
                },
                new Item
                {
                    Value = 2004,
                    Text = "2004"
                },
                new Item
                {
                    Value = 2003,
                    Text = "2003"
                },
                new Item
                {
                    Value = 2002,
                    Text = "2002"
                },
                new Item
                {
                    Value = 2001,
                    Text = "2001"
                },
                new Item
                {
                    Value = 2000,
                    Text = "2000"
                }
            };

            this.cboAnio.ItemsSource = anios;
            this.cboAnio.DisplayMemberPath = "Text";
            this.cboAnio.SelectedValuePath = "Value";
            this.cboAnio.SelectedIndex = 0;
        }
    }
}
