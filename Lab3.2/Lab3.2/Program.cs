using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ind
{
    class Realty
    {
        public static List<Location> LocationsList = new List<Location>();
        public static void Add(Location l)
        {
            LocationsList.Add(l);
        }
        public static void Show()
        {
            foreach (Location l in LocationsList)
            {
                l.PrintToConsole();
            }
        }
    }

    class Location
    {
        public string Country { get; private set; }
        public string Region { get; private set; }
        public string District { get; private set; }
        public string LocalityName { get; private set; }
        public string SubLocalityName { get; private set; }
        public string NonAdminSubLocality { get; private set; }
        public string Address { get; private set; }
        public string Direction { get; private set; }

        public Location(string country, string region, string district, string localityName,
                        string subLocalityName, string nonAdminSubLocality,
                        string address, string direction)
        {
            Country = country;
            Region = region;
            District = district;
            LocalityName = localityName;
            SubLocalityName = subLocalityName;
            NonAdminSubLocality = nonAdminSubLocality;
            Address = address;
            Direction = direction;
        }

        public void PrintToConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Країна:{Country}");
            Console.WriteLine($"Регіон:{Region}");
            Console.WriteLine($"Район:{District}");
            Console.WriteLine($"Назва населеного пункту:{LocalityName}");
            Console.WriteLine($"Назва підлокальності:{SubLocalityName}");
            Console.WriteLine($"Назва неадміністративної підлокальності:{NonAdminSubLocality}");
            Console.WriteLine($"Адреса:{Address}");
            Console.WriteLine($"Напрямок:{Direction}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"D:\visual\XMLFile3.xml");

            foreach (XmlNode node in xml.DocumentElement)
            {
                string country = node["country"].InnerText;
                string region = node["region"].InnerText;
                string district = node["district"].InnerText;
                string localityName = node["locality-name"].InnerText;
                string subLocalityName = node["sub-locality-name"] != null ? node["sub-locality-name"].InnerText : "";
                string nonAdminSubLocality = node["non-admin-sub-locality"] != null ? node["non-admin-sub-locality"].InnerText : "";
                string address = node["address"] != null ? node["address"].InnerText : "";
                string direction = node["direction"] != null ? node["direction"].InnerText : "";

                Realty.Add(new Location(country, region, district, localityName,
                                        subLocalityName, nonAdminSubLocality,
                                        address, direction));
            }

            Realty.Show();
        }
    }
}
