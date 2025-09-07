using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustNom;
using JustNom___Capstone_project.ConsoleMenus;
namespace JustNom___Capstone_project
{
    internal  class Recipe: ConsoleMenu
    {
        public Shop shoptemp;
        public Order Order;
        public Recipe (Shop shoptemp, Order Order)
        {
            this.shoptemp = shoptemp;
            this.Order = Order;
        }
        public override void CreateMenu()
        {
            _menuItems.Clear();
        }
        public override string MenuText()
        {
            return "Add food to order";
        }
        public override void Select()
        {
            bool IsSaved = true;
            // This loop diplays all of the fooditems in the menu.
            do
            {
                #region main food list
                // Allfood contains standrad list of fooditems from file

                List<FoodItem> AllFood = new List<FoodItem>();
                List<FoodItem> p = new List<FoodItem>(shoptemp.Pizzas);
                List<FoodItem> b = new List<FoodItem>(shoptemp.Burgers);
                AllFood.AddRange(p);
                AllFood.AddRange(b);
                StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
                int i = 1;
                FoodItem FoodStD = null;
                foreach (FoodItem foodItem in AllFood)
                {
                    sb.Append($"{i}. {foodItem}");
                    i++;
                }
                sb.Append($"{i}. Exit");

                #endregion 
                
                bool IsFoodActive = true;
                do
                {
                    string FoodMenu = sb.ToString();
                    int selectedIndex = ConsoleHelpers.GetIntegerInRange(1, AllFood.Count + 1, FoodMenu) - 1;
                    if (selectedIndex == AllFood.Count)
                        break;
                    FoodStD = AllFood[selectedIndex];
                    FoodItem food = FoodStD.Copy();
                    List<Ingredient> standarding = new List<Ingredient>(food.Ingredients);
                    Console.WriteLine(food);
                    IsActive = true;

                    #region submenu

                    // This loop adds and removes ingredients and increases and reduces the price accordingly.
                    do
                    {
                        List<Ingredient> ings = new List<Ingredient>(food.Ingredients);
                        if (food is Pizza)
                        {
                            
                            foreach (Ingredient ing in shoptemp.Toppings)
                            {
                                ings.Add(ing);
                            }
                        }
                        else
                        {
                            
                            foreach (Ingredient ing in shoptemp.Garnishes)
                            {
                                ings.Add(ing);
                            }
                        }
                        int j, inbuilting;
                        string IngMenu;
                        createsubmenu(food, out j, out inbuilting, out IngMenu);
                        selectedIndex = ConsoleHelpers.GetIntegerInRange(1, j, IngMenu) - 1;
                        if (selectedIndex == j - 1)
                            break;
                        Ingredient selected = ings[selectedIndex];
                        if (selectedIndex >= inbuilting)
                        {
                            food.AddIngredients(ings[selectedIndex]);
                        }
                        else
                        {
                            // If a ingredient not present in original fooditem, then when the ingredient is removed the price is reduced
                            bool Isstd = false;
                            int count = 0;
                            double price = selected.Price;
                            foreach (var item1 in food.Ingredients)
                            {
                                if (item1.Name == ings[selectedIndex].Name)
                                {
                                    Isstd = FoodStD.Ingredients.Any(x=>x.Name==item1.Name);
                                    count++;
                                    if(item1.Price > 0)
                                    {
                                        price = item1.Price;
                                    }
                                }
                            }
                            
                            if(Isstd && count > 1)
                            {
                                food.Price -= price;
                            }
                            if (!Isstd)
                            {
                                food.Price -= price;
                            }

                            food.RemoveIngredients(ings[selectedIndex]);
                        }
                        Console.WriteLine(food);
                    } while (IsActive);

                    #endregion

                    Order.AddToOrder(food);
                    Console.WriteLine(Order);
                } while (IsFoodActive);


                if (Order.Price >= 2200)
                {
                    Order.Price -= 200;
                    Console.WriteLine();
                }
                TakeawayShop.Orders.Add(Order);

                // I made an object of the Manager Menu class which call the select method in the that class.
                ManagerMenu MM = new ManagerMenu();
                MM.Select();

                IsSaved = false;

            } while (IsSaved);

           
        }

        // This method displays the list ingredients that is associated with the fooditem selected by the user.
        private void createsubmenu(FoodItem food, out int j, out int inbuilting, out string IngMenu)
        {
            StringBuilder sb1 = new StringBuilder();
            j = 1;
            inbuilting = food.Ingredients.Count;
            foreach (Ingredient ing in food.Ingredients)
            {
                if(ing != null)
                {
                    sb1.AppendLine($"{j++}. Remove {ing.Name}");
                }
                
            }
            if (food is Pizza)
            {
                foreach (Ingredient ing in shoptemp.Toppings)
                {
                    sb1.AppendLine($"{j++}. Add {ing}" + $" {SError.StrPrice(ing.Price)}");
                }
            }
            else
            {
                foreach (Ingredient ing in shoptemp.Garnishes)
                {
                    sb1.AppendLine($"{j++}. Add {ing}" + $" {SError.StrPrice(ing.Price)}");
                }
            }
            sb1.Append($"{j}. Exit");
            IngMenu = sb1.ToString();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MenuText());
            for (int i = 0; i < _menuItems.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {_menuItems[i].MenuText()}");
            }
            return sb.ToString();
        }
    }
}
