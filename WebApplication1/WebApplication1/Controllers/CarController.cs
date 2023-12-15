using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarController : Controller
    {
        private IConfiguration _configuration;
        private SqlConnection con;

        public CarController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

          [HttpGet]
            [Route("GetCars")]
            public JsonResult GetCars()
            {
                string query = "select * from dbo.Car";
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
        [Route("UpdateCar/WithID")]
        public JsonResult UpdateCar(int carId, [FromBody] Car updatedCar)
        {
            string query = "UPDATE dbo.Car SET CarName = @CarName /*, other fields */ WHERE CarId = @CarId";
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");

            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@CarId", carId);
                    myCommand.Parameters.AddWithValue("@CarName", updatedCar.CarName);
                    // Add other parameters here

                    int rowsAffected = myCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult("Car Updated Successfully!");
                    }
                    else
                    {
                        return new JsonResult("No Car Found with the given ID.");
                    }
                }
            }
        }

        [HttpPost]
        [Route("AddCar")]
        public JsonResult AddCar([FromBody] Car car)
        {
            string query = "INSERT INTO dbo.Car (CarName) VALUES (@CarName)";
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");

            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@CarName", car.CarName);

                    int rowsAffected = myCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return new JsonResult("Car Added Successfully!");
                    }
                    else
                    {
                        return new JsonResult("Failed to Add Car.");
                    }
                }
            }
        }

            [HttpDelete]
            [Route("DeleteCar")]
            
            public JsonResult DeleteCar(int CarId)
            {
                string query = "delete from dbo.Car where CarId=@CarId";
                DataTable table = new DataTable();
                string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");
                SqlDataReader myReader;
                using (SqlConnection myConn = new SqlConnection(sqlDatasource))
                {
                    myConn.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myConn))
                    {
                        myCommand.Parameters.AddWithValue("@CarId", CarId);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myConn.Close();
                    }
                }
                return new JsonResult("Car Deleted!");
            }


        
    }
}
