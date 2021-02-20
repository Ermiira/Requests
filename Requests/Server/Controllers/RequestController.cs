using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Requests.Client.ViewModels;
using Requests.Server.Data;
using Requests.Server.Models;
using Requests.Server.Repository;
using Requests.Shared;
using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Requests.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RequestController : ControllerBase
    {
       
        private readonly ILogger<RequestController> logger;
        private readonly UserManager<ApplicationUser> _user;
        protected RequestsContext _context;

        public RequestController(ILogger<RequestController> logger,RequestsContext context, UserManager<ApplicationUser> user)
        {
            this.logger = logger;
            _context = context;
            _user = user;
             
        }

        
        //bani
        [HttpGet("requestlist")]
        public async Task<List<RequestViewModel>> RequestList()
        {
            var list =  await _context.Request.Join(_context.Category,
                        e=>e.CategoryId,c=>c.CategoryId,(e,c)=>
                        new RequestViewModel {
                                Title = e.Title,
                                Description = e.Description,
                                Active = e.Active,
                                Address = e.Address,
                                IconDisplay = c.Icon,
                                Email = e.Email,
                                PhoneNumber = e.PhoneNumber
                            }).ToListAsync();

            return list;
        }

        [HttpGet("myrequests")]
        public async Task<List<RequestViewModel>> MyRequests()
        {
              
            var lista = await (from r in _context.Request
                                join c in _context.Category on r.CategoryId equals c.CategoryId
                                where r.UserId == "18fb9898-50b3-4854-9df3-f7d834bdd3b9"
                                select new RequestViewModel {
                                    RequestId = r.RequestId,
                                    Title = r.Title,
                                    Description = r.Description,
                                    Active = r.Active,
                                    Address = r.Address,
                                    IconDisplay = c.Icon,
                                    Email = r.Email,
                                    PhoneNumber = r.PhoneNumber
                                }).ToListAsync();
            return lista;
        }
        [HttpGet("filterrequest")]
        public async Task<List<RequestViewModel>> FilterRequest(int category)
        {
            var list = await (from r in _context.Request
                        join c in _context.Category on r.CategoryId equals c.CategoryId
                        where c.CategoryId == category
                        select new RequestViewModel
                        {
                            Title = r.Title,
                            Description = r.Description,
                            Active = r.Active,
                            Address = r.Address,
                            IconDisplay = c.Icon,
                            Email = r.Email,
                            PhoneNumber = r.PhoneNumber
                        }).ToListAsync();
                
            return list;
        }
        //banii<3
        [HttpPost("register")]
        public void Create(RequestShared r)
        {
            if (ModelState.IsValid) { }
            var userId = _user.GetUserId(HttpContext.User);
            var id = "18fb9898-50b3-4854-9df3-f7d834bdd3b9";
            Request data = new Request()
                {
                    CategoryId = r.CategoryId,
                    UserId = id,
                    CityId = r.CityId,
                    PhoneNumber = r.PhoneNumber,
                    Title = r.Title,
                    Description = r.Description,
                    Approved = false,
                    Email = r.Email,
                    Active = true,
                    Address = r.Address,
                    PostalCode = r.PostalCode,
                    InsertedDate = DateTime.Now
                };
                _context.Request.Add(data);
                _context.SaveChanges();
        }

        [HttpPost("editrequest")]
        public void UpdateRequest(RequestShared request)
        {

            var updateRow =  _context.Request.Where(e => e.RequestId == request.RequestId).FirstOrDefault();
                updateRow.Title = request.Title;
                updateRow.Description = request.Description;
                updateRow.CityId = request.CityId;
                updateRow.Address = request.Address;
                updateRow.PostalCode = request.PostalCode;
                updateRow.PhoneNumber = request.PhoneNumber;
                updateRow.Email = request.Email;
                _context.SaveChanges();
             
        }

        [HttpGet("editdata")]
        public async Task<RequestShared> GetRequestes(int requestId)
        {
            RequestsContext db = new RequestsContext();

            var request = await db.Request.Select(e=> new RequestShared { 
            
                RequestId = e.RequestId,
                Title = e.Title,
                CategoryId = e.CategoryId,
                Description = e.Description,
                CityId = e.CityId,
                Address = e.Address,
                PostalCode = e.PostalCode,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email

            }).FirstOrDefaultAsync(e => e.RequestId.Equals(requestId));
            
            return request;

        }


        [HttpGet("{id}", Name = "GetRequest")]
        public async Task<ActionResult<RequestViewModel>> Get(int id)
        {
            var selected = await _context.Request.
                Select(e => new RequestViewModel
                {

                    Title = e.Title,
                    Description = e.Description,
                    Active = e.Active,
                    Address = e.Address

                }).FirstOrDefaultAsync(x => x.RequestId == id);
            return selected;
        }

        [HttpGet("city")]
        public async Task<List<CityShared>> Cities()
        {
            var list = await _context.City
                .Select(e => new CityShared
                {
                    CityId = e.CityId,
                    Name = e.Name
                }).ToListAsync();

            return list;
        }

        [HttpDelete("deleterequest/{id}")]
        public void DeleteRequest(int id)
        {
            var delete = _context.Request.Find(id);
            _context.Request.Remove(delete);
            _context.SaveChanges();
        }

        [HttpPost("finishrequest/{id}")]
        public void FinishRequest(int id)
        {
            var finish = _context.Request.Find(id);
            finish.Active = false;
            _context.SaveChanges();
        }
    }
}
