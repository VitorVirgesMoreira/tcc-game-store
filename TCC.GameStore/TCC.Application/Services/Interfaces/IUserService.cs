using System.Collections.Generic;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.UserModel;

namespace TCC.GameStore.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserRequestModel requestModel);
        Task UpdateUser(int userId, UserRequestModel requestModel);
        Task DeleteUser(int userId);
        Task<UserResponseModel> GetById(int id);
        Task<IEnumerable<UserResponseModel>> GetAll();
    }
}
