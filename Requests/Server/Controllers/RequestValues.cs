using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Requests.Server.Data;
using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Server.Controllers
{
     
    public class RequestValues : ControllerBase
    {
        private RequestDbOperations dbOpereations = new RequestDbOperations();
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Request> GetRecipes()
        {
            return dbOpereations.GetAllRecipes();
        }
        // GET api/<controller>/5
        [HttpGet]
        public Request GetRecipeDetail(int id)
        {
            //return dbOpereations.GetRecipeDetail(id);
            return null;
        }
        // POST api/<controller>
        [HttpPost("create")]
        public void Post([FromBody] Request recipe)
        {
            if (ModelState.IsValid)
                dbOpereations.AddRecipe(recipe);
        }
        // PUT api/<controller>/5
        [HttpPut("edit")]
        public void Put([FromBody] Request recipe)
        {
            if (ModelState.IsValid)
                dbOpereations.UpdateRecipe(recipe);
        }
        // DELETE api/<controller>/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            dbOpereations.DeleteRecipe(id);
        }

    }
}
