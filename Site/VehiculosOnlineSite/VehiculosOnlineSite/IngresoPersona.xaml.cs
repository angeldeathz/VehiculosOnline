using System;
using System.Windows;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class IngresoPersona
    {
        private readonly SolicitudBL _solicitudBl = new SolicitudBL();

        public VehiculoDataGrid Vehiculo { get; set; }

        public IngresoPersona()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IngresarSolicitud();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void IngresarSolicitud()
        {
            if (EsPersonaValida())
            {
                var persona = new Persona
                {
                    Nombres = nombretxt.Text,
                    Apellidos = apellidotxt.Text,
                    Email = correoTxt.Text
                };
                persona.ValidaRut(ruttxt.Text);

                var solicitud = new SolicitudDto
                {
                    IdVehiculo = Vehiculo.Id,
                    Cliente = persona
                };

                var idSolicitud = _solicitudBl.IngresarSolicitud(solicitud);
                if (idSolicitud > 0)
                {
                    var detalleVehiculoForm = new DetalleVehiculo();
                    detalleVehiculoForm.ShowDialog();
                }
            }
        }

        private bool EsPersonaValida()
        {
            var mensaje = string.Empty;
            var esValido = true;

            if (nombretxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje = "Debe ingresar su nombre." + "\r\n";
            }

            if (apellidotxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar sus apellidos." + "\r\n";
            }

            if (correoTxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar su correo electrónico." + "\r\n";
            }

            if (ruttxt.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar el rut." + "\r\n";
            }
            else
            {
                var persona = new Persona();
                if (!persona.ValidaRut(ruttxt.Text))
                {
                    esValido = false;
                    mensaje += "El rut ingresado es inválido." + "\r\n";
                }
            }

            if (!esValido) MessageBox.Show(mensaje, "Ha ocurrido un error");

            return esValido;
        }
    }
}
