using AutoMapper;
using HRManagement.API.DTOs.DepartmentDTO;
using HRManagement.API.DTOs.UserDTO;
using HRManagement.Domain.AggregateModels.DepartmentAggregate;
using HRManagement.Domain.AggregateModels.UserAggregate;
using HRManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRManagement.API.Services
{
    public partial class DepartmentServiceCRUD
    {
        #region Variables +Constructor

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentServiceCRUD(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Get
        public async Task<GetDepartmentsResponse> GetAllAsync()
        {
            List<Department> departments = await _context.Departments.ToListAsync();

            IEnumerable<DepartmentDto> departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return new GetDepartmentsResponse
            {
                Departments = departmentDtos
            };
        }
        #endregion

        #region GetById
        public async Task<GetDepartmentByIdResponse?> GetByIdAsync(int departmentId)
        {
            Department? department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == departmentId);

            return department != null ? _mapper.Map<GetDepartmentByIdResponse>(department) : null;
        }

        #endregion

        #region Add
        public async Task<AddDepartmentResponse> AddAsync(AddDepartmentRequest request)
        {
            Department department = _mapper.Map<Department>(request);

            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return _mapper.Map<AddDepartmentResponse>(department);
        }
        #endregion

        #region Update
        public async Task<UpdateDepartmentResponse> UpdateAsync(int id, UpdateDepartmentRequest request)
        {
            Department? department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return new UpdateDepartmentResponse { Success = false };
            }

            _mapper.Map(request, department);

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return new UpdateDepartmentResponse { Success = true };
        }
        #endregion

        #region Delete

        public async Task<DeleteDepartmentResponse> DeleteAsync(DeleteDepartmentRequest request)
        {
            Department? department = await _context.Departments.FindAsync(request.DepartmentId);
            if (department == null)
            {
                return new DeleteDepartmentResponse { Success = false };
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return new DeleteDepartmentResponse { Success = true };
        }

        #endregion
    }
}
