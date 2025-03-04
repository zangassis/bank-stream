using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankStream.Consumers;

public class WithdrawalConsumer : IConsumer<WithdrawalEvent>
{
    private readonly EventDbContext _dbContext;

    public WithdrawalConsumer(EventDbContext dbContext) => _dbContext = dbContext;

    public async Task Consume(ConsumeContext<WithdrawalEvent> context)
    {
        _dbContext.Withdrawals.Add(context.Message);
        await _dbContext.SaveChangesAsync();
    }
}
