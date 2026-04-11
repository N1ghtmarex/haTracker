using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserService(ApplicationDbContext dbContext) : IUserService
{
    public async Task<Result<User>> GetUserAsync(Ulid id, CancellationToken cancellationToken = default)
    {
        var user = await dbContext.Users
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user != null)
        {
            return Result.Success(user);
        }

        return Result.Failure<User>($"Эмодзи с идентификатором \"{id}\" не найдено!");
    }
}