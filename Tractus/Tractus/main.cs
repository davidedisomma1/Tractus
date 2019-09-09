using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tractus
{
    class main
    {
        static void Main(string[] args)
        {
            /*  //esercizio 1
             *  
            Periods deserializedPeriods = JsonConvert.DeserializeObject<Periods>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level1\data.json"));
            Availabilities availabilities = new Availabilities();
            foreach (Period period in deserializedPeriods.periodsList)
            {
                availabilities.availabilitiesList.Add(new Availability(period));
            }
            string output = JsonConvert.SerializeObject(availabilities);
            System.IO.File.WriteAllText(@"D:\output.txt", output);
            */

            //esercizio 2
            /*
            Periods deserializedPeriods = JsonConvert.DeserializeObject<Periods>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level2\data.json"));
            Developers deserializedDevelopers = JsonConvert.DeserializeObject<Developers>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level2\data.json"));
            LocalHolidays deserializedLocalHolidays = JsonConvert.DeserializeObject<LocalHolidays>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level2\data.json"));

            foreach (Period period in deserializedPeriods.periodsList)
            {
                foreach (Developer dev in deserializedDevelopers.developerList)
                {
                    Availabilities.availabilitiesList.Add(new Availability(period,dev,deserializedLocalHolidays.LocalHolidaysList));
                }
            }
            string output = JsonConvert.SerializeObject(Availabilities.availabilitiesList);
            System.IO.File.WriteAllText(@"D:\output.txt", output);
            */

            //esercizio 3
            Projects deserializedProjects = JsonConvert.DeserializeObject<Projects>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level3\data.json"));
            Developers deserializedDevelopers = JsonConvert.DeserializeObject<Developers>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level3\data.json"));
            LocalHolidays deserializedLocalHolidays = JsonConvert.DeserializeObject<LocalHolidays>(File.ReadAllText(@"C:\Users\david\source\repos\ruby-challenge\level3\data.json"));

            foreach (Project proj in deserializedProjects.projectList)
            {
                Availabilities.availabilitiesList.Add(new Availability(proj, deserializedDevelopers.developerList, deserializedLocalHolidays.LocalHolidaysList));
            }
            string output = JsonConvert.SerializeObject(Availabilities.availabilitiesList);
            Console.WriteLine(output);

            //esercizio 4
            /*
             *
             */
        }
    }
}
