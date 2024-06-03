using backendP.DTOs;
using backendP.Models;
using backendP.Services;
using Microsoft.AspNetCore.Mvc;

namespace backendP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private IDataService<DepartmentDto> _departmentService;
        
        public DepartmentController(IDataService<DepartmentDto> departmentService) { 
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentDto>> Get() => await _departmentService.Get();

    }
}
