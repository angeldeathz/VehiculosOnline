﻿using System;
using System.Net;
using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Personas
{
    public class PersonaService
    {
        private readonly RestClientHttp _restClientHttp;

        public PersonaService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/personas/api/personas/{id}";
            var respuesta = await _restClientHttp.GetAsync<Persona>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public async Task<RestClientResponse<int>> InsertarAsync(Persona persona)
        {
            const string url = "http://localhost/VehiculosOnline/personas/api/personas/";
            return await _restClientHttp.PostAsync<int>(url, persona);
        }
    }
}
