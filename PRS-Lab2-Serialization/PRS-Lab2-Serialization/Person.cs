using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Lab2_Serialization
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }

        // Parameterless constructor
        public Person() { }

        public Person(string name, int age, Company company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
    }
}
