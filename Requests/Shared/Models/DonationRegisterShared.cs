using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Requests.Shared.Models
{
    public partial class DonationRegisterShared
    {
    
        public int DonationId { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        
        [Required]
        public string Title { get; set; }
        
        [Required] 
        public string Description { get; set; }
        
        public string Email { get; set; }
        
        [Required] 
        public string PhoneNumber { get; set; }
  
    }
}
