using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankStream.Data;

public class EventDbContext : DbContext
{
    public DbSet<DepositEvent> Deposits { get; set; }
    public DbSet<WithdrawalEvent> Withdrawals { get; set; }

    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options) { }
}
