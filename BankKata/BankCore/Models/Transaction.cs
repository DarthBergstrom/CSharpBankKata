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
    }
}