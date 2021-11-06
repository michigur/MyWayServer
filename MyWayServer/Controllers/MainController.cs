using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWayServerBL.Models;

namespace MyWayServer.Controllers
{
    [Route("mywayAPI")]
    [ApiController]
    public class MainController : ControllerBase
    {
        MyWayDBContext context;

        public MainController(MyWayDBContext context)
        {
            this.context = context;
        }

        [Route("SignUp")]
        [HttpPost]
        public Client AdultSignUp([FromBody] Client client)
        {
            //Check user name and password
            if (client != null)
            {
                this.context.SignUp(client.ClientsEmail,client.ClientsPassword,client.ClientName,client.ClientsLastName,client.ClientsUsername,client.ClientsGenedr,client.ClientsBirthDay);
                HttpContext.Session.SetObject("theUser", client);
                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return client;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
 
        [Route("Login")]
        [HttpGet]
        public Client Login([FromQuery] string email, [FromQuery] string pass)
        {
            Client client = context.Login(email, pass);

            //Check user name and password
            if (client != null)
            {
                HttpContext.Session.SetObject("theUser", client);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!
                return client;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

    }
}
