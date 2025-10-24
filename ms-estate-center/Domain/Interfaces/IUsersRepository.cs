using ms_estate_center.Domain.Entities;

namespace ms_estate_center.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetByEmail(string email);
    }
}
