    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project
{
    public class Order
    {
        public bool IsDelivery;
        public string CustomerName;
        public double Price;
        public string Address;
        public List<FoodItem> Foods;
        public Order()
        {
            Foods = new List<FoodItem>();
        }
        public void AddToOrder(FoodItem Food)
        {
            Foods.Add(Food);
            this.Price += Food.Price;
        }

        // This tostring diplays the customer name, total cost of the customer's order.
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("Customer Name: " + CustomerName + "\n");
            sb.Append("Total cost: " + SError.StrPrice(Price) + "\n");
            foreach (FoodItem food in Foods)
            {
                sb.Append(food.ToString());
            }


            if (IsDelivery)
            {
                sb.Append(Price >= 2200 ? $"Delivery free for " + CustomerName : $"delivery cost for {CustomerName} is £2.00" + "\n");

            }
            return sb.ToString();
        }
    }
}
