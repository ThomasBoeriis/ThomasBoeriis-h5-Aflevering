using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdministrationsPanel.Controllers
{
    public class EventController : ApiController
    {
        public Event.Models.EventSystemContext _db = new Event.Models.EventSystemContext();

        public List<Event.Models.Events> GetAll()
        {
            
            var data = _db.Events.ToList();

            return data;

        }
    }
}
