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
using VehiculosOnlineSite.BLL;

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para IngresoSolicitud.xaml
    /// </summary>
    public partial class IngresoSolicitud : Window
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();

        public IngresoSolicitud()
        {
            InitializeComponent();
            ObtenerMarcas();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCotizar_Click(object sender, RoutedEventArgs e)
        {
            IngresoPersona ingresoPersonaForm = new IngresoPersona();
            ingresoPersonaForm.ShowDialog();
        }

        private void Marcacbo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idMarca = this.marcacbo.SelectedValue;
            if (idMarca != null)
            {
                ObtenerModelos(int.Parse(idMarca.ToString()));
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
    }
}
