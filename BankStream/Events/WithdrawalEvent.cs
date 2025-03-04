using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankStream.Events;

public record WithdrawalEvent(string AccountId, decimal Amount);
