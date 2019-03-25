using System;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Aop.Aspects
{
    [PSerializable]
    public class AccountCheckAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            var values = string.Join(", ", args.Arguments);
            Console.WriteLine($"The {args.Method.Name} method has been entered. Args: {values}");

            int sender = Convert.ToInt32(args.Arguments[0]);
            int recipient = Convert.ToInt32(args.Arguments[1]);
            int amount = Convert.ToInt32(args.Arguments[2]);

            if (sender >= BalanceProvider.Balances.Length || recipient >= BalanceProvider.Balances.Length)
            {
                args.FlowBehavior = FlowBehavior.Return;
                args.ReturnValue = false;

                return;
            }

            if (BalanceProvider.Balances[sender] < amount)
            {
                args.FlowBehavior = FlowBehavior.Return;
                args.ReturnValue = false;
            }
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("The {0} method executed successfully. Returned {1}", args.Method.Name, args.ReturnValue);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("The {0} method has exited.", args.Method.Name);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("An exception was thrown in {0}.", args.Method.Name);
        }
    }
}