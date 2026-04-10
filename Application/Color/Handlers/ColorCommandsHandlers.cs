using Application.Color.Commands;
using Application.Color.Mappers;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Color.Handlers;

internal class ColorCommandsHandlers(ApplicationDbContext dbContext) : IRequestHandler<AddColorCommand, Result<Ulid>>
{
    public async Task<Result<Ulid>> Handle(AddColorCommand request, CancellationToken cancellationToken)
    {
        var colorWithSameValue = await dbContext.Colors
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Value == request.Model.Value, cancellationToken);

        if (colorWithSameValue != null)
        {
            return Result.Failure<Ulid>($"Цвет со значением \"{colorWithSameValue.Value}\" уже существует!");
        }

        var colorToCreate = ColorMapper.MapToEntity(request.Model);

        var createdColor = await dbContext.AddAsync(colorToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdColor.Entity.Id);
    }
}
