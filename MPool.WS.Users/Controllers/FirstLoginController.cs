using System;
//using System.Data.EntityState;
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
    public class FirstLoginController : ApiController
    {
        
        private MPOOL_HackathonEntities MpoolData = new MPOOL_HackathonEntities();
        [Route("api/FirstLogin/BranchesLoad")]
        [HttpGet]
        public Response BranchesLoad()
        {
            var branches = MpoolData.BRANCHES.ToList<BRANCH>();
            Response res = new Response();
            if(branches is null || branches.Count() <= 0)
            {
                PrepareResponseBranches("400", "User not Found", branches, res);
            }
            else
            {
                PrepareResponseBranches("200", "Success", branches, res);
            }
            return res;
            
        }
        [Route("api/FirstLogin/GetRouting")]
        [HttpGet]
        public Response GetRouting(int id )
        {
            var routes = from r in MpoolData.Routings where r.BranchId == id select r;
            Response res = new Response();
            if (routes is null || routes.Count() <= 0)
            {
                PrepareResponseRoutes("400", "User not Found", routes, res);
            }
            else
            {
                PrepareResponseRoutes("200", "Success", routes, res);
            }
            return res;
        }
        [Route("api/FirstLogin/UpdateUser")]
        [HttpPost]
        public bool UpdateUserForFirst(string BranchId, int RoutingID, string PoolerStatus, int userid, bool firstLogin, string wheeler, int SeatsAvailability)
        {           
            if (firstLogin == false)
            {
                USER UpdateUser = (from c in MpoolData.USERS
                                   where c.ID == userid
                                   select c).FirstOrDefault();
                UpdateUser.BranchCode = BranchId;
                UpdateUser.RoutingId = RoutingID;
                UpdateUser.Pooler_Passanger = PoolerStatus;
                MpoolData.SaveChanges();
                if (PoolerStatus == "Pooler")
                {
                    AddUserVehicleInfo(userid, wheeler, SeatsAvailability, RoutingID.ToString(), new VEHICLE_INFO());                    
                    UpdateUser.FirstLogin = true;
                    MpoolData.SaveChanges();
                    return true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public IHttpActionResult AddUserVehicleInfo(int userid, string wheeler, int SeatsAvailability, string RoutingID, VEHICLE_INFO vehiInfo)
        {
            MpoolData.VEHICLE_INFO.Add(new VEHICLE_INFO()
            {
                UserId = userid,
                IsPooler = true,
                Wheeler = wheeler,
                SeatsAvailability = SeatsAvailability,
                RouteID = RoutingID
            });
            MpoolData.SaveChanges();
            return Ok();
        }
        public static Response PrepareResponseBranches(string stat, string Msg, IEnumerable<BRANCH> branches, Response res)
        {
            res.Status = stat;
            res.Message = Msg;
            res.branches = branches;
            return res;
        }
        public static Response PrepareResponseRoutes(string stat, string Msg, IEnumerable<Routing> routes, Response res)
        {
            res.Status = stat;
            res.Message = Msg;
            res.routes = routes;
            return res;
        }

        //private IHttpActionResult Ok()
        //{
        //    try
        //    {

        //    }
        //    catch(Exception ex)
        //    {
        //        throw new NotImplementedException(ex.Message);
        //    }

        //}
    }
}
