using AutoMapper;
using HRManagement.API.DTOs.UserDTO;
using HRManagement.Domain.AggregateModels.UserAggregate;
using HRManagement.Infrastructure.Data;
using HRManagement.SharedKarnel.Models;
using Microsoft.EntityFrameworkCore;
using HRManagement.API.Models;

namespace HRManagement.API.Services
{
    public partial class UserServiceCRUD
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        #region Variable+Constructor
        public UserServiceCRUD(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region GetList
       /* public async Task<PagedResponse<GetUserListResponse>> GetListAsync(int currentPage, int pageSize)
        {
            List<User> users = await _context.Users
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            GetUserListResponse response = new GetUserListResponse
            {
                Users = _mapper.Map<List<UserDto>>(users)
            };

            PagedList<GetUserListResponse> pagedList = new PagedList<GetUserListResponse>(
                new List<GetUserListResponse> { response },
                await _context.Users.CountAsync(),
                currentPage,
                pageSize
            );

            return new PagedResponse<GetUserListResponse>(pagedList);
        }*/
        public async Task<PagedResponse<UserDto>> GetListAsync(int currentPage, int pageSize)
        {
            List<User> users = await _context.Users
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            List<UserDto> userDtos = _mapper.Map<List<UserDto>>(users);

            int totalCount = await _context.Users.CountAsync();

            PagedList<UserDto> pagedList = new PagedList<UserDto>(
                userDtos,
                totalCount,
                currentPage,
                pageSize
            );

            return new PagedResponse<UserDto>(pagedList);
        }

        #endregion

        #region GetById
        public async Task<GetUserByIdResponse?> GetByIdAsync(Guid userId)
        {
            User? user = await _context.Users
                .Include(u => u.Department)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user != null ? _mapper.Map<GetUserByIdResponse>(user) : null;
        }

        #endregion

        #region Add
        public async Task<AddUserResponse> AddAsync(AddUserRequest request)
        {
            User user = _mapper.Map<User>(request);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<AddUserResponse>(user);
        }
        #endregion

        #region Update
        public async Task<UpdateUserResponse> UpdateAsync(Guid id, UpdateUserRequest request)
        {
            User? user = await _context.Users.FindAsync(id);
          
            if (user == null)
            {
                return new UpdateUserResponse { Success = false };
            }

            _mapper.Map(request, user);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return new UpdateUserResponse { Success = true };
        }
        #endregion

        #region Delete

        public async Task<DeleteUserResponse> DeleteAsync(DeleteUserRequest request)
        {
            User? user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return new DeleteUserResponse { Success = false };
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new DeleteUserResponse { Success = true };
        }

        #endregion
    }
}

/*  IEnumerable<User> users = await _context.Users
         .Include(u => u.Department)
         .Include(u => u.PaySlips)
         .Skip((request.PageNumber - 1) * request.PageSize)
         .Take(request.PageSize) 
         .ToListAsync();*/