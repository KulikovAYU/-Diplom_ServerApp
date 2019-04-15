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

                    //найдем все записи, связанные с id клиента
                    var records = await _unitOfWork.ClientsFcmInfos.FindAllAsync(_cli=>_cli.ClientId.Equals(client.Id));

                    if (records != null) //если есть записи
                    {
                        //теперь поищем, нет ли похожего токена в таблице
                        FcmInfo Fcmrecords = null;

                        foreach (var rec in records)
                        {
                            Fcmrecords = await _unitOfWork.FcmInfos.GetAsync(rec.FcmInfoId);
                            if (Fcmrecords != null)
                            {
                                break;
                            }
                        }
                        //если записи в таблице нет, создаем
                        if (Fcmrecords == null)
                        {
                            var info = await _unitOfWork.FcmInfos.AddAsync(new FcmInfo
                                { FcmToken = model.FcmToken, RegistrationDateTime = DateTime.Now });
                            //2. связываем отношением многие ко многим
                            await _unitOfWork.ClientsFcmInfos.AddAsync(new ClientsFcmInfo { ClientId = client.Id, FcmInfoId = info.Id });
                        }
                        else
                        {
                            Fcmrecords.RegistrationDateTime = DateTime.Now;
                            //иначе просто обновим
                            await _unitOfWork.FcmInfos.UpdateAsync(Fcmrecords);
                        }
                    }
                    else //иначе добавим запись
                    {
                        //1.создаем запись в FcmInfo
                        var info = await _unitOfWork.FcmInfos.AddAsync(new FcmInfo
                            { FcmToken = model.FcmToken, RegistrationDateTime = DateTime.Now });
                        //2. связываем отношением многие ко многим
                        await _unitOfWork.ClientsFcmInfos.AddAsync(new ClientsFcmInfo { ClientId = client.Id, FcmInfoId = info.Id });
                    }

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
