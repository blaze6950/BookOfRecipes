using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace BookOfRecipes
{
    class Recipes
    {
        private List<Recipe> _recipes = new List<Recipe>();

        public Recipes()
        {
            ReadData();
        }
        private void ReadData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Recipes.xml");

            var recipes = doc.DocumentElement;

            if (recipes != null)
                foreach (XmlNode recipe in recipes.ChildNodes)
                {
                    Recipe newRecipe = new Recipe();
                    if (recipe.Attributes != null) newRecipe.Id = Int32.Parse(recipe.Attributes["id"].Value);
                    newRecipe.Name = recipe["name"]?.InnerText;
                    // ReSharper disable once PossibleNullReferenceException
                    foreach (XmlNode ingridient in recipe["ingridients"]?.ChildNodes)
                    {
                        Ingridient newIngridient = new Ingridient();
                        newIngridient.Name = ingridient["name"]?.InnerText;
                        newIngridient.Measure = ingridient["quantity"]?.Attributes["measure"].Value;
                        newIngridient.Quantity = Double.Parse(ingridient["quantity"]?.InnerText ?? throw new InvalidOperationException());

                        newRecipe.Ingridients.Add(newIngridient);
                    }
                    newRecipe.Cooking = recipe["cooking"]?.InnerText;
                    newRecipe.NumberOfServings = Int32.Parse(recipe["numberOfServings"]?.InnerText ?? throw new InvalidOperationException());
                    newRecipe.CalContent.Proteins = Int32.Parse(recipe["caloricContent"]?["proteins"]?.InnerText ?? throw new InvalidOperationException());
                    newRecipe.CalContent.Fats = Int32.Parse(recipe["caloricContent"]?["fats"]?.InnerText ?? throw new InvalidOperationException());
                    newRecipe.CalContent.Carbohydrates =
                        Int32.Parse(recipe["caloricContent"]?["carbohydrates"]?.InnerText ?? throw new InvalidOperationException());

                    _recipes.Add(newRecipe);
                }
        }
        private void WriteData()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Recipes.xml");
            var recipes = doc.DocumentElement;
            recipes?.RemoveAll();

            foreach (var recipe in _recipes)
            {
                var recipeEl = doc.CreateElement("recipe");

                var idAttr = doc.CreateAttribute("id");
                idAttr.Value = (recipe.Id).ToString();
                recipeEl.Attributes.Append(idAttr);

                var nameEl = doc.CreateElement("name");
                nameEl.InnerText = recipe.Name;
                recipeEl.AppendChild(nameEl);

                var ingridientsEl = doc.CreateElement("ingridients");
                recipeEl.AppendChild(ingridientsEl);

                foreach (var ingridient in recipe.Ingridients)
                {
                    var ingridientEl = doc.CreateElement("ingridient");
                    nameEl = doc.CreateElement("name");
                    nameEl.InnerText = ingridient.Name;
                    ingridientEl.AppendChild(nameEl);
                    var quantityEl = doc.CreateElement("quantity");
                    quantityEl.InnerText = (ingridient.Quantity).ToString(CultureInfo.InvariantCulture);
                    ingridientEl.AppendChild(quantityEl);
                    var measureAttr = doc.CreateAttribute("measure");
                    measureAttr.Value = (ingridient.Measure);
                    quantityEl.Attributes.Append(measureAttr);
                    ingridientsEl.AppendChild(ingridientEl);
                }

                var cookingEl = doc.CreateElement("cooking");
                cookingEl.InnerText = recipe.Cooking;
                recipeEl.AppendChild(cookingEl);

                var numberOfServingsEl = doc.CreateElement("numberOfServings");
                numberOfServingsEl.InnerText = (recipe.NumberOfServings).ToString();
                recipeEl.AppendChild(numberOfServingsEl);

                var caloricContentEl = doc.CreateElement("caloricContent");
                recipeEl.AppendChild(caloricContentEl);

                var proteinsEl = doc.CreateElement("proteins");
                proteinsEl.InnerText = (recipe.CalContent.Proteins).ToString();
                caloricContentEl.AppendChild(proteinsEl);

                var fatsEl = doc.CreateElement("fats");
                fatsEl.InnerText = (recipe.CalContent.Fats).ToString();
                caloricContentEl.AppendChild(fatsEl);

                var carbohydratesEl = doc.CreateElement("carbohydrates");
                carbohydratesEl.InnerText = (recipe.CalContent.Carbohydrates).ToString();
                caloricContentEl.AppendChild(carbohydratesEl);

                if (doc.DocumentElement != null) doc.DocumentElement.AppendChild(recipeEl);
            }
            
            doc.Save("phonebook.xml");
        }
        public void AddRecipe(Recipe newRecipe)
        {
            if (_recipes != null && _recipes.Count > 0)
            {
                newRecipe.Id = _recipes.Last().Id;
            }
            else
            {
                newRecipe.Id = 1;
            }
            if (_recipes != null) _recipes.Add(newRecipe);
            WriteData();
        }
        public void AddRecipe(String newName, List<Ingridient> newIngridients, String newCooking, Int32 newNumberOfServings, CaloricContent newCalContent)
        {
            Recipe newRecipe = new Recipe();
            newRecipe.Name = newName;
            newRecipe.Ingridients = newIngridients;
            newRecipe.Cooking = newCooking;
            newRecipe.NumberOfServings = newNumberOfServings;
            newRecipe.CalContent = newCalContent;
            if (_recipes != null && _recipes.Count > 0)
            {
                newRecipe.Id = _recipes.Last().Id;
            }
            else
            {
                newRecipe.Id = 1;
            }
            if (_recipes != null) _recipes.Add(newRecipe);
            WriteData();
        }
        public void DelRecipe(Int32 index)
        {
            _recipes.Remove(_recipes[index]);
        }
        public void DelRecipe(Recipe delRecipe)
        {
            _recipes.Remove(delRecipe);
        }
        public void ClearRecipes()
        {
            _recipes.Clear();
        }
        public Recipe GetRecipe(int index)
        {
            if (index >= _recipes.Count)
            {
                return null;
            }
            return _recipes[index];
        }
        public List<Recipe> GetRecipes()
        {
            return _recipes;
        }
        public void Print(Int32 index) // вывод элемента по индексу
        {
            if (index >= _recipes.Count)
            {
                Console.WriteLine("Your index is very big! {0}", index);
            }
            Console.WriteLine(GetRecipe(index).ToString());
        }
        public void Print() // вывод всех элементов
        {
            foreach (var recipe in _recipes)
            {
                Console.WriteLine("================================");
                Console.WriteLine(recipe.ToString());
                Console.WriteLine("================================");
            }
        }
    }
}
