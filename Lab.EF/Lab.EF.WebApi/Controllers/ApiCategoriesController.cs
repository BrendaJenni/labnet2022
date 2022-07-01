using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Http.Cors;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Lab.EF.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApiCategoriesController : ApiController
    {
        // GET: Api
        public CategoriesLogic logic = new CategoriesLogic();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<Response> response;
                var categories = logic.GetAll();

                response = categories.Select(s => new Response
                {
                    CategoryId = s.CategoryID,
                    CategoryName = s.CategoryName
                }).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var categories = logic.GetAll();
                Categories mapping = categories.Find(s => s.CategoryID == id);

                if (mapping == null)
                {
                    return NotFound();
                }
                else
                {
                    Response categoriesResponse = new Response
                    {
                        CategoryId = mapping.CategoryID,
                        CategoryName = mapping.CategoryName
                    };
                    return Ok(categoriesResponse);
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Categories insertCategory = new Categories
                    {
                        CategoryID = request.CategoryId,
                        CategoryName = request.CategoryName
                    };

                    logic.Add(insertCategory);
                    return Ok(insertCategory);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody] Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool category = logic.GetAll().Exists(s => s.CategoryID == id);

                    if (category)
                    {
                        Categories updatedCategory = new Categories
                        {
                            CategoryID = request.CategoryId,
                            CategoryName = request.CategoryName
                        };

                        logic.Update(updatedCategory);
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var deteleCategory = logic.GetAll().Find(s => s.CategoryID == id);
                if (deteleCategory != null)
                {
                    logic.Delete(id);
                    return Ok(deteleCategory);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {

                return InternalServerError(e);
            }
        }
    }
}