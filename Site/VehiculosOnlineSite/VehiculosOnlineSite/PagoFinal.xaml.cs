using System;
using System.Windows;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class PagoFinal
    {
        private readonly VentaBL _ventaBl = new VentaBL();
        public Cotizacion CotizacionActual { get; set; }

        public PagoFinal()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RealizarPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void BtnVolver_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void RealizarPago()
        {
            var venta = new Venta
            {
                IdCotizacion = CotizacionActual.Id
            };

            var idVenta = _ventaBl.RealizarVenta(venta);

            if (idVenta == 0)
            {
                MessageBox.Show("No se puso generar el pago", "Error");
            }
            else
            {
                MessageBox.Show($"Se realizó la venta con el número {idVenta}, un ejecutivo se contactará con usted a la brevedad.", "VEHICULO VENDIDO");
                CerrarVentanas();
            }
        }

        public void CargarDetallePago(ResumenCotizacion resumenCotizacion, Cotizacion cotizacion)
        {
            CotizacionActual = cotizacion;
            CotizacionActual.Id = resumenCotizacion.IdCotizacion;

            lblPrecioVehiculo.Content = "$"+resumenCotizacion.PrecioFinal;
            lblCostoTotalCredito.Content = "$" + resumenCotizacion.CostoTotalCredito;
            lblCuota.Content = resumenCotizacion.Cuotas;
            lblPrecioSinIVA.Content = "$" + resumenCotizacion.PrecioSinIva;
            lblValorCouta.Content = "$" + resumenCotizacion.ValorCuota;
        }

        private void CerrarVentanas()
        {
            for (int intCounter = Application.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
            {
                Application.Current.Windows[intCounter]?.Close();
            }
        }
    }
}
