using System;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace PlayingWith2015
{
    static class Program
    {
        static void Main(string[] args)
        {
            var me = new Person() { Name = "Ken", Dob = DateTime.Now.AddDays(-1), FavoriteFood = new Food { Name = "Spicy"} };
            Console.WriteLine($"{me}");

            var age = int.Parse(args?[0] ?? "1");
            var s = $"{me.Name} is {age} year{(age == 1? "": "s")} old";
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }

    class MyObject: object
    {
        public override string ToString()
        {
            var ret = "";
            foreach(var pi in GetType().GetProperties())
            {
                // Using the getter here that ReSharper can't "see"
                var t = pi.GetValue(this).GetType();
                ret += $"{pi.Name}:{t} == {pi.GetValue(this)}" + Environment.NewLine;
            }
            return ret;
        }
    }

    class Person: MyObject
    {
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public Food FavoriteFood { get; set; }
    }

    class Food: MyObject
    {
        public string Name { get; set; }
    }
}
