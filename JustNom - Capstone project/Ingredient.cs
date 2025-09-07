using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
    public abstract class Ingredient
    {
        private string _Name;
        private double _Price;

        public double Price
        {
            get { return _Price; }
            set
            {
                SError.IsNegative(value);
                _Price = value;
            }
            }
        public string Name
        {
            get { return _Name; }
            set {

                SError.IsAlphaNumeric(value);
                _Name = value;
            }
        }
        public Ingredient(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        public override string ToString()
        {
           return Name ;
            
        }
        public override bool Equals(object? other)
        {
            return Name == ((Ingredient)other).Name;
        }
    }
}
