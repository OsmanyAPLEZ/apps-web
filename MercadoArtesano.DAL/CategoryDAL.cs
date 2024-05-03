using MercadoArtesano.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.DAL
{
    public class CategoryDAL
    {
        #region Metodo Crear
        public static async Task<int> CreateAsync(Category category)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                dbContext.Categories.Add(category);
                result = await dbContext.SaveChangesAsync();
            }
            return result;
        }
        #endregion

        #region Metodo Modificar
        public static async Task<int> UpdateAsync(Category category)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var categoryDb = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (categoryDb != null)
                {
                    categoryDb.Name = category.Name;
                    dbContext.Categories.Update(categoryDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo Eliminar
        public static async Task<int> DeleteAsync(Category category)
        {
            int result = 0;
            using (var dbContext = new ContextDB())
            {
                var categoryDb = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (categoryDb != null)
                {
                    dbContext.Categories.Remove(categoryDb);
                    result = await dbContext.SaveChangesAsync();
                }
            }
            return result;
        }
        #endregion

        #region Metodo Obtener Id
        public static async Task<Category> GetByIdAsync(Category category)
        {
            var categoryDb = new Category();
            using (var dbContext = new ContextDB())
            {
                categoryDb = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            }
            return categoryDb!;
        }
        #endregion

        #region Metodo Obtener todo
        public static async Task<List<Category>> GetAllAsync()
        {
            var categories = new List<Category>();
            using (var dbContext = new ContextDB())
            {
                categories = await dbContext.Categories.ToListAsync();
            }
            return categories;
        }
        #endregion

        #region Metodo Buscar
        internal static IQueryable<Category> QuerySelect(IQueryable<Category> query, Category category)
        {
            if (category.Id > 0)
                query = query.Where(c => c.Id == category.Id);

            if (!string.IsNullOrWhiteSpace(category.Name))
                query = query.Where(c => c.Name.Contains(category.Name));

            query = query.OrderByDescending(c => c.Id);

            if (category.Top_Aux > 0)
                query = query.Take(category.Top_Aux).AsQueryable();

            return query;
        }

        public static async Task<List<Category>> SearchAsync(Category category)
        {
            var categories = new List<Category>();
            using (var dbContext = new ContextDB())
            {
                var select = dbContext.Categories.AsQueryable();
                select = QuerySelect(select, category);
                categories = await select.ToListAsync();
            }
            return categories;
        }
        #endregion
    }
}
