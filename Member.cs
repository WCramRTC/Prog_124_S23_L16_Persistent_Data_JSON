using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_S23_L16_Persistent_Data_JSON
{
    internal class Member
    {
        string _name;
        string _number;
        List<Transaction> _transactions;

        public Member(string name)
        {
            Random rand = new Random();
            _name = name;
            _transactions = new List<Transaction>();
            _number = rand.Next(10000000, 100000000).ToString();
        } // Member()

        public string Name { get => _name; set => _name = value; }
        public string Number { get => _number; set => _number = value; }
        public List<Transaction> Transactions { get => _transactions; }

        public void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
        } // AddTransaction()

        public override string ToString()
        {
            return $"{_name} - {_number} - Transactions: {_transactions.Count}";
        } // ToString()

    }
}
