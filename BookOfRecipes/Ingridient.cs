using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes
{
    class Ingridient
    {
        public Ingridient()
        {
            Name = String.Empty;
            Measure = String.Empty;
            Quantity = 0;
        }

        public Ingridient(String name, Double quantity, String measure)
        {
            Name = name;
            Quantity = quantity;
            Measure = measure;
        }

        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Measure { get; set; }
    }
}
