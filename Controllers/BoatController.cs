using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnorishBoatProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        IBoatActivities boatActivities;

        public BoatController(IBoatActivities _boatActivities)
        {
            boatActivities = _boatActivities;
        }

        [HttpPost]
        [Route("RegisterBoat")]
        public Guid RegisterBoat(string boatName, Int32 hourlyRate)
        {

            return boatActivities.RegisterBoat(boatName, hourlyRate);
        }

        [HttpPost]
        [Route("BookBoat")]
        public bool BookBoat(Guid boatNumber, string customerName)
        {
            return boatActivities.BookBoat(boatNumber, customerName);
        }
    }
}
