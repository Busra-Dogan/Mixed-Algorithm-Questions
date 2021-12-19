using System;
using System.Collections.Generic;

namespace FeaturedProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = new string[]
            {
                "redShirt",
                "greenPants",
                "redShirt",
                "orangeShoes",
                "blackPants",
                "blackPants",
                "blackPants",
                "orangeHat",
                "orangeHat",
                "orangeHat"
            };

            var map = new Dictionary<string, int>();
            for (int i = 0; i < products.Length; i++)
            {
                if (!map.ContainsKey(products[i]))
                {
                    map.Add(products[i], 0);
                }


            }
            int maxDeger = map[products[0]];
            int sayac = 0;
            for (int i = 0; i < products.Length; i++)
            {
                for (int j = 0; j < products.Length; j++)
                {
                    if (products[i] == products[j])
                    {
                        for (int k = 0; k < j; k++)
                        {
                            if (products[k] == products[i])
                                sayac = -1;
                        }
                        sayac++;
                        map[products[i]] += sayac;
                    }
                }

                sayac = 0;
                if (maxDeger < map[products[i]])
                { maxDeger = map[products[i]]; }
            }
            List<string> productsMax = new List<string>();

            foreach (KeyValuePair<string, Int32> author in map)
            {
                if (author.Value == maxDeger)
                {
                    productsMax.Add(author.Key);
                }

            }

            productsMax.Sort();
            var featuredProcut = productsMax[productsMax.Count - 1];

            Console.WriteLine(featuredProcut);
        }
    }
}
