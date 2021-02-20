using System;
using System.Collections.Generic;

namespace Requests.Server.Data
{
    public partial class Category
    {
        public Category()
        {
            Donation = new HashSet<Donation>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<Donation> Donation { get; set; }
    }
}
