using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VehiculosOnlineSite.BLL;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnlineSite
{
    public partial class CrearEditarVehiculo
    {
        private readonly MarcaBL _marcaBl = new MarcaBL();
        private readonly VehiculoBL _vehiculoBl = new VehiculoBL();
        private readonly LocalizacionBL _localizacionBl = new LocalizacionBL();
        private bool EsModificacion { get; set; }
        private int IdVehiculo { get; set; }

        public CrearEditarVehiculo()
        {
            try
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen;
                InitializeComponent();
                ObtenerMarcas();
                ObtenerTipoVehiculos();
                ObtenerTipoCombustibles();
                ObtenerPaises();
                ObtenerAnios();
                ObtenerColores();
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

        private void btnGuardarVehiculo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EsModificacion)
                {
                    ModificarVehiculo();
                }
                else
                {
                    GuardarVehiculo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: \r\n {ex.Message}", "Ocurrió un error");
            }
        }

        public void ObtenerVehiculoParaModificar(VehiculoDataGrid vehiculo)
        {
            var vehiculoBdd = _vehiculoBl.ObtenerPorId(vehiculo.Id);

            if (vehiculoBdd != null)
            {
                cboMarca.SelectedValue = vehiculoBdd.Modelo.IdMarca;
                cboModelo.SelectedValue = vehiculoBdd.IdModelo;
                cboAnio.SelectedValue = vehiculoBdd.Anio;
                cboTipoVehiculo.SelectedValue = vehiculoBdd.IdTipoVehiculo;
                //ACA SE ARREGLA PORQUE  NO MOSTRABA EL COLOR
                cboColor.SelectedValue = vehiculoBdd.Color.Substring(0, 1) + vehiculoBdd.Color.Substring(1).ToLower();
                cboPais.SelectedValue = vehiculoBdd.IdPaisOrigen;
                cboTipoCombustible.SelectedValue = vehiculoBdd.IdTipoCombustible;
                txtPrecio.Text = vehiculoBdd.Precio.ToString();
                txtStock.Text = vehiculoBdd.Stock.ToString();
                //aca decia .name, lo modifique por .contect
                btnGuardarVehiculo.Content = "Modificar Vehículo";
                IdVehiculo = vehiculo.Id;
                EsModificacion = true;
            }
        }

        private void GuardarVehiculo()
        {
            if (EsFormularioValido())
            {
                var vehiculo = new Vehiculo
                {
                    IdModelo = int.Parse(cboModelo.SelectedValue.ToString()),
                    IdTipoVehiculo = int.Parse(cboTipoVehiculo.SelectedValue.ToString()),
                    IdTipoCombustible = int.Parse(cboTipoCombustible.SelectedValue.ToString()),
                    IdPaisOrigen = int.Parse(cboPais.SelectedValue.ToString()),
                    Anio = int.Parse(cboAnio.SelectedValue.ToString()),
                    Color = cboColor.Text,
                    Precio = int.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                var idVehiculo = _vehiculoBl.Insertar(vehiculo);

                if (idVehiculo > 0)
                {
                    MessageBox.Show("Vehiculo ingresado correctamente", "Éxito", MessageBoxButton.OK);
                    this.Close();
                }
            }
        }

        private void ModificarVehiculo()
        {
            if (EsFormularioValido())
            {
                var vehiculo = new Vehiculo
                {
                    Id = IdVehiculo,
                    IdModelo = int.Parse(cboModelo.SelectedValue.ToString()),
                    IdTipoVehiculo = int.Parse(cboTipoVehiculo.SelectedValue.ToString()),
                    IdTipoCombustible = int.Parse(cboTipoCombustible.SelectedValue.ToString()),
                    IdPaisOrigen = int.Parse(cboPais.SelectedValue.ToString()),
                    Anio = int.Parse(cboAnio.SelectedValue.ToString()),
                    Color = cboColor.Text,
                    Precio = int.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text)
                };

                var idVehiculo = _vehiculoBl.Modificar(vehiculo);

                if (idVehiculo > 0)
                {
                    MessageBox.Show("Vehiculo modificado correctamente", "Éxito", MessageBoxButton.OK);
                    this.Close();
                }
            }
        }

        private bool EsFormularioValido()
        {
            var esValido = true;
            var mensaje = string.Empty;

            if (cboMarca.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger una marca. \r\n";
            }

            if (cboModelo.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un modelo. \r\n";
            }

            if (cboAnio.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un año. \r\n";
            }

            if (cboTipoVehiculo.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un tipo vehículo. \r\n";
            }

            if (cboColor.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un color. \r\n";
            }

            if (cboPais.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un país. \r\n";
            }

            if (cboTipoCombustible.SelectedValue.ToString().Equals("0"))
            {
                esValido = false;
                mensaje += "Debe escoger un tipo combustible. \r\n";
            }

            if (txtPrecio.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar un precio. \r\n";
            }
            else
            {
                if (int.Parse(txtPrecio.Text) < 500000 || int.Parse(txtPrecio.Text) > 300000000)
                {
                    esValido = false;
                    mensaje += "Precio debe estar entre 500.000 y 300.000.000. \r\n";
                }
            }

            if (txtStock.Text.Trim().Length == 0)
            {
                esValido = false;
                mensaje += "Debe ingresar un stock. \r\n";
            }
            else
            {
                if (int.Parse(txtStock.Text) < 0 || int.Parse(txtStock.Text) > 999)
                {
                    esValido = false;
                    mensaje += "Stock debe estar entre 0 y 999 \r\n";
                }
            }

            if (!esValido)
            {
                MessageBox.Show($"{mensaje}", "Ocurrió un error");
            }

            return esValido;
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

        private void ObtenerTipoVehiculos()
        {
            this.cboTipoVehiculo.ItemsSource = _vehiculoBl.ObtenerTipoVehiculos();
            this.cboTipoVehiculo.DisplayMemberPath = "Nombre";
            this.cboTipoVehiculo.SelectedValuePath = "Id";
            this.cboTipoVehiculo.SelectedIndex = 0;
        }

        private void ObtenerTipoCombustibles()
        {
            this.cboTipoCombustible.ItemsSource = _vehiculoBl.ObtenerTipoCombustibles();
            this.cboTipoCombustible.DisplayMemberPath = "Nombre";
            this.cboTipoCombustible.SelectedValuePath = "Id";
            this.cboTipoCombustible.SelectedIndex = 0;
        }

        private void ObtenerPaises()
        {
            this.cboPais.ItemsSource = _localizacionBl.ObtenerPaises();
            this.cboPais.DisplayMemberPath = "Nombre";
            this.cboPais.SelectedValuePath = "Id";
            this.cboPais.SelectedIndex = 0;
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

        private void ObtenerColores()
        {

            var colores = new List<Item>
            {
                new Item
                {
                    Text = "Seleccione...",
                    Value = 0
                },
                new Item
                {
                    Text = "Rojo",
                },
                new Item
                {
                    Text = "Amarillo",
                },
                new Item
                {
                    Text = "Azul",
                },
                new Item
                {
                    Text = "Negro",
                },
                new Item
                {
                    Text = "Blanco",
                },
                new Item
                {
                    Text = "Plateado",
                },
                new Item
                {
                    Text = "Verde",
                },
                new Item
                {
                    Text = "Calipso",
                },
                new Item
                {
                    Text = "Morado",
                },
                new Item
                {
                    Text = "Dorado",
                },
                new Item
                {
                    Text = "Celeste",
                },
                new Item
                {
                    Text = "Bronce",
                },
                new Item
                {
                    Text = "Naranjo",
                },
                new Item
                {
                    Text = "Gris",
                }
            };

            colores = colores.OrderByDescending(x => x.Value).ToList();

            this.cboColor.ItemsSource = colores;
            this.cboColor.DisplayMemberPath = "Text";
            this.cboColor.SelectedValuePath = "Text";
            this.cboColor.SelectedIndex = 0;
        }
    }
}
