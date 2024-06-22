using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ManagersController : BaseApiController
    {
        private readonly AppDbContext _context;

        public ManagersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manager>>> GetManagers()
        {
            return await _context.Managers.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetManager")]
        public async Task<ActionResult<Manager>> GetManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null)
            {
                return NotFound();
            }

            return manager;
        }

        [HttpPost]
        public async Task<ActionResult<Manager>> CreateManager(Manager manager)
        {
            _context.Managers.Add(manager);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return CreatedAtAction("GetManager", new { Id = manager.ManagerId }, manager);

            return BadRequest(new ProblemDetails { Title = "Problem creating new manager" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManager(Manager manager)
        {
            var managerEntity = await _context.Managers.FindAsync(manager.ManagerId);

            if (managerEntity == null) return NotFound();

            managerEntity.ManagerName = manager.ManagerName;
            managerEntity.ManagerPhoneNumber = manager.ManagerPhoneNumber;

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok(managerEntity);

            return BadRequest(new ProblemDetails { Title = "Problem updating manager" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            var manager = await _context.Managers.FindAsync(id);

            if (manager == null) return NotFound();

            _context.Managers.Remove(manager);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem deleting manager" });
        }
    }
}