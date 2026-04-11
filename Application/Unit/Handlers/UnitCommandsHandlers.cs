using Application.Unit.Commands;
using Application.Unit.Mappers;
using Core.Utils;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Unit.Handlers;

internal class UnitCommandsHandlers(ApplicationDbContext dbContext) : IRequestHandler<AddUnitCommand, Result<Ulid>>
{
    public async Task<Result<Ulid>> Handle(AddUnitCommand request, CancellationToken cancellationToken)
    {
        var unitWithSameName = await dbContext.Units
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Name == request.Body.Name, cancellationToken);

        if (unitWithSameName != null)
        {
            return Result.Failure<Ulid>($"Единица измерения с названием \"{unitWithSameName.Name}\" уже существует!");
        }

        var unitToCreate = UnitMapper.MapToEntity(request.Body);

        var createdUnit = await dbContext.AddAsync(unitToCreate, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(createdUnit.Entity.Id);
    }
}
