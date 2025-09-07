using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace JustNom___Capstone_project.ConsoleMenus
{
    internal class AddFoodItemMenuItem : MenuItem
    {
        public Shop shoptemp;
        public Order Order;
        public AddFoodItemMenuItem( Shop shoptemp)
        {
            this.shoptemp = shoptemp;
        }
        public override string MenuText()
        {
            return "place order";
        }

        // This select also takes the name, and asks if it is delivery, and they enter 'Y' a delivery cost is added.
        public override void Select()
        {
            StringBuilder sb = new StringBuilder($"{MenuText()}{Environment.NewLine}");
            int i = 1;
            Console.WriteLine("Please enter your name");
            string CustomerName = Console.ReadLine();
            Console.WriteLine("Is this a delivery?");
            Console.WriteLine("Enter Y for yes and N for no");
            string IsDelivery = Console.ReadLine();

            Order = new Order();

            Order.CustomerName = CustomerName;
            Order.IsDelivery = IsDelivery == "Y";

            if (Order.IsDelivery)
            {
                Console.WriteLine("Enter delivery address");
                string DeliveryAdd = Console.ReadLine();
                Order.Price += 200;
            }

            // This checks if the total cost exceeds £20 and if it does it takes makes the delivery free.

            if (Order.IsDelivery)
            {
                sb.Append(Order.Price >= 2200 ? $"Delivery free for " + CustomerName : $"delivery cost for {CustomerName} is £2.00");

            }
            Console.WriteLine(Order);

            Recipe recipe = new Recipe(shoptemp, Order);
            recipe.Select();
            
        }
    }
}