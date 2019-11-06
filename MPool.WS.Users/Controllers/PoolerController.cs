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
    [EnableCors(origins: "http://localhost:8085", headers: "*", methods: "*")]
    public class PoolerController : ApiController
    {
        public static MPOOL_HackathonEntities MpoolData = new MPOOL_HackathonEntities();
        [Route("api/Pooler/UpdateUser")]
        [HttpPost]
        public bool DeparturePooler(string fName, string lName, int Userid, int RoutingId, DateTime startTime, int SeatsAvailability)
        {
            try
            {
                string Name = fName + lName;
                PoolerInfoInsertion(Name, Userid, RoutingId, startTime, SeatsAvailability, new PoolerDeparture());
                MpoolData.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           
        }
        public IHttpActionResult PoolerInfoInsertion(string Name,int Userid, int RoutingId, DateTime startTime, int SeatsAvailability, PoolerDeparture poolerDep)
        {
            MpoolData.PoolerDepartures.Add(new PoolerDeparture()
            {
               UserId = Userid,
               Name = Name,
               RoutingID = RoutingId,
               SeatsAvailable = SeatsAvailability,
               TimeOfDeparture = startTime
            });
            MpoolData.SaveChanges();
            return Ok();
        }

    }
}
