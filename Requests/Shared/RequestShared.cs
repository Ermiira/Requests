using System;
using System.Collections.Generic;
using System.Text;

namespace Requests.Shared
{
    class RequestShared
    {
        public RequestShared()
        {

        }

        public int RequestId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public int? DonationId { get; set; }
        public int CityId { get; set; }
        public int SettlementId { get; set; }
        public string Address { get; set; }
        public int? PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool? Approved { get; set; }
        public bool? Active { get; set; }
    }
}
