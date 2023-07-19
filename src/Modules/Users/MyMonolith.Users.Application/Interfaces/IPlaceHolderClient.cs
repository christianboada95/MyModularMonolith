using MyMonolith.Users.Domain.Entities;
using Refit;

namespace MyMonolith.Users.Application.Interfaces;

public interface IPlaceHolderClient
{
    [Get("/users")]
    Task<IEnumerable<User>> GetUsersAsync();

    [Get("/users/{id}")]
    Task<User> GetUserAsync([AliasAs("id")] int userId);
}

