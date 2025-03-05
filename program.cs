using System;
using System.Collections.Generic;

class ParkingLot
{
    private List<string?> parkingSpaces;  
    private int capacity;  
        static void Main()
    {
        ParkingLot parking = new ParkingLot(5); 

        parking.ParkCar("BMW M5", 1);
        parking.ParkCar("Audi Q7", 0);
        parking.ParkCar("Tesla Model S", 2);
        parking.DisplayParking();
        parking.RemoveCar("Audi Q7");
        parking.DisplayParking();
        parking.ParkCar("Mercedes G63", 0);
        parking.DisplayParking();
    }  
    public void DisplayParking()
    {
        Console.WriteLine("\nСтан автостоянки:");
        for (int i = 0; i < capacity; i++)
        {
            Console.WriteLine($"Місце {i + 1}: {(parkingSpaces[i] == null ? "вільно" : $"машина '{parkingSpaces[i]}'")}");
        }
    }
    public bool RemoveCar(string carName)
    {
        for (int i = 0; i < capacity; i++)
        {
            if (parkingSpaces[i] == carName)
            {
                parkingSpaces[i] = null;
                Console.WriteLine($"Машина '{carName}' виїхала з місця {i + 1}");
                return true;
            }
        }
        Console.WriteLine($"Машини '{carName}' немає на стоянці!");
        return false;
    }     
    public ParkingLot(int capacity)
    {
        if (capacity <= 0) throw new ArgumentException("Розмір стоянки має бути більше 0");
        this.capacity = capacity;
        parkingSpaces = new List<string?>(new string?[capacity]); 
    }
    public bool ParkCar(string carName, int startIndex)
    {
        if (startIndex < 0 || startIndex >= capacity)
        {
            Console.WriteLine("Некоректний номер місця!");
            return false;
        }
        for (int i = startIndex; i < capacity; i++)
        {
            if (parkingSpaces[i] == null)
            {
                parkingSpaces[i] = carName;
                Console.WriteLine($"Машина '{carName}' припаркована на місце {i + 1}");
                return true;
            }
        }
        Console.WriteLine($"Машина '{carName}' не змогла припаркуватися - немає вільних місць.");
        return false;
    }
   
   
}