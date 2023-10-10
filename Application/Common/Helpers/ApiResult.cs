using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers;

public record ApiResult<T> : IApiResult<T>
{
    public T Data { get; set; } = default!;
    public string[] Errors { get; set; } = Array.Empty<string>();
    public bool IsSuccess { get; set; }

    public static ApiResult<T> Error(params string[] errors)
    {
        return new ApiResult<T>
        {
            Errors = errors,
            IsSuccess = false
        };
    }

    public static ApiResult<T> Success(T data)
    {
        return new ApiResult<T>
        {
            Data = data,
            IsSuccess = true
        };
    }
}

public record ApiResult : IApiResult
{
    public string[] Errors { get; set; } = Array.Empty<string>();
    public bool IsSuccess { get; set; }

    public static ApiResult Error(params string[] errors)
    {
        return new ApiResult
        {
            Errors = errors,
            IsSuccess = false
        };
    }

    public static ApiResult Success()
    {
        return new ApiResult
        {
            IsSuccess = true
        };
    }
}
