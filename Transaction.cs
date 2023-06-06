using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_124_S23_L16_Persistent_Data_JSON
{
    public class Transaction
    {
        string _name;
        double _price;
        int _quantity;

        public Transaction() { }

        public Transaction(string name, double price, int quantity)
        {
            _name = name;
            _price = price;
            _quantity = quantity;
        } // Transaction

        public string Name { get => _name; set => _name = value; }
        public double Price { get => _price; set => _price = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public string TotalPrice { get => (_quantity * _price).ToString("c"); }
    }
}
