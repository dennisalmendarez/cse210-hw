using System;

class Program
{
    static void Main(string[] args)
{
    Address address1 = new Address("10125 Storey Grv Wy", "Winter Garge", "FL", "34787");
    Address address2 = new Address("2241 Mapple Grove", "Apoka", "Winter Garden", "32818");
    Address address3 = new Address("7452 Males Plaza", "Cortes", "Cortes", "52412");

    LecturesEvent lecture = new LecturesEvent("The Future of AI", "A talk about the future of artificial intelligence", "10/28/2024", "10:00 AM", address1, "Dr. John Smith", 100);
    ReceptionsEvent reception = new ReceptionsEvent("Networking Event", "An opportunity to network with industry professionals", "2024-06-17", "6:00 PM", address2, "rsvp@event.com");
    OutdoorGathering outdoorGathering = new OutdoorGathering("Summer Picnic", "A fun summer picnic in the park", "11/21/2024", "12:00 PM", address3, "Sunny with a chance of rain");

    Console.WriteLine("Standard Details:");
    Console.WriteLine();
    Console.WriteLine(lecture.GetStandardDetails());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(reception.GetStandardDetails());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(outdoorGathering.GetStandardDetails());

    Console.WriteLine("\nFull Details:");
    Console.WriteLine(lecture.GetFullDetails());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(reception.GetFullDetails());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(outdoorGathering.GetFullDetails());
    

    Console.WriteLine("\nShort Descriptions:");
    Console.WriteLine();
    Console.WriteLine(lecture.GetShortDescription());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(reception.GetShortDescription());
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(outdoorGathering.GetShortDescription());
}

}
