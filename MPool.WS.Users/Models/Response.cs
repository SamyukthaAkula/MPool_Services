using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPool.WS.Users.Models
{
    public class Response
    {
        public string Status { set; get; }
        public string Message { set; get; }
        public IEnumerable<LOGIN> data { set; get; }
        public IEnumerable<BRANCH> branches { set; get; }
        public IEnumerable<Routing> routes { set; get; }
        public IEnumerable<PoolerDeparture> routes { set; get; }
    }
}