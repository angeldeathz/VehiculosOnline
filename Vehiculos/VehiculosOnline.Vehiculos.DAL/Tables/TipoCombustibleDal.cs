using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Vehiculos.DAL.Tables
{
    public class TipoCombustibleDal
    {
        private readonly Repository _repository;

        public TipoCombustibleDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<TipoCombustible>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre
                        from TipoCombustible";

            return await _repository.GetAllAsync<TipoCombustible>(sql);
        }
    }
}
