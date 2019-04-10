using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities;
using FC_EMDB.Entities.Entities;
using JsonConverters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }


        [Route("client")]
        [HttpPost]
        public async Task<ActionResult<Client>> Login([FromBody]LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = await _unitOfWork.Clients.FindAsync(clnt =>
                  clnt.AbonementNumber == int.Parse(model.AbonementNumber) && 
                  clnt.PasswordHash.Equals(model.PasswordHash));

                if (client != null)
                {
                    await AuthenticateClient(client); // аутентификация
                    return Ok(await client.ToJSONAsync(_unitOfWork));
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return NotFound();
        }

        private async Task AuthenticateClient(Client client)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType,client.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,"Client")
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        // GET: api/Account
        [HttpGet]
        public async Task<LoginModel> Get()
        {
            return  new LoginModel{ AbonementNumber = "123", PasswordHash = "233"};
        }

        // GET: api/Account/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Account
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Account/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
