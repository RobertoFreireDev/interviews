using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRegistration.Domain.Dtos.User;
using UserRegistration.Domain.Entities;

namespace UserRegistration.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetUsersAsync(UserFilterDto filter = null);
        Task<int> ToggleActivationInUserAsync(UserToggleActivationDto userToggleActivationDto);
        Task<int> EditUserAsync(UserEntity user);
        Task<bool> AddUserAsync(UserEntity user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}