using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tractus
{
    [Serializable]
    public class Availability
    {
        [JsonProperty("period_id")]
        public int Period_id { get; set; }
        [JsonProperty("total_days")]
        public int Total_days { get; set; }
        [JsonProperty("workdays")]
        public int Workdays { get; set; }
        [JsonProperty("weekend_days")]
        public int Weekend_days { get; set; }
        [JsonProperty("holidays")]
        public int Holidays_Count { get; set; }
        [JsonProperty("feasibility")]
        public bool Feasibility { get; set; }
        [NonSerialized]
        public DateTime[] Holidays = new DateTime[]
        {
          new DateTime(2017, 11, 1),
          new DateTime(2017, 12, 8),
          new DateTime(2017, 12, 25),
          new DateTime(2017, 12, 16),
          new DateTime(2017, 1, 1),
          new DateTime(2017, 1, 6),
          new DateTime(2017, 4, 16),
          new DateTime(2017, 4, 17),
          new DateTime(2017, 4, 25),
          new DateTime(2017, 5, 1),
          new DateTime(2017, 6, 2),
        };

        public Availability(Project proj, List<Developer> devList, List<LocalHoliday> localHolidays)
        {
            Period_id = proj.Id;
            List<DateTime> HolidaysList = Holidays.ToList();

            foreach (LocalHoliday localHoliday in localHolidays)
            {
                HolidaysList.Add(localHoliday.Day);
            }

            foreach (Developer dev in devList)
            {
                HolidaysList.Add(new DateTime(2017, dev.Birthday.Month, dev.Birthday.Day));
                Workdays = WorkdaysInPeriod(proj, HolidaysList);
                if (proj.EffortDays > 0)
                {
                    proj.EffortDays -= Workdays;
                }
            }
            Total_days = TotalDaysInPeriod(proj);
            Holidays_Count = HolidaysCount(proj, HolidaysList);
            Weekend_days = Total_days - Workdays - Holidays_Count;
            if (proj.EffortDays <= 0) Feasibility = true;
            else Feasibility = false;
        }

        private int HolidaysCount(Project proj, List<DateTime> holidays)
        {
            int count = 0; //se un giorno di festa coincide con il weekend non viene considerato
            foreach (DateTime holiday in holidays)
            {
                DateTime bh = holiday.Date;
                if (proj.Since <= bh && bh <= proj.Until && !(bh.DayOfWeek == DayOfWeek.Sunday || bh.DayOfWeek == DayOfWeek.Saturday))
                    count++;
            }
            return count;
        }
        private int TotalDaysInPeriod(Project proj) {
            if (proj.Since > proj.Until)
                throw new ArgumentException("La data di inizio e' maggiore di quella di fine");

            TimeSpan span = proj.Until - proj.Since;
            int total = span.Days + 1; // Aggiunto un giorno perche' se Since==Until considera un giorno lavorativo invece di 0
            return total;
        }

        private int WorkdaysInPeriod(Project proj, List<DateTime> holidays)  
        {
            var totalDays = 0;
            for (var date = proj.Since; date <= proj.Until; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }


            foreach (DateTime holiday in holidays)
            {
                DateTime bh = holiday.Date;
                if (proj.Since <= bh && bh <= proj.Until && !(bh.DayOfWeek == DayOfWeek.Sunday || bh.DayOfWeek == DayOfWeek.Saturday))
                    --totalDays;
            }
            return totalDays;
        }
    }
}
