using Common.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetCore
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected ApiResult CommandResult(OperationResult result)
        {
            return new ApiResult
            {
                IsSuccess = result.Status == OperationResultStatus.Success,
                MetaData = new MetaData
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapStatus()
                }
            };
        }


        //For create commands
        protected ApiResult<TData?> CommandResult<TData>(OperationResult<TData> result, HttpStatusCode status = HttpStatusCode.OK, string headerUrl = null)
        {
            bool isSuccess = result.Status == OperationResultStatus.Success;
            if (isSuccess)
            {
                HttpContext.Response.StatusCode = (int)status;
                if (string.IsNullOrWhiteSpace(headerUrl))
                {
                    HttpContext.Response.Headers.Add("location", headerUrl);
                }
            }
            return new ApiResult<TData?>()
            {
                IsSuccess = isSuccess,
                Data = isSuccess ? result.Data : default,
                MetaData = new MetaData
                {
                    Message = result.Message,
                    StatusCode = result.Status.MapStatus()
                }
            };

        }

        //For Queries
        protected ApiResult<TData> QueryResult<TData>(TData result)
        {
            if (result == null)
                return new ApiResult<TData> {
                    IsSuccess = false,
                    Data = result,
                    MetaData = new MetaData
                    {
                        Message = "موردی یافت نشد",
                        StatusCode = ResponseStatusCode.NotFound
                    }
                };
            return new ApiResult<TData>()
            {
                IsSuccess = true,
                Data = result,
                MetaData = new MetaData
                {
                    Message = "عملیات با موفقیت انجام شد",
                    StatusCode = ResponseStatusCode.Success
                }
            };
        }

        protected string JoinErrors()
        {
            var errors = new Dictionary<string, List<string>>();

            if (!ModelState.IsValid)
            {
                if (ModelState.ErrorCount > 0)
                {
                    for (int i = 0; i < ModelState.Values.Count(); i++)
                    {
                        var key = ModelState.Keys.ElementAt(i);
                        var value = ModelState.Values.ElementAt(i);

                        if (value.ValidationState == ModelValidationState.Invalid)
                        {
                            errors.Add(key, value.Errors.Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage).ToList());
                        }
                    }
                }
            }
            var error = string.Join(" ", errors.Select(x => $"{string.Join(" - ", x.Value)}"));
            return error;
        }
    }

    public static class EnumHelper
    {
        public static ResponseStatusCode MapStatus(this OperationResultStatus status)
        {
            switch (status)
            {
                case OperationResultStatus.Success:
                    return ResponseStatusCode.Success;

                case OperationResultStatus.NotFound:
                    return ResponseStatusCode.NotFound;

                case OperationResultStatus.Error:
                    return ResponseStatusCode.LogicError;
            }
            return ResponseStatusCode.LogicError;
        }
    }
}
