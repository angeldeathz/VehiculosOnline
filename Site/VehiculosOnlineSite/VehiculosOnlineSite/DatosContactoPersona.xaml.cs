using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para DatosContactoPersona.xaml
    /// </summary>
    public partial class DatosContactoPersona : Window
    {
        //private readonly VehiculoBL _vehiculoBl = new VehiculoBL();
        private readonly VentaBL _ventaBl = new VentaBL();
        private readonly LocalizacionBL _localizacionBl = new LocalizacionBL();
        private readonly SolicitudBL _solicitudBl = new SolicitudBL();
        private readonly CotizacionBL _cotizacionBl = new CotizacionBL();

        public string mensaje;

        public DatosContactoPersona()
        {
            InitializeComponent();
        }

        private void btnConfirmarCotizacion_Click(object sender, RoutedEventArgs e)
        {
            lblMensaje.Content = "";
            mensaje = "";
            if (validarFormulario())
            {
                lblMensaje.Content = mensaje;
            }
            else
            {
                 guardarCotizacion();
            }
            
        }

        public void guardarCotizacion()
        {
            var solicitud = _solicitudBl.ObtenerUltimaSolicitud();
            Cotizacion ingresaCotizacion = new Cotizacion();
            ingresaCotizacion.IdSolicitud = solicitud.Id;
            ingresaCotizacion.IdTipoPago = cboTipoPago.SelectedIndex;
            ingresaCotizacion.FechaIngresoCotizacion = DateTime.Now;
            if (rbSi.IsChecked==true)
            {
                ingresaCotizacion.EsPagoDiferido = true;
                ingresaCotizacion.CantidadMesesDiferido = cboMesesDiferidos.SelectedIndex;
            }
            else
            {
                ingresaCotizacion.EsPagoDiferido = false;
                ingresaCotizacion.CantidadMesesDiferido = 0;
            }
            if (cboTipoPago.SelectedIndex == 2)
            {
                ingresaCotizacion.CantidadCuotas = Convert.ToInt32(txtCuotas.Text);
            }
            else
            {
                ingresaCotizacion.CantidadCuotas = 0;
            }
            ingresaCotizacion.ValorVehiculo = solicitud.Vehiculo.Precio;

            var pago = _cotizacionBl.IngresarCotizacion(ingresaCotizacion);

            IngresoVenta ingresoVentaForm = new IngresoVenta();
            ingresoVentaForm.CargarDetallePago(pago);
            ingresoVentaForm.ShowDialog();
        }

        public void solicitudCotizada(SolicitudDto solicitud)
        {
            //var vehiculoBdd = _vehiculoBl.ObtenerPorId(solicitud.IdVehiculo);
            emailtxt.Text = solicitud.Cliente.Email;
            ObtenerTipoPago();
            ObtenerRegion();
            cboMesesDiferidos.IsEnabled = false;
            
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public bool validarFormulario()
        {
            bool hayErrores = false;
            if (String.IsNullOrEmpty(fechNacimiento.Text))
            {
                hayErrores = true;
                mensaje = "Debe seleccionar la fecha de nacimiento" + "\r\n";
            }
            if (String.IsNullOrEmpty(emailtxt.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el mail" + "\r\n";
            }
            else
            {
                //valida formato del mail
                try
                {
                    new System.Net.Mail.MailAddress(emailtxt.Text.ToLower());
                }
                catch (FormatException)
                {
                    hayErrores = true;
                    mensaje = mensaje += "El mail no corresponde" + "\r\n";
                }
            }
            if (String.IsNullOrEmpty(celular.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el celular" + "\r\n";
            }
            if (String.IsNullOrEmpty(telefono.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el telefono" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboComuna.Text)|| cboComuna.SelectedIndex==0)
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la comuna" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboCiudad.Text)|| cboCiudad.SelectedIndex == 0)
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la ciudad" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboRegion.Text)|| cboRegion.SelectedIndex == 0)
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la region" + "\r\n";
            }
            if (String.IsNullOrEmpty(direccion.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar su dirección" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboTipoPago.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar el tipo de pago" + "\r\n";
            }
            else
            {
                //aca deberia preguntar si es tarjeta de credito
                if (cboTipoPago.SelectedIndex == 2)
                {
                    if (String.IsNullOrEmpty(txtCuotas.Text))
                    {
                        hayErrores = true;
                        mensaje = mensaje += "Debe ingresar las cuotas" + "\r\n";
                    }
                }
                
            }
            
            return hayErrores;
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

        private void cboTipoPago_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboTipoPago.SelectedIndex == 2)
            {
                txtCuotas.IsEnabled = true;
            }
            else
            {
                txtCuotas.IsEnabled = false;
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

        private void rbSi_Checked(object sender, RoutedEventArgs e)
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
    }
}
