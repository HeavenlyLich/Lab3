using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ind
{
    class Dogs
    {
        public static List<Dog> DogsList = new List<Dog>();
        public static void Add(Dog d)
        {
            DogsList.Add(d);
        }
        public static void Show()
        {
            foreach (Dog d in DogsList)
            {
                d.PrintToConsole();
            }
        }
    }

    class Dog
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public string Color { get; private set; }

        public Dog(string name, int weight, string color)
        {
            Name = name;
            Weight = weight;
            Color = color;
        }

        public void PrintToConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Ім'я собаки:{Name}");
            Console.WriteLine($"Вага собаки:{Weight} кг");
            Console.WriteLine($"Колір собаки:{Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"D:\visual\XMLFile2.xml");
            foreach (XmlNode node in xml.DocumentElement)
            {
                string name = node["dogName"].InnerText;
                int weight = Int32.Parse(node["dogWeight"].InnerText);
                string color = node["dogColor"].InnerText;

                Dogs.Add(new Dog(name, weight, color));
            }
            Dogs.Show();
        }
    }
}
