using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class Tour
    {
        public string Name { get; set; }
        public DateTime DateOftheTour { get; set; }
        public int NumberOfSeats { get; set; }

        public Tour(string name, DateTime date, int num)
        {
            this.Name = name;
            this.DateOftheTour = date;
            this.NumberOfSeats = num;
        }
    }
    public class TourSchedule
    {
        private Dictionary<DateTime, List<Tour>> scheduleByDay =
            new Dictionary<DateTime, List<Tour>>();
        public void CreateTour(string v1, DateTime dateTime, int v2)
        {
            if (scheduleByDay.ContainsKey(dateTime))
            {
                var tur = scheduleByDay[dateTime];
                if (tur.Count >= 3)
                {
                    throw new TourAllocationException(dateTime.AddDays(1).Date);
                }
                tur.Add(new Tour(v1, dateTime, v2));
            }
            else
            {
                scheduleByDay.Add(dateTime.Date, new List<Tour>() { new Tour(v1, dateTime, v2) }); 
            }
        }
       
        public List<Tour>GetToursFor(DateTime date)
        {
            var result = scheduleByDay[date.Date].OrderBy(c=> c.DateOftheTour).ToList();
            
            return result;
        }
    }
    
   
}
