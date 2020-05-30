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
using System.Text.RegularExpressions;
using VehiculosOnlineSite.BLL;

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para MantenedorVehiculo.xaml
    /// </summary>
    public partial class MantenedorVehiculo : Window
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();
        public string mensaje;

        public MantenedorVehiculo()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ObtenerMarcas();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            lblMensaje.Content = "";
            mensaje = "";
            if (validarFormulario())
            {
                lblMensaje.Content = mensaje;
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
            if (String.IsNullOrEmpty(txtPrecio.Text))
            {
                hayErrores = true;
                mensaje = "Debe ingresar el precio"+ "\r\n";
            }
            if (String.IsNullOrEmpty(txtDetalle.Text))
            {
                hayErrores = true;
                mensaje = mensaje+="Debe ingresar el detalle" + "\r\n";
            }
            if (String.IsNullOrEmpty(txtColor.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el color" + "\r\n";
            }
            if (String.IsNullOrEmpty(txtStock.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe ingresar el stock" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboAnio.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar el año" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboMarca.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar la marca" + "\r\n";
            }
            if (String.IsNullOrEmpty(cboModelo.Text))
            {
                hayErrores = true;
                mensaje = mensaje += "Debe seleccionar el modelo" + "\r\n";
            }

            return hayErrores;
        }

        private void cboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idMarca = this.cboMarca.SelectedValue;
            if (idMarca != null)
            {
                ObtenerModelos(int.Parse(idMarca.ToString()));
            }
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
            this.cboModelo.ItemsSource = _marcaBl.ObtenerModelos(idMarca);
            this.cboModelo.DisplayMemberPath = "Nombre";
            this.cboModelo.SelectedValuePath = "Id";
            this.cboModelo.SelectedIndex = 0;
        }
    }
}
