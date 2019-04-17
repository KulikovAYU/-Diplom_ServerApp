using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationTestCore;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public DefaultController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //http://localhost:56073/api/Default/Send?message="Мое тестовое сообщение"
        [HttpGet]
        [Route("Send")]
        public ActionResult<IEnumerable<string>> Send([FromQuery]string message)
        {
            
            new TestSendToken(_unitOfWork).Send(message);
            return new string[] { "notification been send"};
        }

    }
}