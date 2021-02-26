using MediatR;
using Sample.CQRS.Application.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.CQRS.Application.PipelineBehaviors
{
    public class CreateNewCustomerBehavior<CreateNewCustomerCommand, Unit> : IPipelineBehavior<CreateNewCustomerCommand, Unit>
    {
        public async Task<Unit> Handle(CreateNewCustomerCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<Unit> next)
        {
            return await next();
        }
    }
}
