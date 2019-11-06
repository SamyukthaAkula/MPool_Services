using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using MPool.WS.Users.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Microsoft.Owin.Host.SystemWeb;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace MPool.WS.Users.Controllers
{
    [EnableCors(origins: "http://localhost:3000/", headers: "*", methods: "*")]
    public class PassengerController : ApiController
    {
        public static MPOOL_HackathonEntities MpoolData = new MPOOL_HackathonEntities();
        public Response GetPooler(int PassengerRoute)
        {
            var pooler = from p in MpoolData.PoolerDepartures where p.RoutingID == PassengerRoute select p;
            Response res = new Response();
            if (pooler is null || pooler.Count() <= 0)
            {
                PrepareResponsePoolerData("400", "User not Found", pooler, res);
            }
            else
            {
                PrepareResponsePoolerData("200", "Success", pooler, res);
            }
            return res;
        }
        public static Response PrepareResponsePoolerData(string stat, string Msg, IEnumerable<PoolerDeparture> pooler, Response res)
        {
            res.Status = stat;
            res.Message = Msg;
            res.poolerDep = pooler;
            return res;
        }
    }

}
