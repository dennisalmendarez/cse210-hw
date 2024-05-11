using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("Alma", 8, 10, 11);

        var scripture = new Scripture(reference, "Nevertheless Alma labored much in the spirit, wrestling with God in mighty prayer, that he would pour out his Spirit upon the people who were in the city; that he would also grant that he might baptize them unto repentance. Nevertheless, they hardened their hearts, saying unto him: Behold, we know that thou art Alma; and we know that thou art high priest over the church which thou hast established in many parts of the land, according to your tradition; and we are not of thy church, and we do not believe in such foolish traditions.");
        
        Console.WriteLine(reference.GetDisplayText());
        Console.WriteLine(scripture.GetDisplayText());

        string userInput;
        while (true)
        {
            userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit")
            {
                break;
            }
            else if (userInput == "") {

                if (!scripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine(reference.GetDisplayText());
                    Console.WriteLine(scripture.GetDisplayText());
                    scripture.HideRandomWords(1);
                }
            }
            else {
                break;
            }
        }
    }
}