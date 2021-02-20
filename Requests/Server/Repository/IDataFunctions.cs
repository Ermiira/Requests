using Requests.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Server.Repository
{
    interface IDataFunctions
    {
        public Request GetRequests(int id);
    }
}
