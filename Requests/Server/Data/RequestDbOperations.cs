using Microsoft.EntityFrameworkCore;
using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Server.Data
{
    public class RequestDbOperations
    {
        RequestsContext db = new RequestsContext();
        //To Get all recipes
        public IEnumerable<Request> GetAllRecipes()
        {
            try
            {
                return db.Request.ToList();
            }
            catch { throw; }
        }
        //To Add new recipe
        public void AddRecipe(Request recipe)
        {
            try
            {
                db.Request.Add(recipe);
                db.SaveChanges();
            }
            catch { throw; }
        }
        //To Update particular recipe
        public void UpdateRecipe(Request recipe)
        {
            try
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch { throw; }
        }
        //Get the particular recipe
        public Request GetEmployeeData(int id)
        {
            try
            {
                Request recipe = db.Request.Find(id);
                return recipe;
            }
            catch
            {
                throw;
            }
        }
        //To Delete particular recipe
        public void DeleteRecipe(int id)
        {
            try
            {
                Request recipe = db.Request.Find(id);
                db.Request.Remove(recipe);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
