using System;
using System.Collections.Generic;

namespace BookOfRecipes
{
    class Recipe
    {
        public Recipe(string name, List<Ingridient> ingridients, string cooking, int numberOfServings, CaloricContent calContent, int id = 0)
        {
            Id = id;
            Name = name;
            Ingridients = ingridients;
            Cooking = cooking;
            NumberOfServings = numberOfServings;
            CalContent = calContent;
        }

        public Recipe()
        {
            Id = 0;
            Name = String.Empty;
            Ingridients = new List<Ingridient>();
            Cooking = String.Empty;
            NumberOfServings = 0;
            CalContent = new CaloricContent();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingridient> Ingridients { get; set; }
        public string Cooking { get; set; }
        public int NumberOfServings { get; set; }
        public CaloricContent CalContent { get; set; }

        public override string ToString()
        {
            String res = "\t " + Name + " (" + Id + ")\n   Ingridients : \n";
            foreach (var ingridient in Ingridients)
            {
                res += "- " + ingridient.Name + " ( " + ingridient.Quantity + " " + ingridient.Measure + " )\n";
            }
            res += "   Cooking : \n" + Cooking + "\n   Number of servings : " + NumberOfServings + "\n   Caloric content : \n- proteins : " + CalContent.Proteins + "\n- fats : " + CalContent.Fats + "\n- carbohydrates : " + CalContent.Carbohydrates + "\n";
            return res;
        }
    }
}
