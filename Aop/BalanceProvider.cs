using System;
using System.Linq;

namespace Aop
{
    public class BalanceProvider
    {
        public static decimal[] Balances = {
            20,
            30,
            10,
            50
        };

        public static string Print()
        {
            var result = String.Join(" ,", Balances.Select((x, i) => $"[{i}]: ${x}"));
            Console.WriteLine(result);

            return result;
        }
    }
}
