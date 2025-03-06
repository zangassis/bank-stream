using BankStream.Events;
using Microsoft.EntityFrameworkCore;

namespace BankStream.Data;

public class EventDbContext : DbContext
{
    public DbSet<DepositEvent> Deposits { get; set; }
    public DbSet<WithdrawalEvent> Withdrawals { get; set; }

    public EventDbContext(DbContextOptions<EventDbContext> options)
        : base(options) { }
}
