using UserApi.Data.Repositories;
using UserApi.Entities;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(User user)
        {
            return await userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await userRepository.GetByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            await userRepository.UpdateAsync(user);
        }
    }
}
