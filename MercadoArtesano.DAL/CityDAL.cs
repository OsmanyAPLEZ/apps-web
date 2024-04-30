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

    }
}