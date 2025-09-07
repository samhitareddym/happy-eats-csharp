using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustNom;

namespace JustNom___Capstone_project.ConsoleMenus
{
    public class ManagerMenu : MenuItem
    {
        public override string MenuText()
        {
            StringBuilder sb3 = new StringBuilder();
            int k = 1;

            sb3.AppendLine($"{k++}. Place new order");
            sb3.Append($"{k++}. Display all orders\n");
            sb3.AppendLine($"{k++}. Display Total cost");
            sb3.AppendLine($"{k++}. Save orders to file");
            sb3.AppendLine($"{k++}. Exit");

            return sb3.ToString();
        }

        public override void Select()
        {
            bool IsSaved = true;

            do
            {
                int c = ConsoleHelpers.GetIntegerInRange(1, 5, MenuText());
               
                // These if condition place new order, display all orders, display total cost, save orders to file, and exit.
                if (c == 2)
                {
                    foreach (var item in TakeawayShop.Orders)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (c == 3)
                {
                    double totalsum = 0;
                    foreach (var item in TakeawayShop.Orders)
                    {
                        totalsum += item.Price;
                    }
                    Console.WriteLine(SError.StrPrice(totalsum));
                }
                else if (c == 4)
                {
                    Console.WriteLine("enter a file name");
                    string FileName = Console.ReadLine();
                    string D = Directory.GetCurrentDirectory();
                    string FM = D + "\\" + FileName + ".txt";
                    File.WriteAllText(FM, string.Join('\n', TakeawayShop.Orders));
                }
                // If place new order or exit is chosen it exits this do while loop.
                else
                {
                    IsSaved = false;
                }

            } while (IsSaved);
           
           
        }
    }
}
