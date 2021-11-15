using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCC.GameStore.Application.Models.UserModel;
using TCC.GameStore.Application.Services.Interfaces;
using TCC.GameStore.Domain.Builders;
using TCC.GameStore.Domain.Entities;
using TCC.GameStore.Domain.Exceptions;
using TCC.GameStore.Domain.Interfaces.Repositories;

namespace TCC.GameStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(UserRequestModel requestModel)
        {
            var userAlreadyRegistered = await _userRepository.GetByEmail(requestModel.Email);

            if (userAlreadyRegistered == null)
            {
                var user = UserBuild(requestModel);
                user.ValidateEntity();
                await _userRepository.Create(user);
                await _userRepository.Save();
            }
            else
            {
                throw new CustomValidationException("Usuário já cadastrado!");
            }
        }

        public async Task UpdateUser(int userId, UserRequestModel requestModel)
        {
            var userBuild = UserBuild(requestModel);
            var user = await _userRepository.GetById(userId);
            user.UpdateUser(userBuild);

            _userRepository.Update(user);
            await _userRepository.Save();
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetById(userId);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            user.Delete();

            _userRepository.Update(user);
            await _userRepository.Save();
        }

        public async Task<UserResponseModel> GetByEmail(string email)
        {
            var user = await _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new NotFoundException("Usuário não encontrado.");
            }

            return new UserResponseModel(user.Id, user.Name, user.Email, user.Password, user.CreatedAt, user.UpdatedAt);
        }

        public async Task<IEnumerable<UserResponseModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            if (users == null)
            {
                throw new NotFoundException("Usuários não encontrados.");
            }

            return users.Select(x => new UserResponseModel(x.Id, x.Name, x.Email, x.Password, x.CreatedAt, x.UpdatedAt));
        }

        private User UserBuild(UserRequestModel model)
        {
            return new UserBuilder()
                .SetName(model.Name)
                .SetEmail(model.Email)
                .SetPassword(model.Password)
                .Build();
        }
    }
}
