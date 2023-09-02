class Vehicle
{
    public int SlotNumber { get; }
    public string RegistrationNumber { get; }
    public string Color { get; }
    public string Type { get; }

    public Vehicle(int slotNumber, string registrationNumber, string color, string type)
    {
        SlotNumber = slotNumber;
        RegistrationNumber = registrationNumber;
        Color = color;
        Type = type;
    }
}