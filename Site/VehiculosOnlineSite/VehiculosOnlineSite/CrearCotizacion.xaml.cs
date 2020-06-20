using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class CrearCotizacion
    {
        #region Propiedades

        private readonly VentaBL _ventaBl = new VentaBL();
        private readonly LocalizacionBL _localizacionBl = new LocalizacionBL();
        private readonly CotizacionBL _cotizacionBl = new CotizacionBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();

        private SolicitudDto SolicitudActual { get; set; }

        public CrearCotizacion()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerTipoPago();
                ObtenerRegion();
                LlenarCboFactura();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        #endregion

        #region Eventos

        private void btnConfirmarCotizacion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GuardarCotizacion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void cboRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idRegion = this.cboRegion.SelectedValue;
                if (idRegion != null)
                {
                    ObtenerCiudades(int.Parse(idRegion.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void cboCiudad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idCiudad = this.cboCiudad.SelectedValue;
                if (idCiudad != null)
                {
                    ObtenerComunas(int.Parse(idCiudad.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void rbNo_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                cboMesesDiferidos.IsEnabled = false;
                var diferido = new List<Item>
                {
                    new Item
                    {
                        Value = 0,
                        Text = "Seleccione..."
                    },
                    new Item
                    {
                        Value = 1,
                        Text = "1"
                    },
                    new Item
                    {
                        Value = 2,
                        Text = "2"
                    },
                    new Item
                    {
                        Value = 3,
                        Text = "3"
                    }
                };

                this.cboMesesDiferidos.ItemsSource = diferido;
                this.cboMesesDiferidos.DisplayMemberPath = "Text";
                this.cboMesesDiferidos.SelectedValuePath = "Value";
                this.cboMesesDiferidos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void rbSi_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                cboMesesDiferidos.IsEnabled = true;
                var diferido = new List<Item>
                {
                    new Item
                    {
                        Value = 0,
                        Text = "Seleccione..."
                    },
                    new Item
                    {
                        Value = 1,
                        Text = "1"
                    },
                    new Item
                    {
                        Value = 2,
                        Text = "2"
                    },
                    new Item
                    {
                        Value = 3,
                        Text = "3"
                    }
                };

                this.cboMesesDiferidos.ItemsSource = diferido;
                this.cboMesesDiferidos.DisplayMemberPath = "Text";
                this.cboMesesDiferidos.SelectedValuePath = "Value";
                this.cboMesesDiferidos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion

        #region Metodos

        public void CargarDatosVehiculo(SolicitudDto solicitud)
        {
            var vehiculo = _vehiculoBl.ObtenerPorId(solicitud.IdVehiculo);

            if (vehiculo != null)
            {
                txtMarca.Text = vehiculo.Modelo.Marca.Nombre;
                txtModelo.Text = vehiculo.Modelo.Nombre;
                txtAnio.Text = vehiculo.Anio.ToString();
                txtColor.Text = vehiculo.Color;
                txtTipoVehiculo.Text = vehiculo.TipoVehiculo.Nombre;
                txtTipoCombustible.Text = vehiculo.TipoCombustible.Nombre;
                txtPaisOrigen.Text = vehiculo.PaisOrigen.Nombre;
                txtPrecio.Text = vehiculo.Precio.ToString("#,##0");
            }

            solicitud.Vehiculo = vehiculo;
            SolicitudActual = solicitud;

            emailtxt.Text = solicitud.Cliente.Email;
            cboMesesDiferidos.IsEnabled = false;
        }

        private void GuardarCotizacion()
        {
            if (EsFormularioValido())
            {
                var cotizacion = new Cotizacion
                {
                    IdSolicitud = SolicitudActual.Id,
                    IdTipoPago = Convert.ToInt32(cboTipoPago.SelectedValue.ToString()),
                    FechaIngresoCotizacion = DateTime.Now,
                    Solicitud = new Solicitud
                    {
                        Persona = SolicitudActual.Cliente
                    }
                };
                cotizacion.Solicitud.Persona.Email = emailtxt.Text;
                cotizacion.Solicitud.Persona.Telefono = txtTelefono.Text;
                cotizacion.Solicitud.Persona.FechaNacimiento = Convert.ToDateTime(fechNacimiento.Text);
                cotizacion.Solicitud.Persona.Direccion = new Direccion
                {
                    Calle = txtCalle.Text,
                    IdComuna = int.Parse(cboComuna.SelectedValue.ToString()),
                    Numero = txtNumeroCalle.Text
                };

                if (rbSi.IsChecked == true)
                {
                    cotizacion.EsPagoDiferido = true;
                    cotizacion.CantidadMesesDiferido = cboMesesDiferidos.SelectedIndex;
                }
                else
                {
                    cotizacion.EsPagoDiferido = false;
                    cotizacion.CantidadMesesDiferido = 0;
                }

                cotizacion.CantidadCuotas = Convert.ToInt32(txtCuotas.Text);
                cotizacion.ConFactura = int.Parse(cboFactura.SelectedValue.ToString()) == 1;

                cotizacion = _cotizacionBl.IngresarCotizacion(cotizacion);

                if (cotizacion != null)
                {
                    var pagoFinal = new PagoFinal();
                    pagoFinal.CargarDetallePago(cotizacion);
                    pagoFinal.ShowDialog();
                }
            }
        }

        private bool EsFormularioValido()
        {
            var esValido = true;
            var mensaje = string.Empty;
            
            if (string.IsNullOrEmpty(fechNacimiento.Text))
            {
                esValido = false;
                mensaje = "Debe seleccionar la fecha de nacimiento" + "\r\n";
            }

            if (emailtxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar el mail" + "\r\n";
            }
            else
            {
                //valida formato del mail
                try
                {
                    var unused = new System.Net.Mail.MailAddress(emailtxt.Text.ToLower());
                }
                catch (FormatException)
                {
                    esValido = false;
                    mensaje += "El mail es inválido" + "\r\n";
                }
            }

            if (txtTelefono.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar el telefono" + "\r\n";
            }

            if (cboComuna.SelectedIndex == 0)
            {
                esValido = false;
                mensaje += "Debe seleccionar la comuna" + "\r\n";
            }

            if (cboCiudad.SelectedIndex == 0)
            {
                esValido = false;
                mensaje += "Debe seleccionar la ciudad" + "\r\n";
            }

            if (cboRegion.SelectedIndex == 0)
            {
                esValido = false;
                mensaje += "Debe seleccionar la region" + "\r\n";
            }

            if (txtCalle.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar su dirección" + "\r\n";
            }

            if (txtNumeroCalle.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar el número de la dirección" + "\r\n";
            }

            if (cboTipoPago.SelectedIndex == 0)
            {
                esValido = false;
                mensaje += "Debe seleccionar el tipo de pago" + "\r\n";
            }
            
                    if (txtCuotas.Text.Trim().Length == 0)
                    {
                        esValido = false;
                        mensaje += "Debe ingresar las cuotas" + "\r\n";
                    }
                    else
                    {
                        if (int.Parse(txtCuotas.Text) <= 0)
                        {
                            esValido = false;
                            mensaje += "El n° de cuotas debe ser igual o mayor a 1" + "\r\n";
                        }
                    }
                
            

            if (!esValido) MessageBox.Show(mensaje, "Ha ocurrido un error");

            return esValido;
        }

        private void ObtenerTipoPago()
        {
            this.cboTipoPago.ItemsSource = _ventaBl.ObtenerTipoPago();
            this.cboTipoPago.DisplayMemberPath = "Nombre";
            this.cboTipoPago.SelectedValuePath = "Id";
            this.cboTipoPago.SelectedIndex = 0;
        }

        private void ObtenerRegion()
        {
            this.cboRegion.ItemsSource = _localizacionBl.ObtenerRegiones();
            this.cboRegion.DisplayMemberPath = "Nombre";
            this.cboRegion.SelectedValuePath = "Id";
            this.cboRegion.SelectedIndex = 0;
        }

        private void ObtenerCiudades(int idRegion)
        {
            this.cboCiudad.ItemsSource = _localizacionBl.ObtenerCiudades(idRegion);
            this.cboCiudad.DisplayMemberPath = "Nombre";
            this.cboCiudad.SelectedValuePath = "Id";
            this.cboCiudad.SelectedIndex = 0;
        }

        private void ObtenerComunas(int idCiudad)
        {
            this.cboComuna.ItemsSource = _localizacionBl.ObtenerComunas(idCiudad);
            this.cboComuna.DisplayMemberPath = "Nombre";
            this.cboComuna.SelectedValuePath = "Id";
            this.cboComuna.SelectedIndex = 0;
        }

        private void LlenarCboFactura()
        {
            var siNo = new List<Item>
            {
                new Item
                {
                    Value = 0,
                    Text = "No"
                },
                new Item
                {
                    Value = 1,
                    Text = "Si"
                }
            };

            this.cboFactura.ItemsSource = siNo;
            this.cboFactura.DisplayMemberPath = "Text";
            this.cboFactura.SelectedValuePath = "Value";
            this.cboFactura.SelectedIndex = 0;
        }

        #endregion
    }
}
