using System;

namespace BankCore.Models
{
    public class Clock
    {
        private const string dd_MM_yyyy = "dd/MM/yyyy";

        public virtual string TodayAsString()
        {
            return Today();
        }

        protected virtual string Today()
        {
            return DateTime.Today.ToString(dd_MM_yyyy);
        }
    }
}