﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Vehiculo.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class VehiculoDal
    {
        private readonly Repository _repository;
            
        public VehiculoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Vehiculo>> ObtenerTodosAsync()
        {
            var sql = @"select 
                        id,
                        anio,
                        id_modelo AS IdModelo
                        from vehiculo";
            return await _repository.GetAllAsync<Vehiculo>(sql);
        }
    }
}
