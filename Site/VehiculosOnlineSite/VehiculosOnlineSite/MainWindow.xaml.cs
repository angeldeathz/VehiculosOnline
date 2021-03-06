﻿using System;
using System.Windows;
using VehiculosOnlineSite.BLL;

namespace VehiculosOnlineSite
{
    public partial class MainWindow
    {
        private readonly UsuarioBL _usuarioBl = new UsuarioBL();

        public MainWindow()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                NoIniciadoSesion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnIngresarVenta_Click(object sender, RoutedEventArgs e)
        {
            var ingresoSolicitudForm = new IngresoSolicitud();
            //Hide();
            ingresoSolicitudForm.ShowDialog();
        }

        private void btnFlujoEjecutivo_Click(object sender, RoutedEventArgs e)
        {
            var listarVehiculos = new MantenedorVehiculo();
            listarVehiculos.ShowDialog();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IngresoUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NoIniciadoSesion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void IngresoUsuario()
        {
            if (EsFormularioValido())
            {
                if (_usuarioBl.Autenticar(txtRut.Text, txtContrasena.Password))
                {
                    MostrarGridIniciadoSesion();
                }
                else
                {
                    MessageBox.Show("Rut o contraseña inválidas", "Ocurrió un error");
                }
            }
        }

        private bool EsFormularioValido()
        {
            var mensajeError = string.Empty;
            var esValido = true;

            if (txtRut.Text.Trim().Length == 0)
            {
                esValido = false;
                mensajeError = "Debe ingresar su usuario" + "\r\n";
            }

            if (txtContrasena.Password.Trim().Length == 0)
            {
                esValido = false;
                mensajeError += "Debe ingresar su contraseña" + "\r\n";
            }

            if (!esValido)
            {
                MessageBox.Show($"{mensajeError}", "Ocurrió un error");
            }

            return esValido;
        }

        private void NoIniciadoSesion()
        {
            gridInicio.Visibility = Visibility.Visible;
            gridIniciadoSesion.Visibility = Visibility.Hidden;
            btnIngresarVenta.Visibility = Visibility.Visible;
            txtRut.Text = string.Empty;
            txtContrasena.Password = string.Empty;
        }

        private void MostrarGridIniciadoSesion()
        {
            gridInicio.Visibility = Visibility.Hidden;
            gridIniciadoSesion.Visibility = Visibility.Visible;
            btnIngresarVenta.Visibility = Visibility.Hidden;
        }

        private void btnVerVentas_Click(object sender, RoutedEventArgs e)
        {
            var listarVentaForm = new ListarVenta();
            //Hide();
            listarVentaForm.ShowDialog();
        }

        private void btnVerSolicitudes_Click(object sender, RoutedEventArgs e)
        {
            var listarSolicitudForm = new ListarSolicitud();
            //Hide();
            listarSolicitudForm.ShowDialog();
        }
    }
}
