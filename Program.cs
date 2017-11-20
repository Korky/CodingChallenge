using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge
{
    class Person
    {
        public DateTime dob;//date of birth
        public DateTime dod;//date of death
    }
    class Program
    {
        //Large Dataset generator for proper testing
        static List<Person> GenerateData()
        {
            Random rand = new Random();
            var ret = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                var birth = new DateTime(year: rand.Next(1900, 2000), month: rand.Next(1, 12), day: rand.Next(1, 28));
                var death = new DateTime(year: rand.Next(birth.Year, 2000), month: rand.Next(1, 12), day: rand.Next(1, 28));
                ret.Add(new Person() { dob = birth, dod = death });
            }


            return ret;
        }
        static void Main(string[] args)
        {
            var pplLst = GenerateData();
            int birth = 1900, death = 2000;


            int maxYear = 0, maxPeople = 0;
            for (int year = birth; year < death; year++)
            {
                var pplAlive = pplLst.Where(i => year >= i.dob.Year && year < i.dod.Year).Count();//query people alive in current year
                //Console.WriteLine(year + " " +pplAlive);
                if (maxPeople < pplAlive)
                {
                    maxYear = year;
                    maxPeople = pplAlive;
                }
            }

            //Print solution
            Console.WriteLine("Most people alive in year " + maxYear + " " + maxPeople+"\n\n\nDataset(Date of Birth - Date of Death):");

            //Print Dataset
            foreach (var person in pplLst)
            {
                Console.Write(person.dob.ToShortDateString() + "-" + person.dod.ToShortDateString()+"\t");
            }
            Console.ReadKey();
        }
    }
}
