using BankCore;
using NUnit.Framework;
using System;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class ClockShould
    {
        private const string TODAY = "07/04/2016";

        [Test]
        public void Return_todays_date_in_dd_MM_yyyy_format()
        {
            var clock = new testableClock();

            Assert.That(clock.TodayAsString, Is.EqualTo(TODAY));
        }

        private class testableClock : Clock
        {
            protected override string Today()
            {
                return "07/04/2016";
            }
        }
    }
}
