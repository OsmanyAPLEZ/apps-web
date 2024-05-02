using MercadoArtesano.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.DAL
{
    public class CityDAL
    {
        #region Metodo de agregar
        // El STATIC sirve para tener acceso sin necesidad de hacer una instancia 
        // El async significa que las peticiones se haran en donde haya cupo (usando todos los recursos de la PC) para que sea mas fluido 
        // Task si se trabaja con async siempre (C#) se usara TASK por que async devuelve una tarea (task) 
        public static async Task<int> CreateAsync(City pCity)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque l base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Cities.Add(pCity);
                result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region Metodo de Buscar Registro
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<City> QuerySelect(IQueryable<City> query, City pCity)
        {

            // Por ID
            if (pCity.Id > 0)
                query = query.Where(r => r.Id == pCity.Id);


            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(pCity.Name))
                query = query.Where(r => r.Name.Contains(pCity.Name));

            query = query.OrderByDescending(r => r.Id).AsQueryable();

            // Para la cantidad de registros a mostrar
            if (pCity.Top_Aux > 0)
                query = query.Take(pCity.Top_Aux).AsQueryable();

            return query;
        }
        public static async Task<List<City>> SearchAsync(City pCity)
        {
            var cities = new List<City>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Cities.AsQueryable();
                select = QuerySelect(select, pCity);
                cities = await select.ToListAsync();
            }
            return cities;
        }
        #endregion

        #region Metodo para Modificar 
        public static async Task<int> UpdateAsync(City city)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var cityDb = await dbContext.Cities.FirstOrDefaultAsync(c => c.Id == city.Id);
                if (cityDb != null)
                {
                    cityDb.Name = city.Name;
                    dbContext.Cities.Update(cityDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo para Eliminar 
        public static async Task<int> DeleteAsync(City city)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var cityDb = await dbContext.Cities.FirstOrDefaultAsync(c => c.Id == city.Id);
                if (cityDb != null)
                {
                    dbContext.Cities.Remove(cityDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo para Obtener Id 
        public static async Task<City> GetByIdAsync(City city)
        {
            var cityDb = new City();
            using (var dbContext = new ContextDB())
            {
                cityDb = await dbContext.Cities.FirstOrDefaultAsync(c => c.Id == city.Id);
            }
            return cityDb!;
        }
        #endregion

        #region Mostrar todos
        public static async Task<List<City>> GetAllAsync()
        {
            var cities = new List<City>();
            using (var dbContext = new ContextDB())
            {
                cities = await dbContext.Cities.ToListAsync();
            }
            return cities;
        }
        #endregion

    }
}