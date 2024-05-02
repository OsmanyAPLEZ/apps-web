using MercadoArtesano.DAL;
using MercadoArtesano.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.BL
{
    public class CityBL
    {
        public async Task<int> CreateAsync(City city)
        {
            return await CityDAL.CreateAsync(city);
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await CityDAL.GetAllAsync();
        }

        public async Task<List<City>> SearchAsync(City city)
        {
            return await CityDAL.SearchAsync(city);
        }

        public async Task<int> UpdateAsync(City city)
        {
            return await CityDAL.UpdateAsync(city);
        }

        public async Task<int> DeleteAsync(City city)
        {
            return await CityDAL.DeleteAsync(city);
        }

        public async Task<City> GetByIdAsync(City city)
        {
            return await CityDAL.GetByIdAsync(city);
        }
    }
}
