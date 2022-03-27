using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyWayServerBL.Models;

namespace MyWayServerBL.Models
{
    public partial class MyWayContext: DbContext 
    {
        public Client Login(string email, string pswd)
        {
            try
            {
                Client client = this.Clients
                    .Where(u => u.ClientsEmail == email && u.ClientsPassword == pswd).FirstOrDefault();

                return client;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;


            }
        }

        public Manager Loginm(string email, string pswd)
        {
            try
            {
                Manager client = this.Managers
                    .Where(u => u.ManagerEmail == email && u.ManagerPassword == pswd).FirstOrDefault();

                return client;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;


            }
        }



        public Client UpdateUser(Client user, Client updatedUser)
        {
            try
            {
                Client currentUser = this.Clients
                .Where(u => u.ClientId == user.ClientId).FirstOrDefault();

                currentUser.ClientName = updatedUser.ClientName;
                currentUser.ClientsLastName = updatedUser.ClientsLastName;
                currentUser.ClientsPassword = updatedUser.ClientsPassword;
                currentUser.ClientsBirthDay = updatedUser.ClientsBirthDay;
                currentUser.ClientsGenedr = updatedUser.ClientsGenedr;

                this.SaveChanges();
                return currentUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }





        public Client SignUp(string email, string pswd, string fName, string lName, string uName, string gender, DateTime bday, string addres, string cardnum, DateTime cardate, int cvv)
        {
            Client user = new Client()
            {
                ClientsUsername = uName,
                ClientName = fName,
                ClientsLastName = lName,
                ClientsGenedr = gender,
                ClientsEmail = email,
                ClientsPassword = pswd,
                ClientsBirthDay = bday,
                ClientCurrentLocation = addres,
                ClientCreditCardCvv = cvv,
                ClientCreditCardDate = cardate,
                ClientCreditCardNumber = cardnum
                
            };
            return user;
        }
    }
}
