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
    /// Lógica de interacción para IngresoPersona.xaml
    /// </summary>
    public partial class IngresoPersona : Window
    {
        public string mensaje;

        public IngresoPersona()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            lblMensaje.Content = "";
            mensaje = "";
            if (validarFormulario())
            {
                lblMensaje.Content = mensaje;
            }
            else
            {
                DetalleVehiculo detalleVehiculoForm = new DetalleVehiculo();
                detalleVehiculoForm.ShowDialog();
            }
            
        }

        public bool validarFormulario()
        {
            bool hayErrores = false;
            if (String.IsNullOrEmpty(nombretxt.Text))
            {
                hayErrores = true;
                mensaje = "Debe ingresar su nombre" + "\r\n";
            }
            if (String.IsNullOrEmpty(apellidotxt.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar sus apellidos" + "\r\n";
            }
            if (String.IsNullOrEmpty(ruttxt.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el rut" + "\r\n";
            }
            else
            {
                int letters = 0;

                foreach (char a in ruttxt.Text)
                {
                    if (Char.IsLetter(a))
                    {
                        letters++;
                    }
                }
                if (letters>=2)
                {
                    hayErrores = true;
                    mensaje = mensaje += "El rut ingresado no es valido" + "\r\n";
                }
                else
                {
                    ruttxt.Text = FormatearIdentificador(ruttxt.Text);
                    if (!ValidarIdentificador(ruttxt.Text))
                    {
                        hayErrores = true;
                        mensaje = mensaje += "El rut ingresado no es valido" + "\r\n";
                    }
                }
               
            }
            

            return hayErrores;
        }

        public bool ValidarIdentificador(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
            {
                throw new ArgumentException("Argumento no debe ser nulo ni vacio", nameof(documento));
            }

            bool validacion = false;
            documento = documento.ToUpper();
            documento = documento.Replace(".", "");
            documento = documento.Replace("-", "");
            int rutAux = int.Parse(documento.Substring(0, documento.Length - 1));

            char dv = char.Parse(documento.Substring(documento.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                validacion = true;
            }
            return validacion;
        }
        public string FormatearIdentificador(string rut)
        {

            int cont = 0;
            string format;
            if (rut == null || rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                return format;
            }
        }
    }
}
