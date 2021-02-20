using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Client.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }

        public static implicit operator CategoryViewModel(CategoryShared donation)
        {
            return new CategoryViewModel
            {

                CategoryId = donation.CategoryId,
                CategoryName = donation.CategoryName,
                Icon = donation.Icon,

            };
        }

    }
}
