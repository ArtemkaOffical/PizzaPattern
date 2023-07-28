namespace PizzaPattern.Ingredients
{
    public class Pasta : Ingredient
    {
        public Type TypePasta { get; private set; }

        public Pasta(string name, Type typePasta) : base(name)
        {
            TypePasta = typePasta;
        }
        public override void Change()
        {
            Console.WriteLine("input Tomato or Mazik for pasta");
            string input = Console.ReadLine();
            Type value = GetSomeValueInterface<Type>(input);
            TypePasta = value;
            Console.WriteLine("pasta type = " + value);
        }

        public enum Type
        {
            Tomato,
            Mazik
        }
    }
}