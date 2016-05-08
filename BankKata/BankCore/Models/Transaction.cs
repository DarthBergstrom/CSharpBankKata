namespace BankCore.Models
{
    public class Transaction
    {
        private int amount;
        private string date;

        public Transaction(string date, int amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            Transaction that = (Transaction)obj;

            if (this.date != that.date || this.amount != that.amount)
                return false;

            return true;
        }
    }
    
}