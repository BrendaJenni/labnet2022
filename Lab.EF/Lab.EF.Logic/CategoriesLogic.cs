using Lab.EF.Data;
using Lab.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public CategoriesLogic()
        {
        }

        public List<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Add(Categories newCategory)
        {
            try
            {
                _context.Categories.Add(newCategory);
                _context.SaveChanges();
            }
            catch (FormatException e)
            {
                throw e;

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Delete(int id)
        {
            try
            {
                var categoryToDelete = _context.Categories.First(r => r.CategoryID == id);
                _context.Categories.Remove(categoryToDelete);
                _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                throw e;
            }
            catch (PersonalException e)
            {
                throw e;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(Categories category)
        {
            try
            {
                var categoriesUpdate = _context.Categories.Single(r => r.CategoryID == ((Categories)category).CategoryID);
                categoriesUpdate.Description = category.Description;
                categoriesUpdate.CategoryName = category.CategoryName;
                _context.SaveChanges();
            }
            catch (FormatException e)
            {
                throw e;
            }
            catch (PersonalException e)
            {
                throw e;
            }
            catch (InvalidOperationException e)
            {
                throw e;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
        public void ValidateID(int id)
        {
            var validate = GetAll().FirstOrDefault(i => i.CategoryID == id);
            if(validate == null)
            {
                throw new PersonalException();
            }
        }
    }
}
