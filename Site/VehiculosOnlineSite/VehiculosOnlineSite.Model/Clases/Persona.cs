﻿using System;
using System.Text.RegularExpressions;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Persona : Base
    {
        public int IdDireccion { get; set; }
        public int Rut { get; set; }
        public string Dv { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Direccion Direccion { get; set; }

        /// <summary>
        /// Metodo de validación de rut con digito verificador
        /// dentro de la cadena
        /// </summary>
        /// <param name="rut">string</param>
        /// <returns>booleano</returns>
        public bool ValidaRut(string rut)
        {
            // se valida que no sea nulo o vacio
            if (string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut)) return false;
            rut = rut.Replace(".", "").Replace("-", "").ToUpper();

            // si es un rut muy antiguo o muy grande es invalido
            if (rut.Length <= 7 || rut.Length > 9) return false;

            var expresion = new Regex("^([0-9]+[0-9K])$");
            if (!expresion.IsMatch(rut))
            {
                return false;
            }

            string dv = rut.Substring(rut.Length - 1, 1);
            var rutNumerico = Convert.ToInt32(rut.Substring(0, rut.Length - 1));

            if (dv != Digito(rutNumerico))
            {
                return false;
            }

            this.Rut = rutNumerico;
            this.Dv = dv;
            return true;
        }

        /// <summary>
        /// Método que valida el rut con el digito verificador
        /// por separado
        /// </summary>
        /// <param name="rut">integer</param>
        /// <param name="dv">char</param>
        /// <returns>booleano</returns>
        public bool ValidaRut(string rut, string dv)
        {
            return ValidaRut(rut + "-" + dv);
        }

        /// <summary>
        /// método que calcula el digito verificador a partir
        /// de la mantisa del rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }

        public string ObtenerRutCompleto()
        {
            return $"{Rut}-{Dv}";
        }
	}
}
