using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static List<Message> MessageListDB = new List<Message>();
        //// GET message/values

        [HttpGet]
        [Route("{From}/{To}")]
        public ActionResult<List<Message>> Get(string From, string To)
        {
            var tempListMessage = new List<Message>();
            foreach (var item in MessageListDB)
            {
                if ((From == item.From && To == item.To) || (From == item.To && To == item.From))
                {
                    tempListMessage.Add(item);
                }
            }
            return tempListMessage;
        }

        [HttpGet]
        public ActionResult<List<Message>> Get()
        {
            return MessageListDB;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Message value)
        {
            MessageListDB.Add(value);
        }

        [HttpDelete]
        public void Delete()
        {
            MessageListDB.Clear();
        }
    }
}