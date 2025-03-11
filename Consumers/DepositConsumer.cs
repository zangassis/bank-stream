using BankStream.Data;
using BankStream.Events;
using BankStream.Models;
using MassTransit;

namespace BankStream.Consumers;

public class DepositConsumer : IConsumer<DepositEvent>
{
    private readonly EventDbContext _dbContext;

    public DepositConsumer(EventDbContext dbContext) => _dbContext = dbContext;

    public async Task Consume(ConsumeContext<DepositEvent> context)
    {
        var deposit = context.Message;

        await _dbContext.TransactionStatus.AddAsync(new TransactionStatus(
            Guid.NewGuid(),
            deposit.AccountId, 
            StatusEnum.Completed,
            deposit.Amount,
            true,
            string.Empty,
            TransactionTypeEnum.Deposit,
            DateTime.Now)
        );

        _dbContext.Deposits.Add(deposit);

        await _dbContext.SaveChangesAsync();
    }
}