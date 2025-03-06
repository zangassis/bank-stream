using BankStream.Data;
using BankStream.Events;
using MassTransit;

namespace BankStream.Consumers;

public class DepositConsumer : IConsumer<DepositEvent>
{
    private readonly EventDbContext _dbContext;

    public DepositConsumer(EventDbContext dbContext) => _dbContext = dbContext;

    public async Task Consume(ConsumeContext<DepositEvent> context)
    {
        _dbContext.Deposits.Add(context.Message);
        await _dbContext.SaveChangesAsync();
    }
}
