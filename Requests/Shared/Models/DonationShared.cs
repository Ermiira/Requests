using System;
using System.Collections.Generic;

namespace Requests.Shared.Models
{
    public partial class DonationShared
    {
    
        public int DonationId { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

    }
}
