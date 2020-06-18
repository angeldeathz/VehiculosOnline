using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    //Cliente nombre,correo cliente, Vehiculo, Marca, Modelo, Anio, tipoPago, precio de venta, fecha de venta
    public partial class ListarSolicitud
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();
        private readonly SolicitudBL _solicitudBL = new SolicitudBL();

        public ListarSolicitud()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerMarcas();
                ObtenerAnios();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void cboMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idMarca = this.cboMarca.SelectedValue;
                if (idMarca != null)
                {
                    ObtenerModelos(int.Parse(idMarca.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BuscarSolicitud();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
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

        private void BuscarSolicitud()
        {
            //aca el ejemplo
            int.TryParse(this.cboMarca.SelectedValue.ToString(), out int idMarca);
            int.TryParse(this.cboModelo.SelectedValue.ToString(), out int idModelo);
            int.TryParse(this.cboAnio.SelectedValue.ToString(), out int anio);

            DateTime fechaDesde = DateTime.MinValue;
            DateTime fechaHasta = DateTime.MinValue;
            if (this.fechDesde.SelectedDate!=null)
            {
                fechaDesde = this.fechDesde.SelectedDate.Value;
            }
            if (this.fechHasta.SelectedDate != null)
            {
                fechaHasta = this.fechHasta.SelectedDate.Value;
            }

            var rut = this.txtRut.Text;


            var ventas = _solicitudBL.ObtenerSolicitudListado(rut, idMarca, idModelo, anio, fechaDesde, fechaHasta);
            this.gridSolicitudes.ItemsSource = ventas;
            this.gridSolicitudes.IsReadOnly = true;

            if (!ventas.Any())
            {
                MessageBox.Show("No se han encontrado resultados", "Atención");
            }

        }

        private void ObtenerAnios()
        {
            var anios = new List<Item>
            {
                new Item
                {
                    Value = 0,
                    Text = "Selecione..."
                },
                new Item
                {
                    Value = 2020,
                    Text = "2020"
                },
                new Item
                {
                    Value = 2019,
                    Text = "2019"
                },
                new Item
                {
                    Value = 2018,
                    Text = "2018"
                },
                new Item
                {
                    Value = 2017,
                    Text = "2017"
                },
                new Item
                {
                    Value = 2016,
                    Text = "2016"
                },
                new Item
                {
                    Value = 2015,
                    Text = "2015"
                },
                new Item
                {
                    Value = 2014,
                    Text = "2014"
                },
                new Item
                {
                    Value = 2013,
                    Text = "2013"
                },
                new Item
                {
                    Value = 2012,
                    Text = "2012"
                },
                new Item
                {
                    Value = 2011,
                    Text = "2011"
                },
                new Item
                {
                    Value = 2010,
                    Text = "2010"
                },
                new Item
                {
                    Value = 2009,
                    Text = "2009"
                },
                new Item
                {
                    Value = 2008,
                    Text = "2008"
                },
                new Item
                {
                    Value = 2007,
                    Text = "2007"
                },
                new Item
                {
                    Value = 2006,
                    Text = "2006"
                },
                new Item
                {
                    Value = 2005,
                    Text = "2005"
                },
                new Item
                {
                    Value = 2004,
                    Text = "2004"
                },
                new Item
                {
                    Value = 2003,
                    Text = "2003"
                },
                new Item
                {
                    Value = 2002,
                    Text = "2002"
                },
                new Item
                {
                    Value = 2001,
                    Text = "2001"
                },
                new Item
                {
                    Value = 2000,
                    Text = "2000"
                }
            };

            this.cboAnio.ItemsSource = anios;
            this.cboAnio.DisplayMemberPath = "Text";
            this.cboAnio.SelectedValuePath = "Value";
            this.cboAnio.SelectedIndex = 0;
        }


    }
}
