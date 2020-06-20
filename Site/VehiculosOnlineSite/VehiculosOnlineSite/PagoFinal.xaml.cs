using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void RealizarPago()
        {
            if (EsFormularioValido())
            {
                var venta = new Venta
                {
                    IdCotizacion = CotizacionActual.Id
                };

                if (gridPac.IsVisible)
                {
                    venta.Detalle = new VentaDetalle
                    {
                        DiaVencimiento = int.Parse(txtDiaVencimientoPac.Text),
                        IdBanco = int.Parse(cboBancos.SelectedValue.ToString()),
                        NumeroCuentaCorriente = txtNumeroCuentaCorriente.Text
                    };
                }
                else
                {
                    venta.Detalle = new VentaDetalle
                    {
                        DiaVencimiento = int.Parse(txtDiaVencimientoPat.Text),
                        CvvTarjetaCredito = int.Parse(txtCvv.Text),
                        VencimientoTarjetaCredito = txtMes.Text + "/" + txtAnio.Text,
                        NumeroTarjetaCredito = txtNumeroTarjeta.Text,
                        IdTipoTarjeta = int.Parse(cboTipoTarjeta.SelectedValue.ToString())
                    };
                }

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
        }

        private bool EsFormularioValido()
        {
            var esValido = true;
            var mensaje = string.Empty;

            if (gridPac.IsVisible)
            {
                if (cboBancos.SelectedIndex == 0)
                {
                    esValido = false;
                    mensaje += "Debe seleccionar el banco" + "\r\n";
                }

                if (txtNumeroCuentaCorriente.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el número de cuenta corriente" + "\r\n";
                }

                if (txtDiaVencimientoPac.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el día de vencimiento" + "\r\n";
                }
            }
            else
            {
                if (cboTipoTarjeta.SelectedIndex == 0)
                {
                    esValido = false;
                    mensaje += "Debe seleccionar el tipo de tarjeta de crédito" + "\r\n";
                }

                if (txtNumeroTarjeta.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el número de la tarjeta de crédito" + "\r\n";
                }

                if (txtMes.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el mes de caducidad" + "\r\n";
                }

                if (txtAnio.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el año de la tarjeta de crédito" + "\r\n";
                }

                if (txtCvv.Text.Trim().Length == 0)
                {
                    esValido = false;
                    mensaje += "Debe ingresar el número CVV de la tarjeta de crédito" + "\r\n";
                }
            }

            if (!esValido) MessageBox.Show(mensaje, "Ha ocurrido un error");

            return esValido;
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

            if (cotizacion.IdTipoPago == 1)
            {
                CargarBancos();
                gridPac.Visibility = Visibility.Visible;
                gridPat.Visibility = Visibility.Hidden;
            }
            else
            {
                CargarTarjetasDeCredito();
                gridPat.Visibility = Visibility.Visible;
                gridPac.Visibility = Visibility.Hidden;
            }
        }

        private void CargarTarjetasDeCredito()
        {
            this.cboTipoTarjeta.ItemsSource = _ventaBl.ObtenerTarjetasDeCredito();
            this.cboTipoTarjeta.DisplayMemberPath = "Nombre";
            this.cboTipoTarjeta.SelectedValuePath = "Id";
            this.cboTipoTarjeta.SelectedIndex = 0;
        }

        private void CargarBancos()
        {
            this.cboBancos.ItemsSource = _ventaBl.ObtenerBancos();
            this.cboBancos.DisplayMemberPath = "Nombre";
            this.cboBancos.SelectedValuePath = "Id";
            this.cboBancos.SelectedIndex = 0;
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