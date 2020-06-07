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
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    /// <summary>
    /// Lógica de interacción para IngresoVenta.xaml
    /// </summary>
    public partial class IngresoVenta : Window
    {
        private readonly SolicitudBL _solicitudBl = new SolicitudBL();

        public IngresoVenta()
        {
            InitializeComponent();
        }


        public void CargarDetallePago(PagoDto pago)
        {
            lblPrecioVehiculo.Content = "$"+pago.PrecioVehiuclo;
            lblCostoTotalCredito.Content = "$" + pago.CostoTotalCredito;
            lblCuota.Content = pago.Cuota;
            lblPrecioSinIVA.Content = "$" + pago.PrecioSinIVA;
            lblValorCouta.Content = "$" + pago.ValorCuota;
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            var guardaVenta = _solicitudBl.IngresarVentaActualizaStock();
            if (guardaVenta==0)
            {
                MessageBox.Show("Existe un error", "ERROR");
            }
            else
            {
                MessageBox.Show("Se han guardado la compra del vehiculo, un ejecutivo se comunicara con usted a la brevedad", "VEHICULO VENDIDO");
            }
        }
    }
}
