using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class PaisDal
    {
        private readonly Repository _repository;

        public PaisDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Pais>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre,
                        activo
                        from pais";

            return await _repository.GetAllAsync<Pais>(sql);
        }
    }
}
