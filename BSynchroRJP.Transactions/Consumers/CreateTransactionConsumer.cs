using BSynchroRJP.Common.Messaging.Commands;
using BSynchroRJP.Transactions.Domain.CQRS.Commands;
using MassTransit;
using MediatR;

namespace BSynchroRJP.Transactions.Consumers
{
    public class CreateTransactionConsumer : IConsumer<CreateTransaction>
    {
        readonly IMediator _mediator;

        public CreateTransactionConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<CreateTransaction> context)
        {
            await _mediator.Send(new CreateTransactionCommand()
            {
                Amount = context.Message.Amount,
                CurrentAccountId = context.Message.CurrentAccountId,
                TransactionDate = context.Message.TransactionDate,

            });
        }
    }
}
