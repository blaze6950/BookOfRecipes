using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfRecipes
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipes bookRecipes = new Recipes();
            bookRecipes.ClearRecipes();
            Recipe newRecipe = new Recipe();
            newRecipe.Name = "Борщ";
            newRecipe.Cooking =
                "Guhyfw gwfwsrjvbrjheswbg rswjhfgasf wqgafgas jgy vfauygfydg fjagdfc dasufytgdff ugasdyfg asdyfg ajhygf saduygf d";
            newRecipe.NumberOfServings = 4;
            newRecipe.Ingridients.Add(new Ingridient("Вода", 3, "л"));
            newRecipe.Ingridients.Add(new Ingridient("Картошка", 1.5, "кг"));
            newRecipe.Ingridients.Add(new Ingridient("Капуста", 1, "кг"));
            newRecipe.CalContent = new CaloricContent(123, 23, 34);
            bookRecipes.AddRecipe(newRecipe);
            bookRecipes.AddRecipe(new Recipe("Пирог", new List<Ingridient>(), "KJghsg fkhdgsfadkfhg ajhdagf kjagfdfafdajhfgd jhgfajhgfd jhdag ", 5, new CaloricContent(1324,1324,234)));
            bookRecipes.Print();
            bookRecipes.DelRecipe(newRecipe);
            Console.WriteLine("llllllllllllllllllllllllllllllllllllllllllllllllllll");
            bookRecipes.Print();
        }
    }
}
