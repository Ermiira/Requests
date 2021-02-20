using Requests.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Requests.Client.ViewModels
{
    public class CityViewModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        
        public static implicit operator CityViewModel(CityShared city)
        {
            return new CityViewModel
            {
                 CityId = city.CityId,
                 Name = city.Name

            };
        }
    }
}
