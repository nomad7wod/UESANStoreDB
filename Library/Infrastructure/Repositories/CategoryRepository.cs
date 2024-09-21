using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string obtenerApellido()
        {
            return "";
        }
        //Metodo Sincrono
        //public IEnumerable<Category> GetCategories() 
        //{
        //    var categories = _dbContext.Category.ToList();
        //    return categories;
        //}

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _dbContext.Category.ToListAsync();
            return categories;
        }

        //Get Category by ID
        public async Task<Category> GetCategorieByID(int id)
        {
            var category = await _dbContext.Category.Where(c => c.Id == id && c.IsActive == true ).FirstOrDefaultAsync();
                
            return category;
        }



        // Create Category

        public async Task<int> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();
            //return category.Id;

            return rows>0 ? category.Id: -1;
        }


        //Update Category
        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        //Delete category
        public async Task<bool> Delete(int id)
        {
            var category = await _dbContext.Category.FirstOrDefaultAsync(c => c.Id == id);

            if(category == null) return false;

            category.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync(); 
            return rows > 0;


            //borrar //int rows _dbContext.Category.Remove(category);
            
        }






    }
}
