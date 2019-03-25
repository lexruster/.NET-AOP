using System;
using Aop.Aspects;

namespace Aop
{
    public class AccountModuleTest
    {
        [AccountCheckAspect]
        public bool Transfer(int sender, int recipient, decimal amount)
        {
            Console.WriteLine($"Send from {sender} to {recipient} Amount {amount}");
            if (amount > 70)
            {
                throw new Exception("Amount is to high");
            }

            BalanceProvider.Balances[sender] -= amount;
            BalanceProvider.Balances[recipient] += amount;

            return true;
        }
    }
}