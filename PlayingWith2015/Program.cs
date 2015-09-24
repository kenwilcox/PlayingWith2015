using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlayingWith2015
{
    class Program
    {
        static void Main(string[] args)
        {
            var me = new Person() { Name = "Ken", DOB = DateTime.Now.AddDays(-1), FavoriteFood = new Food { Name = "Spicy"} };
            Console.WriteLine($"{me}");

            var age = 1;
            var s = $"{me.Name} is {age} year{(age == 1? "": "s")} old";
            Console.WriteLine(s);

            Console.ReadKey();
        }
    }

    class MyObject: Object
    {
        public override string ToString()
        {
            var ret = "";
            foreach(PropertyInfo pi in this.GetType().GetProperties())
            {
                var t = pi.GetValue(this).GetType();
                ret += $"{pi.Name}:{t} == {pi.GetValue(this)}" + Environment.NewLine;
            }
            return ret;
        }
    }

    class Person: MyObject
    {
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public Food FavoriteFood { get; set; }
    }

    class Food: MyObject
    {
        public string Name { get; set; }
    }
}
