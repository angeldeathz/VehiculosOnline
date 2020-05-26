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

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para DatosContactoPersona.xaml
    /// </summary>
    public partial class DatosContactoPersona : Window
    {

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
                IngresoVenta ingresoVentaForm = new IngresoVenta();
                ingresoVentaForm.ShowDialog();
            }
            
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
            if (String.IsNullOrEmpty(comuna.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la comuna" + "\r\n";
            }
            if (String.IsNullOrEmpty(ciudad.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la ciudad" + "\r\n";
            }
            if (String.IsNullOrEmpty(region.Text))
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
                if (String.IsNullOrEmpty(txtCuotas.Text))
                {
                    hayErrores = true;
                    mensaje = mensaje += "Debe ingresar las cuotas" + "\r\n";
                }
            }
            
            return hayErrores;
        }


    }
}
