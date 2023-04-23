using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class UniqueWords
    {
        static void Main(string[] args) //путь к текстовому файлу следует передать в аргументе командной строки
        {
            try
            {
                string line;
                string tmp;

                Regex regex = new Regex("[^\\p{L}'-]+");
                List<string> book = new List<string>();
                List<string> wordsList = new List<string>();
                Dictionary<string, int> occurrencesMap = new Dictionary<string, int>();
                int numberOfOccurrences = 1;

                StreamReader streamReader = new StreamReader(args[0]);
                while ((line = streamReader.ReadLine()) != null)
                {
                    book.Add(line);
                }
                streamReader.Close();

                for (int i = 0; i < book.Count; i++)
                {
                    tmp = book[i];
                    string[] words = regex.Split(tmp);
                    for (int j = 0; j < words.Length; j++)
                    {
                        wordsList.Add(words[j].ToLower());
                    }
                }

                for (int i = 0; i < wordsList.Count; i++)
                {
                    if (wordsList[i].Equals("") || wordsList[i].Equals("--") || wordsList[i].Equals("-"))
                    {
                        wordsList.RemoveAt(i);
                        i--;
                    }
                }

                for (int i = 0; i < wordsList.Count; i++)
                {

                    if (!occurrencesMap.ContainsKey(wordsList[i]))
                    {
                        occurrencesMap.Add(wordsList[i], numberOfOccurrences);
                    }
                    else
                    {
                        occurrencesMap[wordsList[i]]++;
                    }
                }

                var sortedMap = occurrencesMap.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                StreamWriter streamWriter = new StreamWriter("result.txt");

                foreach (var entry in sortedMap)
                {
                    streamWriter.WriteLine(String.Format("{0,-30}{1}", entry.Key, entry.Value));
                }
                streamWriter.Close();

            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}