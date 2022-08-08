using MediatR;

namespace Diff.WebUI.AppCode.Infrastructure
{
    public interface IJsonRequest : IRequest<CommandJsonResponse>
    {
    }
    public interface IJsonRequestHandler<T> : IRequestHandler<T, CommandJsonResponse>
        where T : IRequest<CommandJsonResponse>
    {

    }

}
