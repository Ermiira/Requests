using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class DonationController : ControllerBase
    {
        private readonly ILogger<DonationController> logger;
        private readonly UserManager<ApplicationUser> _user;
        protected RequestsContext _context;

        public DonationController(ILogger<DonationController> logger, RequestsContext context, UserManager<ApplicationUser> user)
        {
            this.logger = logger;
            _context = context;
            _user = user;
        }

        [HttpGet("mydonations")]
        public async Task<List<RequestViewModel>> MyDonations()
        {

            var lista = await (from d in _context.Donation
                               join c in _context.Category on d.CategoryId equals c.CategoryId
                               where d.UserId == "18fb9898-50b3-4854-9df3-f7d834bdd3b9"
                               select new RequestViewModel
                               {
                                   Title = d.Title,
                                   Description = d.Description,
                                   Email = d.Email,
                                   PhoneNumber = d.PhoneNumber,
                                   CategoryId = c.CategoryId,
                                   UserId = "Emri perdoruesit",
                                   IconDisplay = c.Icon

                               }).ToListAsync();
            return lista;
        }

        [HttpGet("donationlist")]
        public async Task<List<DonationViewModel>> DonationList(int category)
        {

            var list = await (from d in _context.Donation
                              join c in _context.Category on d.CategoryId equals c.CategoryId
                              where c.CategoryId == category
                              select new DonationViewModel
                              {
                                  Title = d.Title,
                                  Description = d.Description,
                                  Email = d.Email,
                                  PhoneNumber = d.PhoneNumber,
                                  CategoryId = c.CategoryId,
                                  UserId = "Emri perdoruesit",
                                  IconDisplay = c.Icon
                              }).ToListAsync();

            return list;
        }
        [HttpGet("alldonationlist")]
        public async Task<List<DonationViewModel>> AllDonationList()
        {
            var list = await _context.Donation.Join(_context.Category,
                       e => e.CategoryId, c => c.CategoryId, (e, c) =>
                             new DonationViewModel
                             {
                            DonationId = e.DonationId,
                            Title = e.Title,
                            Description = e.Description,
                            Email = e.Email,
                            PhoneNumber = e.PhoneNumber,
                            CategoryId = c.CategoryId,
                            IconDisplay = c.Icon,
                            UserId = "Emri perdoruesit"
                        }).ToListAsync();

            return list;
        }
        [HttpGet("category")]
        public async Task<List<CategoryViewModel>> Categories()
        {
            var list = await _context.Category
                .Select(e => new CategoryViewModel
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName,
                    Icon = e.Icon
                }).ToListAsync();

            return list;
        }

        [HttpPost("donationregister")]
        public void Create(DonationRegisterShared register)
        {
            if (ModelState.IsValid) { }
            var userId = _user.GetUserId(HttpContext.User);
            var id = "18fb9898-50b3-4854-9df3-f7d834bdd3b9";
            Donation data = new Donation()
            {
                CategoryId = register.CategoryId,
                UserId = id,
                PhoneNumber = register.PhoneNumber,
                Title = register.Title,
                Description = register.Description,
                Email = register.Email,
                InsertedDate = DateTime.Now
            };
            _context.Donation.Add(data);
            _context.SaveChanges();
        }


        [HttpPost("editdonation")]
        public void UpdateDonation(DonationShared donation)
        {
            var updateRow = _context.Donation.Where(e => e.DonationId == donation.DonationId).FirstOrDefault();
            updateRow.Title = donation.Title;
            updateRow.CategoryId = donation.CategoryId;
            updateRow.Description = donation.Description;
            updateRow.PhoneNumber = donation.PhoneNumber;
            updateRow.Email = donation.Email;
            _context.SaveChanges();
        }

        [HttpGet("donationdata")]
        public async Task<DonationShared> GetDonation(int donationId)
        {
            
            var donation = await _context.Donation.Select(e => new DonationShared
            {

                DonationId = e.DonationId,
                Title = e.Title,
                CategoryId = e.CategoryId,
                Description = e.Description,
                PhoneNumber = e.PhoneNumber,
                Email = e.Email

            }).FirstOrDefaultAsync(e => e.DonationId.Equals(donationId));

            return donation;

        }

        [HttpDelete("deletedonation/{id}")]
        public void DeleteDonation(int id)
        {
            var delete = _context.Donation.Find(id);
            _context.Donation.Remove(delete);
            _context.SaveChanges();
        }

        
    }
}
