using MongoDB.Driver;
using ms_estate_center.Domain.Entities;
using ms_estate_center.Domain.Interfaces;

namespace ms_estate_center.Adapter.Out.Mongodb.Users
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IMongoCollection<User> _users;

        public UsersRepository(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("users");
        }

        public async Task<User> GetByEmail(string email) =>
            await _users.Find(p => p.Email == email).FirstOrDefaultAsync();

    }
}
