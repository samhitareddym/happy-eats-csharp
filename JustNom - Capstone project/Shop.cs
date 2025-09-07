using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
     public class Shop
    {

        public string name
        {
            get { return _name; }
            set {
                SError.IsAlphaNumeric(value);                
                _name = value; }
        }
        public List<Topping> Toppings
        {
            get { return _Toppings; }
            set {
                SError.IsNameNotNull(_name);    
                _Toppings = value;
            }
        }
        public List<Garnish> Garnishes
        {
            get { return _Garnishes; }
            set
            {
                SError.IsNameNotNull(_name);
                _Garnishes = value;
            }
        }
        public List<Pizza> Pizzas
        {
            get { return _Pizzas; }
            set
            {              
                _Pizzas = value;
            }
        }
        public List<Burger> Burgers
        {
            get { return _Burgers; }
            set
            {              
                _Burgers = value;
            }
        }

        private string _name;
        private List<Topping> _Toppings;
        private List<Garnish> _Garnishes;
        private List<Pizza> _Pizzas;
        private List<Burger> _Burgers;
        public Shop()
        {
            Pizzas = new List<Pizza>();
            Burgers = new List<Burger>();

        }
        
     }
}
