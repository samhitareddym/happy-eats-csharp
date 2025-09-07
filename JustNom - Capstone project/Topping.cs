using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
     public class Topping : Ingredient
    {       
        public Topping(string Name, double Price) : base(Name, Price)
        { }

        public override bool Equals(object? other)
        {
            return base.Equals(other);
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
