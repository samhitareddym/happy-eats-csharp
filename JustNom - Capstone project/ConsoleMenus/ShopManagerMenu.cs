using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustNom___Capstone_project.ConsoleMenus
{
    internal class ShopManagerMenu : ConsoleMenu
    {
        private ShopManager _manager;
        private Shop shopTemp;

        public ShopManagerMenu(ShopManager manager)
        {
            _manager = manager;
        }

        public ShopManagerMenu(ShopManager manager, Shop shopTemp) : this(manager)
        {
            this.shopTemp = shopTemp;
        }

        public override string MenuText()
        {
            return "Shop Manager Menu" + Environment.NewLine + _manager.ToString();
        }

        public override void CreateMenu()
        {
            _menuItems.Clear();
            _menuItems.Add(new AddFoodItemMenuItem(shopTemp));
            _menuItems.Add(new ExitMenuItem(this));           
        }
    }
}
