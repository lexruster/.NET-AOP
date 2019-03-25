using System;
using System.Threading;
using PostSharp.Patterns.Caching;

namespace Aop
{
    public class CachedTest
    {
        [Cache]
        public int GetNumber(int id)
        {
            Console.WriteLine($">> Retrieving {id} from the database...");
            Thread.Sleep(1000);
            return id;
        }
    }
}