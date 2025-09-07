using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project.ConsoleMenus
{
    public class ShopManager
    {
        public List<FoodItem> Foods { get; private set; }
        public ShopManager()
        {
            Foods = new List<FoodItem>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (FoodItem food in Foods)
            {
                sb.Append(food.ToString() + Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
