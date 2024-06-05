using System;

public class Running : Activity{

    private double _distance;

    public Running(string date, int lengthInMinutes, double distance)
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / _distance;
    }

    public override double GetSpeed()
    {
        return _distance / (GetLengthInMinutes() / 60.0);
    }
}