using Microsoft.EntityFrameworkCore;
using UserApi.Entities;

namespace UserApi.Data.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
