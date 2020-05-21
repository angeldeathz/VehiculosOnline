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

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para MantenedorVehiculo.xaml
    /// </summary>
    public partial class MantenedorVehiculo : Window
    {
        public string mensaje;
        public MantenedorVehiculo()
        {
            InitializeComponent();
            llenarCBO();
            
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
        public void llenarCBO()
        {
            //deshabilita el modelo, cuando escoje una marca ahi lo habilita
            cboModelo.IsEnabled = false;
            //llenar cbo Anio
            cboAnio.Items.Insert(0, "2020");
            cboAnio.Items.Insert(1, "2019");
            cboAnio.Items.Insert(2, "2018");
            cboAnio.Items.Insert(3, "2017");
            cboAnio.Items.Insert(4, "2016");
            cboAnio.Items.Insert(5, "2015");
            cboAnio.Items.Insert(6, "2014");
            cboAnio.Items.Insert(7, "2013");
            cboAnio.Items.Insert(8, "2012");
            cboAnio.Items.Insert(9, "2011");
            cboAnio.Items.Insert(10, "2010");
            //llenar cbo marca
            cboMarca.Items.Insert(0, "Chevrolet");
            cboMarca.Items.Insert(1, "KIA");
            cboMarca.Items.Insert(2, "Chery");
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
            //Llena cbo Modelo
            cboModelo.IsEnabled = true;
            cboModelo.Items.Clear();
            int id = cboMarca.SelectedIndex;
            switch (id)
            {
                case (0):
                    cboModelo.Items.Insert(0, "Spark");
                    cboModelo.Items.Insert(1, "Camaro");
                    break;
                case (1):
                    cboModelo.Items.Insert(0, "RIO");
                    break;
                case (2):
                    cboModelo.Items.Insert(0, "Fulwin 2 Sport");
                    break;
                default:
                    break;
            }


        }
    }
}
