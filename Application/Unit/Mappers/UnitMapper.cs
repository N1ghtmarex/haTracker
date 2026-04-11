using Application.Mappers;
using Application.Unit.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.Unit.Mappers;

[Mapper]
public static partial class UnitMapper
{
    [MapValue(nameof(Domain.Entities.Emoji.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Domain.Entities.Unit MapToEntity(AddUnitModel source);

    public static partial IQueryable<UnitViewModel> ProjectToViewModel(this IQueryable<Domain.Entities.Unit> q);
}
