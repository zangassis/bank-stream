using BankStream.Data;
using BankStream.Events;
using BankStream.Models;
using MassTransit;

namespace BankStream.Consumers;

public class WithdrawalConsumer : IConsumer<WithdrawalEvent>
{
    private readonly EventDbContext _dbContext;

    public WithdrawalConsumer(EventDbContext dbContext) => _dbContext = dbContext;

    public async Task Consume(ConsumeContext<WithdrawalEvent> context)
    {
        var withdrawal = context.Message;

        await _dbContext.TransactionStatus.AddAsync(new TransactionStatus(
            Guid.NewGuid(),
            withdrawal.AccountId,
            StatusEnum.Completed,
            withdrawal.Amount,
            true,
            string.Empty,
            TransactionTypeEnum.Withdrawal,
            DateTime.Now)
        );

        _dbContext.Withdrawals.Add(context.Message);
        await _dbContext.SaveChangesAsync();
    }
}
