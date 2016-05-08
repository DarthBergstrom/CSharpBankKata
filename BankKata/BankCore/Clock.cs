using System;

namespace BankCore
{
    public class Clock
    {
        public virtual string TodayAsString()
        {
            return Today();
        }

        protected virtual string Today()
        {
            return DateTime.Today.ToString("dd/MM/yyyy");
        }
    }
}