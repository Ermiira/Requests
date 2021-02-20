using Requests.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requests.Server.Repository
{
    public class DataFunctions : IDataFunctions
    {
         private readonly RequestsContext _db;

        public DataFunctions(RequestsContext db)
        {
            _db = db;
        }
        public Request GetRequests(int id)
        {
            var request = _db.Request.Where(e => e.RequestId == id).FirstOrDefault();
            return request;
        }
    }
}
