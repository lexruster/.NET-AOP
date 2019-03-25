using System;
using PostSharp.Patterns.Caching;
using PostSharp.Patterns.Caching.Backends;

namespace Aop
{
    public class Runner
    {
        public void RunCache()
        {
            CachingServices.DefaultBackend = new MemoryCachingBackend();
            var cachedTest = new CachedTest();

            Console.WriteLine("Retrieving value of 1 for the 1st time should hit the database.");
            Console.WriteLine("Retrieved: " + cachedTest.GetNumber(1));

            Console.WriteLine("Retrieving value of 1 for the 2nd time should NOT hit the database.");
            Console.WriteLine("Retrieved: " + cachedTest.GetNumber(1));

            Console.WriteLine("Retrieving value of 2 for the 1st time should hit the database.");
            Console.WriteLine("Retrieved: " + cachedTest.GetNumber(2));

            Console.WriteLine("Retrieving value of 2 for the 2nd time should NOT hit the database.");
            Console.WriteLine("Retrieved: " + cachedTest.GetNumber(2));
        }

        public void RunAccount()
        {
            var accountModuleTest = new AccountModuleTest();
            BalanceProvider.Print();
            Transfer(accountModuleTest, 2, 0, 65);
            Transfer(accountModuleTest, 0, 1, 10);
            Transfer(accountModuleTest, 0, 2, 15);
            Transfer(accountModuleTest, 0, 2, 10);
            Transfer(accountModuleTest, 4, 2, 10);
            Transfer(accountModuleTest, 3, 2, 50);
            Transfer(accountModuleTest, 2, 0, 65);
        }

        private void Transfer(AccountModuleTest accountModuleTest, int sender, int recipient, int amount)
        {
            var result = accountModuleTest.Transfer(sender, recipient, amount);
            Console.WriteLine($">>Transfer from {sender} to {recipient} Amount {amount}, result {result}");
            BalanceProvider.Print();
        }
    }
}
