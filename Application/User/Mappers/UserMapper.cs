using Application.User.Dtos;
using Riok.Mapperly.Abstractions;

namespace Application.User.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial IQueryable<UserViewModel> ProjectToViewModel(this IQueryable<Domain.Entities.User> q);
}
