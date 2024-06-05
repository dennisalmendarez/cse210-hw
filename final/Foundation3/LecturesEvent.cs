using System;

public class LecturesEvent : Event
{
    private string _speaker;
    private int _capLimit;

    public LecturesEvent(string title, string description, string date, string time, Address address, string speaker, int capLimit)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capLimit = capLimit;
    }

    public new string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {_speaker}\nCapacity: {_capLimit}";
    }
}