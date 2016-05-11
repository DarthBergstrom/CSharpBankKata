using BankCore;
using NUnit.Framework;
using System;
using BankCore.Models;

namespace BankKataTests.UnitTests
{
    [TestFixture]
    public class ClockShould
    {
        private const string TODAY = "07/04/2016";

        [Test]
        public void Return_Todays_Date_In_Dd_Mm_Yyyy_Format()
        {
            var clock = new TestableClock();

            Assert.That(clock.TodayAsString, Is.EqualTo(TODAY));
        }

        private class TestableClock : Clock
        {
            protected override string Today()
            {
                return "07/04/2016";
            }
        }
    }
}
