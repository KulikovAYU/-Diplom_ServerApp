using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FC_EMDB.Database.DbContext;
using FC_EMDB.Database.UnitOfWork;
using FC_EMDB.Entities.Entities;
using JsonConverters;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataBaseFcContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        /// <summary>
        /// Получить фотографию работника (тренера и др.)
        /// </summary>
        /// <param name="trainerId"></param>
        /// <returns>изображение тренера в формате jpg (можно и в bmp)</returns>
        [HttpGet]
        [Route("getPhoto/{trainerId}")]
        public async Task<ActionResult> Get(string trainerId)
        {
            int nTrId = Int16.Parse(trainerId);
            var employee = await _unitOfWork.Employees.GetAsync(nTrId);
            if (employee == null)
                return NotFound();

            return File(employee.Photo, "image/jpg");
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployees()
        {

            return _unitOfWork.Employees.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee([FromRoute] int id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        /// <summary>
        /// Получить информацию о тренере
        /// </summary>
        /// <param name="training">тренировка</param>
        /// <returns>Информация о работнике</returns>
        [HttpPut]
        public async Task<ActionResult<Employee>> PutEmployee([FromBody] Training training)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var coachTraining = await _unitOfWork.CoachesTrainings.FindAsync(tr => tr.TrainingId == training.Id);

            if (coachTraining == null)
            {
                return NotFound();
            }
            var employee = await _unitOfWork.Employees.GetAsync(coachTraining.CoachId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee.ToJSON());
        }



        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}