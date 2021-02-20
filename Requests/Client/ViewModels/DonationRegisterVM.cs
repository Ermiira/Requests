using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Client.ViewModels
{
    public class DonationRegisterVM
    {
        public int DonationId { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public static implicit operator DonationRegisterVM(DonationRegisterShared donation)
        {
            return new DonationRegisterVM
            {

                Title = donation.Title,
                Email = donation.Email,
                Description = donation.Description,
                PhoneNumber = donation.PhoneNumber,
                CategoryId = donation.CategoryId,
                
            };
        }
    }
}
