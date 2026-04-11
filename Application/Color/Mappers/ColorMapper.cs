using Application.Color.Dtos;
using Application.Mappers;
using Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Application.Color.Mappers;

[Mapper]
public static partial class ColorMapper
{
    [MapValue(nameof(User.Id), Use = nameof(@GeneralMapper.GenerateId))]
    public static partial Domain.Entities.Color MapToEntity(AddColorModel source);

    public static partial IQueryable<ColorViewModel> ProjectToViewModel(this IQueryable<Domain.Entities.Color> q);
}
