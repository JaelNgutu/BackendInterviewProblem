using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers;

public interface IPaginatedApiRequest<T> : IRequest<PaginatedApiResult<T>>
{
    int PageIndex { get; init; }
    int PageSize { get; init; }
}

public interface IPaginatedApiRequestHandler<in TRequest, TResponse> : IRequestHandler<TRequest, PaginatedApiResult<TResponse>>
    where TRequest : IPaginatedApiRequest<TResponse>
{
}


