// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using System.Xml.Linq;
using JustNom___Capstone_project;
using JustNom___Capstone_project.ConsoleMenus;
using static System.Net.Mime.MediaTypeNames;

namespace JustNom
{
    /// <summary>
    /// Sahasra's capstone project
    /// </summary>
    public class TakeawayShop
    {
        public static List<Order> Orders = new List<Order>();
        public static void Main(string[] args)
        {
            string[] files = Directory.GetFiles(Environment.CurrentDirectory, "*nom");

            Console.WriteLine("please select a file ");

            for (int P = 0; P < files.Length; P++)
            {
                Console.WriteLine($"{P + 1}. {files[P].Substring(files[P].LastIndexOf('\\') + 1)}");
            }

            int SelectedFileNumber = selectFile(1, files.Length);
            try
            {
                (string[] lines, Shop ShopTemp) = LoadFile(SelectedFileNumber, files);
                Console.WriteLine(ShopTemp.name);
                ShopManager shopManager = new ShopManager();
                ShopManagerMenu menu = new ShopManagerMenu(shopManager, ShopTemp);
                menu.Select();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }

        }

        public static int selectFile(int min, int max)
        {
            int selectedNumber;
            do
            {
                string input = Console.ReadLine();

                if ((int.TryParse(input, out selectedNumber)) & ((selectedNumber >= min) & (selectedNumber <= max)))
                {
                    return selectedNumber;
                }

                else
                {
                    Console.WriteLine("it is not a valid input");
                }

            } while (true);

        }

        // The LoadFile Method loads the file selected by the user and splits the data into: Name, Toppings, Garnishes, Pizza, Burgers.
        public static (string[], Shop) LoadFile(int selectedNumber, string[] files)
        {
            string[] lines;
            int selectedFile = selectedNumber - 1;
            lines = File.ReadAllLines(files[selectedFile]);
            Shop ShopTemp = null;
            ShopTemp = new Shop();

            foreach (string line in lines)
            {
                // If there is an empty line, it can continue and read the next one.
                if(line == string.Empty)
                {
                    continue;
                }

                string[] words = line.Split(':');
                string NameOfFood = words[0];
                string val = words[1];

                switch (NameOfFood)
                { 
                    case "Name":
                        {

                            ShopTemp.name = val;

                            break;
                        }

                    case "Toppings":
                        {
                            SError.IsNameNotNull(ShopTemp.name);
                            

                            if (ShopTemp.Garnishes != null)
                            {
                                throw new Exception("Fail - Topping and Garnishes in wrong order");
                            }

                            // Splits the toppings in the file and adds to the topping list created

                            char[] separators = new char[] { '<', '>' , ',', '[',']'};
                            string[] subs = val.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            List<Topping> Toppings = new List<Topping>();

                            for (int i = 0; i < subs.Length; i+=2)
                            {
                                double val1 = 0;
                                try
                                {
                                    val1 = double.Parse(subs[i + 1]);
                                    if (val1< 0)
                                    {
                                        throw new Exception("Fail - negative price");
                                    }
                                }
                                catch (Exception)
                                {

                                    throw new Exception("Fail - non-numeric price");
                                }
                                Topping TempT = new Topping(subs[i], val1);
                                Toppings.Add(TempT);
                            }

                            ShopTemp.Toppings = new List<Topping>(Toppings);

                            if (ShopTemp.Toppings == null)
                            {
                                throw new Exception("Fail - no toppings list");
                            }

                            break;
                        }

                    case "Garnishes":
                        {
                            SError.IsNameNotNull(ShopTemp.name);                           
                            // Splits garishes from the file and adds to the garnish list created
                            char[] separators = new char[] { '<', '>', ',', '[', ']' };

                            string[] subs = val.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                            List<Garnish> Garnishes = new List<Garnish>();

                            for (int i = 0; i < subs.Length; i += 2)
                            {
                                double val2 = 0;
                                try
                                {
                                    val2 = double.Parse(subs[i + 1]);
                                    if (val2 < 0)
                                    {
                                        throw new Exception("Fail - negative price");
                                    }
                                }
                                catch (Exception)
                                {

                                    throw new Exception("Fail - non-numeric price");
                                }

                                Garnish TempG = new Garnish(subs[i], val2);
                                Garnishes.Add(TempG);
                            }

                            ShopTemp.Garnishes = new List<Garnish>(Garnishes);

                    

                            break;
                        }
                    case "Pizza":
                        {
                            SError.IsNameNotNull(ShopTemp.name);

                            // Splits pizzas in the file by name, toppings avaible in the food, and price using pattern
                            string pattern = @"Name:([^,]+),Toppings:\[([\w\s,]*)\],Price:(-*\d*\w*)";
                            Match match = Regex.Match(line, pattern);

                            if (match.Success)
                            {
                                string name = match.Groups[1].Value;
                                string[] toppings = match.Groups[2].Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                
                                List<Ingredient> Toppings = new List<Ingredient>();

                                string nameT = null;
                                Topping TempT = null;

                                for (int i = 0; i < toppings.Length; i ++)
                                {

                                    if (ShopTemp.Toppings == null)
                                    {
                                        throw new Exception("Fail - no toppings list");
                                    }

                                     nameT = toppings[i].Trim();
                                     TempT = new Topping(nameT, 0);

                                    if (!ShopTemp.Toppings.Contains(TempT))
                                    {
                                        throw new Exception("Fail - toppings not in toppings list");
                                    }
                                    else
                                    {
                                        TempT = ShopTemp.Toppings.FirstOrDefault(x => x.Name == nameT);
                                    }

                                    if (TempT != null)
                                    {
                                        Toppings.Add(TempT);
                                    }
                                    
                                }

                                double val3 = 0;
                                val3 = SError.ParseDouble(match.Groups[3].Value);

                                double price = val3;
                                Pizza pizza = new Pizza(name, price, Toppings) ;

                                ShopTemp.Pizzas.Add(pizza);                               
                            }

                            break;
                        }
                    case "Burger":
                        {
                            SError.IsNameNotNull(ShopTemp.name);

                            // Splits burgers in the file by name, garnishes avaible in the food, and price using pattern
                            string pattern = @"Name:([^,]+),Garnishes:\[([\w\s,]*)\],Price:(-*\d*\w*)";                            
                            Match match = Regex.Match(line, pattern);

                            if (match.Success)
                            {
                                string name = match.Groups[1].Value;
                                string[] Garnishstr = match.Groups[2].Value.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                                
                                List<Ingredient> Garnishes = new List<Ingredient>();

                                string nameG = null;
                                Garnish TempG = null;

                                for (int i = 0; i < Garnishstr.Length; i++)
                                {
                                    nameG = Garnishstr[i].Trim();
                                    TempG = new Garnish(nameG, 0);

                                    if (!ShopTemp.Garnishes.Contains(TempG))
                                    {
                                        throw new Exception("Fail - garnishes not in garnish list");
                                    }

                                }

                                if (ShopTemp.Garnishes == null)
                                {
                                    throw new Exception("Fail - no garnish list");
                                }
                                else
                                {
                                    TempG = ShopTemp.Garnishes.FirstOrDefault(x => x.Name == nameG);
                                }

                                if (TempG != null)
                                {
                                    Garnishes.Add(TempG);
                                }
                                
                                double val4 = 0;
                                val4 = SError.ParseDouble(match.Groups[3].Value);

                                double price = val4;
                                Burger burger = new Burger(name, price, Garnishes);

                                ShopTemp.Burgers.Add(burger);

                            }

                            break;
                        }
                }
            }

            if (ShopTemp.Toppings == null)
            {
                throw new Exception("Fail - no toppings list");
            }

            if (ShopTemp.Garnishes == null)
            {
                throw new Exception("Fail - no garnish list");
            }

            return (lines, ShopTemp);
        }
    }
}
