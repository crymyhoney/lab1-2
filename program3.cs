using System;
using System.Linq;

class Program3
{
    static void Main2()
    {
        string[] words = { "mama", "papa", "sister", "brother", "apple" };
        int sumLength = words.Sum(word => word.Length);
        Console.WriteLine($"Сума довжин усіх рядків: {sumLength}");
    }
}