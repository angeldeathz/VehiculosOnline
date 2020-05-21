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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string mensaje;
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            lblMensaje.Content = "";
            mensaje = "";
            if (validarFormulario())
            {
                lblMensaje.Content = mensaje;
            }
        }
        public bool validarFormulario()
        {
            bool hayErrores = false;
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                hayErrores = true;
                mensaje = "Debe ingresar su usuario" + "\r\n";
            }
            if (String.IsNullOrEmpty(txtContrasena.Password))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar su contraseña" + "\r\n";
            }
            if (hayErrores == false)
            {
                //Aca debe validar si el usuario existe
            }
            return hayErrores;
        }
    }
}
