using System;

namespace MoneyGame.Logic
{
    public class Rate
    {
        public Rate(decimal value, DateTime date)
        {
            Value = value;
            Date = date;
        }

        public decimal Value { get; }

        public DateTime Date { get; }
    }
}
