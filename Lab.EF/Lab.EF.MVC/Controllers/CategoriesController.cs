using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic logic = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            
            List<Categories> categories = logic.GetAll();

            List<CategoriesView> categoryView = categories.Select(s => new CategoriesView
            {
                Id = s.CategoryID,
                Name = s.CategoryName
            }).ToList();

            return View(categoryView);
        }
        public ActionResult InsertUpdate(int id,string name)
        {
            CategoriesView newView = new CategoriesView
            {
                Id=id,
                Name = name
            };
            return View(newView);
        }
        [HttpPost]
        public ActionResult InsertUpdate(CategoriesView categoryView)
        {
            if (categoryView.Id == null)
            {
                try
                {
                    Categories categoriesEntity = new Categories { CategoryName = categoryView.Name };
                    logic.Add(categoriesEntity);

                    return RedirectToAction("Index");
                }
                catch (FormatException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (InvalidOperationException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (OverflowException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage=e.Message
                    });
                }
            }
            else
            {
                try
                {
                    Categories categoriesEntity = new Categories { CategoryName = categoryView.Name, CategoryID= (int)(categoryView.Id) };
                    logic.Update(categoriesEntity);

                    return RedirectToAction("Index");
                }
                catch (FormatException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (OverflowException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (InvalidOperationException e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index", "Error", new
                    {
                        eMessage = e.Message
                    });
                }
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException e)
            {
                return RedirectToAction("Index", "Error", new
                {
                    eMessage = e.Message
                });
            }
            
        }
    }
}