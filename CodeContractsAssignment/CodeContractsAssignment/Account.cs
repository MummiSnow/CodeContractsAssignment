using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContractsAssignment
{
    class Account
    {

        public string Name { get; set; }

        public int Balance { get; set; }

        /// <summary>
        /// This method, holds true on the instance of this class.
        /// Meaning that we have a condition that must be true following every public method call
        /// This case is that: 
        ///     Name of the Account must not be Null or contain only whitespaces
        ///     Balance must not be less than 0
        /// </summary>
        [ContractInvariantMethod]
        private void CheckBalanceAndName()
        {
            Contract.Invariant(Balance >= 0);
            Contract.Invariant(!String.IsNullOrWhiteSpace(Name));
        }

        /// <summary>
        /// This method, is relevant in the case of multiple methods having the same parameters and the same rules that needs to hold
        /// NOTE: Sometimes this may not work, since it reuires a file in the Microsoft/Contracts/Languages folder!
        ///     If it does bring issues, make sure to uncomment this method in the Deposit/Withdraw method!
        /// </summary>
        /// <param name="amount">Must be greater than 0</param>
        [ContractAbbreviator]
        private void ValidateAmount(int amount)
        {
            Contract.Requires(amount > 0, "Amount must be greater than 0");
            Contract.Requires<ArgumentException>(amount > 0, "Exception");
            
        }

        public Account(string name)
        {
            Name = name;
            Balance = -10;
        }

        public Account(string name, int startBalance)
        {
            Balance = startBalance;
            Name = name;
        }

        /// <summary>
        /// Deposit money into the account
        /// </summary>
        /// <param name="amount"> Amount must be greater than 0 </param>
        /// <returns></returns>
        public int Deposit(int amount)
        {
            //Contract.Requires(amount > 0, "Amount must be greater than 0");
            //Contract.Requires<ArgumentException>(amount > 0, "Exception");
            ValidateAmount(amount);

            Contract.Ensures(Contract.Result<int>() > Contract.OldValue(Balance));
            Balance += amount;

            return Balance;
        }

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="amount"> Amount must be greater than 0</param>
        /// <returns></returns>
        public int Withdraw(int amount)
        {
            //Contract.Requires(amount > 0, "Amount must be greater than 0");
            //Contract.Requires<ArgumentException>(amount > 0, "Exception");

            ValidateAmount(amount);
            Contract.Ensures(Contract.Result<int>() < Contract.OldValue(Balance));

            Balance -= amount;

            return Balance;
        }




    }
}
