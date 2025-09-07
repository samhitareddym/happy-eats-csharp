using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
    public class Burger : FoodItem
    {
        public List<Garnish> Garnish;
        public Burger(string name, double price, List<Ingredient> garnish) : base(name, price, garnish)
        { }

        public override FoodItem Copy()
        {
            List<Ingredient> I = new List<Ingredient>();
            foreach (var item in base.Ingredients)
            {
                I.Add(new Garnish(item.Name, item.Price));
            }
            return new Burger(base.Name, base.Price, I);
            
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
