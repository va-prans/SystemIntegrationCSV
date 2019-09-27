using System;
using System.Collections.Generic;
using System.IO;
using ChoETL;

namespace SystemIntegrationCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string csvData = File.ReadAllText("C:\\Users\\SkyNet\\source\\repos\\SystemIntegrationCSV\\SystemIntegrationCSV\\csvFile1.csv");
            Console.WriteLine(csvData);

            var reader = new ChoCSVReader("C:\\Users\\SkyNet\\source\\repos\\SystemIntegrationCSV\\SystemIntegrationCSV\\csvFile1.csv").WithFirstLineHeader();
            dynamic rec;
            List<string> names = new List<string>();
            List<string> surnames = new List<string>();
            List<string> notes = new List<string>();

            while ((rec = reader.Read()) != null)
            {
                Console.WriteLine(String.Format("Name: {0}", rec.Name) + " " +
                                  String.Format("Surname: {0}", rec.Surname) + " " +
                                  String.Format("Email: {0}", rec.Email) + " " +
                                  String.Format("Note: {0}", rec.Note));
                names.Add(rec.Name);
                surnames.Add(rec.Surname);
                notes.Add(rec.Note);
            }
            Console.WriteLine("----------------Result------------------");
            Console.WriteLine($"Hi, your names are {names[0]}, {names[1]}, {names[2]}");
            Console.WriteLine($"your last names are {surnames[0]}, {surnames[1]}, {surnames[2]}");
            Console.WriteLine("The notes are:");
            foreach (var note in notes)
            {
                Console.WriteLine(note);
            }
            Console.ReadKey();
        }
    }
}
