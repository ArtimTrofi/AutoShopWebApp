/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtimAppController : ControllerBase
    {
        private IConfiguration _configuration;
        public ArtimAppController(IConfiguration configuration)
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
            using(SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using(SqlCommand myCommand = new SqlCommand(query,myConn))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult(table);
        }


        [HttpPost]
        [Route("AddCar")]
        public JsonResult AddCar([FromForm] string newCar)
        {
            string query = "insert into dbo.Car values(@newCar)";
            DataTable table = new DataTable();
            string sqlDatasource = _configuration.GetConnectionString("artimAppDBCon");
            SqlDataReader myReader;
            using (SqlConnection myConn = new SqlConnection(sqlDatasource))
            {
                myConn.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myConn))
                {
                    myCommand.Parameters.AddWithValue("@newCar", newCar);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myConn.Close();
                }
            }
            return new JsonResult("Car Added!");
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
}*/
