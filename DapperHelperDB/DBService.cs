using Dapper;
using DapperHelperDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperHelperDB
{
    public static class DBService
    {

        public static void InsertUser(User i_UserToSign)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                connection.Execute("dbo.spTable_Users_InsertUser @Name,@Password", i_UserToSign);
            }
        }

        public static List<User> GetAllUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(getConnectionString()))
            {
                return connection.Query<User>("dbo.spTable_Users_GetAll").ToList();
            }
        }

        public static User GetUserByName(string i_UserName)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                return connection.QuerySingleOrDefault<User>("spTable_Users_Login @Name", new { Name = i_UserName });
            }
        }

        public static Product GetProductByName(string i_ProductName)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                return connection.QuerySingleOrDefault<Product>("spTable_Product_GetProductByName @Name", new { Name = i_ProductName });
            }
        }

        public static Product GetProductByID(int i_ProductID)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                return connection.QuerySingleOrDefault<Product>("spGetProductById @IdOfProduct", new { IdOfProduct = i_ProductID });
            }
        }

        public static bool BelongProductsToUser(int i_UserId, List<int> i_ListIdsOfProducts)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                foreach (int productID in i_ListIdsOfProducts)
                {
                    connection.Execute("dbo.spTable_ProductsOfUser_InsertProductToUser @UserId,@ProductId", new
                    {
                        UserId = i_UserId,
                        ProductId = productID
                    });
                }
                return true;
            }
        }

        public static bool InsertProduct(Product i_ProductToInsert)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                connection.Execute("dbo.spTable_Product_InsertProduct @Name,@Proteine,@Calories,@Fat", i_ProductToInsert);
                return true;
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(getConnectionString()))
            {
                return connection.Query<Product>("spTableProduct_GetProducts").ToList();
            }
        }

        public static List<Product> GetProductsNotBelongToUser(int i_UserId, string i_WordToSearch = "")
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(getConnectionString()))
            {
                return connection.Query<Product>("spGetProductsThatNotBelongToUserThatContainsWord @UserID, @WordSearch", new
                {
                    UserID = i_UserId,
                    WordSearch = i_WordToSearch
                }).ToList();
            }
        }

        public static List<Product> GetProductsBelongToUser(int i_UserId, string i_WordToSearch = "")
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(getConnectionString()))
            {
                return connection.Query<Product>(
                    "spGetProductsBelongToUser @UserId ,@WordSearch",
                    new
                    {
                        UserId = i_UserId,
                        WordSearch = i_WordToSearch
                    }).ToList();
            }
        }

        public static SummaryConsume GetSummaryConsumeByUserAtDate(int i_UserId, DateTime i_DateToConsume)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(getConnectionString()))
            {
                return connection.QuerySingleOrDefault<SummaryConsume>(
                    "spGetSummaryConsumByUserAndDate @UserId, @DateToSummary",
                    new
                    {
                        UserId = i_UserId,
                        DateToSummary = i_DateToConsume.ToString("yyyy-MM-dd")
                    });
            }
        }

        public static void ConsumeProductsByUser(int i_UserIdConsume, List<int> i_ListIdsOfProductsConsume)
        {
            using (IDbConnection connection = new SqlConnection(getConnectionString()))
            {
                foreach (int productIdConsume in i_ListIdsOfProductsConsume)
                {
                    connection.Execute("dbo.spTable_Consumptions_Consume @UserID,@ProductId",
                        new
                        {
                            UserID = i_UserIdConsume,
                            ProductID = productIdConsume
                        });

                }
            }
        }

        private static string getConnectionString()
        {
            SqlConnectionStringBuilder stringToConnection = new SqlConnectionStringBuilder();

            stringToConnection.DataSource = "LAPTOP-A76KD8QN";
            stringToConnection.InitialCatalog = "MyAppDB";
            stringToConnection.Encrypt = true;
            stringToConnection.TrustServerCertificate = true;
            stringToConnection.ConnectTimeout = 30;
            stringToConnection.AsynchronousProcessing = true;
            stringToConnection.MultipleActiveResultSets = true;
            stringToConnection.IntegratedSecurity = true;

            return stringToConnection.ToString();

        }

    }
}