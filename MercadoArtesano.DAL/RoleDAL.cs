using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MercadoArtesano.EN;

namespace MercadoArtesano.DAL
{
    public class RoleDAL
    {
        #region Metodo de agregar
        // El STATIC sirve para tener acceso sin necesidad de hacer una instancia 
        // El async significa que las peticiones se haran en donde haya cupo (usando todos los recursos de la PC) para que sea mas fluido 
        // Task si se trabaja con async siempre (C#) se usara TASK por que async devuelve una tarea (task) 
        public static async Task<int> CreateAsync(Role pRole)
        {
            int result = 0;
            // Un bloque de conexion que mientras se permanezca en el bloque l base de datos permanecera abierta y al terminar se destruira
            using (var dbContext = new ContextDB())
            {
                dbContext.Roles.Add(pRole);
                result = await dbContext.SaveChangesAsync(); // Await sirve para esperar a terminar todos los procesos para devolverlos todos juntos
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region Metodo de Actualizar 
        public static async Task<int> UpdateAsync(Role pRole)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var RoleDB = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == pRole.Id);
                if (RoleDB != null)
                {
                    RoleDB.Name = pRole.Name;
                    dbContext.Roles.Update(RoleDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region Motodo de eliminar
        public static async Task<int> DeleteAsync(Role pRole)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                // Ubicar o localizar el registro que vamos eliminar
                var RoleDB = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == pRole.Id);
                if (RoleDB != null)
                {
                    dbContext.Roles.Remove(RoleDB);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;  // Si se realizo con exito devuelve 1 sino devuelve 0
        }
        #endregion

        #region Metodo Mostrar por ID
        public static async Task<Role> GetByIdAsync(Role pRole)
        {
            var RoleDB = new Role();
            using (var dbContext = new ContextDB())
            {
                RoleDB = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == pRole.Id);
            }
            return RoleDB;

        }
        #endregion

        #region Mostrar todos
        public static async Task<List<Role>> GetAllAsync()
        {
            var roles = new List<Role>();
            using (var dbContext = new ContextDB())
            {
                roles = await dbContext.Roles.ToListAsync();
            }
            return roles;
        }
        #endregion

        #region Metodo de Buscar Registro
        // IQueryable es una interfaz que toma un coleccion a la cual se le pueden implementar multiples consultas (Filtros) 
        internal static IQueryable<Role> QuerySelect(IQueryable<Role> query, Role pRole)
        {

            // Por ID
            if (pRole.Id > 0)
                query = query.Where(r => r.Id == pRole.Id);


            // Por Nomnbre, Si es verdadero lo vuelve falso y viceversa 
            if (!string.IsNullOrWhiteSpace(pRole.Name))
                query = query.Where(r => r.Name.Contains(pRole.Name));

            query = query.OrderByDescending(r => r.Id).AsQueryable();

            // Para la cantidad de registros a mostrar
            if (pRole.Top_Aux > 0)
                query = query.Take(pRole.Top_Aux).AsQueryable();

            return query;
        }

        public static async Task<List<Role>> SearchAsync(Role pRole)
        {
            var Roles = new List<Role>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Roles.AsQueryable();
                select = QuerySelect(select, pRole);
                Roles = await select.ToListAsync();
            }
            return Roles;
        }
        #endregion
    }
}
