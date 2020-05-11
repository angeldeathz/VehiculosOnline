﻿using System;
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
    /// Lógica de interacción para IngresoPersona.xaml
    /// </summary>
    public partial class IngresoPersona : Window
    {
        public IngresoPersona()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            DetalleVehiculo detalleVehiculoForm = new DetalleVehiculo();
            detalleVehiculoForm.ShowDialog();
        }
    }
}
