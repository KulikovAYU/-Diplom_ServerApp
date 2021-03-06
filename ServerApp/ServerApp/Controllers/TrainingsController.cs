﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;
using JsonConverters;
using JsonConverters.JSONEntities;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
    
        public TrainingsController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Получить список тренировок на выбранный день
        /// </summary>
        /// <param name="date">Выбранная дата</param>
        /// <returns>Список тренировок</returns>
        [HttpGet]
        [Route("gettrainingsList/{date}")]
        public async Task <ActionResult<IEnumerable<JSONTraining>>> Get(DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var list = await _unitOfWork.Trainings.FindAllAsync(time =>
                time.StartTime.Day == date.Day && time.StartTime.Year == date.Year &&
                time.StartTime.Month == date.Month);

            if (list == null)
                return NotFound();

            var trainingList = await list.ToJSONAsync(_unitOfWork);

            return Ok(trainingList);
        }

        /// <summary>
        /// Получить информацию о тренировке
        /// </summary>
        /// <param name="Id">id тренировки</param>
        /// <param name="date">дата начала тренировки</param>
        /// <returns>информацию о тренировке</returns>
        [HttpGet]
        [Route("gettraining",Name = "getTrainingInfo")]
        public async Task<IActionResult> Get([FromQuery(Name = "trainingId")][FromRoute] string Id, [FromQuery(Name = "trainingDate")][FromRoute] DateTime date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //получим ID тренировки в расписании
            var training =
                await _unitOfWork.Trainings.FindAsync(tr => tr.Id == int.Parse(Id) && tr.StartTime == date);

            if (training == null)
                return NotFound();

            var trainingJSON = await training.ToJSONAsync(_unitOfWork);

            if (trainingJSON == null)
                return NotFound();

            return Ok(trainingJSON);
        }

        // GET: api/TrainingsController_1
        [HttpGet]
        public IEnumerable<Training> GetTrainings()
        {
            return _unitOfWork.Trainings.GetAll();
        }

        // GET: api/TrainingsController_1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var training = await _unitOfWork.Trainings.GetAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        // PUT: api/TrainingsController_1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining([FromRoute] int id, [FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != training.Id)
            {
                return BadRequest();
            }

            //_context.Entry(training).State = EntityState.Modified;

            try
            {
                await _unitOfWork.Trainings.UpdateAsync(training);
               // await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await TrainingExists(id)))
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

        // POST: api/TrainingsController_1
        [HttpPost]
        public async Task<IActionResult> PostTraining([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // _context.Trainings.Add(training);
           // await _context.SaveChangesAsync();

            await _unitOfWork.Trainings.AddAsync(training);

            return CreatedAtAction("GetTraining", new { id = training.Id }, training);
        }

        // DELETE: api/TrainingsController_1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           // var training = await _context.Trainings.FindAsync(id);
            var training = await _unitOfWork.Trainings.GetAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            // _context.Trainings.Remove(training);
            await _unitOfWork.Trainings.RemoveAsync(training);

            return Ok(training);
        }

        private async Task<bool> TrainingExists(int id)
        {
            return await _unitOfWork.Trainings.FindAsync(e => e.Id == id) != null;
        }
    }
}