using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Client.ViewModels
{
    public class DonationViewModel
    {
        public int DonationId { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        
        [Required] 
        public string Title { get; set; }

        [Required] 
        public string Description { get; set; }

        [Required] 
        [EmailAddress]
        public string Email { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }
        public string IconDisplay { get; set; }


        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public static implicit operator DonationViewModel(DonationShared d)
        {
            return new DonationViewModel
            {

                Title = d.Title, 
                Email = d.Email,
                Description = d.Description,
                PhoneNumber = d.PhoneNumber,
                CategoryId = d.CategoryId,
                From =d.From,
                To = d.To
            };
        }
    }
}
