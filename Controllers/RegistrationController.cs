using JWT_AUTH_DOT_NET.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace JWT_AUTH_DOT_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("connect_it").ToString());
            SqlCommand cmd=new SqlCommand("INSERT INTO REGISTRATION(UserName,Password,Email,IsActive) values('"+registration.UserName+ "','"+registration.password+ "','"+registration.Email+ "','"+registration.IsActive+"')",con);
            con.Open();
            int i =cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return "Data entered";

            }
            else
            {
                return "Error";
            }

                


        }
        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("connect_it").ToString());
            SqlDataAdapter da=new SqlDataAdapter("Select * from registration where email='"+registration.Email+"' and password= '"+registration.password+"' and IsActive=1",con);
            DataTable dt=new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return "Data Found";
            }
            else
            {
                return "Invalid user";
            }
        }
    }
}
