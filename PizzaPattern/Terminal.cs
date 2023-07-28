using PizzaPattern.Builder;
using PizzaPattern.Command;
using PizzaPattern.CommandPattern;
using PizzaPattern.Ingredients;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPattern
{

    public class Terminal
    {
        private Director _director = new Director();
        private CommandExecuter _commandExecuter;
        public bool IsActive { get; private set; }
        public PizzaBuilder[] PizzaBuilders { get; private set; } = null!;
        public Dictionary<Ingredient, decimal> AvailableIngredients { get; private set; } = null!;
        public List<Order> Orders { get; private set; } = new List<Order>();
        public Terminal(CommandExecuter commandExecuter)
        {
            _commandExecuter = commandExecuter;
        }

        public void Init()
        {
            IsActive = true;

            PizzaBuilders = new PizzaBuilder[]
            {
                new MozzarellaPizzaBuilder("Mozzarella"),
                new GreekPizzaBuilder("Greek")
            };

            AvailableIngredients = new Dictionary<Ingredient, decimal>
            {
                [new Dough("Dough",Dough.Type.Thin)] = 15,
                [new Dough("Dough",Dough.Type.Thick)] = 15,
                [new Pasta("Pasta",Pasta.Type.Tomato)] = 15,
                [new Pasta("Pasta",Pasta.Type.Mazik)] = 15,
                [new Cheese("Cheder")] = 20,
                [new Cheese("Parmezan")] = 30,
                [new Cheese("Dorblu")] = 25,
            };

        }

        public Pizza CreatePizza(int id)
        {
            if (id > PizzaBuilders.Length)
                throw new IndexOutOfRangeException();

            _director.SetBuilder(PizzaBuilders[id - 1]);
            _director.Construct();
            return PizzaBuilders[id - 1].GetPizza();
        }

        public void Close()
        {
            IsActive = false;
        }

        public void ChangingIngredientsForPizza(Pizza pizza)
        {
            bool isConfiguringIngredients = true;

            while (isConfiguringIngredients)
            {
                Console.WriteLine("Желаете ли add new или edit или back");
                string input = Console.ReadLine();

                if (input == "back")
                    isConfiguringIngredients = false;

                else if (input == "edit")
                {
                    while (true)
                    {
                        if (pizza.Ingredients.Count == 0)
                            break;

                        KeyValuePair<Ingredient, int> pair;
                        Console.Write("Выберите ингредиент или back: ");
                        Console.WriteLine();
                        for (int i = 0; i < pizza.Ingredients.Count; i++)
                        {
                            pair = pizza.Ingredients.ElementAt(i);
                            int num = i + 1;
                            Console.WriteLine(num + ". " + pair.Key.Name + " - " + pair.Value);
                        }

                        input = Console.ReadLine();

                        if (input == "back")
                            break;
                        else if (input == "undo")
                            _commandExecuter.Undo();

                        if (!int.TryParse(input, out int ingId))
                        {

                            Console.WriteLine("Не удалось преоброзовать в число");
                            continue;
                        }

                        pair = pizza.Ingredients.ElementAt(ingId - 1);
                        Console.WriteLine("Вы выбрали - " + pair.Key.Name + ". Количество - " + pair.Value);
                        Console.WriteLine("add или remove или change(если ингредиент изменяем)");
                        input = Console.ReadLine();

                        if (input == "add")
                            //AddIngredient(pair.Key);
                            _commandExecuter.SetCommand(new AddIngredientCommand(pizza, pair.Key));
                        else if (input == "remove")
                            //RemoveIngredient(pair.Key);
                            _commandExecuter.SetCommand(new RemoveIngredientCommand(pizza, pair.Key));
                        else if (input == "change")
                            _commandExecuter.SetCommand(new ChangeIngredientCommand(pair.Key, pizza));
                    }
                }

                else if (input == "add new")
                {
                    while (true)
                    {
                        KeyValuePair<Ingredient, decimal> pair;
                        for (int i = 0; i < AvailableIngredients.Count; i++)
                        {
                            pair = AvailableIngredients.ElementAt(i);
                            int num = i + 1;
                            Console.WriteLine($"{num}. {pair.Key.Name} за {pair.Value}");
                        }
                        Console.Write("Выберите ингредиент для добавления к пицце или back: ");
                        input = Console.ReadLine();
                        if (input == "back")
                            break;
                        if (!int.TryParse(input, out int id))
                        {

                            Console.WriteLine("Не удалось преоброзовать в число");
                            continue;
                        }
                        pair = AvailableIngredients.ElementAt(id-1);
                        _commandExecuter.SetCommand(new AddIngredientCommand(pizza, pair.Key));
                        Console.WriteLine($"Вы добавили {pair.Key.Name} за {pair.Value}");

                    }
                }
            }
        }

        public void ConfiguringPizzas(Order order)
        {
            bool isConfiguringPizzas = true;
            while (isConfiguringPizzas)
            {
                for (int i = 0; i < PizzaBuilders.Length; i++)
                {
                    int num = i + 1;
                    Console.WriteLine(num + ". " + PizzaBuilders[i].Name);
                }
                Console.Write("Выберите пиццу или back: ");
                string input = Console.ReadLine();

                if (input == "back")
                {
                    isConfiguringPizzas = false;
                    // _commandExecuter.SetCommand(new CloseTerminalCommand(this));
                    break;
                }
                else if (!int.TryParse(input, out int id))
                {
                    Console.WriteLine("cant convert to number");
                    continue;
                }
                else
                {
                    Pizza pizza;
                    Order.PizzaIDontKnowHowNameThisClass pizzaIDontKnowHowNameThisClass;
                    try
                    {
                        pizza = CreatePizza(id);
                        pizzaIDontKnowHowNameThisClass = new Order.PizzaIDontKnowHowNameThisClass(pizza);

                        order.AddPizza(pizzaIDontKnowHowNameThisClass);
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                        continue;
                    }
                    bool isD = true;
                    while (isD)
                    {
                        Console.WriteLine($"Pizza: {pizza}");
                        Console.WriteLine("Изменить ингредиенты? yes или no");

                        input = Console.ReadLine();

                        if (input == "no")
                        {
                            isD = false;
                            Console.WriteLine("Изменить кол-во пиццы? yes или no");
                            input = Console.ReadLine();
                            if (input == "yes")
                            {
                                do
                                {
                                    Console.WriteLine("add или remove или back");
                                    input = Console.ReadLine();
                                    if (input == "add")
                                        //AddIngredient(pair.Key);
                                        _commandExecuter.SetCommand(new AddPizzaCommand(order, pizzaIDontKnowHowNameThisClass));
                                    else if (input == "remove")
                                        //RemoveIngredient(pair.Key);
                                        _commandExecuter.SetCommand(new RemovePizzaCommand(order, pizzaIDontKnowHowNameThisClass));

                                    foreach (var item in order.Pizzas)
                                        Console.WriteLine($"{item.Key.Pizza.Name}:{item.Value}");

                                } while (input != "back");
                            }
                            else if (input == "no")
                            {
                                isConfiguringPizzas = false;
                                break;
                            }
                        }
                        else if (input == "yes")
                            ChangingIngredientsForPizza(pizza);

                    }
                }

            }
        }
      
        public void Start()
        {
            while (IsActive)
            {
                Console.WriteLine("Сделать заказ? yes или no");
                string input = Console.ReadLine();
                if (input == "no")
                {
                    _commandExecuter.SetCommand(new CloseTerminalCommand(this));
                    break;
                }
                else if (input == "yes")
                {
                    Order order = new Order();
                    Console.WriteLine("New order #" + order.Id);
                    ConfiguringPizzas(order);
                    if (order.Pizzas.Count != 0)
                        Orders.Add(order);
                }

            }

            foreach (var order in Orders)
            {
                decimal cost = 0;
                decimal f_cost = 0;
                Console.WriteLine($"-------------Id Order - {order.Id}---------------");
                foreach (var item in order.Pizzas)
                {
                    foreach (var item2 in item.Key.Pizza.Ingredients)
                    {
                        if (AvailableIngredients.ContainsKey(item2.Key))
                            cost += AvailableIngredients[item2.Key] * item2.Value;
                    }
                    cost *= item.Value;
                    Console.WriteLine($"{item.Key.Pizza.Name}x{item.Value} - {cost}");
                    f_cost += cost;
                    cost = 0;
                }
                Console.WriteLine($"ИТОГ: {f_cost}");
                f_cost = 0;
                Console.WriteLine("---------------------------------------------------");
            }

        }
    }
}
