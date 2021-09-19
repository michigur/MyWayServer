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
        MyWayDContext context;

        public MainController(MyWayDContext context)
        {
            this.context = context;
        }
    }
}
