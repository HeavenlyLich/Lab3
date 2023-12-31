﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ind
{
    class Cars
    {
        public static List<Shop> CarsList = new List<Shop>();
        public static void Add(Shop s)
        {
            CarsList.Add(s);
        }
        public static void Show()
        {
            foreach (Shop id in CarsList)
            {
                id.PrintToConsole();
            }
        }
    }

    class Shop
    {
        public string Id { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public int Price { get; private set; }

        public Shop(string id, string model, int year, int price)
        {
            Id = id;
            Model = model;
            Year = year;
            Price = price;
        }

        public void PrintToConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Автосалон:{Id}");
            Console.WriteLine($"Марка:{Model}");
            Console.WriteLine($"Рік:{Year}");
            Console.WriteLine($"Ціна:{Price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"D:\visual\XMLFile1.xml");
            foreach (XmlNode node in xml.DocumentElement)
            {
                string id = node.Attributes[0].InnerText;
                string model = node["model"].InnerText;
                int year = Int32.Parse(node["year"].InnerText);
                int price = Int32.Parse(node["price"].InnerText);
                Cars.Add(new Shop(id, model, year, price));
                
            }
            Cars.Show();
        }
    }
}
