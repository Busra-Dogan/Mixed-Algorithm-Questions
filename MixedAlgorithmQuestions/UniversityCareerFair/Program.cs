using System;
using System.Collections.Generic;

namespace UniversityCareerFair
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> companiesArrivals = new List<int>();
            List<KeyValuePair<int, int>> conflicts = new List<KeyValuePair<int, int>>();
            List<int> arrivals = new List<int>();
            List<int> durations = new List<int>();

            int countOfFair = 0;

            arrivals.Add(1);
            arrivals.Add(3);
            arrivals.Add(3);
            arrivals.Add(5);
            arrivals.Add(7);
            arrivals.Add(8);
            arrivals.Add(8);
            arrivals.Add(9);
            arrivals.Add(9);

            durations.Add(2);
            durations.Add(2);
            durations.Add(3);
            durations.Add(2);
            durations.Add(1);
            durations.Add(3);
            durations.Add(2);
            durations.Add(5);
            durations.Add(4);

            int tekrar = 0;
            for (int i = 0; i < arrivals.Count; i++)
            {
                for (int j = 0; j < arrivals.Count; j++)
                {
                    if (arrivals[i] == arrivals[j])
                    {
                        for (int k = 0; k < i; k++)
                        {
                            if (arrivals[k] == arrivals[i])
                                tekrar = -1;
                        }
                        tekrar++;
                    }
                }
                if (tekrar == 1)
                {
                    countOfFair++;
                }
                if (tekrar > 1)
                {
                    Console.WriteLine(arrivals[i] + " saatinde " + tekrar + " tane sunum vardır.");
                    companiesArrivals.Add(arrivals[i]);
                    for (int t = 0; t < arrivals.Count; t++)
                    {
                        if (arrivals[t] == arrivals[i])
                        {
                            Dictionary<int, int> dict = new Dictionary<int, int>();
                            dict.Add(arrivals[t], durations[t]);
                            foreach (KeyValuePair<Int32, Int32> item in dict)
                            {
                                conflicts.Add(item);
                                dict.Clear();
                            }
                        }
                    }
                    countOfFair++;
                }
                tekrar = 0;
            }

            for (int i = 0; i < companiesArrivals.Count; i++)
            {
                List<int> companiesDurations = new List<int>();
                foreach (KeyValuePair<Int32, Int32> item in conflicts)
                {
                    if (item.Key == companiesArrivals[i])
                    {
                        companiesDurations.Add(item.Value);

                    }
                }
                int minDuration = companiesDurations[0];
                foreach (var item2 in companiesDurations)
                {

                    if (item2 < minDuration)
                    {
                        minDuration = item2;
                    }
                }
                Console.WriteLine("Çakışanlar içinden seçilen sunum adı: " + companiesArrivals[i] + " süresi: " + minDuration);
                companiesDurations.Clear();
            }

            Console.WriteLine("University Career Fair içerisinde toplam " + countOfFair + " adet sunum yapılabilir.");
        }
    }
}
