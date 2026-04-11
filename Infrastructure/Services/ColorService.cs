using Abstractions.Interfaces;
using Core.Utils;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ColorService(ApplicationDbContext dbContext) : IColorService
{
    public async Task<Result<Color>> GetColorAsync(Ulid id, CancellationToken cancellationToken = default)
    {
        var color = await dbContext.Colors
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (color != null)
        {
            return Result.Success(color);
        }

        return Result.Failure<Color>($"Цвет с идентификатором \"{id}\" не найден!");
    }
}
