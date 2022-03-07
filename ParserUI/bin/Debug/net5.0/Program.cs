using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using ParserLibrary.Databases;
using static System.Net.Mime.MediaTypeNames;

namespace ParserUI
{
    class Program
    {
        private static string csvFile; //= "TacoBell-US-AL.csv";
        private static ParserControl control = new ParserControl();

        static void Main(string[] args)
        {

            csvFile = GetFile();
            var locations = control.ReadAllRecords(csvFile);
            control.GetFurthestLocations(locations);
            Console.ReadLine();
        }

        private static string GetFile()
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location.Substring(0, Assembly.GetEntryAssembly().Location.IndexOf("bin\\")));
            string fileFolder = "\\DataFile\\";

            string fileName = "";

            foreach (var files in Directory.GetFiles("DataFile"))
            {
                FileInfo info = new FileInfo(files);
                fileName = string.Concat(Path.GetFileName(info.FullName));
            }

            return path + fileFolder + fileName;
        }

    }
}