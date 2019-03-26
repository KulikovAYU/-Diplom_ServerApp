using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;
using JsonConverters;
using Microsoft.AspNetCore.Routing;

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

        /// <summary>
        /// Создать предварительную регистрацию на тренировку
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <param name="trainingId">Id тренировки</param>
        /// <param name="date">Дата начала тренировки</param>
        /// <returns>измененная тренировка</returns>
        [HttpGet]
        [Route("createregistrationtraining")]
        public async Task<IActionResult> Get([FromQuery(Name = "userId")] string userId,
            [FromQuery(Name = "trainingId")] string trainingId, [FromQuery(Name = "date")] DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //впринципе проверку можно и не делать , но сделаем
            var result = await _unitOfWork.TrainingClients.FindAsync(tc =>
                tc.ClientId == int.Parse(userId) && tc.TrainingId == int.Parse(trainingId));

           

            //если нет трени в записи
            if (result == null)
            {
                Training trID = await _unitOfWork.Trainings.FindAsync(tr =>
                    tr.Id == int.Parse(trainingId) && tr.StartTime == date);

                if (trID == null)
                {
                    StatusCode((int) HttpStatusCode.Conflict);
                }


              var record = await _unitOfWork.TrainingClients.AddAsync(new TrainingClient()
                    {ClientId = int.Parse(userId), TrainingId = trID?.Id});

                //теперь возьмем тренировку и сократим кол-во свободных и увеличим кол-во занятых мест

                if (record.TrainingId == null)
                    return NotFound();

                var training = await _unitOfWork.Trainings.GetAsync((int) record.TrainingId);

                training.BusyPlacesCount += 1;//увеличим кол-во мест

                var newTraining = await _unitOfWork.Trainings.UpdateAsync(training);

                if (newTraining == null)
                {
                    return NotFound();
                }



                return Ok(await newTraining.ToJSONAsync(_unitOfWork));
            }
            //м.б.потом реализовать здесь же отмену записи

            return StatusCode((int) HttpStatusCode.Conflict);

          

            //иначе найдем тренировку в расписании


            
         
                    //
            return Ok();
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