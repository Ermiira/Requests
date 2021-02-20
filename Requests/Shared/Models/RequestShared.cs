using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Requests.Shared.Models
{
    public partial class RequestShared
    {
        [Required]
        public int RequestId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required] 
        public string Description { get; set; }
        public string UserId { get; set; } 
        
        [Required]
        public int CityId { get; set; }
        
        [Required] 
        public string Address { get; set; }

        [Required] 
        public int? PostalCode { get; set; }

        [Required] 
        public string PhoneNumber { get; set; }

        [Required] 
        [EmailAddress]
        public string Email { get; set; }
        
        public string IconDisplay { get; set; }
        public bool? Approved { get; set; }
        public bool? Active { get; set; }
         
     }
}
