using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(string date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetLengthInMinutes() / 60.0) ;
    }

    public override double GetPace()
    {
        return GetLengthInMinutes() / GetDistance();
    }

    public override double GetSpeed()
    {
        return _speed;
    }
}