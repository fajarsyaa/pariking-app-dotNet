using System;

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = null;

        while (true)
        {
            string command = Console.ReadLine();
            string[] parts = command.Split(' ');

            if (parts[0] == "create_parking_lot")
            {
                int totalSlots = int.Parse(parts[1]);
                parkingLot = new ParkingLot(totalSlots);
                parkingLot.CreateParkingLot();
            }
            else if (parts[0] == "park")
            {
                string registrationNumber = parts[1];
                string color = parts[2];
                string type = parts[3];
                parkingLot.ParkVehicle(registrationNumber, color, type);
            }
            else if (parts[0] == "leave")
            {
                int slotNumber = int.Parse(parts[1]);
                parkingLot.Leave(slotNumber);
            }
            else if (parts[0] == "status")
            {
                parkingLot.Status();
            }
            else if (parts[0] == "type_of_vehicles")
            {
                string type = parts[1];
                parkingLot.TypeOfVehicles(type);
            }
            else if (parts[0] == "registration_numbers_for_vehicles_with_odd_plate")
            {
                parkingLot.RegistrationNumbersForVehiclesWithOddPlate();
            }
            else if (parts[0] == "registration_numbers_for_vehicles_with_even_plate")
            {
                parkingLot.RegistrationNumbersForVehiclesWithEvenPlate();
            }
            else if (parts[0] == "registration_numbers_for_vehicles_with_colour")
            {
                string color = parts[1];
                parkingLot.RegistrationNumbersForVehiclesWithColor(color);
            }
            else if (parts[0] == "slot_number_for_registration_number")
            {
                string registrationNumber = parts[1];
                int slotNumber = parkingLot.SlotNumberForRegistrationNumber(registrationNumber);
                if (slotNumber != -1)
                {
                    Console.WriteLine(slotNumber);
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
            else if (parts[0] == "exit")
            {
                break;
            }
        }
    }
}
