using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;
using JsonConverters;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        // GET: api/Clients
        [HttpGet]
        public IEnumerable<Client> GetClients()
        {
            return _unitOfWork.Clients.GetAll();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _unitOfWork.Clients.GetAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(await client.ToJSONAsync(_unitOfWork));
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient([FromRoute] int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await _unitOfWork.Clients.UpdateAsync(client);
            }
            catch (DbUpdateConcurrencyException)
            {
                bool bIsExist = await ClientExists(id);
                if (bIsExist)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clients
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.Clients.AddAsync(client);

            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var client = await _unitOfWork.Clients.GetAsync(id);
            if (client == null)
            {
                return NotFound();
            }

           
            await _unitOfWork.Clients.RemoveAsync(client);

            return Ok(client);
        }

        private async Task<bool> ClientExists(int id)
        {
            return await _unitOfWork.Clients.FindAsync(client => client.Id == id) != null;
        }
    }
}