﻿using System;
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

        public Client SignUp(string email, string pswd, string fName, string lName, string uName, string gender, DateTime bday)
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
                
            };
            return user;
        }
    }
}