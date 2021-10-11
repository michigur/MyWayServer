using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWayServerBL.Models;

namespace MyWayServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        MyWayDBContext context;

        public MainController(MyWayDBContext context)
        {
            this.context = context;
        }




    }
}
