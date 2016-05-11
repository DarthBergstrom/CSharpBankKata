namespace BankCore.Models
{
    public class Transaction
    {
        private readonly int _amount;
        private readonly string _date;

        public Transaction(string date, int amount)
        {
            _date = date;
            _amount = amount;
        }

        public string Date
        {
            get { return _date; }
        }

        public int Amount
        {
            get { return _amount; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || obj.GetType() != GetType())
                return false;

            Transaction that = (Transaction)obj;

            if (_date != that._date || _amount != that._amount)
                return false;

            return true;
        }
    }
    
}