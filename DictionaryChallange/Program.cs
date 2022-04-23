using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryChallange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();
            string path = @"c:\temp\challenge.txt";
            try
            {
                using(StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string [] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int vote = int.Parse(line[1]);
                        if (votes.ContainsKey(name))
                        {
                            vote += votes[name];
                            votes[name] = vote;
                        }
                        else
                        {
                            votes.Add(name, vote);
                        }

                    }
                    foreach(var item in votes)
                    {
                        Console.WriteLine(item.Key + " : " + item.Value);    
                        
                    }
                }
            }catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
