using System;
using System.Linq;
using System.Collections.Generic;

namespace AW_Fullstack_W2_D3_People_exercise
{
    class Person
    {
        public string FirstName;
        public string Lastname;
        public string Email;
        public DateTime DoB;
        public int Age;


        public Person(string in_fnamne, string in_lname, string in_email, DateTime in_dob)
        {
            this.FirstName = in_fnamne;
            this.Lastname = in_lname;
            this.Email = in_email;
            this.DoB = in_dob;
        }

        public Person(string in_fnamne, string in_lname, string in_email)
        {
            this.FirstName = in_fnamne;
            this.Lastname = in_lname;
            this.Email = in_email;
        }

        public Person(string in_fnamne, string in_lname, DateTime in_dob)
        {
            this.FirstName = in_fnamne;
            this.Lastname = in_lname;
            this.DoB = in_dob;
        }

        public int ReturnAge()
        {
            this.Age = DateTime.Now.Year - DoB.Year;

            if (DateTime.Now.Month < DoB.Month || (DateTime.Now.Month == DoB.Month && DateTime.Now.Day < DoB.Day))
                this.Age--;

            return Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> ihmisLista = new List<Person>();

            Person eka = new Person("Erkki", "Esimerkki", DateTime.Parse("01/01/1984"));
            Person toka = new Person("Örkki", "Örkkinen", DateTime.Parse("07/13/1970"));
            Person toka2 = new Person("Örkki", "Örkkinen", DateTime.Parse("07/13/1970"));
            Person kolmas = new Person("Pertti", "Perttinen", DateTime.Parse("10/28/1990"));
            Person neljas = new Person("Laila", "Liima", DateTime.Parse("10/28/1977"));
            Person viides = new Person("Sirpa", "Siivo", DateTime.Parse("12/24/1999"));

            ihmisLista.Add(eka);
            ihmisLista.Add(toka);
            ihmisLista.Add(kolmas);
            ihmisLista.Add(neljas);
            ihmisLista.Add(viides);

            double kesk = ihmisLista.Average(ihminen => ihminen.ReturnAge());

            IEnumerable<Person> tulos = ihmisLista.Where(ihminen => ihminen.Age > kesk);

            foreach(Person yksi in tulos)
            {
                Console.WriteLine(yksi.FirstName);
            }

            IEnumerable<Person> tulos2 = ihmisLista.Where(ihminen => ihminen.Age > ihmisLista.Average(toinen_ihminen => toinen_ihminen.ReturnAge()));

            foreach(Person yksi in tulos2)
            {
                Console.WriteLine(yksi.Lastname);
            }

        }
    }
}
