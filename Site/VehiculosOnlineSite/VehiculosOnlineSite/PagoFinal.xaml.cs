using System;
using System.Globalization;
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

        public void CargarDetallePago(Cotizacion cotizacion)
        {
            CotizacionActual = cotizacion;
            CotizacionActual.Id = cotizacion.Id;

            var format = new NumberFormatInfo { NumberDecimalSeparator = ",", NumberGroupSeparator = "." };

            txtNumCotizacion.Text = cotizacion.Id.ToString();
            txtPrecioSinIva.Text = $"$ {cotizacion.TotalSinIva.ToString("#,##0.00", format)}";
            txtIva.Text = $"$ {cotizacion.Iva.ToString("#,##0.00", format)}";
            txtPrecioFinal.Text = $"$ {cotizacion.TotalFinal.ToString("#,##0.00", format)}";
            txtCuotas.Text = $"$ {cotizacion.CantidadCuotas.ToString("#,##0.00", format)}";
            txtValorCuotas.Text = $"$ {cotizacion.ValorCuota.ToString("#,##0.00", format)}";
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