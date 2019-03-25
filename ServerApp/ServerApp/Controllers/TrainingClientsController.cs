using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingClientsController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Проверка записи на тренировку
        /// </summary>
        /// <param name="userId">id пользователя</param>
        /// <param name="trainingId">id тренировки</param>
        /// <returns>истина-ложь: записан/не записан</returns>
        [HttpGet]
        [Route("checkWriting")]
        public async Task<IActionResult> Get([FromQuery(Name = "userId")] string userId, [FromQuery(Name = "trainingId")] string trainingId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var result = await _unitOfWork.TrainingClients.FindAsync(tc =>
                tc.ClientId == int.Parse(userId) && tc.TrainingId == int.Parse(trainingId));
            if (result == null)
            {
                return Ok(false);
            }
            return Ok(true);
        }

        // GET: api/TrainingClients
        [HttpGet]
        public async Task<IEnumerable<TrainingClient>>  GetTrainingClients()
        {
            return await _unitOfWork.TrainingClients.GetAllAsync();
        }

        // GET: api/TrainingClients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainingClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainingClient = await _unitOfWork.TrainingClients.GetAsync(id);

            if (trainingClient == null)
            {
                return NotFound();
            }

            return Ok(trainingClient);
        }

        // PUT: api/TrainingClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainingClient([FromRoute] int id, [FromBody] TrainingClient trainingClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainingClient.TrainingId)
            {
                return BadRequest();
            }

            //_context.Entry(trainingClient).State = EntityState.Modified;

            try
            {
                await _unitOfWork.TrainingClients.UpdateAsync(trainingClient);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await TrainingClientExists(id)))
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

        // POST: api/TrainingClients
        [HttpPost]
        public async Task<IActionResult> PostTrainingClient([FromBody] TrainingClient trainingClient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.TrainingClients.AddAsync(trainingClient);
           

            return CreatedAtAction("GetTrainingClient", new { id = trainingClient.TrainingId }, trainingClient);
        }

        // DELETE: api/TrainingClients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainingClient([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainingClient = await _unitOfWork.TrainingClients.GetAsync(id);
            if (trainingClient == null)
            {
                return NotFound();
            }

            await _unitOfWork.TrainingClients.RemoveAsync(trainingClient);


            return Ok(trainingClient);
        }

        private async Task<bool> TrainingClientExists(int id)
        {
            return await _unitOfWork.TrainingClients.FindAsync(e => e.TrainingId == id) != null;
        }
    }
}