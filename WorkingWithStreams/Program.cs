using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithStreams
{
    class Program
    {
        // определение массива позывных пилота Viper
        static string[] callsigns = new string[] { "Husker", "Starbuck",
            "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };

        static void Main(string[] args)
        {
            
        }


        // запись в текстовый файл 
        static void WorkWithText()
        {
            // определение файла для записи
            string textFile = Combine(CurrentDirectory, "streams.txt");
            // создание текстового файла и возвращение помощника записи
            StreamWriter text = File.CreateText(textFile);
            // перечисление строк с записью каждой из них в поток в отдельной строке
            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Close(); // release resources
                          // вывод содержимого файла в консоль
            WriteLine($"{textFile} contains { new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));
        }

    }
}
