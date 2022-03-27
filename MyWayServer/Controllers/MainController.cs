using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWayServerBL.Models;
using Microsoft.EntityFrameworkCore;

namespace MyWayServer.Controllers
{
    [Route("mywayAPI")]
    [ApiController]
    public class MainController : ControllerBase
    {
        MyWayContext context;

        public MainController(MyWayContext context)
        {
            this.context = context;
        }

        [Route("SignUp")]
        [HttpPost]
        public Client SignUp([FromBody] Client client)
        {
            //Check user name and password
            if (client != null)
            {
                this.context.SignUp(client.ClientsEmail,client.ClientsPassword,client.ClientName,client.ClientsLastName,client.ClientsUsername,client.ClientsGenedr,client.ClientsBirthDay, client.ClientCurrentLocation,client.ClientCreditCardNumber,client.ClientCreditCardDate,(int)client.ClientCreditCardCvv);
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


        [Route("LoginM")]
        [HttpGet]
        public Manager Loginm([FromQuery] string email, [FromQuery] string pass)
        {
            Manager client = context.Loginm(email, pass);

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



        [Route("GetClients")]
        [HttpGet]
        public List<Client> GetUsers()
        {
            List<Client> list = context.Clients.ToList();

            return list;
        }



        [Route("UpdateUser")]
        [HttpPost]
        public Client UpdateUser([FromBody] Client user)
        {
            //If user is null the request is bad
            if (user == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }

            Client currentUser = HttpContext.Session.GetObject<Client>("theUser");
            //Check if user logged in and its ID is the same as the contact user ID
            if (currentUser != null && currentUser.ClientId == user.ClientId)
            {
                Client updatedUser = context.UpdateUser(currentUser, user);

                if (updatedUser == null)
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return null;
                }

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return updatedUser;

                ////Now check if an image exist for the contact (photo). If not, set the default image!
                //var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", DEFAULT_PHOTO);
                //var targetPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{user.Id}.jpg");
                //System.IO.File.Copy(sourcePath, targetPath);

                //return the contact with its new ID if that was a new contact
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }


    }
}
