using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Client.ViewModels
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Active { get; set; }
        public bool? Approved { get; set; }
        public string IconDisplay { get; set; }

        public static implicit operator RequestViewModel(RequestShared request)
        {
            return new RequestViewModel
            {
                CategoryId = request.CategoryId,
                Title = request.Title,
                CityId = request.CityId,
                Address = request.Address,
                PostalCode = request.PostalCode,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Approved = request.Approved,
                Active = request.Active,
                IconDisplay = request.IconDisplay
            }; 
        } 
    }
}
