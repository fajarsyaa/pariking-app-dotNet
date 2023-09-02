using System;
using System.Collections.Generic;
using System.Linq;

class ParkingLot
{
    private int totalSlots;
    private List<Vehicle> slots;

    public ParkingLot(int totalSlots)
    {
        this.totalSlots = totalSlots;
        this.slots = new List<Vehicle>(totalSlots);
        for (int i = 0; i < totalSlots; i++)
        {
            slots.Add(null);
        }
    }

    public void CreateParkingLot()
    {
        Console.WriteLine($"Created a parking lot with {totalSlots} slots");
    }

    public void ParkVehicle(string registrationNumber, string color, string type)
    {
        // Check if the parking lot is full
        if (IsFull())
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }

        // Find the first available slot
        int slotNumber = FindAvailableSlot();

        // Create a new parking slot
        slots[slotNumber - 1] = new Vehicle(slotNumber, registrationNumber, color, type);

        Console.WriteLine($"Allocated slot number: {slotNumber}");
    }

    public void Leave(int slotNumber)
    {
        if (slotNumber < 1 || slotNumber > totalSlots)
        {
            Console.WriteLine("Invalid slot number");
            return;
        }

        // Check if the slot is already empty
        if (slots[slotNumber - 1] == null)
        {
            Console.WriteLine($"Slot number {slotNumber} is already empty");
            return;
        }

        slots[slotNumber - 1] = null;
        Console.WriteLine($"Slot number {slotNumber} is free");
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (var slot in slots.Where(s => s != null))
        {
            Console.WriteLine($"{slot.SlotNumber}\t{slot.RegistrationNumber}\t{slot.Type}\t{slot.Color}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        int count = slots.Count(s => s != null && s.Type == type);
        Console.WriteLine(count);
    }

    public void RegistrationNumbersForVehiclesWithOddPlate()
    {
        var oddPlateNumbers = slots
            .Where(s => s != null && IsOddPlate(s.RegistrationNumber))
            .Select(s => s.RegistrationNumber);
        Console.WriteLine(string.Join(", ", oddPlateNumbers));
    }

    public void RegistrationNumbersForVehiclesWithEvenPlate()
    {
        var evenPlateNumbers = slots
            .Where(s => s != null && !IsOddPlate(s.RegistrationNumber))
            .Select(s => s.RegistrationNumber);
        Console.WriteLine(string.Join(", ", evenPlateNumbers));
    }

    public void RegistrationNumbersForVehiclesWithColor(string color)
    {
        var vehiclesWithColor = slots
            .Where(s => s != null && s.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(s => s.RegistrationNumber);
        Console.WriteLine(string.Join(", ", vehiclesWithColor));
    }

    public int SlotNumberForRegistrationNumber(string registrationNumber)
    {
        var slot = slots.FirstOrDefault(s => s != null && s.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
        return slot != null ? slot.SlotNumber : -1;
    }

    private bool IsFull()
    {
        return slots.All(s => s != null);
    }

    private int FindAvailableSlot()
    {
        for (int i = 0; i < totalSlots; i++)
        {
            if (slots[i] == null)
            {
                return i + 1;
            }
        }
        return -1; // No available slot
    }


    private bool IsOddPlate(string registrationNumber)
    {
        // delete char is not number from string registrationNumber
        string numberPart = new string(registrationNumber.Where(char.IsDigit).ToArray());

        if (!string.IsNullOrEmpty(numberPart) && int.TryParse(numberPart, out int number))
        {            
            if (number % 2 != 0)
            {                
                return true;
            }
        }

        return false;
    }

}
