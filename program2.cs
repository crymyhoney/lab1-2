using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main1()
    {
        string inputFilePath = "input.json";
        string outputFilePath = "output.json";

        try
        {
            string jsonInput = File.ReadAllText(inputFilePath);
            var inputDict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonInput);
            var groupedByValue = inputDict
                .GroupBy(pair => pair.Value)
                .Where(group => group.Count() > 1)
                .ToDictionary(group => group.Key, group => group.Select(pair => pair.Key).ToList());
            string jsonOutput = JsonSerializer.Serialize(groupedByValue, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputFilePath, jsonOutput);
            Console.WriteLine("Результат збережено у 'output.json'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
    }
}