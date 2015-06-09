﻿using System;
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
            var me = new Person() { Name = "Ken", DOB = DateTime.Now.AddDays(-1), FavoriteFood = new List<string> { "Spicy", "Yummy" } };
            Console.WriteLine($"{me}");

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
        public List<string> FavoriteFood { get; set; }

        public Person()
        {
            FavoriteFood = new List<string>();
        }
    }
}
