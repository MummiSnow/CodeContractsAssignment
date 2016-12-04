using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContractsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account("acc1",0);
            acc.Deposit(20);
            acc.Deposit(100);
            acc.Withdraw(100);

            //acc.Withdraw(102); // will disobey the Contract Invariant 

            //int amount = acc.Deposit(0); //wont work 'Purple LINE!'
            
            Console.WriteLine("Account Balane: {0}", acc.Balance);
            Console.ReadKey();
        }
    }
}
