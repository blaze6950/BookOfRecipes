namespace BookOfRecipes
{
    class CaloricContent
    {
        public CaloricContent()
        {
            Proteins = 0;
            Fats = 0;
            Carbohydrates = 0;
        }

        public CaloricContent(int proteins, int fats, int carbohydrates)
        {
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }

        public int Proteins { get; set; } // белки
        public int Fats { get; set; } // жиры
        public int Carbohydrates { get; set; } // углеводы
    }
}
