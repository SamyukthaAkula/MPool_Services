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


//using RouteAttribute = System.Web.Http.RouteAttribute;
//using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;
//using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace MPool.WS.Users.Controllers
{
    //[Authorize]
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class UserLoginController : ApiController
    {
        public static  MPOOL_HackathonEntities MpoolData = new MPOOL_HackathonEntities();
        // GET api/UserLogin
        [Route("api/UserLogin/PostmanTest")]
        [HttpPost]
        public string PostmanTest(LOGIN logins)
        {
            return "Samyuktha first API call";
        }
        // GET api/GetEmployees
        [Route("api/GetEmployees")]
        [HttpPost]
        public IEnumerable<LOGIN> GetEmployees()
        {
            return MpoolData.LOGINS.ToList<LOGIN>();
        }
        // GET api/UserLogin/GetLogin
        [Route("api/UserLogin/GetEmployeeWithID")]
        [HttpGet]
        public IEnumerable<LOGIN> GetEmployeeWithID(int id)
        {
            var users = from l in MpoolData.LOGINS where l.UserId == id select l;
            return users;
        }

        [Route("api/UserLogin/LoginValidation")]
        [HttpPost]
        public Response LoginValidation(string uname, string pswrd)
        {
            var user = from l1 in MpoolData.LOGINS where l1.UserName == uname && l1.UserPassword == pswrd select l1;
            Response res = new Response();
            //string finalres = null;
            if (user is null || user.Count() <= 0)
            {
                PrepareResponse("400", "User not Found", user, res);
               // finalres = JsonConvert.SerializeObject(res);
            }
            else
            {
               PrepareResponse("200", "Success", user, res);
            }
            return res;
        }
        public static Response PrepareResponse(string stat, string Msg, IEnumerable<LOGIN> user,  Response res)
        {
            res.Status = stat;
            res.Message = Msg;
            res.data = user;
            return res;
        }
    }
}