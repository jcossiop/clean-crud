using Application.Features.Users.Abstractions;
using Domain.Users;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<User> Add(User user)
    {
        throw new NotImplementedException();
    }
}
