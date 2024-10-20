using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS_Lab2_Serialization
{
    [Serializable]
    public class Company
    {
        public string Name { get; set; }

        // Parameterless constructor
        public Company() { }

        public Company(string name)
        {
            Name = name;
        }
    }
}
