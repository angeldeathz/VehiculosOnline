﻿namespace VehiculosOnlineSite.Model.Clases
{
    public class Comuna : Base
    {
        public string Nombre { get; set; }
        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
