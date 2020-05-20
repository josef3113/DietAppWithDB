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
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> GetAllProducts()
        {
            return DBService.GetAllProducts();
        }

        [Route("api/products/{i_ProductIdToSearch:int}")]
        public Product GetProductById(int i_ProductIdToSearch)
        {
            return DBService.GetProductByID(i_ProductIdToSearch);
        }

        [Route("api/products/{i_ProductNameToSearch:alpha}")]
        public Product GetProductByName(string i_ProductNameToSearch)
        {
            return DBService.GetProductByName(i_ProductNameToSearch);
        }

        [Route("api/products/NotBelongToUser/{i_UserId:int}")]
        public IEnumerable<Product> GetProductsNotBelongToUser(int i_UserId, string i_WordToSearch = "")
        {
            return DBService.GetProductsNotBelongToUser(i_UserId, i_WordToSearch);
        }

        [Route("api/products/BelongToUser/{i_UserId:int}")]
        public IEnumerable<Product> GetProductsBelongToUser(int i_UserId, string i_WordToSearch = "")
        {
            return DBService.GetProductsBelongToUser(i_UserId, i_WordToSearch);
        }

        [HttpPost]
        [Route("api/products/BelongProductsToUser/{i_UserId:int}")]
        public void BelongProductsToUser(int i_UserId, [FromBody] List<int> i_ListIdsOfProducts)
        {
            DBService.BelongProductsToUser(i_UserId, i_ListIdsOfProducts);
        }

        public void PostProduct([FromBody] Product i_ProductToPost)
        {
            DBService.InsertProduct(i_ProductToPost);
        }
    }
}
