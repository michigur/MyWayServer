using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyWayServerBL.Models
{
    public partial class MyWayDBContext: DbContext
    {
        public Client Login(string email, string pswd)
        {
            Client client = this.Clients
                .Where(u => u.ClientsEmail == email && u.ClientsPassword == pswd).FirstOrDefault();

            return client;
        }

    }
}
