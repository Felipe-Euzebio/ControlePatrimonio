using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class DepartmentsController : BaseApiController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments([FromQuery]QueryParams queryParams)
        {
            var query = _context.Departments
                .Include(d => d.Manager)
                .Sort(queryParams.OrderBy)
                .Search(queryParams.SearchTerm)
                .AsQueryable();

            var departments = await PagedList<Department>
                .ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);

            Response.AddPaginationHeader(departments.PaginationMetaData);

            return departments;
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _context.Departments
                .Include(d => d.Manager)
                .FirstOrDefaultAsync(d => d.DepartmentId == id);

            if (department == null) return NotFound();

            return department;
        }

        [HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(CreateDepartmentDTO createDepartmentDTO)
        {
            var manager = await _context.Managers.FindAsync(createDepartmentDTO.ManagerId);

            if (manager == null) 
            {
                return BadRequest(new ProblemDetails { Title = "Manager not found" });
            }

            var department = _mapper.Map<Department>(createDepartmentDTO);

            department.Manager = manager;

            _context.Departments.Add(department);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return CreatedAtRoute("GetDepartment", new { id = department.DepartmentId }, department);

            return BadRequest(new ProblemDetails { Title = "Problem creating department" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var department = await _context.Departments.FindAsync(updateDepartmentDTO.DepartmentId);

            if (department == null) return NotFound();

            var manager = await _context.Managers.FindAsync(updateDepartmentDTO.ManagerId);

            if (manager == null) 
            {
                return BadRequest(new ProblemDetails { Title = "Manager not found" });
            }

            var updatedDepartment = _mapper.Map(updateDepartmentDTO, department);

            updatedDepartment.Manager = manager;

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return NoContent();

            return BadRequest(new ProblemDetails { Title = "Problem updating department" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null) return NotFound();

            _context.Departments.Remove(department);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem deleting department" });
        }
    }
}