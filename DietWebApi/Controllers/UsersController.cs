using DapperHelperDB;
using DapperHelperDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DietWebApi.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<User> GetAllUsers()
        {
            return DBService.GetAllUsers();
        }

        [Route("api/users/{i_UserName:alpha}")]
        public User GetUserByName(string i_UserName)
        {
            return DBService.GetUserByName(i_UserName);
        }

        public void PostUser(User i_UserToPost)
        {
            DBService.InsertUser(i_UserToPost);
        }
    }
}
