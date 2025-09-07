using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
    public abstract class FoodItem
    {
        private string name;
        private double price;
        private List<Ingredient> ingredients;

        public string Name { get => name; set { SError.IsAlphaNumeric(value);  name = value; } }
        public double Price { get => price; set { SError.IsNegative(value); price = value; } }
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }

        protected FoodItem(string name, double price)
        {
            Name = name;
            Price = price;
            Ingredients = new List<Ingredient>();
        }
        protected FoodItem(string name, double price, List<Ingredient> ingredients) : this(name, price)
        {
            this.Ingredients = ingredients;
        }
        public void AddIngredients (Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            this.Price += ingredient.Price;
            Console.WriteLine("Extra " + ingredient + " " + SError.StrPrice(ingredient.Price));

        }
        public void RemoveIngredients(Ingredient ingredient)
        {
            bool IsRemoved = Ingredients.Remove(ingredient);
            if (IsRemoved == true)
            {
                Console.WriteLine(ingredient + " has been removed");
            }
        }

        public override string? ToString()
        {
            return Name + " (" + string.Join(", ", Ingredients) + ") " + SError.StrPrice(Price) + "\n";
        }
        public abstract FoodItem Copy();
       
    }
}
