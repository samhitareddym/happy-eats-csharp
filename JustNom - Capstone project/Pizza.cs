using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JustNom___Capstone_project
{
    public class Pizza : FoodItem
    {
        public List<Topping> Toppings;
        public Pizza(string name, double price, List<Ingredient> topping) : base(name, price, topping)
        { }
        public override string? ToString()
        {

            return base.ToString();
        }
        public override FoodItem Copy()
        {
            List<Ingredient> I = new List<Ingredient>();
            foreach (var item in base.Ingredients)
            {
                I.Add(new Topping(item.Name, item.Price));
            }
            return new Pizza(base.Name, base.Price, I);
        }
    }
}
