using MediatR;
using System.Net;

namespace Common.Query
{
    public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : class?
    {

    }

}
