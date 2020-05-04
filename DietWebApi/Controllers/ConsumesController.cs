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
    public class ConsumeController : ApiController
    {
        // need to add date time from user
        [HttpGet]
        [Route("api/consume/atDate/{i_UserId:int}")]
        public SummaryConsume GetSummaryConsumeByUserAtDate(int i_UserId)
        {
            return DBService.GetSummaryConsumeByUserAtDate(i_UserId, DateTime.Now);
        }

        [HttpPost]
        [Route("api/consume/{i_UserConsume:int}")]
        public void PostConsumeProductsByUser(int i_UserConsume, List<int> i_ListIdsOfProductsConsume)
        {
            DBService.ConsumeProductsByUser(i_UserConsume, i_ListIdsOfProductsConsume);
        }
    }
}
