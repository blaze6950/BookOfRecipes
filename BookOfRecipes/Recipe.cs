using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes
{
    class Recipe
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Ingridient> Ingridients { get; private set; }
        public string Cooking { get; private set; }
        public int NumberOfServings { get; private set; }
        public CaloricContent Content { get; private set; }
    }
}
