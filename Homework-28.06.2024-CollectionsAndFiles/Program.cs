using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Homework_28._06._2024_CollectionsAndFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = @"C:\Users\Asus\OneDrive\Рабочий стол\Kobzar.txt";

            FileStream fs = new (filePath, FileMode.Open);

            StreamReader reader = new(fs);

            string text = reader.ReadToEnd();

            text = Regex.Replace(text.ToLower(), @"[^\w\s]", "");

            string[] words = text.Split(' ', '\t', '\n', '\r');
            Dictionary<string, int> wordCounts = [];
            foreach (string word in words)
            {
                if (word.Length >= 3 && word.Length <= 20)
                {
                    if (wordCounts.ContainsKey(word))
                    {
                        wordCounts[word]++;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            Console.WriteLine("+----+-----------+-----------------+");
            Console.WriteLine("|  № |   слово   | встречается раз |");
            Console.WriteLine("+----+-----------+-----------------+");

            for (int i = 0; i < 50; i++)
            {
                string? word = null;
                int count = 0;

                foreach (var current in wordCounts)
                {
                    if (current.Value > count)
                    {
                        word = current.Key;
                        count = current.Value;
                    }
                }

                if (word == null)
                    break;

                Console.Write("| {0, -3}", i + 1);
                Console.Write("|{0, -10}","\t " + word);
                Console.Write("|{0, 12}", count + "\t  |");
                Console.WriteLine();
                wordCounts.Remove(word);
            }
            Console.WriteLine("+----+-----------+-----------------+");

            reader.Close();
            fs.Close();
        }
    }
}
