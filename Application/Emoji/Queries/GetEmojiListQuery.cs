using Application.Emoji.Dtos;
using Core.BaseModels;
using Core.EntityFramework.Features.SearchPagination.Models;
using Core.Utils;
using MediatR;

namespace Application.Emoji.Queries;

public class GetEmojiListQuery : SearchablePagedQuery, IRequest<Result<PagedResult<EmojiViewModel>>>
{
}
