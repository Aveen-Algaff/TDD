using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;
        [SetUp]
        public void setUp()
        {
           sut = new TourSchedule();
        }
        [Test]
        public void CanCreateNewTour()
        {
            
            sut.CreateTour(
            "New years day safari",
            new DateTime(2013, 1, 1), 20);

            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual("New years day safari", result[0].Name);
        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {
           
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual("New years day safari", result[0].Name);
        }
        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour(
               " years day safari",
               new DateTime(2014, 2, 2, 10, 15, 0), 20);
            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual("New years day safari", result[0].Name);

        }
        [Test]
        public void TourAllocationException()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);


            Assert.Throws<TourAllocationException>(()=> sut.CreateTour("New years day safari", new DateTime(2013,1,1),20));
        }
    }
}
