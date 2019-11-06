using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPool.WS.Users.Models
{
    public class ParamsForBody
    {
        public int id { set; get; }
        public string uname { set; get; }
        public string pswrd { set; get; }
        //public IEnumerable<BRANCH> branches { set; get; }
        //public IEnumerable<Routing> routes { set; get; }
        //public IEnumerable<PoolerDeparture> poolerDep { set; get; }
    }
}