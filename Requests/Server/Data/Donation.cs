using System;
using System.Collections.Generic;

namespace Requests.Server.Data
{
    public partial class Donation
    {
        public int DonationId { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? InsertedDate { get; set; }

        public virtual Category Category { get; set; }
    }
}
