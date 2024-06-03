using AutoMapper;
using backendP.DTOs;
using backendP.Models;
using backendP.Repository;

namespace backendP.Services
{
    public class DepartmentService:IDataService<DepartmentDto>
    {
        private IDepartmentRepository<Department> _IDepartmentService;
        private IMapper _Mapper;

        public DepartmentService(IDepartmentRepository<Department> deparmentRepository,IMapper mapper)
        {
            this._IDepartmentService = deparmentRepository;
            this._Mapper = mapper;
        }
        public async Task<IEnumerable<DepartmentDto>> Get()
        {
            var department= await _IDepartmentService.Get();
            return department.Select(x=>_Mapper.Map<DepartmentDto>(x));
        }
    }
}
