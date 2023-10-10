using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Helpers;

public interface IApiResult<T> : IApiResult
{
    T Data { get; set; }

    static IApiResult<T> Success(T data)
    {
        return new ApiResult<T>
        {
            Data = data,
            IsSuccess = true
        };
    }
}

public interface IApiResult
{
    string[] Errors { get; set; }
    bool IsSuccess { get; set; }

    static IApiResult Error(string[] errors)
    {
        return new ApiResult
        {
            Errors = errors,
            IsSuccess = false
        };
    }

    static IApiResult Success()
    {
        return new ApiResult
        {
            IsSuccess = true
        };
    }
}
