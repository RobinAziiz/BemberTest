using BemberTest.Models;
using BemberTest.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BemberTest.Controllers
{


    [Route("api/Anstalld")]
    [ApiController]
    public class AnstalldController : ControllerBase
    {
        private readonly IAnstalldDapperRepository _repository;

        public AnstalldController(IAnstalldDapperRepository repository, ILogger<AnstalldController> logger)
        {
            _repository = repository;  
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var anstalld = await _repository.GetAllAsync();

            return Ok(anstalld);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnstalldAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);

            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var anstalld = await _repository.GetByIdAsync(id);

            if (anstalld == null)
            {
                return NotFound();
            }

            return Ok(anstalld);
        }


        [HttpPost]
        public async Task<IActionResult> AddAnstalldAsync([FromBody] AnstalldDto anstalld)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            Anstalld newAnstalld = new Anstalld()
            {
                AnstalldNamn = anstalld.AnstalldNamn,
                Foretag = anstalld.Foretag,
            }; 

            int newId = await _repository.AddAsync(newAnstalld);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newId }, anstalld);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnstalld(int id, [FromBody] Anstalld updatedAnstalld)
        {
            if (id != updatedAnstalld.AnstalldId)
            {
                return BadRequest();
            }

            bool success = await _repository.UpdateAsync(updatedAnstalld);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }


    }

}
