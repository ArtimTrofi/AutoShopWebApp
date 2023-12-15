using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OwnerController : Controller
    {

        /*public HttpResponseMessage Get()
        {

        }*/

        private IConfiguration _configuration;
        public OwnerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetOwner")]
        public JsonResult GetOwner()
        {
            string query = "select * from dbo.Owner";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPut]
        [Route("UpdateOwner/WithID")]
        public JsonResult UpdateOwner(int ownerId, [FromBody] Owner updatedOwner)
        {
            string query = "UPDATE dbo.Owner SET OwnerName = @OwnerName, Car = @Car, DateOfPurchase = @DateOfPurchase WHERE OwnerId = @OwnerId";
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");

            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@OwnerId", ownerId);
                    myCommand.Parameters.AddWithValue("@OwnerName", updatedOwner.OwnerName);
                    myCommand.Parameters.AddWithValue("@Car", updatedOwner.Car);
                    myCommand.Parameters.AddWithValue("@DateOfPurchase", updatedOwner.DateOfPurchase);

                    int rowsAffected = myCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult("Owner Updated Successfully!");
                    }
                    else
                    {
                        return new JsonResult("No Owner Found with the given ID.");
                    }
                }
            }
        }

        [HttpPost]
        [Route("AddOwner")]
        public JsonResult AddOwner([FromBody] Owner newOwner)
        {
            string query = "INSERT INTO dbo.Owner (OwnerName, Car, DateOfPurchase) VALUES (@OwnerName, @Car, @DateOfPurchase)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@OwnerName", newOwner.OwnerName);
                    myCommand.Parameters.AddWithValue("@Car", newOwner.Car);
                    myCommand.Parameters.AddWithValue("@DateOfPurchase", newOwner.DateOfPurchase);

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        table.Load(myReader);
                    }
                }
            }
            return new JsonResult("Owner Added!");
        }

        [HttpDelete]
        [Route("DeleteOwner")]
        public JsonResult DeleteOwner(int ownerId)
        {
            string query = "DELETE FROM dbo.Owner WHERE OwnerId = @OwnerId";
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");

            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@OwnerId", ownerId);

                    // ExecuteNonQuery is more appropriate for a DELETE operation
                    int rowsAffected = myCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult("Owner Deleted!");
                    }
                    else
                    {
                        return new JsonResult("No Owner Found with the given ID.");
                    }
                }
            }
        }

        [HttpGet]
        [Route("Owner/GetAllCarNames")]
        public JsonResult GetAllCarNames()
        {
            string query = "SELECT CarName FROM dbo.Car";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");

            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        table.Load(myReader);
                    }
                }
            }

            return new JsonResult(table);
        }



    }
}
